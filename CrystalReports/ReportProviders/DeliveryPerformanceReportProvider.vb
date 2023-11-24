Option Strict On

Imports log4net
Imports MySql.Data.MySqlClient

Public Class DeliveryPerformanceReportProvider
    Implements IReportProvider

    Private Shared ReadOnly _logger As ILog = LogManager.GetLogger("ExceptionLogger")

    Private Const REPORT_NAME As String = "Delivery Performance Report"

    Public Property Name As String = REPORT_NAME Implements IReportProvider.Name

    Public Property IsHidden As Boolean = False Implements IReportProvider.IsHidden

    Public Async Function RunAsync() As Task Implements IReportProvider.RunAsync
        'Dim integerResult = New Integer

        Dim connectionText = String.Concat("server=localhost;user id=root;database=dreamheartsdb;port=3307;password=globagility;")

        Dim strQuery = "SELECT
/**/
#IFNULL(CONCAT(IFNULL(c.firstname,''),' ',IFNULL(c.middlename,''),' ',IFNULL(c.lastname,''),' ',IFNULL(c.suffix,''),' - ',IFNULL(c.contactno,'')),'') `DriverName`,
c.RowID `DriverId`,
#COUNT(DISTINCT IFNULL(lu.ConfirmedDeliveryTimeStamp, lu.LineUpDate)) `DeliveryCount`,
'DEFAULT DRIVER1' `DriverName`,
t.RowID `TruckId`,
CONCAT_WS(' ', t.TruckName, t.PlateNo) `TruckName`,
lu.RowID `LineUpId`,
lu.LineUpNo,
lu.DeliveryTruckShiftID,
lu.LineUpDate,
IFNULL(lu.DeliveryDate, lu.LineUpDate) `DeliveryDate`,
IFNULL(lu.ConfirmedDeliveryTimeStamp, lu.LineUpDate) `ConfirmedDeliveryTimeStamp`,
CONCAT_WS('-', IF(MINUTE(s.TimeFrom) = 0, TIME_FORMAT(s.TimeFrom, '%I%p'), TIME_FORMAT(s.TimeFrom, '%I:%i%p')), IF(MINUTE(s.TimeTo) = 0, TIME_FORMAT(s.TimeTo, '%I%p'), TIME_FORMAT(s.TimeTo, '%I:%i%p'))) `ShiftSched`,

# GROUP_CONCAT(DISTINCT pl.PackingListNo) `PackingListNos`,
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

#,lu.*
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

LEFT JOIN contacts c ON c.RowID=lu.ContactID

INNER JOIN orders o ON o.RowID=oi.OrderID

LEFT JOIN rackshelfcolumn rsc ON rsc.InventoryLocationID=o.InventoryLocationID
LEFT JOIN productinventorylocation pil ON pil.RackShelfColumnID=rsc.RowID AND pil.ProductColorSizeID=oi.ProductColorSizeID

WHERE lu.`Status` IN ('Delivered', 'Confirmed Delivery')
#AND lu.RowID=21
#GROUP BY lu.ContactID, IFNULL(lu.ConfirmedDeliveryTimeStamp, lu.LineUpDate)
ORDER BY # DRIVER_NAME
IFNULL(lu.ConfirmedDeliveryTimeStamp, lu.LineUpDate), p.ProductCode, cc.ColorName, pcs.Size
;"

        Using command = New MySqlCommand(strQuery, New MySqlConnection(connectionText))

            With command.Parameters
                '.AddWithValue("@orgId", 0)
                '.AddWithValue("@userId", 0)
                '.AddWithValue("@datefrom", 0)
            End With

            Dim adapter As New MySqlDataAdapter

            Await command.Connection.OpenAsync()

            Try
                'Dim result = Await command.ExecuteNonQueryAsync()

                adapter.SelectCommand = command
                Dim dataSet As New DataSet
                adapter.Fill(dataSet)

                'integerResult = result

                Dim report = New DeliveryPerformanceReport()
                report.SetDataSource(dataSet.Tables.OfType(Of DataTable).FirstOrDefault())

                Dim form As New DefaultReportViewer
                form.CrystalReportViewer1.ReportSource = report
                form.Show()

            Catch ex As Exception
                _logger.Error("DeliveryPerformanceReportProvider", ex)

                MessageBox.Show(String.Concat("Oops! something went wrong, please contact Globagility Inc."),
                    String.Empty,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation)

            End Try

        End Using

        'Return integerResult
    End Function

End Class