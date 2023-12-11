Option Strict On
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports log4net

Public Class DefaultReportViewerForm
    Private ReadOnly _dataSource As DataTable
    Private ReadOnly _logger As ILog = LogManager.GetLogger("ExceptionLogger")

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(dataSource As DataTable)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _dataSource = dataSource
    End Sub

    Private Sub DefaultReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _dataSource IsNot Nothing AndAlso
            Not _dataSource?.Rows.OfType(Of DataRow).Any() Then

            MessageBox.Show("No data found.",
                    String.Empty,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ExportAsWordDocument(nameOfFile As String)
        If CrystalReportViewer1.ReportSource Is Nothing Then
            Return
        End If

        If nameOfFile.Trim.Length > 0 Then
            Dim rpt As ReportClass = CType(CrystalReportViewer1.ReportSource, ReportClass)

            Try
                Dim fileName = $"{Path.GetTempPath}{nameOfFile}.doc"

                rpt.ExportToDisk(ExportFormatType.WordForWindows,
                    fileName:=fileName)

                Process.Start(fileName)

            Catch ex As Exception
                _logger.Error(rpt.Name, ex)
                MsgBox("Error occured when exporting.", MsgBoxStyle.Critical, "Export failed")
            End Try
        End If
    End Sub

    Private Sub ToolStripButtonExportAsWordDocument_Click(sender As Object, e As EventArgs) Handles ToolStripButtonExportAsWordDocument.Click
        ExportAsWordDocument(nameOfFile:=$"{Guid.NewGuid.ToString()}")
    End Sub
End Class