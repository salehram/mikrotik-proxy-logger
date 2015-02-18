Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sql
Imports System.Management
Imports System.Diagnostics
Imports System.ServiceProcess
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports Mikrotik_Proxy_Logger.Global_Functions

Public Class DBOperations
    Dim GF As New Global_Functions

    Public Sub buildDB()
        Dim connectionString As String = "Server=" & Config_DB_Server & "\" & Config_DB_Instance & ";Database=" & Config_DB_Name & ";User Id=" & Config_DB_User_Name & ";Password=" & Config_DB_Password & ";"
        Dim sqlConnection As New SqlClient.SqlConnection(connectionString)
        Dim sqlCmd As SqlClient.SqlCommand
        Dim sqlStr As String
        Try
            sqlConnection.Open()
            sqlCmd = sqlConnection.CreateCommand
            ''
            ''main table
            'sqlStr = "CREATE TABLE mtpl_table1 (Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, logdatetime datetime, logheader VARCHAR(17), logsource  varchar(15), logmethod varchar(50), logportno int, logurl text, logaction varchar(50), reqcached varchar(50), flag int not null)"
            'sqlCmd.CommandText = sqlStr
            'sqlCmd.ExecuteNonQuery()
            ''
            ''hosts table
            'sqlStr = "create table mtpl_hosts (Id int IDENTITY(1,1) not null primary key, host_ipaddr varchar(15) not null, host_hostname text, flag int not null)"
            'sqlCmd.CommandText = sqlStr
            'sqlCmd.ExecuteNonQuery()
            '
            'accounting table
            sqlStr = "create table mtpl_accounting (Id int IDENTITY(1,1) not null primary key, logDate datetime not null, src_addr varchar(15) not null, dst_addr varchar(15) not null, bytes_vol int not null, packets_count int not null, flag int not null)"
            sqlCmd.CommandText = sqlStr
            sqlCmd.ExecuteNonQuery()
        Catch ex As Exception
            GF.ShowMsg(2, ERR05_buildDB(0), ERR05_buildDB(1) & ex.Message, ERR05_buildDB(2), 1)
        End Try
        sqlConnection.Close()
        sqlConnection = Nothing
    End Sub
End Class
