Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Mikrotik_Proxy_Logger.Global_Functions

Public Class frmSingleUserReport_Config
    Dim GF As New Global_Functions

    Private Sub frmSingleUserReport_Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'filling the 2 lists with ip address and host name if available
        fillHostIP_Lists()
        cbSrcIPList.SelectedIndex = 0
    End Sub

    Private Sub fillHostIP_Lists()
        Dim x As Integer = 0
        Dim rowsCount As Integer
        Dim connectionString As String = "Server=" & Config_DB_Server & "\" & Config_DB_Instance & ";Database=" & Config_DB_Name & ";User Id=" & Config_DB_User_Name & ";Password=" & Config_DB_Password & ";"
        Dim sqlConnection As New SqlConnection(connectionString)
        Dim sqlAdapter As SqlDataAdapter
        Dim dsHosts As New DataSet
        Try
            sqlConnection.Open()
            sqlAdapter = New SqlDataAdapter("select * from mtpl_hosts", sqlConnection)
            sqlAdapter.Fill(dsHosts, "mtpl_hosts")
            If dsHosts.Tables("mtpl_hosts").Rows.Count > 0 Then
                rowsCount = dsHosts.Tables("mtpl_hosts").Rows.Count
                Do
                    cbSrcIPList.Items.Add(dsHosts.Tables("mtpl_hosts").Rows(x)(1).ToString)
                    cbHostNameList.Items.Add(dsHosts.Tables("mtpl_hosts").Rows(x)(2).ToString)
                    x = x + 1
                Loop While x < rowsCount
                cbSrcIPList.AutoCompleteSource = AutoCompleteSource.ListItems
                cbHostNameList.AutoCompleteSource = AutoCompleteSource.ListItems
            End If
            sqlConnection.Close()
            sqlConnection = Nothing
        Catch ex As Exception
            GF.ShowMsg(2, ERR06_fillHostIP_Lists(0), ERR06_fillHostIP_Lists(1) & vbCrLf & vbCrLf & ex.Message, ERR06_fillHostIP_Lists(2), 1)
            sqlConnection.Close()
            sqlConnection = Nothing
        End Try
    End Sub

    Private Sub cbSrcIPList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSrcIPList.SelectedIndexChanged
        cbHostNameList.SelectedIndex = cbSrcIPList.SelectedIndex
    End Sub

    Private Sub cbHostNameList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbHostNameList.SelectedIndexChanged
        cbSrcIPList.SelectedIndex = cbHostNameList.SelectedIndex
    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        Dim fromDate As DateTime
        Dim toDate As DateTime
        Dim dateDifference As Integer
        '
        'getting the from date variable
        If dtFromDate.Value = Nothing Then
            dtFromDate.Value = DateTime.Now
            fromDate = dtFromDate.Value
        Else
            fromDate = dtFromDate.Value
        End If
        '
        'getting the to date vriable
        If DtTillDate.Value = Nothing Then
            DtTillDate.Value = DateTime.Now
            toDate = DtTillDate.Value
        Else
            toDate = DtTillDate.Value
        End If
        '
        'comaring the 2 dates to make sure no errors occur
        dateDifference = DateTime.Compare(fromDate, toDate)
        '
        'comparing the 2 dates and take action based on the result:
        Select Case dateDifference
            Case Is < 0
                'from date is earlier than to date, which is the correct case we want
                MsgBox("success")
            Case Else
                'from date is equal or later than to date, which is the wrong case,
                'we will display error message and abort report generation
                MsgBox("Fail")
        End Select
    End Sub
End Class