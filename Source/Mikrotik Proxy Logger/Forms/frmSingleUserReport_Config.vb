Imports System
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization
Imports System.Windows.Forms.DataVisualization.Charting
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
        'checking if the checkbox to take all time data is checked, then we will override the date selection comparison
        If chkAllTimeData.Checked = True Then dateDifference = -1
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
                            If chkAllTimeData.Checked = True Then
                                'we will get all time data
                                sqlAdapter = New SqlDataAdapter("select * from mtpl_table1", sqlConnection)
                            Else
                                'we will get selected date data
                                sqlAdapter = New SqlDataAdapter("select * from mtpl_table1 where logdatetime between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
                            End If
                        Case Else
                            If chkAllTimeData.Checked = True Then
                                'we will get all time data
                                sqlAdapter = New SqlDataAdapter("select * from mtpl_table1 where logsource='" & reportTargetIP & "'", sqlConnection)
                            Else
                                'we will get selected date data
                                sqlAdapter = New SqlDataAdapter("select * from mtpl_table1 where logsource='" & reportTargetIP & "' and logdatetime between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
                            End If
                    End Select
                    sqlAdapter.Fill(dsSingleUserReport, "mtpl_table1")
                    '
                    ' assigning the dataset to the datagrid view in the report form
                    frmViewReport.dgReportMain.DataSource = dsSingleUserReport.Tables("mtpl_table1")
                    '
                    ' putting the ip and device name and date range in the report form
                    frmViewReport.lblDeviceIP.Text = reportTargetIP
                    frmViewReport.lblDeviceName.Text = reportTargetName
                    If chkAllTimeData.Checked = True Then
                        frmViewReport.lblFromDate.Text = "All time"
                        frmViewReport.lblToDate.Text = "All time"
                    Else
                        frmViewReport.lblFromDate.Text = fromDate
                        frmViewReport.lblToDate.Text = toDate
                    End If
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
                    '
                    ' coloring the grid rows
                    colorGridLines()
                    sqlConnection.Close()
                    sqlConnection = Nothing
                    Me.Dispose()
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

    Private Sub colorGridLines()
        Dim gridRows_Count As Integer
        gridRows_Count = frmViewReport.dgReportMain.Rows.Count
        If gridRows_Count > 0 Then
            For x As Integer = 0 To gridRows_Count - 1
                If frmViewReport.dgReportMain.Rows(x).Cells(7).Value = "deny" Then
                    frmViewReport.dgReportMain.Rows(x).DefaultCellStyle.ForeColor = Color.Red
                ElseIf frmViewReport.dgReportMain.Rows(x).Cells(7).Value = "allow" Then
                    frmViewReport.dgReportMain.Rows(x).DefaultCellStyle.ForeColor = Color.Green
                End If
            Next
        End If
        frmViewReport.dgReportMain.Refresh()
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
            If chkAllTimeData.Checked = True Then
                'we will get all time data
                sqlAdapter = New SqlDataAdapter("select sum(bytes_vol), sum(packets_count) from mtpl_accounting where dst_addr='" & targetIP & "'", sqlConnection)
            Else
                'we will get selected date data
                sqlAdapter = New SqlDataAdapter("select sum(bytes_vol), sum(packets_count) from mtpl_accounting where dst_addr='" & targetIP & "' and logdate between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
            End If
            sqlAdapter.Fill(dsSingleUserReport_ACCOUNTING, "mtpl_accounting")
            '
            ' putting the usage numbers in the report form
            userUsageDL = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(0), Double) / 1048576
            packetsCountDL = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(1), Integer)
            frmViewReport.lblBWUsage.Text = FormatNumber(userUsageDL, 2, TriState.True, TriState.True, TriState.True) & " mb"
            frmViewReport.lblPacketsCount.Text = FormatNumber(packetsCountDL, 2, TriState.True, TriState.True, TriState.True)
            dsSingleUserReport_ACCOUNTING.Tables.Clear()
            '
            ' selecting the data in the time ragne for the specific user we want (src_addr)
            If chkAllTimeData.Checked = True Then
                'we will get all time data
                sqlAdapter = New SqlDataAdapter("select sum(bytes_vol), sum(packets_count) from mtpl_accounting where src_addr='" & targetIP & "'", sqlConnection)
            Else
                'we will get selected date data
                sqlAdapter = New SqlDataAdapter("select sum(bytes_vol), sum(packets_count) from mtpl_accounting where src_addr='" & targetIP & "' and logdate between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
            End If
            sqlAdapter.Fill(dsSingleUserReport_ACCOUNTING, "mtpl_accounting")
            '
            ' putting the upload usage numbers in the report form
            userUsageUP = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(0), Double) / 1048576
            packetsCountUP = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(1), Integer)
            frmViewReport.lblUPDWUsage.Text = FormatNumber(userUsageUP, 2, TriState.True, TriState.True, TriState.True) & " mb"
            frmViewReport.lblUPBWPackets.Text = FormatNumber(packetsCountUP, 2, TriState.True, TriState.True, TriState.True)
            dsSingleUserReport_ACCOUNTING.Tables.Clear()
            '
            ' now selecting the usage statistics for all users in the time range
            If chkAllTimeData.Checked = True Then
                'we will get all time data
                sqlAdapter = New SqlDataAdapter("select sum(bytes_vol), sum(packets_count) from mtpl_accounting", sqlConnection)
            Else
                'we will get selected date data
                sqlAdapter = New SqlDataAdapter("select sum(bytes_vol), sum(packets_count) from mtpl_accounting where logdate between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
            End If
            dsSingleUserReport_ACCOUNTING.Tables.Clear()
            sqlAdapter.Fill(dsSingleUserReport_ACCOUNTING, "mtpl_accounting")
            '
            ' calculating the numbers and putting the remaining values in the report form
            totalUsage = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(0), Double) / 1048576.0
            totalPackets = CType(dsSingleUserReport_ACCOUNTING.Tables("mtpl_accounting").Rows(0).Item(1), Integer)
            usePercentageBytes = (userUsageDL / totalUsage) * 100
            usePercentagePackets = (packetsCountDL / totalPackets) * 100
            frmViewReport.lblTotalUsage.Text = FormatNumber(totalUsage, 2, TriState.True, TriState.True, TriState.True) & " mb"
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
        '
        ' bandwidth chart
        Dim BWChart As Chart = New Chart
        Dim BWChart_Area As ChartArea = New ChartArea
        Dim BWChart_Series As Series = New Series
        Dim BWChart_Series_Point1 As DataPoint = New DataPoint(Nothing, totalUsage)
        Dim BWChart_Series_Point2 As DataPoint = New DataPoint(Nothing, userUsageDL)
        Dim BWChart_Legend As Legend = New Legend
        Dim BWChart_Legend_ItemDP1 As LegendItem = New LegendItem
        Dim BWChart_Legend_ItemDP2 As LegendItem = New LegendItem
        Dim BWChart_Legend_ItemDP1_C1 As LegendCell = New LegendCell
        Dim BWChart_Legend_ItemDP1_C2 As LegendCell = New LegendCell
        Dim BWChart_Legend_ItemDP2_C1 As LegendCell = New LegendCell
        Dim BWChart_Legend_ItemDP2_C2 As LegendCell = New LegendCell
        '
        ' packets chart
        Dim PacketChart As Chart = New Chart
        Dim PacketChart_Area As ChartArea = New ChartArea
        Dim PacketChart_Series As Series = New Series
        Dim PacketChart_Series_Point1 As DataPoint = New DataPoint(Nothing, totalPackets)
        Dim PacketChart_Series_Point2 As DataPoint = New DataPoint(Nothing, packetsCountDL)
        Dim PacketChart_Legend As Legend = New Legend
        Dim PacketChart_Legend_ItemDP1 As LegendItem = New LegendItem
        Dim PacketChart_Legend_ItemDP2 As LegendItem = New LegendItem
        Dim PacketChart_Legend_ItemDP1_C1 As LegendCell = New LegendCell
        Dim PacketChart_Legend_ItemDP1_C2 As LegendCell = New LegendCell
        Dim PacketChart_Legend_ItemDP2_C1 As LegendCell = New LegendCell
        Dim PacketChart_Legend_ItemDP2_C2 As LegendCell = New LegendCell
        '
        ' starting with BWChart
        BWChart_Series_Point1.Name = "BWChart_TotalBW"
        BWChart_Series_Point1.IsValueShownAsLabel = True
        BWChart_Series_Point1.IsVisibleInLegend = False
        BWChart_Series_Point1.Label = "[" & FormatNumber(totalUsage, 2, TriState.True, TriState.True, TriState.True) & " mb]"
        BWChart_Series_Point1.LegendText = ""
        BWChart_Series_Point1.LegendToolTip = ""
        BWChart_Series_Point1.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        BWChart_Series_Point2.Name = "BWChart_UserBW"
        BWChart_Series_Point2.IsValueShownAsLabel = True
        BWChart_Series_Point2.IsVisibleInLegend = False
        BWChart_Series_Point2.Label = "[" & FormatNumber(userUsageDL, 2, TriState.True, TriState.True, TriState.True) & " mb]"
        BWChart_Series_Point2.LegendText = ""
        BWChart_Series_Point2.LegendToolTip = ""
        BWChart_Series_Point2.Color = System.Drawing.Color.Red
        '
        BWChart_Area.Name = "BWMain"
        '
        BWChart_Series.ChartArea = "BWMain"
        BWChart_Series.IsVisibleInLegend = False
        BWChart_Series.Legend = ""
        BWChart_Series.Name = "BWSeries"
        BWChart_Series.Points.Add(BWChart_Series_Point1)
        BWChart_Series.Points.Add(BWChart_Series_Point2)
        '
        BWChart_Legend_ItemDP1_C1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        BWChart_Legend_ItemDP1_C1.Name = "BWChart_TotalBW_Icon_Legend"
        '
        BWChart_Legend_ItemDP1_C2.BackColor = Color.White
        BWChart_Legend_ItemDP1_C2.Name = "BWChart_TotalBW_Title_Legend"
        BWChart_Legend_ItemDP1_C2.Text = "Total Bandwidth"
        '
        BWChart_Legend_ItemDP2_C1.BackColor = Color.Red
        BWChart_Legend_ItemDP2_C1.Name = "BWChart_UserBW_Icon_Legend"
        '
        BWChart_Legend_ItemDP2_C2.BackColor = Color.White
        BWChart_Legend_ItemDP2_C2.Name = "BWChart_UserBW_Title_Legend"
        BWChart_Legend_ItemDP2_C2.Text = "User Bandwidth"
        '
        BWChart_Legend_ItemDP1.Cells.Add(BWChart_Legend_ItemDP1_C1)
        BWChart_Legend_ItemDP1.Cells.Add(BWChart_Legend_ItemDP1_C2)
        '
        BWChart_Legend_ItemDP2.Cells.Add(BWChart_Legend_ItemDP2_C1)
        BWChart_Legend_ItemDP2.Cells.Add(BWChart_Legend_ItemDP2_C2)
        '
        BWChart_Legend.Name = "BWChart_Legend"
        BWChart_Legend.CustomItems.Add(BWChart_Legend_ItemDP1)
        BWChart_Legend.CustomItems.Add(BWChart_Legend_ItemDP2)
        BWChart_Legend.Alignment = System.Drawing.StringAlignment.Center
        BWChart_Legend.DockedToChartArea = "BWMain"
        BWChart_Legend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        BWChart_Legend.IsDockedInsideChartArea = False
        '
        BWChart.Name = "BWChart"
        BWChart.ChartAreas.Add(BWChart_Area)
        BWChart.Legends.Add(BWChart_Legend)
        BWChart.Series.Add(BWChart_Series)
        BWChart.Location = New Point(443, 439)
        BWChart.Size = New Size(264, 233)
        '
        ' now with PacketChart
        PacketChart_Series_Point1.Name = "PacketChart_TotalPACKET"
        PacketChart_Series_Point1.IsValueShownAsLabel = True
        PacketChart_Series_Point1.IsVisibleInLegend = False
        PacketChart_Series_Point1.Label = "[" & FormatNumber(totalPackets, 0, TriState.True, TriState.True, TriState.True) & "]"
        PacketChart_Series_Point1.LegendText = ""
        PacketChart_Series_Point1.LegendToolTip = ""
        PacketChart_Series_Point1.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        PacketChart_Series_Point2.Name = "PacketChart_UserBW"
        PacketChart_Series_Point2.IsValueShownAsLabel = True
        PacketChart_Series_Point2.IsVisibleInLegend = False
        PacketChart_Series_Point2.Label = "[" & FormatNumber(packetsCountDL, 0, TriState.True, TriState.True, TriState.True) & "]"
        PacketChart_Series_Point2.LegendText = ""
        PacketChart_Series_Point2.LegendToolTip = ""
        PacketChart_Series_Point2.Color = System.Drawing.Color.Red
        '
        PacketChart_Area.Name = "PacketsMain"
        '
        PacketChart_Series.ChartArea = "PacketsMain"
        PacketChart_Series.IsVisibleInLegend = False
        PacketChart_Series.Legend = ""
        PacketChart_Series.Name = "PacketsSeries"
        PacketChart_Series.Points.Add(PacketChart_Series_Point1)
        PacketChart_Series.Points.Add(PacketChart_Series_Point2)
        '
        PacketChart_Legend_ItemDP1_C1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        PacketChart_Legend_ItemDP1_C1.Name = "PacketChart_TotalBW_Icon_Legend"
        '
        PacketChart_Legend_ItemDP1_C2.BackColor = Color.White
        PacketChart_Legend_ItemDP1_C2.Name = "PacketChart_TotalBW_Title_Legend"
        PacketChart_Legend_ItemDP1_C2.Text = "All Pkts."
        '
        PacketChart_Legend_ItemDP2_C1.BackColor = Color.Red
        PacketChart_Legend_ItemDP2_C1.Name = "PacketChart_UserBW_Icon_Legend"
        '
        PacketChart_Legend_ItemDP2_C2.BackColor = Color.White
        PacketChart_Legend_ItemDP2_C2.Name = "PacketChart_UserBW_Title_Legend"
        PacketChart_Legend_ItemDP2_C2.Text = "User Pkts"
        '
        PacketChart_Legend_ItemDP1.Cells.Add(PacketChart_Legend_ItemDP1_C1)
        PacketChart_Legend_ItemDP1.Cells.Add(PacketChart_Legend_ItemDP1_C2)
        '
        PacketChart_Legend_ItemDP2.Cells.Add(PacketChart_Legend_ItemDP2_C1)
        PacketChart_Legend_ItemDP2.Cells.Add(PacketChart_Legend_ItemDP2_C2)
        '
        PacketChart_Legend.Name = "PacketChart_Legend"
        PacketChart_Legend.CustomItems.Add(PacketChart_Legend_ItemDP1)
        PacketChart_Legend.CustomItems.Add(PacketChart_Legend_ItemDP2)
        PacketChart_Legend.Alignment = System.Drawing.StringAlignment.Center
        PacketChart_Legend.DockedToChartArea = "PacketsMain"
        PacketChart_Legend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        PacketChart_Legend.IsDockedInsideChartArea = False
        '
        PacketChart.Name = "PacketsChart"
        PacketChart.ChartAreas.Add(PacketChart_Area)
        PacketChart.Legends.Add(PacketChart_Legend)
        PacketChart.Series.Add(PacketChart_Series)
        PacketChart.Location = New Point(240, 439)
        PacketChart.Size = New Size(200, 233)
        '
        ' Add chart control to the form
        frmViewReport.Controls.Add(BWChart)
        frmViewReport.Controls.Add(PacketChart)
    End Sub

    Private Sub chkAllTimeData_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllTimeData.CheckedChanged
        If chkAllTimeData.Checked = True Then
            dtFromDate.Enabled = False
            DtTillDate.Enabled = False
        Else
            dtFromDate.Enabled = True
            DtTillDate.Enabled = True
        End If
    End Sub
End Class