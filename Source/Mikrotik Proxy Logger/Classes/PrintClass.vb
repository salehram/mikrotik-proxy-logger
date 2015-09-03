Imports System
Imports System.Drawing
Imports System.Drawing.Printing

Public Class PrintClass
    Inherits PrintDocument

    Private TitleFont As Font
    Private HeaderFont As Font
    Private BodyFont As Font
    Private currentPage As Integer = 0
    Private currentRecord As Integer = 0

    Private Sub Print_BeginPrint(sender As Object, e As PrintEventArgs) Handles Me.BeginPrint
        '
        'setting the fonts styles and sizes
        TitleFont = New Font(FontFamily.GenericSerif, 16, FontStyle.Bold, GraphicsUnit.Point)
        HeaderFont = New Font(FontFamily.GenericSerif, 12, FontStyle.Regular, GraphicsUnit.Point)
        BodyFont = New Font(FontFamily.GenericSerif, 10, FontStyle.Regular, GraphicsUnit.Point)
    End Sub

    Private Sub PrintHeaders(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal ReportType As Integer)
        '
        'report type:
        '1=somgle user report
        '2=overall report
        '
        'title print
        e.Graphics.DrawString("Mikrotik Proxy Logger", TitleFont, Brushes.Black, 20, 20)
        '
        'report headers lines
        Select Case ReportType
            Case 1 'single user report
                e.Graphics.DrawString("Single User Report", HeaderFont, Brushes.Black, 20, 40)
                e.Graphics.DrawString("Target: " & reportHeadLine1, HeaderFont, Brushes.Black, 20, 60)
                e.Graphics.DrawString("Time range: " & reportHeadLine2, HeaderFont, Brushes.Black, 20, 80)
                e.Graphics.DrawString("Usage stats:", HeaderFont, Brushes.Black, 20, 120)
                e.Graphics.DrawString(reportHeaderDetailsLine1, HeaderFont, Brushes.Black, 20, 140)
                e.Graphics.DrawString(reportHeaderDetailsLine2, HeaderFont, Brushes.Black, 20, 160)
                e.Graphics.DrawString(reportHeaderDetailsLine3, HeaderFont, Brushes.Black, 20, 180)
                e.Graphics.DrawString(reportHeaderDetailsLine4, HeaderFont, Brushes.Black, 20, 200)
                e.Graphics.DrawString(reportHeaderDetailsLine5, HeaderFont, Brushes.Black, 20, 220)
                e.Graphics.DrawString(reportHeaderDetailsLine6, HeaderFont, Brushes.Black, 20, 240)
                e.Graphics.DrawString(reportHeaderDetailsLine7, HeaderFont, Brushes.Black, 20, 260)
                e.Graphics.DrawString(reportHeaderDetailsLine8, HeaderFont, Brushes.Black, 20, 280)
                e.Graphics.DrawString("Listing all requested URLs by the target", HeaderFont, Brushes.Black, 20, 300)

            Case 2 'overall report

        End Select
    End Sub

    Private Sub Print_PrintPage(sender As Object, e As PrintPageEventArgs) Handles Me.PrintPage
        PrintHeaders(Me, e, printMode)
    End Sub
End Class
