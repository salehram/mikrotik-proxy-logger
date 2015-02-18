<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSingleUserReport_Config
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSrcIPList = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DtTillDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbHostNameList = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnGenerateReport = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(186, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Source IP"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.Location = New System.Drawing.Point(18, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Either enter the source IP or name, directly, or choose it from the list"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbSrcIPList
        '
        Me.cbSrcIPList.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbSrcIPList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbSrcIPList.FormattingEnabled = True
        Me.cbSrcIPList.Items.AddRange(New Object() {"All", "----"})
        Me.cbSrcIPList.Location = New System.Drawing.Point(189, 30)
        Me.cbSrcIPList.Name = "cbSrcIPList"
        Me.cbSrcIPList.Size = New System.Drawing.Size(121, 21)
        Me.cbSrcIPList.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.DtTillDate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtFromDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(425, 76)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date/Time range"
        '
        'DtTillDate
        '
        Me.DtTillDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DtTillDate.Location = New System.Drawing.Point(43, 44)
        Me.DtTillDate.Name = "DtTillDate"
        Me.DtTillDate.Size = New System.Drawing.Size(200, 20)
        Me.DtTillDate.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "To"
        '
        'dtFromDate
        '
        Me.dtFromDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtFromDate.Location = New System.Drawing.Point(43, 19)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(200, 20)
        Me.dtFromDate.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "From"
        '
        'cbHostNameList
        '
        Me.cbHostNameList.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbHostNameList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbHostNameList.FormattingEnabled = True
        Me.cbHostNameList.Items.AddRange(New Object() {"All", "----"})
        Me.cbHostNameList.Location = New System.Drawing.Point(316, 30)
        Me.cbHostNameList.Name = "cbHostNameList"
        Me.cbHostNameList.Size = New System.Drawing.Size(121, 21)
        Me.cbHostNameList.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(313, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Device Name"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.Location = New System.Drawing.Point(12, 139)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Tag = ""
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGenerateReport.Location = New System.Drawing.Point(93, 139)
        Me.btnGenerateReport.Name = "btnGenerateReport"
        Me.btnGenerateReport.Size = New System.Drawing.Size(344, 23)
        Me.btnGenerateReport.TabIndex = 7
        Me.btnGenerateReport.Text = "Generate Report"
        Me.btnGenerateReport.UseVisualStyleBackColor = True
        '
        'frmSingleUserReport_Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 170)
        Me.Controls.Add(Me.btnGenerateReport)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbHostNameList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbSrcIPList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSingleUserReport_Config"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Single user report configuration"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSrcIPList As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbHostNameList As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnGenerateReport As System.Windows.Forms.Button
    Friend WithEvents DtTillDate As System.Windows.Forms.DateTimePicker
End Class
