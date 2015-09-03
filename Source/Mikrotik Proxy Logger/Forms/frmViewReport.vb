Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmViewReport
    Dim prepareReport As New PrintClass

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        '
        'clearing previous contents in reportHeadLine variables
        printMode = 0
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
        reportHeadLine1 = lblDeviceIP.Text & " - " & lblDeviceName.Text
        reportHeadLine2 = "From: " & lblFromDate.Text & " to: " & lblToDate.Text
        reportHeaderDetailsLine1 = "User download usage (mb): " & lblBWUsage.Text
        reportHeaderDetailsLine2 = "Packets requested by user: " & lblPacketsCount.Text
        reportHeaderDetailsLine3 = "User upload usage (mb): " & lblUPBWPackets.Text
        reportHeaderDetailsLine4 = "Packets sent by user: " & lblUPBWPackets.Text
        reportHeaderDetailsLine5 = "Total download utilizatin (mb): " & lblTotalUsage.Text
        reportHeaderDetailsLine6 = "Total Packets requested: " & lblTotalPackets.Text
        reportHeaderDetailsLine7 = "Bandwidth usage percentage: " & lblUsagePercentageBytes.Text
        reportHeaderDetailsLine8 = "Packets usage percentage: " & lblUsagePercentagePackets.Text
        '
        'setting print mode
        printMode = 1
        '
        'showing the print form
        PrintPreviewDialog1.Document = prepareReport
        PrintPreviewDialog1.ShowDialog()
    End Sub
End Class