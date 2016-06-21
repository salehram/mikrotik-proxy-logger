Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmViewReport
    Dim prepareReport As New PrintClass
    Dim ExportText As New ExportData

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        '
        'clealring print mode
        printMode = 0
        '
        'calling the assign report headers sub procedure, which will fill the header lines for the report
        AssignReportHeaders()
        '
        'setting print mode
        printMode = 1
        '
        'showing the print form
        If printConfig.ShowDialog = Windows.Forms.DialogResult.OK Then
            prepareReport.PrinterSettings = printConfig.PrinterSettings
        End If
        PrintPreviewDialog1.Document = prepareReport
        PrintPreviewDialog1.MdiParent = frmMain
        PrintPreviewDialog1.Show()
    End Sub

    Private Sub btnExportTXT_Click(sender As Object, e As EventArgs) Handles btnExportTXT.Click
        '
        'calling the assign report headers sub procedure, which will fill the header lines for the report
        AssignReportHeaders()
        '
        'calling the export to csv sub procedure with content type = 1 as a single user report operation
        ExportText.ExportTXT(1)
    End Sub

    Private Sub AssignReportHeaders()
        '
        'clearing previous contents in reportHeadLine variables
        reportHeadLine1 = ""
        reportHeadLine2 = ""
        reportHeadLine3 = ""
        reportHeadLine4 = ""
        reportHeaderDetailsLine1 = ""
        reportHeaderDetailsLine2 = ""
        reportHeaderDetailsLine3 = ""
        reportHeaderDetailsLine4 = ""
        reportHeaderDetailsLine5 = ""
        reportHeaderDetailsLine6 = ""
        reportHeaderDetailsLine7 = ""
        reportHeaderDetailsLine8 = ""
        '
        'assigning new values for reportHeadLine variables
        reportHeadLine1 = "Target: " & lblDeviceIP.Text & " - " & lblDeviceName.Text
        reportHeadLine2 = "Time range: From: " & lblFromDate.Text & " to: " & lblToDate.Text
        reportHeadLine3 = "Usage stats:"
        reportHeaderDetailsLine1 = "User download usage (mb): " & lblBWUsage.Text
        reportHeaderDetailsLine2 = "Packets requested by user: " & lblPacketsCount.Text
        reportHeaderDetailsLine3 = "User upload usage (mb): " & lblUPBWPackets.Text
        reportHeaderDetailsLine4 = "Packets sent by user: " & lblUPBWPackets.Text
        reportHeaderDetailsLine5 = "Total download utilizatin (mb): " & lblTotalUsage.Text
        reportHeaderDetailsLine6 = "Total Packets requested: " & lblTotalPackets.Text
        reportHeaderDetailsLine7 = "Bandwidth usage percentage: " & lblUsagePercentageBytes.Text
        reportHeaderDetailsLine8 = "Packets usage percentage: " & lblUsagePercentagePackets.Text
    End Sub
End Class
