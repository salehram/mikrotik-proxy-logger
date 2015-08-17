<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slbl_SERVICE_STATUS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.sbtn_RestartSvc = New System.Windows.Forms.ToolStripMenuItem()
        Me.sbtn_StartSvc = New System.Windows.Forms.ToolStripMenuItem()
        Me.sbtn_StopSvc = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slbl_DB_SVR_NAME = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mm_Setup = New System.Windows.Forms.ToolStripMenuItem()
        Me.smDBSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LogFilesLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mm_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mm_Data = New System.Windows.Forms.ToolStripMenuItem()
        Me.smResolveHostIPstoNames = New System.Windows.Forms.ToolStripMenuItem()
        Me.mm_Reports = New System.Windows.Forms.ToolStripMenuItem()
        Me.SingleUserReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.smSingleUserReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateSingleUserReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewGroupReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAllUsersReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewRawDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.GenerateOneTimeReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mm_Help = New System.Windows.Forms.ToolStripMenuItem()
        Me.HowToSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServiceController1 = New System.ServiceProcess.ServiceController()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.smOverallReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.slbl_SERVICE_STATUS, Me.ToolStripSplitButton1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.slbl_DB_SVR_NAME})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 808)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1169, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(79, 17)
        Me.ToolStripStatusLabel1.Text = "Service Status"
        '
        'slbl_SERVICE_STATUS
        '
        Me.slbl_SERVICE_STATUS.Name = "slbl_SERVICE_STATUS"
        Me.slbl_SERVICE_STATUS.Size = New System.Drawing.Size(128, 17)
        Me.slbl_SERVICE_STATUS.Text = "[slbl_SERVICE_STATUS]"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbtn_RestartSvc, Me.sbtn_StartSvc, Me.sbtn_StopSvc})
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(16, 20)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'sbtn_RestartSvc
        '
        Me.sbtn_RestartSvc.Name = "sbtn_RestartSvc"
        Me.sbtn_RestartSvc.Size = New System.Drawing.Size(150, 22)
        Me.sbtn_RestartSvc.Text = "Restart Service"
        '
        'sbtn_StartSvc
        '
        Me.sbtn_StartSvc.Name = "sbtn_StartSvc"
        Me.sbtn_StartSvc.Size = New System.Drawing.Size(150, 22)
        Me.sbtn_StartSvc.Text = "Start Service"
        '
        'sbtn_StopSvc
        '
        Me.sbtn_StopSvc.Name = "sbtn_StopSvc"
        Me.sbtn_StopSvc.Size = New System.Drawing.Size(150, 22)
        Me.sbtn_StopSvc.Text = "Stop Service"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = "|"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(163, 17)
        Me.ToolStripStatusLabel3.Text = "Connected to database server"
        '
        'slbl_DB_SVR_NAME
        '
        Me.slbl_DB_SVR_NAME.Name = "slbl_DB_SVR_NAME"
        Me.slbl_DB_SVR_NAME.Size = New System.Drawing.Size(117, 17)
        Me.slbl_DB_SVR_NAME.Text = "[slbl_DB_SVR_NAME]"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mm_Setup, Me.mm_File, Me.mm_Data, Me.mm_Reports, Me.mm_Help})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1169, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mm_Setup
        '
        Me.mm_Setup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smDBSetup, Me.SetupDatabaseToolStripMenuItem, Me.ToolStripMenuItem1, Me.LogFilesLocationToolStripMenuItem})
        Me.mm_Setup.Name = "mm_Setup"
        Me.mm_Setup.Size = New System.Drawing.Size(49, 20)
        Me.mm_Setup.Text = "Setup"
        '
        'smDBSetup
        '
        Me.smDBSetup.Name = "smDBSetup"
        Me.smDBSetup.Size = New System.Drawing.Size(164, 22)
        Me.smDBSetup.Text = "Database server"
        '
        'SetupDatabaseToolStripMenuItem
        '
        Me.SetupDatabaseToolStripMenuItem.Name = "SetupDatabaseToolStripMenuItem"
        Me.SetupDatabaseToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SetupDatabaseToolStripMenuItem.Text = "Setup database"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(161, 6)
        '
        'LogFilesLocationToolStripMenuItem
        '
        Me.LogFilesLocationToolStripMenuItem.Name = "LogFilesLocationToolStripMenuItem"
        Me.LogFilesLocationToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.LogFilesLocationToolStripMenuItem.Text = "Log files location"
        '
        'mm_File
        '
        Me.mm_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.ImportToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem1})
        Me.mm_File.Name = "mm_File"
        Me.mm_File.Size = New System.Drawing.Size(37, 20)
        Me.mm_File.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.ExitToolStripMenuItem.Text = "Export view"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.ImportToolStripMenuItem.Text = "Import report"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(142, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(145, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'mm_Data
        '
        Me.mm_Data.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smResolveHostIPstoNames})
        Me.mm_Data.Name = "mm_Data"
        Me.mm_Data.Size = New System.Drawing.Size(43, 20)
        Me.mm_Data.Text = "Data"
        '
        'smResolveHostIPstoNames
        '
        Me.smResolveHostIPstoNames.Name = "smResolveHostIPstoNames"
        Me.smResolveHostIPstoNames.Size = New System.Drawing.Size(210, 22)
        Me.smResolveHostIPstoNames.Text = "Resolve host IPs to names"
        '
        'mm_Reports
        '
        Me.mm_Reports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SingleUserReportsToolStripMenuItem, Me.ViewGroupReportToolStripMenuItem, Me.ViewAllUsersReportToolStripMenuItem, Me.ToolStripMenuItem4, Me.ViewRawDataToolStripMenuItem, Me.ToolStripMenuItem3, Me.GenerateOneTimeReportToolStripMenuItem})
        Me.mm_Reports.Name = "mm_Reports"
        Me.mm_Reports.Size = New System.Drawing.Size(59, 20)
        Me.mm_Reports.Text = "Reports"
        '
        'SingleUserReportsToolStripMenuItem
        '
        Me.SingleUserReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smSingleUserReport, Me.GenerateSingleUserReportToolStripMenuItem, Me.ToolStripMenuItem6, Me.smOverallReport})
        Me.SingleUserReportsToolStripMenuItem.Name = "SingleUserReportsToolStripMenuItem"
        Me.SingleUserReportsToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.SingleUserReportsToolStripMenuItem.Text = "Predefined reports"
        '
        'smSingleUserReport
        '
        Me.smSingleUserReport.Name = "smSingleUserReport"
        Me.smSingleUserReport.Size = New System.Drawing.Size(215, 22)
        Me.smSingleUserReport.Text = "View single user report"
        '
        'GenerateSingleUserReportToolStripMenuItem
        '
        Me.GenerateSingleUserReportToolStripMenuItem.Name = "GenerateSingleUserReportToolStripMenuItem"
        Me.GenerateSingleUserReportToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.GenerateSingleUserReportToolStripMenuItem.Text = "Generate single user report"
        '
        'ViewGroupReportToolStripMenuItem
        '
        Me.ViewGroupReportToolStripMenuItem.Name = "ViewGroupReportToolStripMenuItem"
        Me.ViewGroupReportToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ViewGroupReportToolStripMenuItem.Text = "View group report"
        '
        'ViewAllUsersReportToolStripMenuItem
        '
        Me.ViewAllUsersReportToolStripMenuItem.Name = "ViewAllUsersReportToolStripMenuItem"
        Me.ViewAllUsersReportToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ViewAllUsersReportToolStripMenuItem.Text = "View all users report"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(203, 6)
        '
        'ViewRawDataToolStripMenuItem
        '
        Me.ViewRawDataToolStripMenuItem.Name = "ViewRawDataToolStripMenuItem"
        Me.ViewRawDataToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ViewRawDataToolStripMenuItem.Text = "View raw data"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(203, 6)
        '
        'GenerateOneTimeReportToolStripMenuItem
        '
        Me.GenerateOneTimeReportToolStripMenuItem.Name = "GenerateOneTimeReportToolStripMenuItem"
        Me.GenerateOneTimeReportToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.GenerateOneTimeReportToolStripMenuItem.Text = "Generate one time report"
        '
        'mm_Help
        '
        Me.mm_Help.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HowToSetupToolStripMenuItem, Me.ToolStripMenuItem5, Me.AboutToolStripMenuItem})
        Me.mm_Help.Name = "mm_Help"
        Me.mm_Help.Size = New System.Drawing.Size(44, 20)
        Me.mm_Help.Text = "Help"
        '
        'HowToSetupToolStripMenuItem
        '
        Me.HowToSetupToolStripMenuItem.Name = "HowToSetupToolStripMenuItem"
        Me.HowToSetupToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.HowToSetupToolStripMenuItem.Text = "How to setup"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(142, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(212, 6)
        '
        'smOverallReport
        '
        Me.smOverallReport.Name = "smOverallReport"
        Me.smOverallReport.Size = New System.Drawing.Size(215, 22)
        Me.smOverallReport.Text = "Overall usage report"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 830)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mikrotik Proxy Logger"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slbl_SERVICE_STATUS As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slbl_DB_SVR_NAME As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mm_Setup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smDBSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetupDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogFilesLocationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mm_File As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mm_Data As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smResolveHostIPstoNames As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mm_Reports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewGroupReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewAllUsersReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewRawDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mm_Help As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HowToSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServiceController1 As System.ServiceProcess.ServiceController
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents sbtn_RestartSvc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sbtn_StartSvc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sbtn_StopSvc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GenerateOneTimeReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SingleUserReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smSingleUserReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateSingleUserReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smOverallReport As System.Windows.Forms.ToolStripMenuItem

End Class
