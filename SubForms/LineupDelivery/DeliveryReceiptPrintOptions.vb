Option Strict On

Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports OfficeOpenXml
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class DeliveryReceiptPrintOptions
    ReadOnly _manager As New sqlModule.Manager
    Private ReadOnly _poNo As String

    Public Sub New(poNo As String)
        _poNo = poNo
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub DeliveryReceiptPrintOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Friend Async Sub Print(lineupRowId As Integer?)
        If Not lineupRowId.HasValue Then Return

        Dim printreport As ReportClass = New DeliveryReceipt

        If CheckBoxFontCalibri.Checked Then printreport = New DeliveryReceiptCalibri

        Dim fileContent = String.Join(separator:=Environment.NewLine, File.ReadAllLines("Report Files\DeliveryReceipt\DeliveryReceipt.json"))
        Dim deliveryReceiptDto = JsonConvert.DeserializeObject(Of DeliveryReceiptDto)(fileContent)

        Dim section = printreport.ReportDefinition.Sections.OfType(Of Section).FirstOrDefault()

        Dim companyNameTitle As TextObject = CType((section?.ReportObjects("CompanyNameTitle1")), TextObject)
        companyNameTitle.Text = deliveryReceiptDto.CompanyNameTitle

        Dim supportingInfo As TextObject = CType((section?.ReportObjects("SupportingInfo1")), TextObject)
        supportingInfo.Text = deliveryReceiptDto.SupportingInfo

        Dim deliveryReceiptCaption As TextObject = CType((section?.ReportObjects("DeliveryReceiptCaption1")), TextObject)
        deliveryReceiptCaption.Text = deliveryReceiptDto.DeliveryReceiptCaption

        Dim receivedNote As TextObject = CType((section?.ReportObjects("ReceivedNote1")), TextObject)
        receivedNote.Text = deliveryReceiptDto.ReceivedNote

        Dim footerNote As TextObject = CType((section?.ReportObjects("FooterNote1")), TextObject)
        footerNote.Text = deliveryReceiptDto.FooterNote

        Dim accreditation As TextObject = CType((section?.ReportObjects("Accreditation1")), TextObject)
        accreditation.Text = deliveryReceiptDto.Accreditation

        Dim quantityClause = If(RadioBtnUnitRoll.Checked,
            "SUM(plci.QtyInCarton) `DataColumn1`,",
            "FORMAT(SUM((plci.QtyInCarton / oi.QtyOrdered) * IFNULL(oi.UnitOfLengthNumber, 0)), 2) `DataColumn1`,")

        Dim unitOfMeasureClause = $"{If(CheckBoxDoNotDisplayUOM.Checked,
            "''",
            If(RadioBtnUnitRoll.Checked,
                "IFNULL(pil.UnitOfMeasure2, '')",
                "IFNULL(oi.UnitOfLength, '')"))} `DataColumn2`,"

        Dim detailsClause =
            If(RadioBtnUnitRoll.Checked AndAlso Not CheckBoxRollWithPrice.Checked,
            "CONCAT(IFNULL(CONCAT('**', p.ProductGroupName, '**'), ''), '\n', GROUP_CONCAT(CONCAT(p.ProductCode, '(', plci.QtyInCarton, ')') SEPARATOR ', ')) `DataColumn3`,",
                If(RadioBtnUnitRoll.Checked AndAlso CheckBoxRollWithPrice.Checked,
                "CONCAT(IFNULL(CONCAT('**', p.ProductGroupName, '**'), ''), '\n', GROUP_CONCAT(CONCAT(p.ProductCode, '(', plci.QtyInCarton, '×', oi.SRP,')') SEPARATOR ', ')) `DataColumn3`,",
                If(RadioBtnUnitNonRoll.Checked AndAlso Not CheckBoxMeterYardWithPrice.Checked, "CONCAT(IFNULL(CONCAT('**', p.ProductGroupName, '**'), ''), '\n', GROUP_CONCAT(CONCAT(p.ProductCode, '(', CAST(FORMAT((plci.QtyInCarton / oi.QtyOrdered) * IFNULL(oi.UnitOfLengthNumber, 0), 2) AS CHAR CHARACTER SET utf8), ')') SEPARATOR ', ')) `DataColumn3`,",
                    If(RadioBtnUnitNonRoll.Checked AndAlso CheckBoxMeterYardWithPrice.Checked, "CONCAT(IFNULL(CONCAT('**', p.ProductGroupName, '**'), ''), '\n', GROUP_CONCAT(CONCAT(p.ProductCode, '(', CAST(FORMAT((plci.QtyInCarton / oi.QtyOrdered) * IFNULL(oi.UnitOfLengthNumber, 0), 0) AS CHAR CHARACTER SET UTF8), '×', IF(IFNULL(oi.UnitOfLengthNumber, 0)=0, 0, FORMAT((oi.SRP * oi.QtyOrdered) / oi.UnitOfLengthNumber, 2)), ')') SEPARATOR ', ')) `DataColumn3`,", String.Empty))))

        Dim subTotalClause = If((RadioBtnUnitRoll.Checked AndAlso Not CheckBoxRollWithPrice.Checked) Or (RadioBtnUnitNonRoll.Checked AndAlso Not CheckBoxMeterYardWithPrice.Checked),
            "0 `DataColumn4`",
            If((RadioBtnUnitRoll.Checked AndAlso CheckBoxRollWithPrice.Checked) Or (RadioBtnUnitNonRoll.Checked AndAlso CheckBoxMeterYardWithPrice.Checked),
                "SUM(plci.QtyInCarton * oi.SRP) `DataColumn4`",
                "0 `DataColumn4`"))

        Dim unitOfMeasureGroupClause = If(RadioBtnUnitRoll.Checked, "pil.UnitOfMeasure2", "IFNULL(oi.UnitOfLength, '')")

        Dim sql = String.Concat("SELECT
            IFNULL(o.DRNumber, lu.DeliveryNo) `DRNo`,
            #a.*,
            a.CompanyName,
            CONCAT_WS(', ', NULLIF(ad.StreetAddress1, ''), NULLIF(ad.StreetAddress2, ''), NULLIF(ad.Barangay, ''), NULLIF(ad.CityTown, ''), NULLIF(ad.Province, ''), NULLIF(ad.State, ''), NULLIF(ad.ZipCode, ''), NULLIF(ad.Country, '')) `Address`,
            lu.LineUpDate,",
            quantityClause,
            unitOfMeasureClause,
            detailsClause,
            subTotalClause,
            $", o.ReferenceNumber 
            FROM lineups lu
            JOIN lineupcartons lc ON lu.RowID = lc.LineUpID
            LEFT JOIN contacts c ON lu.ContactID = c.RowID
            LEFT JOIN contacts c2 ON lu.Helper1Id = c2.RowID
            LEFT JOIN contacts c3 ON lu.Helper2Id = c3.RowID
            INNER JOIN orders o ON lu.OrderID = o.RowID {If(CheckBoxBasedOnPOnumber.Checked, $" AND o.ReferenceNumber={_poNo}", String.Empty)}
            INNER JOIN accounts a ON a.RowID=o.AccountID
            LEFT JOIN address ad ON ad.RowID=a.PrimaryAddressID
            INNER JOIN packinglistcartonitems plci ON lc.PackingListCartonID = plci.PackingListCartonID
            INNER JOIN orderitems oi ON plci.OrderItemID = oi.RowID
            INNER JOIN productcolorsizes pcs ON oi.ProductColorSizeID = pcs.RowID
            INNER JOIN productcolors pc ON pc.RowID=pcs.ProductColorID
            INNER JOIN products p ON p.RowID=pc.ProductID
            INNER JOIN productinventorylocation pil ON pil.RowID=oi.ProductInventoryLocationId
            INNER JOIN picklistorders plo ON plo.OrderItemID=oi.RowID
            INNER JOIN picklistorderitems ploi ON ploi.PickListOrderID=plo.RowID AND ploi.`status` NOT IN ('Cancelled', 'Inactive')
            #AND oi.ProductInventoryLocationId=ploi.ProductInventoryLocationID
            AND ploi.QtyPicked > 0
            INNER JOIN picklist pl ON pl.RowID=plo.PickListID AND pl.`Status` NOT IN ('New', 'Cancelled')
            WHERE lu.RowID IS NOT NULL
            AND lu.`Status` != 'Cancelled'
            {If(CheckBoxBasedOnPOnumber.Checked, String.Empty, "AND lu.RowID = @lineupRowId")}
            GROUP BY p.ProductGroupName, ",
            unitOfMeasureGroupClause,
            ";")

        Await FunctionUtils.TryCatchFunctionAsync(messageTitle:="",
            Async Function()
                Using connection As New MySqlConnection(connectionString:=_manager.GetConnString()),
            command As New MySqlCommand(sql, connection)

                    With command.Parameters
                        If lineupRowId.HasValue Then
                            .AddWithValue("@lineupRowId", lineupRowId.Value)
                        Else
                            .AddWithValue("@lineupRowId", DBNull.Value)
                        End If
                    End With

                    Dim adapter = New MySqlDataAdapter()
                    adapter.SelectCommand = command
                    Dim dt As New DataTable()
                    Await Task.Run(Sub()
                                       adapter.Fill(dt)
                                   End Sub)

                    If dt IsNot Nothing Then
                        printreport.SetDataSource(dt)
                    End If

                    Dim row = dt.Rows.OfType(Of DataRow).FirstOrDefault()

                    If row IsNot Nothing Then
                        Dim deliveryReceiptNo As TextObject = CType((section?.ReportObjects("TextDeliveryReceiptNumber")), TextObject)
                        deliveryReceiptNo.Text = CStr((row?.Item("DRNo")))

                        Dim deliveredTo As TextObject = CType((section?.ReportObjects("TextDeliveredTo")), TextObject)
                        deliveredTo.Text = CStr((row?.Item("CompanyName")))

                        Dim address As TextObject = CType((section?.ReportObjects("TextAddress")), TextObject)
                        address.Text = CStr((row?.Item("Address")))

                        Dim [date] As TextObject = CType((section?.ReportObjects("TextDate")), TextObject)
                        [date].Text = $"{CDate(row?.Item("LineUpDate")):MMM dd, yyyy}"

                        Dim terms As TextObject = CType((section?.ReportObjects("TextTerms")), TextObject)
                        terms.Text = CStr((row?.Item("ReferenceNumber")))
                    End If


                    Dim lineupDataService = GetRequiredService(Of ILineupDataService)()
                    Dim lineup = Await lineupDataService.GetByIdAsync(lineupRowId.Value)

                    Dim textDeliveredBy As TextObject = CType((section?.ReportObjects("TextDeliveredBy")), TextObject)
                    textDeliveredBy.Text = $"{lineup.DeliveredBy}/{lineup.PlateNo}"

                    Dim textHelpers As TextObject = CType((section?.ReportObjects("TextHelpers")), TextObject)
                    textHelpers.Text = lineup.Helpers


                    PrintDeliveryReceiptExcel(dt)

                End Using
            End Function)

        Dim openreportviewer As New ReportViewer
        openreportviewer.CrystalReportViewer.ReportSource = printreport
        openreportviewer.Show()
    End Sub

    Private Sub PrintDeliveryReceiptExcel(dataTable As DataTable)
        If Not CheckBoxExcelCopyforDotMatrix.Checked Then Return

        Dim fileName = Path.Combine(Path.GetTempPath(), "DeliveryReceiptExcel.xlsx")
        Dim template = Path.Combine(My.Application.Info.DirectoryPath, "Report Files\DeliveryReceipt\DeliveryReceiptExcel.xlsx")

        File.Copy(sourceFileName:=template, destFileName:=fileName, overwrite:=True)

        Using excel = New ExcelPackage(New FileInfo(fileName))

            Dim worksheet = excel.Workbook.Worksheets.FirstOrDefault()

            Dim row = dataTable.Rows.OfType(Of DataRow).FirstOrDefault()

            If row IsNot Nothing Then
                worksheet.Cells("E3").Value = row?.Item("DRNo")
                worksheet.Cells("B3").Value = row?.Item("CompanyName")
                worksheet.Cells("B4").Value = row?.Item("Address")
                worksheet.Cells("E4").Value = row?.Item("LineUpDate")
                worksheet.Cells("E4").Style.Numberformat.Format = "MMM/dd/yyyy"
            End If

            Dim index = 6

            For Each dr As DataRow In dataTable.Rows
                worksheet.Cells($"B{index}").Value = dr("DataColumn1")
                worksheet.Cells($"C{index}").Value = dr("DataColumn2")
                worksheet.Cells($"D{index}").Value = dr("DataColumn3")
                worksheet.Cells($"D{index}").Style.WrapText = True
                worksheet.Cells($"D{index}").Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.General
                'worksheet.Row(index).

                index += 1
            Next

            worksheet.Cells($"B{index}").Value = dataTable.Select("CompanyName IS NOT NULL").Sum(Function(t) CDbl(t("DataColumn1")))

            excel.Save()

            Process.Start(fileName:=fileName)
        End Using
    End Sub

    Private Sub RadioBtnUnitRoll_CheckedChanged(sender As Object, e As EventArgs) Handles RadioBtnUnitRoll.CheckedChanged
        CheckBoxRollWithPrice.Enabled = RadioBtnUnitRoll.Enabled
        CheckBoxMeterYardWithPrice.Enabled = Not RadioBtnUnitRoll.Enabled
    End Sub

    Private Sub RadioBtnUnitNonRoll_CheckedChanged(sender As Object, e As EventArgs) Handles RadioBtnUnitNonRoll.CheckedChanged
        CheckBoxMeterYardWithPrice.Enabled = RadioBtnUnitNonRoll.Enabled
        CheckBoxRollWithPrice.Enabled = Not RadioBtnUnitNonRoll.Enabled
    End Sub
End Class
