<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewReport))
        Me.dgReportMain = New System.Windows.Forms.DataGridView()
        Me.dg_col_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_col_logdatetime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_col_logheader = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_col_logsource = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_col_logmethod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_col_logportno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_col_logurl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_col_logaction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_col_reqcached = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_col_flag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDeviceIP = New System.Windows.Forms.Label()
        Me.lblDeviceName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblBWUsage = New System.Windows.Forms.Label()
        Me.lblTotalUsage = New System.Windows.Forms.Label()
        Me.lblUsagePercentageBytes = New System.Windows.Forms.Label()
        Me.lblPacketsCount = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTotalPackets = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblUsagePercentagePackets = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblUPBWPackets = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblUPDWUsage = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        CType(Me.dgReportMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgReportMain
        '
        Me.dgReportMain.AllowUserToAddRows = False
        Me.dgReportMain.AllowUserToDeleteRows = False
        Me.dgReportMain.AllowUserToResizeRows = False
        Me.dgReportMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReportMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dg_col_id, Me.dg_col_logdatetime, Me.dg_col_logheader, Me.dg_col_logsource, Me.dg_col_logmethod, Me.dg_col_logportno, Me.dg_col_logurl, Me.dg_col_logaction, Me.dg_col_reqcached, Me.dg_col_flag})
        Me.dgReportMain.Location = New System.Drawing.Point(12, 75)
        Me.dgReportMain.Name = "dgReportMain"
        Me.dgReportMain.ReadOnly = True
        Me.dgReportMain.RowHeadersVisible = False
        Me.dgReportMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgReportMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgReportMain.Size = New System.Drawing.Size(695, 358)
        Me.dgReportMain.TabIndex = 0
        '
        'dg_col_id
        '
        Me.dg_col_id.DataPropertyName = "id"
        Me.dg_col_id.HeaderText = "id"
        Me.dg_col_id.Name = "dg_col_id"
        Me.dg_col_id.ReadOnly = True
        Me.dg_col_id.Visible = False
        '
        'dg_col_logdatetime
        '
        Me.dg_col_logdatetime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dg_col_logdatetime.DataPropertyName = "logdatetime"
        Me.dg_col_logdatetime.HeaderText = "Date/Time"
        Me.dg_col_logdatetime.Name = "dg_col_logdatetime"
        Me.dg_col_logdatetime.ReadOnly = True
        Me.dg_col_logdatetime.Width = 81
        '
        'dg_col_logheader
        '
        Me.dg_col_logheader.DataPropertyName = "logheader"
        Me.dg_col_logheader.HeaderText = "logheader"
        Me.dg_col_logheader.Name = "dg_col_logheader"
        Me.dg_col_logheader.ReadOnly = True
        Me.dg_col_logheader.Visible = False
        '
        'dg_col_logsource
        '
        Me.dg_col_logsource.DataPropertyName = "logsource"
        Me.dg_col_logsource.HeaderText = "logsource"
        Me.dg_col_logsource.Name = "dg_col_logsource"
        Me.dg_col_logsource.ReadOnly = True
        Me.dg_col_logsource.Visible = False
        '
        'dg_col_logmethod
        '
        Me.dg_col_logmethod.DataPropertyName = "logmethod"
        Me.dg_col_logmethod.HeaderText = "logmethod"
        Me.dg_col_logmethod.Name = "dg_col_logmethod"
        Me.dg_col_logmethod.ReadOnly = True
        Me.dg_col_logmethod.Visible = False
        '
        'dg_col_logportno
        '
        Me.dg_col_logportno.DataPropertyName = "logportno"
        Me.dg_col_logportno.HeaderText = "logportno"
        Me.dg_col_logportno.Name = "dg_col_logportno"
        Me.dg_col_logportno.ReadOnly = True
        Me.dg_col_logportno.Visible = False
        '
        'dg_col_logurl
        '
        Me.dg_col_logurl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dg_col_logurl.DataPropertyName = "logurl"
        Me.dg_col_logurl.HeaderText = "Requested URL"
        Me.dg_col_logurl.Name = "dg_col_logurl"
        Me.dg_col_logurl.ReadOnly = True
        '
        'dg_col_logaction
        '
        Me.dg_col_logaction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dg_col_logaction.DataPropertyName = "logaction"
        Me.dg_col_logaction.HeaderText = "Action"
        Me.dg_col_logaction.Name = "dg_col_logaction"
        Me.dg_col_logaction.ReadOnly = True
        Me.dg_col_logaction.Width = 62
        '
        'dg_col_reqcached
        '
        Me.dg_col_reqcached.DataPropertyName = "reqcached"
        Me.dg_col_reqcached.HeaderText = "reqcached"
        Me.dg_col_reqcached.Name = "dg_col_reqcached"
        Me.dg_col_reqcached.ReadOnly = True
        Me.dg_col_reqcached.Visible = False
        '
        'dg_col_flag
        '
        Me.dg_col_flag.DataPropertyName = "flag"
        Me.dg_col_flag.HeaderText = "flag"
        Me.dg_col_flag.Name = "dg_col_flag"
        Me.dg_col_flag.ReadOnly = True
        Me.dg_col_flag.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Viewing report for:"
        '
        'lblDeviceIP
        '
        Me.lblDeviceIP.AutoSize = True
        Me.lblDeviceIP.Location = New System.Drawing.Point(116, 13)
        Me.lblDeviceIP.Name = "lblDeviceIP"
        Me.lblDeviceIP.Size = New System.Drawing.Size(59, 13)
        Me.lblDeviceIP.TabIndex = 2
        Me.lblDeviceIP.Text = "lblDeviceIP"
        '
        'lblDeviceName
        '
        Me.lblDeviceName.AutoSize = True
        Me.lblDeviceName.Location = New System.Drawing.Point(116, 26)
        Me.lblDeviceName.Name = "lblDeviceName"
        Me.lblDeviceName.Size = New System.Drawing.Size(76, 13)
        Me.lblDeviceName.TabIndex = 3
        Me.lblDeviceName.Text = "lblDeviceName"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(245, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Between dates from"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(330, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "To"
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.Location = New System.Drawing.Point(355, 13)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(64, 13)
        Me.lblFromDate.TabIndex = 6
        Me.lblFromDate.Text = "lblFromDate"
        '
        'lblToDate
        '
        Me.lblToDate.AutoSize = True
        Me.lblToDate.Location = New System.Drawing.Point(355, 26)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(52, 13)
        Me.lblToDate.TabIndex = 7
        Me.lblToDate.Text = "lblToDate"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(11, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(247, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "All the requests made by the user"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(12, 439)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Bandwidth usage info"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btnPrint.Location = New System.Drawing.Point(567, 13)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(140, 26)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btnExport.Location = New System.Drawing.Point(567, 43)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(140, 26)
        Me.btnExport.TabIndex = 11
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 469)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "User download usage"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 541)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Total download usage"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 573)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Bandwidth usage %"
        '
        'lblBWUsage
        '
        Me.lblBWUsage.AutoSize = True
        Me.lblBWUsage.Location = New System.Drawing.Point(150, 469)
        Me.lblBWUsage.Name = "lblBWUsage"
        Me.lblBWUsage.Size = New System.Drawing.Size(63, 13)
        Me.lblBWUsage.TabIndex = 16
        Me.lblBWUsage.Text = "lblBWUsage"
        '
        'lblTotalUsage
        '
        Me.lblTotalUsage.AutoSize = True
        Me.lblTotalUsage.Location = New System.Drawing.Point(150, 541)
        Me.lblTotalUsage.Name = "lblTotalUsage"
        Me.lblTotalUsage.Size = New System.Drawing.Size(71, 13)
        Me.lblTotalUsage.TabIndex = 17
        Me.lblTotalUsage.Text = "lblTotalUsage"
        '
        'lblUsagePercentageBytes
        '
        Me.lblUsagePercentageBytes.AutoSize = True
        Me.lblUsagePercentageBytes.Location = New System.Drawing.Point(150, 573)
        Me.lblUsagePercentageBytes.Name = "lblUsagePercentageBytes"
        Me.lblUsagePercentageBytes.Size = New System.Drawing.Size(129, 13)
        Me.lblUsagePercentageBytes.TabIndex = 18
        Me.lblUsagePercentageBytes.Text = "lblUsagePercentageBytes"
        '
        'lblPacketsCount
        '
        Me.lblPacketsCount.AutoSize = True
        Me.lblPacketsCount.Location = New System.Drawing.Point(150, 482)
        Me.lblPacketsCount.Name = "lblPacketsCount"
        Me.lblPacketsCount.Size = New System.Drawing.Size(83, 13)
        Me.lblPacketsCount.TabIndex = 20
        Me.lblPacketsCount.Text = "lblPacketsCount"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 482)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Packets requested by user"
        '
        'lblTotalPackets
        '
        Me.lblTotalPackets.AutoSize = True
        Me.lblTotalPackets.Location = New System.Drawing.Point(150, 554)
        Me.lblTotalPackets.Name = "lblTotalPackets"
        Me.lblTotalPackets.Size = New System.Drawing.Size(78, 13)
        Me.lblTotalPackets.TabIndex = 22
        Me.lblTotalPackets.Text = "lblTotalPackets"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(43, 554)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Total packets count"
        '
        'lblUsagePercentagePackets
        '
        Me.lblUsagePercentagePackets.AutoSize = True
        Me.lblUsagePercentagePackets.Location = New System.Drawing.Point(150, 586)
        Me.lblUsagePercentagePackets.Name = "lblUsagePercentagePackets"
        Me.lblUsagePercentagePackets.Size = New System.Drawing.Size(139, 13)
        Me.lblUsagePercentagePackets.TabIndex = 24
        Me.lblUsagePercentagePackets.Text = "lblUsagePercentagePackets"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(34, 586)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Packets requested %"
        '
        'lblUPBWPackets
        '
        Me.lblUPBWPackets.AutoSize = True
        Me.lblUPBWPackets.Location = New System.Drawing.Point(150, 517)
        Me.lblUPBWPackets.Name = "lblUPBWPackets"
        Me.lblUPBWPackets.Size = New System.Drawing.Size(83, 13)
        Me.lblUPBWPackets.TabIndex = 28
        Me.lblUPBWPackets.Text = "lblUPBWPackets"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(37, 517)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Packets sent by user"
        '
        'lblUPDWUsage
        '
        Me.lblUPDWUsage.AutoSize = True
        Me.lblUPDWUsage.Location = New System.Drawing.Point(150, 504)
        Me.lblUPDWUsage.Name = "lblUPDWUsage"
        Me.lblUPDWUsage.Size = New System.Drawing.Size(77, 13)
        Me.lblUPDWUsage.TabIndex = 26
        Me.lblUPDWUsage.Text = "lblUPDWUsage"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(48, 504)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "User upload usage"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'frmViewReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 684)
        Me.Controls.Add(Me.lblUPBWPackets)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblUPDWUsage)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblUsagePercentagePackets)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblTotalPackets)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblPacketsCount)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblUsagePercentageBytes)
        Me.Controls.Add(Me.lblTotalUsage)
        Me.Controls.Add(Me.lblBWUsage)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblToDate)
        Me.Controls.Add(Me.lblFromDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblDeviceName)
        Me.Controls.Add(Me.lblDeviceIP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgReportMain)
        Me.Name = "frmViewReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report result form"
        CType(Me.dgReportMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgReportMain As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDeviceIP As System.Windows.Forms.Label
    Friend WithEvents lblDeviceName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents lblToDate As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblBWUsage As System.Windows.Forms.Label
    Friend WithEvents lblTotalUsage As System.Windows.Forms.Label
    Friend WithEvents lblUsagePercentageBytes As System.Windows.Forms.Label
    Friend WithEvents lblPacketsCount As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPackets As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblUsagePercentagePackets As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblUPBWPackets As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblUPDWUsage As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dg_col_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg_col_logdatetime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg_col_logheader As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg_col_logsource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg_col_logmethod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg_col_logportno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg_col_logurl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg_col_logaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg_col_reqcached As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg_col_flag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
End Class
