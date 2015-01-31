<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResolveHosts
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
        Me.dgHostsGrid = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHostIPAddr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHostName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAutoResolve = New System.Windows.Forms.Button()
        CType(Me.dgHostsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgHostsGrid
        '
        Me.dgHostsGrid.AllowUserToAddRows = False
        Me.dgHostsGrid.AllowUserToDeleteRows = False
        Me.dgHostsGrid.AllowUserToResizeColumns = False
        Me.dgHostsGrid.AllowUserToResizeRows = False
        Me.dgHostsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHostsGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colHostIPAddr, Me.colHostName, Me.colFlag})
        Me.dgHostsGrid.Location = New System.Drawing.Point(13, 13)
        Me.dgHostsGrid.Name = "dgHostsGrid"
        Me.dgHostsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgHostsGrid.Size = New System.Drawing.Size(357, 285)
        Me.dgHostsGrid.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(13, 304)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 41)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(266, 304)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(104, 41)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'colID
        '
        Me.colID.DataPropertyName = "id"
        Me.colID.HeaderText = "id"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colID.Visible = False
        '
        'colHostIPAddr
        '
        Me.colHostIPAddr.DataPropertyName = "host_ipaddr"
        Me.colHostIPAddr.HeaderText = "Host IP"
        Me.colHostIPAddr.Name = "colHostIPAddr"
        Me.colHostIPAddr.ReadOnly = True
        Me.colHostIPAddr.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colHostName
        '
        Me.colHostName.DataPropertyName = "host_hostname"
        Me.colHostName.HeaderText = "Host Name"
        Me.colHostName.Name = "colHostName"
        Me.colHostName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colHostName.Width = 140
        '
        'colFlag
        '
        Me.colFlag.DataPropertyName = "flag"
        Me.colFlag.HeaderText = "flag"
        Me.colFlag.Name = "colFlag"
        Me.colFlag.ReadOnly = True
        Me.colFlag.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colFlag.Visible = False
        '
        'btnAutoResolve
        '
        Me.btnAutoResolve.Location = New System.Drawing.Point(123, 304)
        Me.btnAutoResolve.Name = "btnAutoResolve"
        Me.btnAutoResolve.Size = New System.Drawing.Size(137, 41)
        Me.btnAutoResolve.TabIndex = 3
        Me.btnAutoResolve.Text = "Auto-resolve" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(MIGHT TAKE TIME)"
        Me.btnAutoResolve.UseVisualStyleBackColor = True
        '
        'frmResolveHosts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 357)
        Me.Controls.Add(Me.btnAutoResolve)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dgHostsGrid)
        Me.Name = "frmResolveHosts"
        Me.Text = "Resolve host IPs to names"
        CType(Me.dgHostsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgHostsGrid As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHostIPAddr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHostName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAutoResolve As System.Windows.Forms.Button
End Class
