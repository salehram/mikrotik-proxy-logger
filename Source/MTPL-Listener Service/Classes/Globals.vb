Imports Microsoft
Imports System
Imports System.Windows
Imports System.Windows.Forms

' All global variables and constants are defined here

Module Globals
    '
    'general globals definitions
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
    Public MikrotikAccounotingURL As String 'complete URL of the mikrotik accounting page
    '
    'errors and messages constants
    Public ERR00_NOSETUP() As String = {"Could not find configuratio file", "We did not find the configuration file file, do you want to create one now?", "ERR00_NOSETUP"}
    Public ERR01_NODBSVR() As String = {"Could not detect any SQL server on the network", "We could not detect any SQL server on the network, Please check the computer connection, or make sure a SQL server is available to connect to.", "ERR01_NODBSVR"}
    Public ERR02_USRCANCELSETUP() As String = {"Setup canceled!", "You have chosen not to do the necessary configuration to have the application running!", "ERR02_USRCANCELSETUP"}
    Public ERR03_EMTYFIELD() As String = {"Empty fields!", "The following fields cannot be empty:", "ERR03_EMTYFIELD"}
    Public ERR04_CANTLOADCONFIG() As String = {"Could not read config file", "Unable to read configuration file in the path " & Config_File & "Please check the file!" & vbCrLf & "Detailed error below:" & vbCrLf, "ERR04_CANTLOADCONFIG"}
End Module
