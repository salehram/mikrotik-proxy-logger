'' this class to check the status of the database and the configuration file
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sql
Imports Mikrotik_Proxy_Logger.Global_Functions

Public Class CheckPrereqs
    Dim GF As New Global_Functions

    ''' <summary>
    ''' Checks the configuration of the system, if no configuration file found, then we will switch to prerequisites check and assume this is the first run.
    ''' </summary>
    ''' <returns>0 for success, -1 for failure</returns>
    ''' <remarks></remarks>
    Public Function checkConfig() As Integer
        If File.Exists(Config_File) = True Then
            'checking the contents of the configuration file
            'checking the lines count of the configuration file, if lines are 0, then configuration file is empty, and we need to fix this
            If File.ReadAllLines(Config_File).Count < 1 Then
                'config file is empty, we need to delete it to create a new one, and we will return -1
                File.Delete(Config_File)
                Return -1
            Else
                'config file is not empty, so we will return 0, and we will read it's contents
                ReadConfig()
                Return 0
            End If
        Else
            'the file does not exists, but we will check for the configuration folder to determine if this is the first run or not
            If Directory.Exists(Config_Dir) = True Then
                'the directory is existing, we just need to create the configuration file, and we will return -1
                Return -1
            Else
                'the directory is not existing, so we need to create it first
                MkDir(Config_Dir)
                Return -1
            End If
        End If
    End Function

    Public Sub ReadConfig()
        Try
            Using sr As New StreamReader(Config_File)
                Config_DB_Server = sr.ReadLine
                Config_DB_Instance = sr.ReadLine
                Config_DB_Name = sr.ReadLine
                Config_DB_User_Name = sr.ReadLine
                Config_DB_Password = sr.ReadLine
                Config_MT_IP = sr.ReadLine
            End Using
            DB_ConnectionString = "Server=" & Config_DB_Server & "\" & Config_DB_Instance & ";Database=" & Config_DB_Name & ";User Id=" & Config_DB_User_Name & ";Password=" & Config_DB_Password & ";"
        Catch e As Exception
            GF.ShowMsg(2, ERR004_ReadConfig(0), ERR004_ReadConfig(1) & e.Message, ERR004_ReadConfig(2), 1)
        End Try
    End Sub

    Public Sub CheckDB()
        Dim sqlInstances As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
        DB_Sources = sqlInstances.GetDataSources
        If DB_Sources.Rows.Count < 1 Then
            'database server is not found, we will stop checking for other items until we fix this problem
            DB_Server = False
        Else
            DB_Server = True 'we found a database server!
            DB_Servers_List.Tables.Add(DB_Sources)
        End If
    End Sub
End Class
