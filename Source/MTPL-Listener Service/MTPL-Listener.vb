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
    Private thrd_listenLogs As Thread
    Private thrd_accounting As Thread

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        If ChkDB.checkConfig = 0 Then
            If ChkDB.pingDB = 0 Then
                '
                'starting the listener thread
                thrd_listenLogs = New Thread(AddressOf StartListener)
                thrd_listenLogs.IsBackground = True
                thrd_listenLogs.Start()
                '
                'starting the accounting data grabber thread
                thrd_accounting = New Thread(AddressOf getAccountingData)
                thrd_accounting.IsBackground = True
                thrd_accounting.Start()
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
        Dim incomingMSG As String
        Dim rawlogMSG() As String
        Dim msgRead(9) As String
        Dim logMSG(9) As String
        Dim actionMsg(2) As String
        Dim cacheMsg(2) As String
        Dim done As Boolean
        Dim listener As New UdpClient(listenPort)
        Dim groupEP As New IPEndPoint(IPAddress.Parse(listenIP), listenPort)
        Dim msgLength As Integer
        Dim intValidate As Integer
        '
        Dim counter As Integer
        Dim msgBreak As String
        Dim progress As Integer
        Global_functions.WriteLog("Listening for connections", 1)
        Try
            While Not done
                'code to save startup event to txt log file
                Dim bytes As Byte() = listener.Receive(groupEP)
                incomingMSG = Nothing
                actionMsg(0) = ""
                actionMsg(1) = ""
                cacheMsg(0) = ""
                cacheMsg(1) = ""
                ' ------------- here code to save incoming logs to database after formating them
                incomingMSG = Trim(Encoding.ASCII.GetString(bytes, 0, bytes.Length))
                progress = 1
                '
                '
                '''''''''' ENABLE FOR DEBUG ''''''''''
                'Global_functions.WriteLog(incomingMSG, 3)
                '''''''''' ENABLE FOR DEBUG ''''''''''
                '
                '
                rawlogMSG = incomingMSG.Split(" ")
                msgLength = rawlogMSG.Length
                progress = 2
                '
                '
                '''''''''' ENABLE FOR DEBUG ''''''''''
                'counter = 0
                'msgBreak = Nothing
                'Do
                '    msgBreak = msgBreak & "'" & rawlogMSG(counter) & "'" & vbCrLf
                '    counter = counter + 1
                'Loop Until counter >= msgLength
                'msgBreak = msgBreak & vbCrLf & vbCrLf & "------- Length: " & msgLength
                'Global_functions.WriteLog(msgBreak, 3)
                '''''''''' ENABLE FOR DEBUG ''''''''''
                '
                '
                'receiving the message on 2 formats:
                'short format, length is 6
                'long format, length is 7
                '
                'Global_functions.WriteLog(Encoding.ASCII.GetString(bytes, 0, bytes.Length), 3)
                logMSG(0) = rawlogMSG(0) 'log header
                progress = 1
                logMSG(1) = rawlogMSG(1) 'log source
                progress = 2
                logMSG(2) = rawlogMSG(2) 'method
                progress = 3
                If msgLength = 5 Then 'we have a message that is having "cached xxxxxx" format.
                    If Integer.TryParse(rawlogMSG(3), intValidate) Then
                        ' we have an integer value here which is the length value
                        logMSG(3) = rawlogMSG(3) 'length
                        progress = 41
                        logMSG(4) = rawlogMSG(4) 'url
                        progress = 42
                        actionMsg(0) = ""
                        actionMsg(1) = ""
                        cacheMsg(0) = ""
                        cacheMsg(1) = ""
                        progress = 43
                    End If
                ElseIf msgLength = 6 Then 'we have a medium length message
                    logMSG(3) = 0
                    progress = 51
                    logMSG(4) = rawlogMSG(3) 'url
                    progress = 52
                    logMSG(5) = rawlogMSG(4)
                    progress = 53
                    logMSG(6) = rawlogMSG(5)
                    progress = 53
                    actionMsg = logMSG(5).Split("=")
                    cacheMsg = logMSG(6).Split("=")
                ElseIf msgLength = 8 Then 'we have a long message
                    logMSG(3) = 0
                    progress = 51
                    logMSG(4) = rawlogMSG(3) 'url
                    progress = 52
                    logMSG(5) = rawlogMSG(4)
                    progress = 53
                    logMSG(6) = rawlogMSG(5)
                    progress = 53
                    actionMsg = logMSG(5).Split("=")
                    cacheMsg = logMSG(6).Split("=")
                Else 'we have a normal message
                    logMSG(3) = 0
                    progress = 51
                    logMSG(4) = rawlogMSG(3) 'url
                    progress = 52
                    logMSG(5) = rawlogMSG(5)
                    progress = 53
                    logMSG(6) = rawlogMSG(6)
                    progress = 53
                    actionMsg = logMSG(5).Split("=")
                    cacheMsg = logMSG(6).Split("=")
                End If
                dbOps.addLog(DateTime.Now, logMSG(0), logMSG(1), logMSG(2), logMSG(3), logMSG(4), actionMsg(1), cacheMsg(1), 0)
                progress = 7
                ' ------------------------------------------------------------------------------
            End While
        Catch e As Exception 'error logging
            Global_functions.WriteLog("Unable to add record to database" & vbCrLf & "Data to be added: " & vbCrLf & _
                                      logMSG(0) & ", " & logMSG(1) & ", " & logMSG(2) & ", " & logMSG(3) & ", " & logMSG(4) & ", " & actionMsg(1) & ", " & cacheMsg(1) & vbCrLf _
                                      & e.Message & vbCrLf & vbCrLf & "Received message was:" & vbCrLf & incomingMSG & vbCrLf & vbCrLf & "Message length: " & msgLength _
                                      & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "Variables are: " & vbCrLf & vbCrLf _
                                      & logMSG(0) & vbCrLf & logMSG(1) & vbCrLf & logMSG(2) & vbCrLf & logMSG(3) & vbCrLf & logMSG(4) & vbCrLf & actionMsg(1) & vbCrLf & cacheMsg(1) _
                                      & vbCrLf & vbCrLf & vbCrLf & "Log catch progress: " & progress, 2)
        Finally
            listener.Close()
        End Try
    End Sub

    Private Sub getAccountingData()
        Dim inStream As StreamReader
        Dim webRequest As WebRequest
        Dim webresponse As WebResponse
        Dim msgData(5) As String
        Do
            webRequest = webRequest.Create("http://" & Config_MT_IP & "/accounting/ip.cgi")
            webresponse = webRequest.GetResponse()
            inStream = New StreamReader(webresponse.GetResponseStream())
            Do While inStream.EndOfStream = False
                msgData = inStream.ReadLine.Split(" ")
                dbOps.addAccountingData(DateTime.Now, msgData(0), msgData(1), msgData(2), msgData(3), 0)
            Loop
            Thread.Sleep(1000)
            msgData(5) = Nothing
        Loop
    End Sub
End Class
