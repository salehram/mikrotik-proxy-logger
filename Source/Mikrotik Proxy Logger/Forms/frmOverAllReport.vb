Imports System
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization
Imports System.Windows.Forms.DataVisualization.Charting
Imports Mikrotik_Proxy_Logger.Global_Functions
Imports Mikrotik_Proxy_Logger.SQLCalls

Public Class frmOverAllReport
    Dim GF As New Global_Functions
    Dim SQLCalls As New SQLCalls
    Dim ReportGridBuilder As New FullReportGridBuilder
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        Dim fromDate As DateTime
        Dim toDate As DateTime
        Dim dateDifference As Integer
        Dim DSInitStatus As Integer
        'start validating the from date and to date
        '
        'checking for "from" date variable
        If dtFrom.Value = Nothing Then
            '"from" date is not set,
            'assigning the defaultl date value (which is now) to the from date
            dtFrom.Value = DateTime.Now
            fromDate = dtFrom.Value
        Else
            '"from" date is set, we will use its value
            fromDate = dtFrom.Value
        End If
        'checking for "to" date variable
        If dtTo.Value = Nothing Then
            '"to" date is not set
            'assigning the default date value (which is now) to the "to" field
            dtTo.Value = DateTime.Now
            toDate = dtTo.Value
        Else
            '"to" date is set, we will use its value
            toDate = dtTo.Value
        End If
        '
        'validating the 2 dates
        dateDifference = DateTime.Compare(fromDate, toDate)
        '
        'checking if the no date check box is checked, if so, we will get all the date from the table
        If chkNoDate.Checked = True Then dateDifference = -1
        Select Case dateDifference
            Case Is < 0
                'from date is earlier than to date, which is the correct case we want
                'start pulling data from the database so we can store it in a dataset we will create now
                Dim CellID As String
                Dim CellIPAddr As String
                Dim CellDevName As String
                Dim CellDLUsage As Int64
                Dim CellPktDL As Int64
                Dim CellUPUsage As Int64
                Dim CellPktUp As Int64
                Dim CellPercent As Double
                Dim allUsageCount As Int64
                Dim userUsageCount As Int64
                Dim otherData As String()
                Dim percentCol As DataView
                '
                '
                '
                '       id
                '       ip address
                '       device name
                '       download usage
                '       packets download
                '       uploiad usage
                '       packets upload
                '       usage percentage
                '   
                '
                '
                'creating the dataset
                '   initializing the dataset
                DSInitStatus = GF.initDataset(0)
                If DSInitStatus <> 0 Then Exit Sub 'TODO: Add error message here
                '   read hosts table
                '   select data from accounting table based on the current record from hosts table
                '   put the retrieved data in the new dataset
                Dim connectionString As String = DB_ConnectionString
                Dim sqlConnection As New SqlConnection(connectionString)
                Dim sqlDBReader As SqlDataReader
                Dim sqlCMD As SqlCommand
                Try
                    sqlConnection.Open()
                    If chkNoDate.Checked = True Then 'here we will select the data from the table with no date/time range
                        sqlCMD = New SqlCommand("select * from mtpl_hosts", sqlConnection)
                        sqlDBReader = sqlCMD.ExecuteReader
                        If sqlDBReader.HasRows = True Then
                            Do While sqlDBReader.Read
                                'read the current row, and send a query to get the current ip accounting information from accounting table
                                With sqlDBReader
                                    CellID = .GetInt32(0)
                                    CellIPAddr = .GetString(1)
                                    CellDevName = .GetString(2)
                                    'getting upload data
                                    otherData = SQLCalls.ExecReader("mtpl_accounting", "select SUM(bytes_vol), SUM(packets_count) from mtpl_accounting where src_addr='" & CellIPAddr & "'")
                                    CellUPUsage = CType(otherData(0), Int64)
                                    CellPktUp = CType(otherData(1), Int64)
                                    'getting the download data
                                    otherData = SQLCalls.ExecReader("mtpl_accounting", "select SUM(bytes_vol), SUM(packets_count) from mtpl_accounting where dst_addr='" & CellIPAddr & "'")
                                    CellDLUsage = CType(otherData(0), Int64)
                                    CellPktDL = CType(otherData(1), Int64)
                                    'calculate the overall usage percentage
                                    'all usage count
                                    otherData = SQLCalls.ExecReader("mtpl_accounting", "select SUM(bytes_vol), SUM(packets_count) from mtpl_accounting")
                                    allUsageCount = CType(otherData(0), Int64)
                                    'user usage count
                                    otherData = SQLCalls.ExecReader("mtpl_accounting", "select SUM(bytes_vol), SUM(packets_count) from mtpl_accounting where src_addr='" & CellIPAddr & "' or dst_addr='" & CellIPAddr & "'")
                                    userUsageCount = CType(otherData(0), Int64)
                                    'calculating the percentage
                                    CellPercent = CType((userUsageCount / allUsageCount) * 100, Double)
                                End With
                                'adding the data to the dataset row
                                With GlobalDataset.Tables(AllUsersReport_Dataset_Table.TableName).Rows
                                    .Add(CellID, CellIPAddr, CellDevName, CellDLUsage, CellPktDL, CellUPUsage, CellPktUp, CellPercent)
                                End With
                            Loop
                        End If
                    Else 'here we will select the data from the table with the specified date/time range
                        sqlCMD = New SqlCommand("select * from mtpl_hosts", sqlConnection)
                        sqlDBReader = sqlCMD.ExecuteReader
                        If sqlDBReader.HasRows = True Then
                            Do While sqlDBReader.Read
                                'read the current row, and send a query to get the current ip accounting information from accounting table
                                With sqlDBReader
                                    CellID = .GetInt32(0)
                                    CellIPAddr = .GetString(1)
                                    CellDevName = .GetString(2)
                                    'getting upload data
                                    otherData = SQLCalls.ExecReader("mtpl_accounting", "select SUM(bytes_vol), SUM(packets_count) from mtpl_accounting where src_addr='" & CellIPAddr & "' and logDate between '" & fromDate & "' and '" & toDate & "'")
                                    CellUPUsage = CType(otherData(0), Int64)
                                    CellPktUp = CType(otherData(1), Int64)
                                    'getting the download data
                                    otherData = SQLCalls.ExecReader("mtpl_accounting", "select SUM(bytes_vol), SUM(packets_count) from mtpl_accounting where dst_addr='" & CellIPAddr & "' and logDate between '" & fromDate & "' and '" & toDate & "'")
                                    CellDLUsage = CType(otherData(0), Int64)
                                    CellPktDL = CType(otherData(1), Int64)
                                    'calculate the overall usage percentage
                                    'all usage count
                                    otherData = SQLCalls.ExecReader("mtpl_accounting", "select SUM(bytes_vol), SUM(packets_count) from mtpl_accounting where logDate between '" & fromDate & "' and '" & toDate & "'")
                                    allUsageCount = CType(otherData(0), Int64)
                                    'user usage count
                                    otherData = SQLCalls.ExecReader("mtpl_accounting", "select SUM(bytes_vol), SUM(packets_count) from mtpl_accounting where src_addr='" & CellIPAddr & "' or dst_addr='" & CellIPAddr & "' and logDate between '" & fromDate & "' and '" & toDate & "'")
                                    userUsageCount = CType(otherData(0), Int64)
                                    'calculating the percentage
                                    CellPercent = CType((userUsageCount / allUsageCount) * 100, Double)
                                End With
                                'adding the data to the dataset row
                                With GlobalDataset.Tables(AllUsersReport_Dataset_Table.TableName).Rows
                                    .Add(CellID, CellIPAddr, CellDevName, CellDLUsage, CellPktDL, CellUPUsage, CellPktUp, FormatNumber(CellPercent, 2, TriState.True, TriState.False, TriState.True))
                                End With
                            Loop
                        End If
                    End If
                    '
                    'building the datagrid view based on the data we provided
                    ReportGridBuilder.buildColumns(0)
                    '
                    'sorting the rows based on the percentage of usage
                    percentCol = GlobalDataset.Tables("allUsersReport_DSTab").DefaultView
                    percentCol.Sort = "allUsersReport_DSTab_DSCol_Percentage"
                    '
                    ' assigning the dataset to the datagrid view in the report form
                    frmReportResults.dgReportResult.DataSource = GlobalDataset.Tables(AllUsersReport_Dataset_Table.TableName)
                    '
                    'formating the grid with readable numbers:
                    ReportGridBuilder.FormatGridNumbers()
                    '
                    'making sure the id column is hidden
                    frmReportResults.dgReportResult.Columns(0).Visible = False
                    '
                    'building the overview report tab
                    buildOverViewReport(frmReportResults.dgReportResult.Rows.Count)
                    '
                    'showing the results form
                    frmReportResults.MdiParent = frmMain
                    frmReportResults.Show()
                    sqlConnection.Close()
                    sqlConnection = Nothing
                    Me.Dispose()
                Catch ex As Exception
                    GF.ShowMsg(2, ERR010_btnGenerateReport_Click_BuildDataset(0), ERR010_btnGenerateReport_Click_BuildDataset(1) & vbCrLf & vbCrLf & ex.Source & vbCrLf & vbCrLf & ex.Message, ERR010_btnGenerateReport_Click_BuildDataset(2), 1)
                    sqlConnection.Close()
                    sqlConnection = Nothing
                End Try
                '
                '
                '
                'end of dataset creation
            Case Else
                'from date is equal or later than to date, which is the wrong case,
                'we will display error message and abort report generation
                GF.ShowMsg(2, ERR012_btnViewReport_Click_frmOverAlLReports(0), ERR012_btnViewReport_Click_frmOverAlLReports(1), ERR012_btnViewReport_Click_frmOverAlLReports(2), 1)
                Exit Sub
        End Select
    End Sub

    Private Sub chkNoDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoDate.CheckedChanged
        If chkNoDate.Checked = True Then
            dtFrom.Enabled = False
            dtTo.Enabled = False
        Else
            dtFrom.Enabled = True
            dtTo.Enabled = True
        End If
    End Sub

    Private Sub buildOverViewReport(ByVal gridCount As Integer)
        'this will build the report in the overview tab
        'it will use data from existing report in user activity tab
        'and if it is required we will build new data
        '
        '
        ' the way to get top 5 results:
        ' loop on datagrid, read all percentage values
        ' register the first value in variable
        ' if we find a larger value we oevrwrite the old value
        ' if we finished the first loop with the largest value, we will register its ID so we ignore it in the second loop
        ' second loop we will do the same, but we will check the ID of each record to make sure we igonore the previous value
        ' when we end the second loop, we wil register the ID of the second largest value along with the first one so we ignore both values
        ' we do this for the remaining 3 loops
        Dim top5Users(4, 2) As Double 'a 3 dim array to store 2 values in each record: {0=>index of row of highest value, 1=>id of row of highest value, 2=>the highest value we found}
        Dim rowIDValue As Integer 'a variable to store the value of the ID cell in the row
        Dim rowPercentValue As Double 'a variable to get the percentage value to compare it with other values to get the highest value
        Dim rowIndex As Integer 'a variable to store the index of the row so we can add it to the grid later
        Dim loopsCount As Integer = 5 'a counter to control the loops we want to make on the grid rows
        Dim counter As Integer = 0 'a counter to be used in loops
        For loopsCount = 0 To 4 Step +1
            counter = 0 'resetting the counter for the new loop
            Do
                rowIndex = frmReportResults.dgReportResult.Rows(counter).Index
                rowIDValue = frmReportResults.dgReportResult.Rows(counter).Cells(0).Value
                rowPercentValue = frmReportResults.dgReportResult.Rows(counter).Cells(7).Value
                ' comparing the top5Users position that holds the percentage value with the row's value
                If top5Users(loopsCount, 2) < rowPercentValue Then
                    'here the row value is larger than what we have in the array
                    'now we will check if we have the ID of this row, if we find it we will ignore this row
                    If CType(top5Users(loopsCount, 1), Integer) = rowIDValue Then
                        'here we found the row ID, we will ignore this value as we already mapped it before
                        'do nothing
                    Else
                        'here we did not find the ID, so this is a new value, we will record it and keep going
                        top5Users(loopsCount, 0) = rowIndex
                        top5Users(loopsCount, 1) = rowIDValue
                        top5Users(loopsCount, 2) = rowPercentValue
                    End If
                End If
                counter = counter + 1
            Loop Until counter = gridCount - 1
        Next
    End Sub
End Class
