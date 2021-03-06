﻿' All global variables and constants are defined here

Module Globals
    '
    'general globals definitions
    Public Service_running As Boolean 'boolean to tell if service is running or not, TRUE = service working, FALSE = service not working
    Public DB_Server As Boolean 'boolean to indicate if database server if present on network
    Public DB_Status As String 'string to store the database server name
    Public DB_Instance As String 'string to store the instance name of the database
    Public DB_Name As String 'string to store the name of the database
    Public DB_Sources As DataTable 'a variable to store a table with available sql servers on the network
    Public DB_Servers_List As New DataSet 'a variable dataset to store the sql servers list from the network
    Public MT_IP As String 'the IP address of the mikrotik, this is used to get accounting data
    Public setupStatus As Boolean 'variable to store the status of setup screen
    Public AppStartDir As String = Application.StartupPath 'application startup path
    Public AppReportsDir As String = Application.StartupPath & "\Reports" 'the reports directory of the application
    '
    'report data variables
    Public reportHeadLine1 As String
    Public reportHeadLine2 As String
    Public reportHeadLine3 As String
    Public reportHeadLine4 As String
    Public reportHeaderDetailsLine1 As String
    Public reportHeaderDetailsLine2 As String
    Public reportHeaderDetailsLine3 As String
    Public reportHeaderDetailsLine4 As String
    Public reportHeaderDetailsLine5 As String
    Public reportHeaderDetailsLine6 As String
    Public reportHeaderDetailsLine7 As String
    Public reportHeaderDetailsLine8 As String
    Public printMode As Integer = 0 'defines the printing mode: 0=nothing, 1=single user report, 2=overall users report
    Public reportLoaded As Boolean
    '
    'global objects
    'global dataset objects
    Public GlobalDataset As New DataSet("GlobalDataset") 'a dataset object to store the data in runtime
    '
    ' all users report dataset objects
    Public AllUsersReport_Dataset_Table As New DataTable("allUsersReport_DSTab") 'the table which will hold the all users report columns, this is a member of the AllUsersReport_Dataset dataset
    Public AllUsersReport_Dataset_Table_ID As New DataColumn("allUsersReport_DSTab_DSCol_ID") 'ID column
    Public AllUsersReport_Dataset_Table_IPAddr As New DataColumn("allUsersReport_DSTab_DSCol_IPAddr") 'IP address column
    Public AllUsersReport_Dataset_Table_DevName As New DataColumn("allUsersReport_DSTab_DSCol_DevName") 'device name column
    Public AllUsersReport_Dataset_Table_DLUsage As New DataColumn("allUsersReport_DSTab_DSCol_DLUsage") 'download usage column
    Public AllUsersReport_Dataset_Table_PktDL As New DataColumn("allUsersReport_DSTab_DSCol_PktDL") 'packets requested column
    Public AllUsersReport_Dataset_Table_UPUsage As New DataColumn("allUsersReport_DSTab_DSCol_UPUsage") 'upload usage column
    Public AllUsersReport_Dataset_Table_PktUP As New DataColumn("allUsersReport_DSTab_DSCol_PktUP") 'packets sent column
    Public AllUsersReport_Dataset_Table_Percentage As New DataColumn("allUsersReport_DSTab_DSCol_Percentage") 'total usage percentage column
    '
    '
    'configuration file contents
    Public Config_Dir As String = Application.StartupPath & "\config" 'variable to store the location of the configuration directory
    Public Config_File As String = Application.StartupPath & "\config\config.ini" 'variable to store the location of the configuration file
    Public Config_DB_Name As String 'the database name as in the configuration file
    Public Config_DB_Server As String 'the database server name as in the configuration file
    Public Config_DB_Instance As String 'the database server instance name as in the configuration file
    Public Config_DB_User_Name As String 'the database server user name as in the configuration file
    Public Config_DB_Password As String 'the database user password as in the configuration file
    Public Config_MT_IP As String 'the IP address of the mikrotik, this is used to get accounting data
    Public DB_ConnectionString As String 'this variable will store the connection string that will be used in all databaese connections.
    '
    'errors and messages constants
    Public ERR000_NOSETUP() As String = {"Could not find configuration file", "We did not find the configuration file file, do you want to create one now?", "ERR00_NOSETUP"}
    Public ERR001_frmMainLOAD_NODBSVR() As String = {"Could not detect any SQL server on the network", "We could not detect any SQL server on the network, Please check the computer connection, or make sure a SQL server is available to connect to.", "ERR01_frmMainLOAD_NODBSVR"}
    Public ERR002_frmMainLOAD_NOSETUP() As String = {"Setup canceled!", "You have chosen not to do the necessary configuration to have the application running!", "ERR02_frmMainLOAD_NOSETUP"}
    Public ERR003_validateFields() As String = {"Empty fields!", "The following fields cannot be empty:", "ERR03_validateFields"}
    Public ERR004_ReadConfig() As String = {"Could not read config file", "Unable to read configuration file in the path " & Config_File & "Please check the file!" & vbCrLf & "Detailed error below:" & vbCrLf, "ERR04_ReadConfig"}
    Public ERR005_buildDB() As String = {"Could not create tables", "We were unable to create tables in the database, please check your SQL server connection settings" & vbCrLf & "Detailed error below:" & vbCrLf & vbCrLf, "ERR05_buildDB"}
    Public ERR006_fillHostIP_Lists() As String = {"Could not fill IP and host name lists", "We were unable to fill the IP and host names lists...", "ERR06_fillHostIP_Lists"}
    Public ERR007_frmResolveHosts_Load() As String = {"Could not fill IP and host name lists", "We were unable to fill the IP and host names lists...", "ERR007_frmResolveHosts_Load"}
    Public ERR008_btnSave_Click() As String = {"Unable to save hosts records", "An error occured during the attempt to save hosts records into hosts table" & vbCrLf & vbCrLf & "Error details:" & vbCrLf & vbCrLf, "ERR008_btnSave_Click"}
    Public ERR009_btnGenerateReport_Click_DATEERROR() As String = {"Date selection error!", "You cannot have 'from' later than 'to' in the dates field." & vbCrLf & "Please fix your date selection!", "ERR009_btnGenerateReport_Click_DATEERROR"}
    Public ERR010_btnGenerateReport_Click_BuildDataset() As String = {"Could not get the required report", "We were unable to connect or fill the dataset with the required data.", "ERR010_btnGenerateReport_Click_BuildDataset"}
    Public ERR011_btnGenerateReport_Click_GetAccData() As String = {"Could not get the accounting data from the table", "We were unable to get the accounting data from the database table, please check the support or report te bug", "ERR011_btnGenerateReport_Click_GetAccData"}
    Public ERR012_btnViewReport_Click_frmOverAlLReports() As String = {"Date selection error!", "You cannot have 'from' later than 'to' in the dates field." & vbCrLf & "Please fix your date selection!", "ERR012_btnViewReport_Click_frmOverAlLReports"}
End Module
