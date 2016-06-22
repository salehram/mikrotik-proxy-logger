<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOverAllReport
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkNoDate = New System.Windows.Forms.CheckBox()
        Me.chkShowDomains = New System.Windows.Forms.CheckBox()
        Me.chkShowProto = New System.Windows.Forms.CheckBox()
        Me.chkShowCharts = New System.Windows.Forms.CheckBox()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnExportCSV = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtTo)
        Me.GroupBox1.Controls.Add(Me.dtFrom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(291, 67)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Selection"
        '
        'dtTo
        '
        Me.dtTo.Location = New System.Drawing.Point(44, 37)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(241, 20)
        Me.dtTo.TabIndex = 3
        '
        'dtFrom
        '
        Me.dtFrom.Location = New System.Drawing.Point(44, 14)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(241, 20)
        Me.dtFrom.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkNoDate)
        Me.GroupBox2.Controls.Add(Me.chkShowDomains)
        Me.GroupBox2.Controls.Add(Me.chkShowProto)
        Me.GroupBox2.Controls.Add(Me.chkShowCharts)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(292, 69)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options"
        '
        'chkNoDate
        '
        Me.chkNoDate.AutoSize = True
        Me.chkNoDate.Location = New System.Drawing.Point(6, 42)
        Me.chkNoDate.Name = "chkNoDate"
        Me.chkNoDate.Size = New System.Drawing.Size(95, 17)
        Me.chkNoDate.TabIndex = 3
        Me.chkNoDate.Text = "No date range"
        Me.chkNoDate.UseVisualStyleBackColor = True
        '
        'chkShowDomains
        '
        Me.chkShowDomains.AutoSize = True
        Me.chkShowDomains.Location = New System.Drawing.Point(111, 42)
        Me.chkShowDomains.Name = "chkShowDomains"
        Me.chkShowDomains.Size = New System.Drawing.Size(172, 17)
        Me.chkShowDomains.TabIndex = 2
        Me.chkShowDomains.Text = "Show most requested domains"
        Me.chkShowDomains.UseVisualStyleBackColor = True
        '
        'chkShowProto
        '
        Me.chkShowProto.AutoSize = True
        Me.chkShowProto.Location = New System.Drawing.Point(111, 19)
        Me.chkShowProto.Name = "chkShowProto"
        Me.chkShowProto.Size = New System.Drawing.Size(151, 17)
        Me.chkShowProto.TabIndex = 1
        Me.chkShowProto.Text = "Show most used protocols"
        Me.chkShowProto.UseVisualStyleBackColor = True
        '
        'chkShowCharts
        '
        Me.chkShowCharts.AutoSize = True
        Me.chkShowCharts.Location = New System.Drawing.Point(6, 19)
        Me.chkShowCharts.Name = "chkShowCharts"
        Me.chkShowCharts.Size = New System.Drawing.Size(85, 17)
        Me.chkShowCharts.TabIndex = 0
        Me.chkShowCharts.Text = "Show charts"
        Me.chkShowCharts.UseVisualStyleBackColor = True
        '
        'btnViewReport
        '
        Me.btnViewReport.Location = New System.Drawing.Point(310, 13)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(189, 34)
        Me.btnViewReport.TabIndex = 2
        Me.btnViewReport.Text = "View report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(310, 121)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(189, 34)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnExportCSV
        '
        Me.btnExportCSV.Location = New System.Drawing.Point(310, 53)
        Me.btnExportCSV.Name = "btnExportCSV"
        Me.btnExportCSV.Size = New System.Drawing.Size(90, 34)
        Me.btnExportCSV.TabIndex = 4
        Me.btnExportCSV.Text = "Export to CSV"
        Me.btnExportCSV.UseVisualStyleBackColor = True
        Me.btnExportCSV.Visible = False
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Location = New System.Drawing.Point(406, 53)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(93, 34)
        Me.btnExportExcel.TabIndex = 5
        Me.btnExportExcel.Text = "Export to Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = True
        Me.btnExportExcel.Visible = False
        '
        'frmOverAllReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 167)
        Me.Controls.Add(Me.btnExportExcel)
        Me.Controls.Add(Me.btnExportCSV)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnViewReport)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmOverAllReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Over All Report Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowDomains As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowProto As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowCharts As System.Windows.Forms.CheckBox
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnExportCSV As System.Windows.Forms.Button
    Friend WithEvents btnExportExcel As System.Windows.Forms.Button
    Friend WithEvents chkNoDate As System.Windows.Forms.CheckBox
End Class
