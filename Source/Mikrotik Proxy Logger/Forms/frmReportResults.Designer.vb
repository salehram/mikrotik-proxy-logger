<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportResults
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpOverview = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnExportXLS = New System.Windows.Forms.Button()
        Me.btnExportText = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tpActivity = New System.Windows.Forms.TabPage()
        Me.dgReportResult = New System.Windows.Forms.DataGridView()
        Me.tpActivityDetail = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.tpOverview.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tpActivity.SuspendLayout()
        CType(Me.dgReportResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpOverview)
        Me.TabControl1.Controls.Add(Me.tpActivity)
        Me.TabControl1.Controls.Add(Me.tpActivityDetail)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(773, 614)
        Me.TabControl1.TabIndex = 7
        '
        'tpOverview
        '
        Me.tpOverview.Controls.Add(Me.Label3)
        Me.tpOverview.Controls.Add(Me.btnClose)
        Me.tpOverview.Controls.Add(Me.btnPrint)
        Me.tpOverview.Controls.Add(Me.btnExportXLS)
        Me.tpOverview.Controls.Add(Me.btnExportText)
        Me.tpOverview.Controls.Add(Me.Panel1)
        Me.tpOverview.Controls.Add(Me.Panel2)
        Me.tpOverview.Location = New System.Drawing.Point(4, 22)
        Me.tpOverview.Name = "tpOverview"
        Me.tpOverview.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOverview.Size = New System.Drawing.Size(765, 588)
        Me.tpOverview.TabIndex = 0
        Me.tpOverview.Text = "Overview"
        Me.tpOverview.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Top 5 Users"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(643, 538)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(116, 44)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(510, 538)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(116, 44)
        Me.btnPrint.TabIndex = 12
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnExportXLS
        '
        Me.btnExportXLS.Location = New System.Drawing.Point(388, 488)
        Me.btnExportXLS.Name = "btnExportXLS"
        Me.btnExportXLS.Size = New System.Drawing.Size(116, 44)
        Me.btnExportXLS.TabIndex = 11
        Me.btnExportXLS.Text = "Export to Excel"
        Me.btnExportXLS.UseVisualStyleBackColor = True
        '
        'btnExportText
        '
        Me.btnExportText.Location = New System.Drawing.Point(388, 538)
        Me.btnExportText.Name = "btnExportText"
        Me.btnExportText.Size = New System.Drawing.Size(116, 44)
        Me.btnExportText.TabIndex = 10
        Me.btnExportText.Text = "Export to Text"
        Me.btnExportText.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(388, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 258)
        Me.Panel1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(246, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Delete this panel, this place holder for top 5 users"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(388, 270)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(368, 211)
        Me.Panel2.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(329, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Delete this panel, this is a place holder for selected user mini report"
        '
        'tpActivity
        '
        Me.tpActivity.Controls.Add(Me.dgReportResult)
        Me.tpActivity.Location = New System.Drawing.Point(4, 22)
        Me.tpActivity.Name = "tpActivity"
        Me.tpActivity.Padding = New System.Windows.Forms.Padding(3)
        Me.tpActivity.Size = New System.Drawing.Size(765, 588)
        Me.tpActivity.TabIndex = 1
        Me.tpActivity.Text = "Users Activity"
        Me.tpActivity.UseVisualStyleBackColor = True
        '
        'dgReportResult
        '
        Me.dgReportResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReportResult.Location = New System.Drawing.Point(6, 6)
        Me.dgReportResult.Name = "dgReportResult"
        Me.dgReportResult.Size = New System.Drawing.Size(386, 576)
        Me.dgReportResult.TabIndex = 8
        '
        'tpActivityDetail
        '
        Me.tpActivityDetail.Location = New System.Drawing.Point(4, 22)
        Me.tpActivityDetail.Name = "tpActivityDetail"
        Me.tpActivityDetail.Padding = New System.Windows.Forms.Padding(3)
        Me.tpActivityDetail.Size = New System.Drawing.Size(765, 588)
        Me.tpActivityDetail.TabIndex = 2
        Me.tpActivityDetail.Text = "Activities Detail"
        Me.tpActivityDetail.UseVisualStyleBackColor = True
        '
        'frmReportResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 638)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmReportResults"
        Me.Text = "Report results"
        Me.TabControl1.ResumeLayout(False)
        Me.tpOverview.ResumeLayout(False)
        Me.tpOverview.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tpActivity.ResumeLayout(False)
        CType(Me.dgReportResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpOverview As System.Windows.Forms.TabPage
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExportXLS As System.Windows.Forms.Button
    Friend WithEvents btnExportText As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tpActivity As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgReportResult As System.Windows.Forms.DataGridView
    Friend WithEvents tpActivityDetail As System.Windows.Forms.TabPage
End Class
