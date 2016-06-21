'' this class is to perform all csv export operations
Imports System
Imports System.IO
Imports System.Management
Imports System.Diagnostics
Imports System.ServiceProcess
Imports Microsoft.VisualBasic
Imports System.Windows.Forms

Public Class ExportData

    ''' <summary>
    ''' Function to export data to CSV
    ''' </summary>
    ''' <param name="ContentType">Content type: 1=Single user report, 2=Overall report</param>
    ''' <remarks>Returns a message box with question to open the file if export succeeded</remarks>
    Public Sub ExportTXT(ByVal ContentType As Integer)
        Dim fileNameFormat As String = Today.Month & Today.Day & Today.Year & "-" & TimeOfDay.Hour & TimeOfDay.Minute & TimeOfDay.Second & TimeOfDay.Millisecond.ToString
        Dim fileName As String = "\" & fileNameFormat & ".CSV"
        Dim reportFile As String = AppReportsDir & fileName
        Const _C As String = ","  'the comma separator
        Dim gridRowsCount As Integer = 0
        Dim currentRow As Integer = 0
        '
        'checking what type of report we want to export to CSV
        Select Case ContentType
            Case 1 'single user report
                Try
                    'we will create a new csv file
                    'then we will start with headers,
                    'then we will go in a loop to append all the details
                    '
                    ' first we will be checking if the reports directory is created or not, if not create we will create it
                    If Not Directory.Exists(AppReportsDir) Then
                        'the directory is not created
                        Directory.CreateDirectory(AppReportsDir)
                    End If
                    '
                    'then we will create the CSV file where we will put the report
                    Using newFileWriter As StreamWriter = File.CreateText(reportFile)
                        'adding the header lines
                        newFileWriter.WriteLine("""Mikrotik Proxy Logger""")
                        newFileWriter.WriteLine("""Single User Report""")
                        newFileWriter.WriteLine("""" & reportHeadLine1 & """")
                        newFileWriter.WriteLine("""" & reportHeadLine2 & """")
                        newFileWriter.WriteLine("""" & reportHeadLine3 & """")
                        newFileWriter.WriteLine("""" & reportHeaderDetailsLine1 & """")
                        newFileWriter.WriteLine("""" & reportHeaderDetailsLine2 & """")
                        newFileWriter.WriteLine("""" & reportHeaderDetailsLine3 & """")
                        newFileWriter.WriteLine("""" & reportHeaderDetailsLine4 & """")
                        newFileWriter.WriteLine("""" & reportHeaderDetailsLine5 & """")
                        newFileWriter.WriteLine("""" & reportHeaderDetailsLine6 & """")
                        newFileWriter.WriteLine("""" & reportHeaderDetailsLine7 & """")
                        newFileWriter.WriteLine("""" & reportHeaderDetailsLine8 & """")
                    End Using
                    '
                    'now filling the details of the grid
                    gridRowsCount = frmViewReport.dgReportMain.Rows.Count
                    If gridRowsCount > 0 Then
                        Do
                            With frmViewReport.dgReportMain
                                Using newFileWriter As StreamWriter = File.AppendText(reportFile)
                                    'adding the grid details
                                    newFileWriter.WriteLine(.Item(1, currentRow).Value & _C & .Item(7, currentRow).Value & _C & .Item(6, currentRow).Value)
                                End Using
                            End With
                            currentRow = currentRow + 1
                        Loop Until currentRow = gridRowsCount - 1
                    End If
                    '
                    'export is complete, asking the user if he want to open the file with a notepad
                    If MessageBox.Show("File created '" & reportFile & "', do you want to open the file with notepad?", "File created", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        System.Diagnostics.Process.Start("Notepad.Exe", reportFile)
                    End If
                Catch ex As Exception
                    'TODO: add error message exception
                    MessageBox.Show(ex.Message)
                End Try
            Case 2 'overall users report

        End Select
    End Sub
End Class
