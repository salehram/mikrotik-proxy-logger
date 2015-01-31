Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets
Imports System.Windows.Forms
Imports MTPL_Listener_Service.Global_Functions
Imports MTPL_Listener_Service.CheckDB
Imports MTPL_Listener_Service.DBOperations

Public Class MTPL_Listener
    Dim Global_functions As New Global_Functions
    Dim dbOps As New DBOperations
    Dim ChkDB As New CheckDB
    Private Const listenPort As Integer = 514
    Private Const listenIP As String = "127.0.0.1"
    Private thrd As Thread

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        If ChkDB.checkConfig = 0 Then
            If ChkDB.pingDB = 0 Then
                thrd = New Thread(AddressOf StartListener)
                thrd.IsBackground = True
                thrd.Start()
                Global_functions.WriteLog("Started service from " & Application.StartupPath, 1)
            Else
                'we got error in checking the database, we are aborting the service startup
                Global_functions.WriteLog("Exiting the service upon an error, please check the event log before this one for details!", 2)
                OnStop()
                End
            End If
        Else
            Global_functions.WriteLog("Exiting the service upon an error, please check the event log before this one for details!", 2)
            OnStop()
            End
        End If
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

    Private Sub StartListener()
        Dim rawlogMSG() As String
        Dim logMSG(6) As String
        Dim actionMsg(1) As String
        Dim cacheMsg(1) As String
        Dim done As Boolean
        Dim listener As New UdpClient(listenPort)
        Dim groupEP As New IPEndPoint(IPAddress.Parse(listenIP), listenPort)
        Global_functions.WriteLog("Listening for connections", 1)
        Try
            While Not done
                'code to save startup event to txt log file
                Dim bytes As Byte() = listener.Receive(groupEP)
                ' ------------- here code to save incoming logs to database after formating them
                rawlogMSG = Encoding.ASCII.GetString(bytes, 0, bytes.Length).Split(" ")
                '
                'Global_functions.WriteLog(Encoding.ASCII.GetString(bytes, 0, bytes.Length), 3)
                logMSG(0) = rawlogMSG(0) 'log header
                logMSG(1) = rawlogMSG(1) 'log source
                logMSG(2) = rawlogMSG(2) 'method
                '
                'Global_functions.WriteLog(logMSG(0) & " -- " & logMSG(1) & " -- " & logMSG(2), 3)
                Try
                    logMSG(3) = CType(rawlogMSG(3), Integer) 'port
                    logMSG(4) = rawlogMSG(4) 'url
                Catch ex As Exception
                    logMSG(3) = 0
                    logMSG(4) = rawlogMSG(3) 'url
                End Try
                '
                'Global_functions.WriteLog(logMSG(3) & " -- " & logMSG(4), 3)
                Try
                    logMSG(5) = rawlogMSG(5) 'action
                    actionMsg = logMSG(5).Split("=")
                Catch ex As Exception
                    logMSG(5) = ""
                    actionMsg(0) = ""
                    actionMsg(1) = ""
                End Try
                '
                'Global_functions.WriteLog(logMSG(5) & " -- " & actionMsg(0) & " -- " & actionMsg(1), 3)
                Try
                    logMSG(6) = rawlogMSG(6) 'is cached?
                    cacheMsg = logMSG(6).Split("=")
                Catch ex As Exception
                    logMSG(6) = ""
                    cacheMsg(0) = ""
                    cacheMsg(1) = ""
                End Try
                '
                'Global_functions.WriteLog(logMSG(6) & " -- " & cacheMsg(0) & " -- " & cacheMsg(1), 3)
                dbOps.addLog(DateTime.Now, logMSG(0), logMSG(1), logMSG(2), logMSG(3), logMSG(4), actionMsg(1), cacheMsg(1), 0)
                ' ------------------------------------------------------------------------------
            End While
        Catch e As Exception
            Global_functions.WriteLog("Unable to add record to database" & vbCrLf & "Data to be added: " & vbCrLf & _
                                      logMSG(0) & ", " & logMSG(1) & ", " & logMSG(2) & ", " & logMSG(3) & ", " & logMSG(4) & ", " & actionMsg(1) & ", " & cacheMsg(1) & vbCrLf _
                                      & e.Message, 2)
        Finally
            listener.Close()
        End Try
    End Sub
End Class
