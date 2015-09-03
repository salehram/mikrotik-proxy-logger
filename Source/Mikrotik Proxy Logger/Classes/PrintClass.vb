Imports System
Imports System.Drawing
Imports System.Drawing.Printing

Public Class PrintClass
    Inherits PrintDocument

    Private TitleFont As Font
    Private HeaderFont As Font
    Private BodyFont As Font
    Private FooterFont As Font
    Private currentPage As Integer = 0
    Private currentRecord As Integer = 0
    Dim extraVerticalMargin As Integer = 25
    Dim headerDone As Boolean = False
    Dim verticalLocation As Integer = 340 + 55
    Dim rowsCount As Integer = 0
    Dim currentRow As Integer = 0

    Private Sub Print_BeginPrint(sender As Object, e As PrintEventArgs) Handles Me.BeginPrint
        '
        'setting the fonts styles and sizes
        TitleFont = New Font(FontFamily.GenericSerif, 16, FontStyle.Bold, GraphicsUnit.Point)
        HeaderFont = New Font(FontFamily.GenericSerif, 12, FontStyle.Regular, GraphicsUnit.Point)
        BodyFont = New Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FooterFont = New Font(FontFamily.GenericSerif, 8, FontStyle.Regular, GraphicsUnit.Point)
    End Sub

    Private Sub Print_PrintPage(sender As Object, e As PrintPageEventArgs) Handles Me.PrintPage
        On Error GoTo CATCH_ERROR
START:
        '
        'initialize the page parameters:
        '
        'report type:
        '1=somgle user report
        '2=overall report
        '
        'title print
        e.Graphics.DrawString("Mikrotik Proxy Logger", TitleFont, Brushes.Black, 40, 20 + 20)
        Select Case printMode
            Case 1 'single user report
                '
                'report headers lines
                If currentPage = 0 Then 'printing the header on the first page only
                    e.Graphics.DrawString("Single User Report", HeaderFont, Brushes.Black, 60, 40 + extraVerticalMargin)
                    e.Graphics.DrawString("Target: " & reportHeadLine1, HeaderFont, Brushes.Black, 60, 60 + extraVerticalMargin)
                    e.Graphics.DrawString("Time range: " & reportHeadLine2, HeaderFont, Brushes.Black, 60, 80 + extraVerticalMargin)
                    e.Graphics.DrawString("Usage stats:", HeaderFont, Brushes.Black, 60, 120 + extraVerticalMargin)
                    e.Graphics.DrawString(reportHeaderDetailsLine1, HeaderFont, Brushes.Black, 60, 140 + extraVerticalMargin)
                    e.Graphics.DrawString(reportHeaderDetailsLine2, HeaderFont, Brushes.Black, 60, 160 + extraVerticalMargin)
                    e.Graphics.DrawString(reportHeaderDetailsLine3, HeaderFont, Brushes.Black, 60, 180 + extraVerticalMargin)
                    e.Graphics.DrawString(reportHeaderDetailsLine4, HeaderFont, Brushes.Black, 60, 200 + extraVerticalMargin)
                    e.Graphics.DrawString(reportHeaderDetailsLine5, HeaderFont, Brushes.Black, 60, 220 + extraVerticalMargin)
                    e.Graphics.DrawString(reportHeaderDetailsLine6, HeaderFont, Brushes.Black, 60, 240 + extraVerticalMargin)
                    e.Graphics.DrawString(reportHeaderDetailsLine7, HeaderFont, Brushes.Black, 60, 260 + extraVerticalMargin)
                    e.Graphics.DrawString(reportHeaderDetailsLine8, HeaderFont, Brushes.Black, 60, 280 + extraVerticalMargin)
                    e.Graphics.DrawLine(Pens.Black, 40, 300 + extraVerticalMargin, 800, 300 + extraVerticalMargin)
                    e.Graphics.DrawString("Listing all requested URLs by the target", HeaderFont, Brushes.Black, 60, 320 + extraVerticalMargin)
                    headerDone = True
                End If
                '
                'report details
                rowsCount = frmViewReport.dgReportMain.Rows.Count
                If rowsCount > 0 Then
                    e.Graphics.DrawString("Total registered requests: " & FormatNumber(rowsCount, 0, TriState.False, TriState.False, TriState.False), HeaderFont, Brushes.Black, 420, verticalLocation - 45)
                    Do
                        With frmViewReport.dgReportMain
                            e.Graphics.DrawString(.Item(1, currentRow).Value, BodyFont, Brushes.Black, New Rectangle(60, verticalLocation, 160, 50))
                            e.Graphics.DrawString(.Item(7, currentRow).Value, BodyFont, Brushes.Black, New Rectangle(220, verticalLocation, 60, 50))
                            e.Graphics.DrawString(.Item(6, currentRow).Value, BodyFont, Brushes.Black, New Rectangle(280, verticalLocation, 520, 50))
                        End With
                        If verticalLocation > 900 Then
                            'we have reached the end of the page, we will add a footer and make a new page
                            '
                            'footer
                            e.Graphics.DrawLine(Pens.Black, 40, verticalLocation + 110, 600, verticalLocation + 110)
                            Dim FooterText As String = "Single User Report" & " - Target: " & reportHeadLine1 & " - Time range: " & reportHeadLine2
                            e.Graphics.DrawString(FooterText, FooterFont, Brushes.Black, 40, verticalLocation + 120)
                            '
                            'end of footer
                            '
                            'setting more pages flag to true
                            e.HasMorePages = True
                            '
                            'adding one more page to the counter
                            currentPage = currentPage + 1
                            '
                            'resetting the location of text printing
                            verticalLocation = 40 + 55
                            Exit Do
                        Else
                            e.HasMorePages = False
                        End If
                        currentRow = currentRow + 1
                        verticalLocation = verticalLocation + 55
                    Loop Until currentRow = rowsCount - 1
                End If
            Case 2 'overall report

        End Select
        Exit Sub
CATCH_ERROR:
        rowsCount = 0
        currentRow = 0
        GoTo START
    End Sub
End Class
