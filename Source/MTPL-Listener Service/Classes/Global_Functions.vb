' all global functions and subroutines will be put here
Imports System
Imports System.IO
Imports System.Management
Imports System.Diagnostics
Imports System.ServiceProcess
Imports Microsoft.VisualBasic
Imports System.Windows.Forms

Public Class Global_Functions

    ''' <summary>
    ''' Function to write information to file and return the result.
    ''' </summary>
    ''' <param name="FileName">The full path and name of the file we want to create</param>
    ''' <param name="Text">The data that we want to write in the file</param>
    ''' <returns>0 as success, error message when fail</returns>
    ''' <remarks></remarks>
    Public Function WriteFile(ByVal FileName As String, ByVal Text As String) As Integer
        Try
            If File.Exists(FileName) = False Then
                File.Create(FileName).Dispose()
            End If
            Dim objWriter As New StreamWriter(FileName, True)
            objWriter.WriteLine(Text)
            objWriter.Close()
            Return 0
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    ''' <summary>
    ''' Writes an event log for debugging purposes
    ''' </summary>
    ''' <param name="sEvent">Log text</param>
    ''' <param name="mode">Log type, 1=info, 2=error, 3=warning</param>
    ''' <remarks></remarks>
    Public Sub WriteLog(ByVal sEvent As String, ByVal mode As Integer)
        Dim sSource As String
        Dim sLog As String
        Dim sMachine As String

        sSource = "MTPL-Listener"
        sLog = "Application"
        sMachine = "."

        Dim ELog As New EventLog(sLog, sMachine, sSource)
        'ELog.WriteEntry(sEvent)
        Select Case mode
            Case 1 'info
                ELog.WriteEntry(sEvent, EventLogEntryType.Information, 10001, CType(3, Short))
            Case 2 'error
                ELog.WriteEntry(sEvent, EventLogEntryType.Error, 10002, CType(3, Short))
            Case 3 'warning
                ELog.WriteEntry(sEvent, EventLogEntryType.Warning, 10003, CType(3, Short))
        End Select
    End Sub
End Class
