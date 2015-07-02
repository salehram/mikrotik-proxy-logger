' all global functions and subroutines will be put here
Imports System
Imports System.IO
Imports System.Management
Imports System.Diagnostics
Imports System.ServiceProcess
Imports Microsoft.VisualBasic
Imports System.Windows.Forms

'functions/sub list:
'F serviceControl
'F ShowMsg
'S DisableApplicationMenus
'F WriteFile

Public Class Global_Functions

    ''' <summary>
    ''' Sends a command to the service.
    ''' </summary>
    ''' <param name="Command">0 = Stop, 1 = Start, 2 = Reestart</param>
    ''' <returns>0 = Success, Other output indicates an error</returns>
    ''' <remarks></remarks>
    Public Function serviceControl(ByVal Command As Integer) As String
        '
        'checking the service status
        serviceControl = Nothing
        Dim svcControl As New ServiceController
        svcControl.ServiceName = "MTPL-Listener"
        svcControl.Refresh()
        Select Case Command
            Case 0 'stop command
                Try
                    svcControl.Stop()
                    Return 0
                Catch ex As Exception
                    Return ex.Message
                End Try
            Case 1 'start command
                Try
                    svcControl.Start()
                    Return 0
                Catch ex As Exception
                    Return ex.Message
                End Try
            Case 2 'restart command
                Try
                    svcControl.Stop()
                    svcControl.Start()
                    Return 0
                Catch ex As Exception
                    Return ex.Message
                End Try
        End Select
    End Function

    ''' <summary>
    ''' A call to a message box with the specified conditions.
    ''' </summary>
    ''' <param name="Type">The type of the message to be shown. 0=Information, 1=Warning, 2=Error, 3=Question</param>
    ''' <param name="Title">The title of the message box window</param>
    ''' <param name="Text">The text should be displayed in the message</param>
    ''' <param name="Code">The code of the message, used for debugging purposes</param>
    ''' <param name="Buttons">The number and type of buttons. 1=Only OK button, 2=Yes/No buttons, 3=OK/Cancel buttons</param>
    ''' <returns>Returns 1 if clicked OK, or Yes, 0 if clicked No or Cancel</returns>
    ''' <remarks></remarks>
    Public Function ShowMsg(ByVal Type As Integer, ByVal Title As String, ByVal Text As String, ByVal Code As String, ByVal Buttons As Integer) As Integer
        Dim btns As MessageBoxButtons
        Dim msgtype As MessageBoxIcon
        '
        'determining the message type
        Select Case Type
            Case 0 'message type information
                msgtype = MessageBoxIcon.Information
            Case 1 'message type warning
                msgtype = MessageBoxIcon.Warning
            Case 2 'message type as error
                msgtype = MessageBoxIcon.Error
            Case 3 'message type as question
                msgtype = MessageBoxIcon.Question
        End Select
        '
        'determining the buttons count
        Select Case Buttons
            Case 1 'only 1 button
                btns = MessageBoxButtons.OK
            Case 2 'yes/no
                btns = MessageBoxButtons.YesNo
            Case 3 'ok/cancel
                btns = MessageBoxButtons.OKCancel
        End Select
        '
        'showing the messagebox
        If btns = 1 Then
            MessageBox.Show(Text, Title, btns, msgtype)
            Return 1
        Else
            If MessageBox.Show(Text & vbCrLf & vbCrLf & "Message code: " & Code, Title, btns, msgtype) = DialogResult.Yes Then
                Return 1
            Else
                Return 0
            End If
        End If
    End Function

    ''' <summary>
    ''' Disable/enable all meuns except Setup menu
    ''' </summary>
    ''' <param name="Status">0=disable mode, 1=enable mode</param>
    ''' <remarks></remarks>
    Public Sub DisableApplicationMenus(ByVal Status As Integer)
        Select Case Status
            Case 0 'we will disable all menus excep setup menu
                With frmMain
                    .mm_File.Enabled = False
                    .mm_Data.Enabled = False
                    .mm_Reports.Enabled = False
                End With
            Case 1 'we will enable all menus
                With frmMain
                    .mm_File.Enabled = True
                    .mm_Data.Enabled = True
                    .mm_Reports.Enabled = True
                End With
        End Select
    End Sub

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
End Class
