'' this class is to control the listener service and check its status
Imports System
Imports System.Management
Imports System.Diagnostics
Imports System.ServiceProcess
Imports Microsoft.VisualBasic
Imports System.Windows.Forms

Public Class CheckService

    Public Function serviceStatus() As String
        '
        'checking the service status
        Dim status As String
        Dim svcControl As New ServiceController
        svcControl.ServiceName = "MTPL-Listener"
        Try
            svcControl.Refresh()
            status = svcControl.Status.ToString
            Select Case status
                Case "Stopped"
                    Service_running = False
                Case "Running"
                    Service_running = True
            End Select
            '
            'displaying service status on the frmMain
            Select Case status
                Case "Stopped"
                    frmMain.slbl_SERVICE_STATUS.Text = "Stopped"
                    frmMain.slbl_SERVICE_STATUS.ForeColor = Color.Red
                    frmMain.sbtn_StopSvc.Enabled = False
                    frmMain.sbtn_StartSvc.Enabled = True
                    frmMain.sbtn_RestartSvc.Enabled = True
                Case "Running"
                    frmMain.slbl_SERVICE_STATUS.Text = "Running"
                    frmMain.slbl_SERVICE_STATUS.ForeColor = Color.Green
                    frmMain.sbtn_StopSvc.Enabled = True
                    frmMain.sbtn_StartSvc.Enabled = False
                    frmMain.sbtn_RestartSvc.Enabled = True
                Case Else
                    frmMain.slbl_SERVICE_STATUS.Text = "ERROR!"
                    frmMain.slbl_SERVICE_STATUS.ForeColor = Color.Red
                    frmMain.sbtn_StopSvc.Enabled = False
                    frmMain.sbtn_StartSvc.Enabled = False
                    frmMain.sbtn_RestartSvc.Enabled = False
            End Select
            svcControl.Dispose()
        Catch ex As Exception
            status = ex.Message
        End Try
        Return status
    End Function
End Class
