Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Mikrotik_Proxy_Logger.Global_Functions

Public Class frmSingleUserReport_Config
    Dim GF As New Global_Functions
    Dim userUsageDL As Double = 0.0
    Dim packetsCountDL As Int64 = 0
    Dim userUsageUP As Double = 0.0
    Dim packetsCountUP As Int64 = 0
    Dim totalUsage As Double = 0.0
    Dim totalPackets As Int64 = 0
    Dim usePercentageBytes As Double = 0.0
    Dim usePercentagePackets As Double = 0.0

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
            GF.ShowMsg(2, ERR006_fillHostIP_Lists(0), ERR006_fillHostIP_Lists(1) & vbCrLf & vbCrLf & ex.Message, ERR006_fillHostIP_Lists(2), 1)
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
        Dim reportTargetIP As String
        Dim reportTargetName As String
        '
        reportTargetIP = cbSrcIPList.SelectedItem.ToString
        reportTargetName = cbHostNameList.SelectedItem.ToString
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
                'start pulling data from the database so we can store it in a dataset we will create now
                '
                '
                '
                'creating the dataset
                Dim connectionString As String = DB_ConnectionString
                Dim sqlConnection As New SqlConnection(connectionString)
                Dim sqlAdapter As SqlDataAdapter
                Dim dsSingleUserReport As New DataSet
                Try
                    sqlConnection.Open()
                    Select Case reportTargetIP
                        Case "All"
                            sqlAdapter = New SqlDataAdapter("select * from mtpl_table1 where logdatetime between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
                        Case Else
                            sqlAdapter = New SqlDataAdapter("select * from mtpl_table1 where logsource='" & reportTargetIP & "' and logdatetime between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
                    End Select
                    sqlAdapter.Fill(dsSingleUserReport, "mtpl_table1")
                    '
                    ' assigning the dataset to the datagrid view in the report form
                    frmViewReport.dgReportMain.DataSource = dsSingleUserReport.Tables("mtpl_table1")
                    '
                    ' putting the ip and device name and date range in the report form
                    frmViewReport.lblDeviceIP.Text = reportTargetIP
                    frmViewReport.lblDeviceName.Text = reportTargetName
                    frmViewReport.lblFromDate.Text = fromDate
                    frmViewReport.lblToDate.Text = toDate
                    '
                    ' getting the accounting data
                    getAccountingData(reportTargetIP, fromDate, toDate)
                    '
                    ' generating the chart
                    CreateChart1()
                    '
                    ' finally showing the report form
                    frmViewReport.MdiParent = frmMain
                    frmViewReport.Show()
                    sqlConnection.Close()
                    sqlConnection = Nothing
                Catch ex As Exception
                    GF.ShowMsg(2, ERR010_btnGenerateReport_Click_BuildDataset(0), ERR010_btnGenerateReport_Click_BuildDataset(1) & vbCrLf & vbCrLf & ex.Message, ERR010_btnGenerateReport_Click_BuildDataset(2), 1)
                    sqlConnection.Close()
                    sqlConnection = Nothing
                End Try
                '
                '
                'end of dataset creation
            Case Else
                'from date is equal or later than to date, which is the wrong case,
                'we will display error message and abort report generation
                GF.ShowMsg(2, ERR009_btnGenerateReport_Click_DATEERROR(0), ERR009_btnGenerateReport_Click_DATEERROR(1), ERR009_btnGenerateReport_Click_DATEERROR(2), 1)
                Exit Sub
        End Select
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub getAccountingData(ByVal targetIP As String, ByVal fromDate As DateTime, ByVal toDate As DateTime)
        'creating the dataset
        Dim connectionString As String = DB_ConnectionString
        Dim sqlConnection As New SqlConnection(connectionString)
        Dim sqlAdapter As SqlDataAdapter
        Dim dsSingleUserReport_ACCOUNTING As New DataSet
        Try
            sqlConnection.Open()
            '
            ' selecting the data in the time ragne for the specific user we want (dst_addr)
            sqlAdapter = New SqlDataAdapter("select sum(bytes_vol), sum(packets_count) from mtpl_accounting where dst_addr='" & targetIP & "' and logdate between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
            sqlAdapter.Fill(dsSingleUserReport_ACCOUNTING, "mtpl_accounting")
            '
            ' putting the usage numbers in the report form
            userUsageDL = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(0), Double) / 1048576
            packetsCountDL = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(1), Integer)
            frmViewReport.lblBWUsage.Text = FormatNumber(userUsageDL, 2, TriState.True, TriState.True, TriState.True)
            frmViewReport.lblPacketsCount.Text = FormatNumber(packetsCountDL, 2, TriState.True, TriState.True, TriState.True)
            dsSingleUserReport_ACCOUNTING.Tables.Clear()
            '
            ' selecting the data in the time ragne for the specific user we want (src_addr)
            sqlAdapter = New SqlDataAdapter("select sum(bytes_vol), sum(packets_count) from mtpl_accounting where src_addr='" & targetIP & "' and logdate between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
            sqlAdapter.Fill(dsSingleUserReport_ACCOUNTING, "mtpl_accounting")
            '
            ' putting the upload usage numbers in the report form
            userUsageUP = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(0), Double) / 1048576
            packetsCountUP = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(1), Integer)
            frmViewReport.lblUPDWUsage.Text = FormatNumber(userUsageUP, 2, TriState.True, TriState.True, TriState.True)
            frmViewReport.lblUPBWPackets.Text = FormatNumber(packetsCountUP, 2, TriState.True, TriState.True, TriState.True)
            dsSingleUserReport_ACCOUNTING.Tables.Clear()
            '
            ' now selecting the usage statistics for all users in the time range
            sqlAdapter = New SqlDataAdapter("select sum(bytes_vol), sum(packets_count) from mtpl_accounting where logdate between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
            dsSingleUserReport_ACCOUNTING.Tables.Clear()
            sqlAdapter.Fill(dsSingleUserReport_ACCOUNTING, "mtpl_accounting")
            '
            ' calculating the numbers and putting the remaining values in the report form
            totalUsage = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(0), Double) / 1048576.0
            totalPackets = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(1), Integer)
            usePercentageBytes = (userUsageDL / totalUsage) * 100
            usePercentagePackets = (packetsCountDL / totalPackets) * 100
            frmViewReport.lblTotalUsage.Text = FormatNumber(totalUsage, 2, TriState.True, TriState.True, TriState.True)
            frmViewReport.lblTotalPackets.Text = FormatNumber(totalPackets, 2, TriState.True, TriState.True, TriState.True)
            frmViewReport.lblUsagePercentageBytes.Text = FormatNumber(usePercentageBytes, 2, TriState.True, TriState.True, TriState.True)
            frmViewReport.lblUsagePercentagePackets.Text = FormatNumber(usePercentagePackets, 2, TriState.True, TriState.True, TriState.True)
            dsSingleUserReport_ACCOUNTING.Tables.Clear()
            sqlConnection.Close()
            sqlConnection = Nothing
        Catch ex As Exception
            GF.ShowMsg(2, ERR011_btnGenerateReport_Click_GetAccData(0), ERR011_btnGenerateReport_Click_GetAccData(1) & vbCrLf & vbCrLf & ex.Message, ERR011_btnGenerateReport_Click_GetAccData(2), 1)
            sqlConnection.Close()
            sqlConnection = Nothing
        End Try
    End Sub

    Sub CreateChart1()
        Dim Chart1 As New System.Windows.Forms.DataVisualization.Charting.Chart()
        '
        ' Add Chart Area to the Chart
        Dim chartArea1 As New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Chart1.ChartAreas.Add(chartArea1)
        '
        ' Add series to the chart
        Dim series1 As New System.Windows.Forms.DataVisualization.Charting.Series()
        Chart1.Series.Add(series1)
        '
        ' Set chart control location & size
        Chart1.Location = New System.Drawing.Point(443, 439)
        Chart1.Size = New System.Drawing.Size(264, 233)
        '
        ' Set the chart data
        series1.Points.Add(totalUsage).Label = "Total BW (mb) [" & FormatNumber(totalUsage, 2, TriState.True, TriState.True, TriState.True) & "]"
        series1.Points(0).Color = Color.Blue
        series1.Points.Add(userUsageDL).Label = "User BW (mb) [" & FormatNumber(userUsageDL, 2, TriState.True, TriState.True, TriState.True) & "]"
        series1.Points(0).Color = Color.Red
        '
        ' Add chart control to the form
        frmViewReport.Controls.Add(Chart1)
    End Sub
End Class