Imports System
Imports System.Net
Imports System.Data
Imports System.Data.SqlClient
Imports Mikrotik_Proxy_Logger.Global_Functions

Public Class frmResolveHosts
    Dim GF As New Global_Functions

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmResolveHosts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'filling the grid with the current hosts table
        Dim connectionString As String = "Server=" & Config_DB_Server & "\" & Config_DB_Instance & ";Database=" & Config_DB_Name & ";User Id=" & Config_DB_User_Name & ";Password=" & Config_DB_Password & ";"
        Dim sqlConnection As New SqlConnection(connectionString)
        Dim sqlAdapter As SqlDataAdapter
        Dim dsHosts As New DataSet
        Try
            sqlConnection.Open()
            sqlAdapter = New SqlDataAdapter("select * from mtpl_hosts", sqlConnection)
            sqlAdapter.Fill(dsHosts, "mtpl_hosts")
            If dsHosts.Tables("mtpl_hosts").Rows.Count > 0 Then
                dgHostsGrid.DataSource = dsHosts.Tables("mtpl_hosts")
            End If
            sqlConnection.Close()
            sqlConnection = Nothing
        Catch ex As Exception
            GF.ShowMsg(2, ERR007_frmResolveHosts_Load(0), ERR007_frmResolveHosts_Load(1) & vbCrLf & vbCrLf & ex.Message, ERR007_frmResolveHosts_Load(2), 1)
            sqlConnection.Close()
            sqlConnection = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '
        'saving the datagrid into the hosts table
        Dim gridRows_Count As Integer = 0
        Dim counter As Integer = 0
        Dim connectionString As String = "Server=" & Config_DB_Server & "\" & Config_DB_Instance & ";Database=" & Config_DB_Name & ";User Id=" & Config_DB_User_Name & ";Password=" & Config_DB_Password & ";"
        Dim sqlConnection As New SqlClient.SqlConnection(connectionString)
        Dim sqlCmd As SqlClient.SqlCommand
        Dim sqlStr As String
        If dgHostsGrid.Rows.Count < 1 Then
            '
            'we don't have rows in the datagrid, so we are exiting the code
            Exit Sub
        Else
            'we have data in the grid
            counter = 0
            gridRows_Count = dgHostsGrid.Rows.Count
            Try
                sqlConnection.Open()
                sqlCmd = sqlConnection.CreateCommand
                Do
                    sqlStr = "update mtpl_hosts set host_ipaddr = '" & dgHostsGrid.Rows(counter).Cells(1).Value & "', host_hostname = '" & dgHostsGrid.Rows(counter).Cells(2).Value & "', flag=0 where id=" & dgHostsGrid.Rows(counter).Cells(0).Value & ""
                    sqlCmd.CommandText = sqlStr
                    sqlCmd.ExecuteNonQuery()
                    counter = counter + 1
                Loop While counter <= gridRows_Count - 1
                sqlConnection.Close()
                sqlConnection = Nothing
            Catch ex As Exception
                GF.ShowMsg(2, ERR008_btnSave_Click(0), ERR008_btnSave_Click(1) & ex.Message, ERR008_btnSave_Click(2), 1)
            End Try
        End If
    End Sub

    Private Sub btnAutoResolve_Click(sender As Object, e As EventArgs) Handles btnAutoResolve.Click
        'attempt auto name resolution
        Dim dgRows As Integer = 0
        Dim counter As Integer = 0
        Dim host As New IPHostEntry
        dgRows = dgHostsGrid.Rows.Count
        If dgRows < 1 Then
            'we don't have any row, we will exit sub
        Else
            'we have data in grid...
            Do
                host = Dns.GetHostEntry(Trim(dgHostsGrid.Rows(counter).Cells(1).Value))
                dgHostsGrid.Rows(counter).Cells(2).Value = host.HostName
                counter = counter + 1
            Loop While counter <= dgRows - 1
        End If
    End Sub
End Class