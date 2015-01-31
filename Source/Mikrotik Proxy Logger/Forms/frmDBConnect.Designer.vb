<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBConnect
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
        Me.lbServerList = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInstanceName = New System.Windows.Forms.TextBox()
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.txtDBUserName = New System.Windows.Forms.TextBox()
        Me.txtDBPassword = New System.Windows.Forms.TextBox()
        Me.btnSaveClose = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBuildDB = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbServerList)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(165, 175)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SQL Server"
        '
        'lbServerList
        '
        Me.lbServerList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbServerList.FormattingEnabled = True
        Me.lbServerList.Location = New System.Drawing.Point(6, 19)
        Me.lbServerList.Name = "lbServerList"
        Me.lbServerList.Size = New System.Drawing.Size(153, 147)
        Me.lbServerList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(184, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SQL Instance name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Database Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(226, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "User name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(231, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Password:"
        '
        'txtInstanceName
        '
        Me.txtInstanceName.Location = New System.Drawing.Point(294, 42)
        Me.txtInstanceName.Name = "txtInstanceName"
        Me.txtInstanceName.Size = New System.Drawing.Size(155, 20)
        Me.txtInstanceName.TabIndex = 5
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(294, 68)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(155, 20)
        Me.txtDBName.TabIndex = 6
        '
        'txtDBUserName
        '
        Me.txtDBUserName.Location = New System.Drawing.Point(294, 94)
        Me.txtDBUserName.Name = "txtDBUserName"
        Me.txtDBUserName.Size = New System.Drawing.Size(155, 20)
        Me.txtDBUserName.TabIndex = 7
        '
        'txtDBPassword
        '
        Me.txtDBPassword.Location = New System.Drawing.Point(294, 120)
        Me.txtDBPassword.Name = "txtDBPassword"
        Me.txtDBPassword.Size = New System.Drawing.Size(155, 20)
        Me.txtDBPassword.TabIndex = 8
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Location = New System.Drawing.Point(356, 161)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(94, 27)
        Me.btnSaveClose.TabIndex = 9
        Me.btnSaveClose.Text = "Save and Close"
        Me.btnSaveClose.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(184, 161)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 27)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnBuildDB
        '
        Me.btnBuildDB.Location = New System.Drawing.Point(259, 161)
        Me.btnBuildDB.Name = "btnBuildDB"
        Me.btnBuildDB.Size = New System.Drawing.Size(91, 27)
        Me.btnBuildDB.TabIndex = 11
        Me.btnBuildDB.Text = "Build Tables"
        Me.btnBuildDB.UseVisualStyleBackColor = True
        '
        'frmDBConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 199)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnBuildDB)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSaveClose)
        Me.Controls.Add(Me.txtDBPassword)
        Me.Controls.Add(Me.txtDBUserName)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.txtInstanceName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmDBConnect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configure Database Connection"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbServerList As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInstanceName As System.Windows.Forms.TextBox
    Friend WithEvents txtDBName As System.Windows.Forms.TextBox
    Friend WithEvents txtDBUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtDBPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveClose As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnBuildDB As System.Windows.Forms.Button
End Class
