Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sql
Imports System.Management
Imports System.Diagnostics
Imports System.ServiceProcess
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports MTPL_Listener_Service.Global_Functions

Public Class DBOperations
    Dim GF As New Global_Functions

    Public Function addLog(ByVal Timestamp As DateTime, ByVal logHeader As String, ByVal logSource As String, ByVal logMethod As String, _
                           ByVal logPort As Integer, ByVal logURL As String, ByVal logAction As String, ByVal logCached As String, ByVal flag As Integer)
        Dim connectionString As String = "Server=" & Config_DB_Server & "\" & Config_DB_Instance & ";Database=" & Config_DB_Name & ";User Id=" & Config_DB_User_Name & ";Password=" & Config_DB_Password & ";"
        Dim sqlConnection As New SqlClient.SqlConnection(connectionString)
        Dim sqlCmd As SqlClient.SqlCommand
        Dim sqlStr As String = ""
        Try
            sqlConnection.Open()
            sqlCmd = sqlConnection.CreateCommand
            'TODO: Add option for extensive logging here
            sqlStr = "insert into mtpl_table1 (logdatetime, logheader, logsource, logmethod, logportno, logurl, logaction, reqcached, flag) values" & _
                " ('" & Timestamp & "', '" & logHeader & "','" & logSource & "','" & logMethod & "'," & logPort & ",'" & logURL & "','" & logAction & "','" & logCached & "'," & flag & ")"
            sqlCmd.CommandText = sqlStr
            sqlCmd.ExecuteNonQuery()
            sqlConnection.Close()
            'GF.WriteLog("Add new log record, SQL:" & vbCrLf & vbCrLf & sqlStr, 3)
            addHostIP(logSource)
            Return 0
        Catch ex As Exception
            GF.WriteLog("Error adding the log to database - Function name 'addLog' in class 'DBOperations'" & vbCrLf & ex.Message & vbCrLf & vbCrLf & _
                        "SQL connection string: " & connectionString & vbCrLf & vbCrLf & "SQL query: " & sqlStr, 2)
            If sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If
            Return -1
        End Try
    End Function

    Public Function addHostIP(ByVal hostIP As String) As Integer
        Dim connectionString As String = "Server=" & Config_DB_Server & "\" & Config_DB_Instance & ";Database=" & Config_DB_Name & ";User Id=" & Config_DB_User_Name & ";Password=" & Config_DB_Password & ";"
        Dim sqlConnection As New SqlClient.SqlConnection(connectionString)
        Dim sqlCmd As SqlClient.SqlCommand
        Dim sqlRdr As SqlClient.SqlDataReader
        Dim sqlStr As String = ""
        Try
            sqlConnection.Open()
            sqlCmd = sqlConnection.CreateCommand
            sqlStr = "select * from mtpl_hosts where host_ipaddr = '" & hostIP & "'"
            sqlCmd.CommandText = sqlStr
            sqlRdr = sqlCmd.ExecuteReader
            If sqlRdr.HasRows = True Then
                sqlRdr.Close()
                'TODO: Add option for extensive logging here
                'GF.WriteLog("DEBUG sqlRdr.HasRows = True - Function name 'addHostIP' in class 'DBOperations'" & vbCrLf & vbCrLf & vbCrLf & _
                '        "SQL connection string: " & connectionString & vbCrLf & vbCrLf & "SQL query: " & sqlStr, 3)
                sqlConnection.Close()
                Return -1
            Else
                sqlRdr.Close()
                'TODO: Add option for extensive logging here
                'GF.WriteLog("DEBUG sqlRdr.HasRows = False - Function name 'addHostIP' in class 'DBOperations'" & vbCrLf & vbCrLf & vbCrLf & _
                '        "SQL connection string: " & connectionString & vbCrLf & vbCrLf & "SQL query: " & sqlStr, 3)
                sqlStr = "insert into mtpl_hosts (host_ipaddr, host_hostname, flag) VALUES ('" & hostIP & "','<unknown>',0)"
                sqlCmd.CommandText = sqlStr
                sqlCmd.ExecuteNonQuery()
                sqlConnection.Close()
                Return 0
            End If
        Catch ex As Exception
            GF.WriteLog("Error adding the log to database - Function name 'addHostIP' in class 'DBOperations'" & vbCrLf & ex.Message & vbCrLf & vbCrLf & _
                        "SQL connection string: " & connectionString & vbCrLf & vbCrLf & "SQL query: " & sqlStr, 2)
            If sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If
            Return -1
        End Try
    End Function

    Public Function addAccountingData(ByVal timeStamp As DateTime, ByVal src_addr As String, ByVal dst_addr As String, ByVal bytes_vol As Integer, ByVal packets_count As Integer, ByVal flag As Integer) As Integer
        Dim connectionString As String = "Server=" & Config_DB_Server & "\" & Config_DB_Instance & ";Database=" & Config_DB_Name & ";User Id=" & Config_DB_User_Name & ";Password=" & Config_DB_Password & ";"
        Dim sqlConnection As New SqlClient.SqlConnection(connectionString)
        Dim sqlCmd As SqlClient.SqlCommand
        Dim sqlStr As String = ""
        Try
            sqlConnection.Open()
            sqlCmd = sqlConnection.CreateCommand
            'TODO: Add option for extensive logging here
            sqlStr = "insert into mtpl_accounting (logDate, src_addr, dst_addr, bytes_vol, packets_count, flag) values" & _
                " ('" & timeStamp & "', '" & src_addr & "', '" & dst_addr & "','" & bytes_vol & "','" & packets_count & "'," & flag & ")"
            sqlCmd.CommandText = sqlStr
            sqlCmd.ExecuteNonQuery()
            sqlConnection.Close()
            Return 0
        Catch ex As Exception
            GF.WriteLog("Error adding the log to database - Function name 'addAccountingData' in class 'DBOperations'" & vbCrLf & ex.Message & vbCrLf & vbCrLf & _
                        "SQL connection string: " & connectionString & vbCrLf & vbCrLf & "SQL query: " & sqlStr, 2)
            If sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If
            Return -1
        End Try
    End Function
End Class
