' All global variables and constants are defined here

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
    Public setupStatus As Boolean 'variable to store the status of setup screen
    '
    'configuration file contents
    Public Config_Dir As String = Application.StartupPath & "\config" 'variable to store the location of the configuration directory
    Public Config_File As String = Application.StartupPath & "\config\config.ini" 'variable to store the location of the configuration file
    Public Config_DB_Name As String 'the database name as in the configuration file
    Public Config_DB_Server As String 'the database server name as in the configuration file
    Public Config_DB_Instance As String 'the database server instance name as in the configuration file
    Public Config_DB_User_Name As String 'the database server user name as in the configuration file
    Public Config_DB_Password As String 'the database user password as in the configuration file
    '
    'errors and messages constants
    Public ERR00_NOSETUP() As String = {"Could not find configuratio file", "We did not find the configuration file file, do you want to create one now?", "ERR00_NOSETUP"}
    Public ERR01_frmMainLOAD_NODBSVR() As String = {"Could not detect any SQL server on the network", "We could not detect any SQL server on the network, Please check the computer connection, or make sure a SQL server is available to connect to.", "ERR01_frmMainLOAD_NODBSVR"}
    Public ERR02_frmMainLOAD_NOSETUP() As String = {"Setup canceled!", "You have chosen not to do the necessary configuration to have the application running!", "ERR02_frmMainLOAD_NOSETUP"}
    Public ERR03_validateFields() As String = {"Empty fields!", "The following fields cannot be empty:", "ERR03_validateFields"}
    Public ERR04_ReadConfig() As String = {"Could not read config file", "Unable to read configuration file in the path " & Config_File & "Please check the file!" & vbCrLf & "Detailed error below:" & vbCrLf, "ERR04_ReadConfig"}
    Public ERR05_buildDB() As String = {"Could not create tables", "We were unable to create tables in the database, please check your SQL server connection settings" & vbCrLf & "Detailed error below:" & vbCrLf & vbCrLf, "ERR05_buildDB"}
    Public ERR06_fillHostIP_Lists() As String = {"Could not fill IP and host name lists", "We were unable to fill the IP and host names lists...", "ERR06_fillHostIP_Lists"}
    Public ERR007_frmResolveHosts_Load() As String = {"Could not fill IP and host name lists", "We were unable to fill the IP and host names lists...", "ERR007_frmResolveHosts_Load"}
    Public ERR008_btnSave_Click() As String = {"Unable to save hosts records", "An error occured during the attempt to save hosts records into hosts table" & vbCrLf & vbCrLf & "Error details:" & vbCrLf & vbCrLf, "ERR008_btnSave_Click"}
End Module
