Imports System
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization
Imports System.Windows.Forms.DataVisualization.Charting
Imports Mikrotik_Proxy_Logger.Global_Functions

Public Class frmOverAllReport
    Dim GF As New Global_Functions
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        Dim fromDate As DateTime
        Dim toDate As DateTime
        Dim dateDifference As Integer
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
            toDate = dtFrom.Value
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
                    If chkNoDate.Checked = True Then 'here we will select the data from the table with no date/time range
                        sqlAdapter = New SqlDataAdapter("select * from mtpl_table1", sqlConnection)
                    Else 'here we will select the data from the table with the specified date/time range
                        sqlAdapter = New SqlDataAdapter("select * from mtpl_table1 where logdatetime between '" & fromDate & "' and '" & toDate & "'", sqlConnection)
                    End If
                    sqlAdapter.Fill(dsSingleUserReport, "mtpl_table1")
                    '
                    ' assigning the dataset to the datagrid view in the report form

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
End Class
