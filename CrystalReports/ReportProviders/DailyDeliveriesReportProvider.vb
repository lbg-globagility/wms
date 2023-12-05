Option Strict On

Imports log4net
Imports MySql.Data.MySqlClient

Public Class DailyDeliveriesReportProvider
    Implements IReportProvider

    Dim manager As New Manager()

    Private Shared ReadOnly _logger As ILog = LogManager.GetLogger("ExceptionLogger")

    Private Const REPORT_NAME As String = "Daily Deliveries Report"

    Public Property Name As String = REPORT_NAME Implements IReportProvider.Name

    Public Property IsHidden As Boolean = False Implements IReportProvider.IsHidden

    Public Async Function RunAsync() As Task Implements IReportProvider.RunAsync
        Dim userDatePickerForm = New UserDatePickerForm(isDateOnlyConfig:=True)
        If Not userDatePickerForm.ShowDialog() = DialogResult.OK Then Return

        'Dim connectionText = "server=localhost;user id=root;database=dreamheartsdb;port=3307;password=globagility;"
        Dim connectionText = manager.GetConnString()

        Dim strQuery = <![CDATA[
            SELECT
            CONCAT_WS(', ', c.LastName, c.FirstName) `DriverName`,
            c.RowID `DriverId`,
            t.RowID `TruckId`,
            CONCAT_WS(' ', t.TruckName, t.PlateNo) `TruckName`,
            lu.RowID `LineUpId`,
            lu.LineUpNo,
            lu.DeliveryTruckShiftID,
            lu.LineUpDate,
            IFNULL(lu.DeliveryDate, lu.LineUpDate) `DeliveryDate`,
            IFNULL(lu.ConfirmedDeliveryTimeStamp, lu.LineUpDate) `ConfirmedDeliveryTimeStamp`,
            CONCAT_WS('-', IF(MINUTE(s.TimeFrom) = 0, TIME_FORMAT(s.TimeFrom, '%I%p'), TIME_FORMAT(s.TimeFrom, '%I:%i%p')), IF(MINUTE(s.TimeTo) = 0, TIME_FORMAT(s.TimeTo, '%I%p'), TIME_FORMAT(s.TimeTo, '%I:%i%p'))) `ShiftSched`,

            pl.PackingListNo,
            pl.RowID `PackingListId`,
            pl.PackingListNo,

            cs.RowID `CartonSizeId`,
            cs.SizeName,

            oi.ProductColorSizeID,
            p.RowID `ProductId`,
            p.ProductCode,
            cc.RowID `ColorId`,
            cc.ColorName,
            pcs.Size,
            pli.QtyInCarton,
            IFNULL(pil.UnitOfMeasure, '') `UnitOfMeasure`
            
            ,lu.DeliveryNo
            ,IFNULL(pil.TotalAvailableQty, 0) `TotalAvailableQty`
            
            ,IFNULL(i.GrantTotalAvailableQty, 0) `Balance`
            ,i.GrantTotalAvailableQty

            FROM lineups lu

            INNER JOIN deliverytruckshifts ts ON ts.RowID=lu.DeliveryTruckShiftID
            INNER JOIN shifts s ON ts.ShiftID=s.RowID

            INNER JOIN deliverytrucks t ON t.RowID=ts.DeliveryTruckID

            INNER JOIN packinglist pl ON pl.RowID=lu.PackingListID

            INNER JOIN packinglistcartons plc ON plc.PackingListID=pl.RowID AND plc.`Status`='Delivered'
            INNER JOIN cartonsizes cs ON cs.RowID=plc.CartonSizeID

            INNER JOIN packinglistcartonitems pli ON pli.PackingListCartonID=plc.RowID AND pli.`Status`='Delivered'

            INNER JOIN orderitems oi ON oi.RowID=pli.OrderItemID
            INNER JOIN productcolorsizes pcs ON pcs.RowID=oi.ProductColorSizeID
            INNER JOIN productcolors pc ON pc.RowID=pcs.ProductColorID
            INNER JOIN colors cc ON cc.RowID=pc.ColorID
            INNER JOIN products p ON p.RowID=pc.ProductID

            INNER JOIN contacts c ON c.RowID=lu.ContactID

            INNER JOIN orders o ON o.RowID=oi.OrderID

            LEFT JOIN rackshelfcolumn rsc ON rsc.InventoryLocationID=o.InventoryLocationID
            LEFT JOIN productinventorylocation pil ON pil.RackShelfColumnID=rsc.RowID AND pil.ProductColorSizeID=oi.ProductColorSizeID
            
            LEFT JOIN (SELECT
                        COUNT(pil.ROwID) `Count`,
                        SUM(IFNULL(pil.TotalAvailableQty, 0)) `GrantTotalAvailableQty`,
                        rsc.InventoryLocationID,
                        pil.*
                        FROM productinventorylocation pil
                        INNER JOIN rackshelfcolumn rsc ON rsc.RowID=pil.RackShelfColumnID #AND rsc.InventoryLocationID=1
                        GROUP BY pil.ProductColorSizeID, rsc.InventoryLocationID
                        HAVING SUM(IFNULL(pil.TotalAvailableQty, 0)) > 0
			            ) i ON i.ProductColorSizeID=oi.ProductColorSizeID AND i.InventoryLocationID=rsc.InventoryLocationID

            WHERE lu.`Status` IN ('Delivered', 'Confirmed Delivery')

            AND lu.OrganizationID = @orgId

            AND IF(@condition,
	            DATE(IFNULL(lu.ConfirmedDeliveryTimeStamp, lu.LineUpDate)) = @startDate,
	            DATE(IFNULL(lu.ConfirmedDeliveryTimeStamp, lu.LineUpDate)) BETWEEN @startDate AND @endDate)

            ORDER BY CONCAT(c.LastName, c.FirstName), IFNULL(lu.ConfirmedDeliveryTimeStamp, lu.LineUpDate), p.ProductCode, cc.ColorName, pcs.Size
            ;]]>.Value

        Using command = New MySqlCommand(strQuery, New MySqlConnection(connectionText))

            With command.Parameters
                .AddWithValue("@orgId", Z_OrganizationID)
                '.AddWithValue("@startDate", userDatePickerForm.StartDate)
                .AddWithValue("@startDate", New Date(2017, 1, 24))
                '2017-01-24
                .AddWithValue("@endDate", userDatePickerForm.EndDate?.Date)
                .AddWithValue("@condition", userDatePickerForm.IsDateOnly)
            End With

            Dim adapter As New MySqlDataAdapter

            Await command.Connection.OpenAsync()

            Try
                adapter.SelectCommand = command
                Dim dataSet As New DataSet
                adapter.Fill(dataSet)

                Dim report = New DailyDeliveriesReport()
                Dim datasource = dataSet.Tables.OfType(Of DataTable).FirstOrDefault()
                report.SetDataSource(datasource)

                Dim form As New DefaultReportViewerForm(dataSource:=datasource)
                form.CrystalReportViewer1.ReportSource = report
                form.Show()
            Catch ex As Exception
                _logger.Error("DailyDeliveriesReportProvider", ex)

                MessageBox.Show(String.Concat("Oops! something went wrong, please contact Globagility Inc."),
                    String.Empty,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation)
            End Try
        End Using
    End Function

End Class