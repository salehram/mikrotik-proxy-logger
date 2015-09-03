'' this class is to fully build and design the full report grid
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sql
Imports System.Windows
Imports System.Windows.Forms
Imports System.Windows.Forms.DataGridView
Imports Mikrotik_Proxy_Logger.Global_Functions

Public Class FullReportGridBuilder
    Dim GF As New Global_Functions

    ''' <summary>
    ''' Create the columns of the grid
    ''' </summary>
    ''' <param name="reportType">The type of the report: 0=all users report,</param>
    ''' <remarks></remarks>
    Public Sub buildColumns(ByVal reportType As Integer)
        Select Case reportType
            Case 0  'all users report
                'all users report columns
                '   id
                '   ip address
                '   device name
                '   download usage
                '   packets download
                '   uploiad usage
                '   packets upload
                '   usage percentage
                '
                'defining the required columns
                Dim dgReportCol_ID As New DataGridViewTextBoxColumn 'id
                Dim dgReportCol_IPAddr As New DataGridViewTextBoxColumn 'ip address
                Dim dgReportCol_DevName As New DataGridViewTextBoxColumn 'device name
                Dim dgReportCol_DLUsage As New DataGridViewTextBoxColumn 'download stats.
                Dim dgReportCol_PktDL As New DataGridViewTextBoxColumn 'dwnloaded packets count
                Dim dgReportCol_UPUsage As New DataGridViewTextBoxColumn 'upload stats.
                Dim dgReportCol_PktUP As New DataGridViewTextBoxColumn 'uploaded packets count
                Dim dgReportCol_Percentage As New DataGridViewTextBoxColumn 'full usage percentage
                '
                'setting data property name for the columns:
                dgReportCol_ID.DataPropertyName = "allUsersReport_DSTab_DSCol_ID"
                dgReportCol_IPAddr.DataPropertyName = "allUsersReport_DSTab_DSCol_IPAddr"
                dgReportCol_DevName.DataPropertyName = "allUsersReport_DSTab_DSCol_DevName"
                dgReportCol_DLUsage.DataPropertyName = "allUsersReport_DSTab_DSCol_DLUsage"
                dgReportCol_PktDL.DataPropertyName = "allUsersReport_DSTab_DSCol_PktDL"
                dgReportCol_UPUsage.DataPropertyName = "allUsersReport_DSTab_DSCol_UPUsage"
                dgReportCol_PktUP.DataPropertyName = "allUsersReport_DSTab_DSCol_PktUP"
                dgReportCol_Percentage.DataPropertyName = "allUsersReport_DSTab_DSCol_Percentage"
                '
                'setting the properties of the columns
                'id column
                With dgReportCol_ID
                    .Name = "Col_ID"
                    .HeaderText = "ID"
                    .Visible = False
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                '
                'ip address column
                With dgReportCol_IPAddr
                    .Name = "Col_IPAddr"
                    .HeaderText = "IP Address"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                '
                'device name column
                With dgReportCol_DevName
                    .Name = "Col_DevName"
                    .HeaderText = "Device Name"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .Width = 150
                End With
                '
                'download stats. column
                With dgReportCol_DLUsage
                    .Name = "Col_DLUsage"
                    .HeaderText = "Download Usage(mb)"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                '
                'downloaded packets count column
                With dgReportCol_PktDL
                    .Name = "Col_PktDL"
                    .HeaderText = "Received Packets"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                '
                'upload stats. column
                With dgReportCol_UPUsage
                    .Name = "Col_UPUsage"
                    .HeaderText = "Upload Usage(mb)"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                '
                'uploaded packets count column
                With dgReportCol_PktUP
                    .Name = "Col_PktUP"
                    .HeaderText = "Sent Packets"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                '
                'usage percentage column
                With dgReportCol_Percentage
                    .Name = "Col_Percentage"
                    .HeaderText = "Total %"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                '
                'adding the columns to the grid
                With frmReportResults.dgReportResult.Columns
                    .Add(dgReportCol_ID)
                    .Add(dgReportCol_IPAddr)
                    .Add(dgReportCol_DevName)
                    .Add(dgReportCol_DLUsage)
                    .Add(dgReportCol_PktDL)
                    .Add(dgReportCol_UPUsage)
                    .Add(dgReportCol_PktUP)
                    .Add(dgReportCol_Percentage)
                End With
                '
                'setting general display properties for the grid
                With frmReportResults.dgReportResult
                    .RowHeadersVisible = False 'removing the header cell of each row
                    .AllowUserToAddRows = False 'disabling row adding
                    .AllowUserToResizeColumns = True 'enable columns resize
                    .AllowUserToResizeRows = False 'disable row resize
                    .AllowUserToDeleteRows = False 'disable row delete
                    .AllowUserToOrderColumns = False 'disable column reordering
                    .ReadOnly = True 'disable cells edit
                End With
        End Select
    End Sub

    ''' <summary>
    ''' Sub procedure to read and format the cells of the grid and make the numbers in a better readable format
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FormatGridNumbers()
        Dim DLUsageMB As Double
        Dim PktDL As Int64
        Dim UPUsageMB As Double
        Dim PktUP As Int64
        Dim Percentage As Double
        Dim gridRowCount As Integer
        Dim rowIndex As Integer = 0
        gridRowCount = frmReportResults.dgReportResult.Rows.Count
        If gridRowCount < 1 Then
            Exit Sub
        Else
            Do
                'bytes to mbs = x / 1048576
                With frmReportResults.dgReportResult
                    DLUsageMB = CType(.Item(3, rowIndex).Value / 1048576, Double)
                    PktDL = CType(.Item(4, rowIndex).Value, Int64)
                    UPUsageMB = CType(.Item(5, rowIndex).Value / 1048576, Double)
                    PktUP = CType(.Item(6, rowIndex).Value, Int64)
                    Percentage = CType(.Item(7, rowIndex).Value, Double)
                    .Item(3, rowIndex).Value = FormatNumber(DLUsageMB, 2, TriState.True, TriState.True, TriState.True)
                    .Item(4, rowIndex).Value = FormatNumber(PktDL, 0, TriState.True, TriState.True, TriState.True)
                    .Item(5, rowIndex).Value = FormatNumber(UPUsageMB, 2, TriState.True, TriState.True, TriState.True)
                    .Item(6, rowIndex).Value = FormatNumber(PktUP, 0, TriState.True, TriState.True, TriState.True)
                    .Item(7, rowIndex).Value = FormatNumber(Percentage, 2, TriState.True, TriState.True, TriState.True)
                End With
                rowIndex = rowIndex + 1
            Loop Until rowIndex >= gridRowCount
        End If
    End Sub
End Class
