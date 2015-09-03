Public Class frmPrintPreview
    Dim printReport As New PrintClass

    Private Sub PrintSettingsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintSettingsToolStripMenuItem1.Click
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            printReport.PrinterSettings = PrintDialog1.PrinterSettings
        End If
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        PrintPreviewDialog1.Document = printReport
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        printReport.Print()
    End Sub

    Private Sub frmPrintPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrintPreviewControl1.Document = printReport
        PrintPreviewDialog1.Document = printReport
        PrintPreviewDialog1.ShowDialog()
    End Sub
End Class