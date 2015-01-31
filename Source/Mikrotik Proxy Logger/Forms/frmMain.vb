Imports System.Net
Imports System.IO
Imports Mikrotik_Proxy_Logger.CheckPrereqs
Imports Mikrotik_Proxy_Logger.CheckService
Imports Mikrotik_Proxy_Logger.Global_Functions

Public Class frmMain
    Dim CheckService As New CheckService
    Dim Global_Functions As New Global_Functions
    Dim CheckPrereqs As New CheckPrereqs

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        slbl_DB_SVR_NAME.Text = "Not connected"
        slbl_DB_SVR_NAME.ForeColor = Color.Red
        CheckService.serviceStatus() 'checking service status
        If CheckPrereqs.checkConfig = 0 Then 'checking if the configuration has been done or not
            'configuration has been done, continue to load the application

        Else 'configuration has not been done
            CheckPrereqs.CheckDB() 'checking databse server
            If DB_Server = True Then 'we have a sql server in the network
                'showing a message asking if the user want to show the setup screen
                If Global_Functions.ShowMsg(3, ERR00_NOSETUP(0), ERR00_NOSETUP(1), ERR00_NOSETUP(2), 2) = 1 Then
                    'show the setup window
                    '1- disabling all menus until we finish from setup
                    Global_Functions.DisableApplicationMenus(0)
                    '2- show setup window:
                    LoadConfigWindow()
                Else 'the user did not want to show the setup window, we will stop loading until setup is done
                    Global_Functions.ShowMsg(2, ERR02_frmMainLOAD_NOSETUP(0), ERR02_frmMainLOAD_NOSETUP(1), ERR02_frmMainLOAD_NOSETUP(2), 1)
                    'disable all menus
                    Global_Functions.DisableApplicationMenus(0)
                    'stop loding the rest of the application
                    Exit Sub
                End If
            Else 'there is no database server on the network, we cannot run the program
                Global_Functions.ShowMsg(2, ERR01_frmMainLOAD_NODBSVR(0), ERR01_frmMainLOAD_NODBSVR(1), ERR01_frmMainLOAD_NODBSVR(2), 1)
                'disable all menus
                Global_Functions.DisableApplicationMenus(0)
                'stop loding the rest of the application
                Exit Sub
            End If
        End If
    End Sub

    Private Sub LoadConfigWindow()
        setupStatus = False
        For Each row In DB_Servers_List.Tables("SqlDataSources").Rows
            frmDBConnect.lbServerList.Items.Add(row(0))
        Next
        frmDBConnect.windowMode = 0
        frmDBConnect.ShowDialog()
        If setupStatus = True Then
            Global_Functions.DisableApplicationMenus(1)
        Else
            Global_Functions.DisableApplicationMenus(0)
        End If
    End Sub

    Private Sub sbtn_StopSvc_Click(sender As Object, e As EventArgs) Handles sbtn_StopSvc.Click
        MsgBox(Global_Functions.serviceControl(0))
        CheckService.serviceStatus() 'checking service status
    End Sub

    Private Sub sbtn_StartSvc_Click(sender As Object, e As EventArgs) Handles sbtn_StartSvc.Click
        MsgBox(Global_Functions.serviceControl(1))
        CheckService.serviceStatus() 'checking service status
    End Sub

    Private Sub sbtn_RestartSvc_Click(sender As Object, e As EventArgs) Handles sbtn_RestartSvc.Click
        MsgBox("Status: " & Global_Functions.serviceControl(2))
        CheckService.serviceStatus() 'checking service status
    End Sub

    Private Sub smDBSetup_Click(sender As Object, e As EventArgs) Handles smDBSetup.Click
        frmDBConnect.windowMode = 1
        frmDBConnect.ShowDialog()
        CheckPrereqs.ReadConfig()
    End Sub

    Private Sub smSingleUserReport_Click(sender As Object, e As EventArgs) Handles smSingleUserReport.Click
        Dim frmSingleUserReport_Config As New frmSingleUserReport_Config
        frmSingleUserReport_Config.MdiParent = Me
        frmSingleUserReport_Config.Show()
    End Sub

    Private Sub smResolveHostIPstoNames_Click(sender As Object, e As EventArgs) Handles smResolveHostIPstoNames.Click
        Dim frmResolveHosts As New frmResolveHosts
        frmResolveHosts.StartPosition = FormStartPosition.CenterScreen
        frmResolveHosts.MdiParent = Me
        frmResolveHosts.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim inStream As StreamReader
        Dim webRequest As WebRequest
        Dim webresponse As WebResponse
        webRequest = webRequest.Create("http://192.168.1.1/accounting/ip.cgi")
        webresponse = webRequest.GetResponse()
        inStream = New StreamReader(webresponse.GetResponseStream())
        MsgBox(inStream.ReadToEnd())
    End Sub
End Class
