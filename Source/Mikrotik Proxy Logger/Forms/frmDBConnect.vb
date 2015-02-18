Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sql
Imports Mikrotik_Proxy_Logger.Global_Functions
Imports Mikrotik_Proxy_Logger.DBOperations
Imports Mikrotik_Proxy_Logger.CheckPrereqs

Public Class frmDBConnect
    Dim global_functions As New Global_Functions
    Dim checkPrereqs As New CheckPrereqs
    Dim DBOps As New DBOperations
    Public windowMode As Integer 'variable to define how we opened the window, 1 = normal open, 0 = the window was opened during first run setup

    Private Sub frmDBConnect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DBSource As DataTable
        Dim serverList As New DataSet
        Select Case windowMode
            Case 1 'normal open
                Dim sqlInstances As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
                DBSource = sqlInstances.GetDataSources
                If DBSource.Rows.Count < 1 Then
                    'database server is not found, we will stop checking for other items until we fix this problem
                    'nothing to be done
                Else
                    serverList.Tables.Add(DBSource)
                    For Each row In serverList.Tables("SqlDataSources").Rows
                        lbServerList.Items.Add(row(0))
                    Next
                    'we need to read the config file though
                    If Config_DB_Instance IsNot Nothing Then txtInstanceName.Text = Config_DB_Instance
                    If Config_DB_Name IsNot Nothing Then txtDBName.Text = Config_DB_Name
                    If Config_DB_User_Name IsNot Nothing Then txtDBUserName.Text = Config_DB_User_Name
                    If Config_DB_Password IsNot Nothing Then txtDBPassword.Text = Config_DB_Password
                    If Config_MT_IP IsNot Nothing Then txtMTIP.Text = Config_MT_IP
                End If
            Case 0 'open from first run setup

        End Select
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Select Case windowMode
            Case 1 'normal open
                checkPrereqs.ReadConfig()
                Me.Dispose()
            Case 0 'open from first run setup
                checkPrereqs.ReadConfig()
                setupStatus = False
                Me.Dispose()
        End Select
    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        Dim config_text As String
        Select Case windowMode
            Case 1 'normal open
                If validateFields() = 0 Then
                    config_text = lbServerList.SelectedItem.ToString & vbCrLf & txtInstanceName.Text & vbCrLf & txtDBName.Text & vbCrLf & txtDBUserName.Text & vbCrLf & txtDBPassword.Text & vbCrLf & txtMTIP.Text
                    global_functions.WriteFile(Config_File, config_text)
                    setupStatus = True
                    checkPrereqs.ReadConfig()
                    Me.Dispose()
                Else
                    Exit Sub
                End If
            Case 0 'open from first run setup
                setupStatus = True
                If validateFields() = 0 Then
                    config_text = lbServerList.SelectedItem.ToString & vbCrLf & txtInstanceName.Text & vbCrLf & txtDBName.Text & vbCrLf & txtDBUserName.Text & vbCrLf & txtDBPassword.Text & vbCrLf & txtMTIP.Text
                    global_functions.WriteFile(Config_File, config_text)
                    setupStatus = True
                    checkPrereqs.ReadConfig()
                    Me.Dispose()
                Else
                    Exit Sub
                End If
        End Select
    End Sub

    Private Function validateFields() As Integer
        Dim ErrorText As String = Nothing
        If lbServerList.SelectedItem = Nothing Then ErrorText = "Server Name" & vbCrLf
        If txtDBName.Text = Nothing Then ErrorText = ErrorText & "Database name" & vbCrLf
        If txtInstanceName.Text = Nothing Then ErrorText = ErrorText & "Instance name" & vbCrLf
        If txtDBUserName.Text = Nothing Then ErrorText = ErrorText & "User name" & vbCrLf
        If txtDBPassword.Text = Nothing Then ErrorText = ErrorText & "Password" & vbCrLf
        If ErrorText <> Nothing Then
            global_functions.ShowMsg(2, ERR03_validateFields(0), ERR03_validateFields(1) & vbCrLf & vbCrLf & ErrorText, ERR03_validateFields(2), 1)
            Return -1
        Else
            Return 0
        End If
    End Function

    Private Sub btnBuildDB_Click(sender As Object, e As EventArgs) Handles btnBuildDB.Click
        If MessageBox.Show("WARNING!!! - Using this function while you have data in the database will DELETE all the data and make your database EMPTY." & vbCrLf & vbCrLf & "Are you ABSOLUTELY sure you want to do this?", "WARNING!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            DBOps.buildDB()
        End If
    End Sub
End Class