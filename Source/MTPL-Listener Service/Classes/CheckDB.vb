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

Public Class CheckDB
    Dim GF As New Global_Functions

    Public Function checkConfig() As Integer
        Try
            Using sr As New StreamReader(Config_File)
                Config_DB_Server = sr.ReadLine
                Config_DB_Instance = sr.ReadLine
                Config_DB_Name = sr.ReadLine
                Config_DB_User_Name = sr.ReadLine
                Config_DB_Password = sr.ReadLine
            End Using
            Return 0
        Catch e As Exception
            GF.WriteLog(ERR04_CANTLOADCONFIG(1) & e.Message, 2)
            Return -1
        End Try
    End Function

    Public Function pingDB() As Integer
        Dim logDate As DateTime = DateTime.Now
        Dim connectionString As String = "Server=" & Config_DB_Server & "\" & Config_DB_Instance & ";Database=" & Config_DB_Name & ";User Id=" & Config_DB_User_Name & ";Password=" & Config_DB_Password & ";"
        Dim sqlConnection As New SqlClient.SqlConnection(connectionString)
        Dim sqlCmd As SqlClient.SqlCommand
        Dim sqlStr As String = ""
        Try
            sqlConnection.Open()
            sqlCmd = sqlConnection.CreateCommand
            sqlStr = "insert into mtpl_table1 (logdatetime, logheader, logsource, logmethod, logportno, logurl, logaction, reqcached, flag) values ('" & logDate & "', 'TEST,TEST','LOC','TEST', 000,'URL','TEST','NO',1)"
            sqlCmd.CommandText = sqlStr
            sqlCmd.ExecuteNonQuery()
            sqlStr = "delete from mtpl_table1 where logheader='TEST,TEST'"
            sqlCmd.CommandText = sqlStr
            sqlCmd.ExecuteNonQuery()
            Return 0
        Catch ex As Exception
            GF.WriteLog("Error while checking database after service intialization - Function name 'pingDB' in class 'CheckDB'" & vbCrLf & ex.Message & vbCrLf & vbCrLf & _
                        "SQL connection string: " & connectionString & vbCrLf & vbCrLf & "SQL query: " & sqlStr, 2)
            Return -1
        End Try
        sqlConnection.Close()
        sqlConnection = Nothing
    End Function
End Class
