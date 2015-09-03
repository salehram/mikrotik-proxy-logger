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
        'PrintPreviewDialog1.Document = printReport
        'PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintPreviewControl1_MouseWheel(sender As Object, e As MouseEventArgs) Handles PrintPreviewControl1.MouseWheel
        If e.Delta > 0 Then
            PrintPreviewControl1.Zoom = PrintPreviewControl1.Zoom + 0.5
        Else
            PrintPreviewControl1.Zoom = PrintPreviewControl1.Zoom - 0.5
        End If
    End Sub
End Class