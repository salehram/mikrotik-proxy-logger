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
                Dim dgReportCol_ID As New DataGridViewColumn 'id
                Dim dgReportCol_IPAddr As New DataGridViewColumn 'ip address
                Dim dgReportCol_DevName As New DataGridViewColumn 'device name
                Dim dgReportCol_DLUsage As New DataGridViewColumn 'download stats.
                Dim dgReportCol_PktDL As New DataGridViewColumn 'dwnloaded packets count
                Dim dgReportCol_UPUsage As New DataGridViewColumn 'upload stats.
                Dim dgReportCol_PktUP As New DataGridViewColumn 'uploaded packets count
                Dim dgReportCol_Percentage As New DataGridViewColumn 'full usage percentage
                '
                'setting the properties of the columns
                'id column
                With dgReportCol_ID
                    .Name = "Col_ID"
                    .HeaderText = "ID"
                    .Visible = False
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                '
                'ip address column
                With dgReportCol_IPAddr
                    .Name = "Col_IPAddr"
                    .HeaderText = "IP Address"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                '
                'device name column
                With dgReportCol_DevName
                    .Name = "Col_DevName"
                    .HeaderText = "Device Name"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                '
                'download stats. column
                With dgReportCol_DLUsage
                    .Name = "Col_DLUsage"
                    .HeaderText = "Download Usage"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                '
                'downloaded packets count column
                With dgReportCol_PktDL
                    .Name = "Col_PktDL"
                    .HeaderText = "Received Packets"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                '
                'upload stats. column
                With dgReportCol_UPUsage
                    .Name = "Col_UPUsage"
                    .HeaderText = "Upload Usage"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                '
                'uploaded packets count column
                With dgReportCol_PktUP
                    .Name = "Col_PktUP"
                    .HeaderText = "Sent Packets"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                '
                'usage percentage column
                With dgReportCol_Percentage
                    .Name = "Col_Percentage"
                    .HeaderText = "Total %"
                    .Visible = True
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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

        End Select

    End Sub
End Class
