' all sql database related function and sub procedures are here
Imports System
Imports System.IO
Imports System.Management
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.ServiceProcess
Imports Microsoft.VisualBasic
Imports System.Windows.Forms

Public Class SQLCalls


    ' ''' <summary>
    ' ''' Function to open a new connection to the database server
    ' ''' </summary>
    ' ''' <param name="mode">0=open connection, 1=close connection</param>
    ' ''' <returns>0 for successfull, error code and message for errors</returns>
    ' ''' <remarks></remarks>
    'Private Function DBConnection(ByVal mode As Integer) As String
    '    Select Case mode
    '        Case 0 'open new connection
    '            Try

    '            Catch ex As Exception
    '                MsgBox(ex.Message) 'TODO: add error message here
    '                Return ex.Message
    '            End Try
    '        Case 1 'close connection
    '            Try
    '                sqlConnection.Close()
    '            Catch ex As Exception
    '                MsgBox(ex.Message) 'TODO: add error message here
    '                Return ex.Message
    '            End Try
    '    End Select
    '    Return 0
    'End Function

    ''' <summary>
    ''' Function to execute a query from SQLDatareader object and return the results in a string array
    ''' </summary>
    ''' <param name="TableName">The table name on which we want to execute the query on</param>
    ''' <param name="Query">The query we want to execute on the table</param>
    ''' <returns>Array with query results, or error code for failures</returns>
    ''' <remarks></remarks>
    Public Function ExecReader(ByVal TableName As String, ByVal Query As String) As String()
        Dim bytesVol As Int64
        Dim pktCount As Int64
        Dim connectionString As String = DB_ConnectionString
        Dim sqlConnection As New SqlConnection(connectionString)
        Try
            'initiating the connection:
            sqlConnection.Open()
            Dim sqlCMD As New SqlCommand(Query, sqlConnection)
            Dim SqlReader As SqlDataReader = sqlCMD.ExecuteReader
            If SqlReader.HasRows = True Then
                Do While SqlReader.Read
                    If SqlReader.GetValue(0) IsNot DBNull.Value Then bytesVol = SqlReader.GetInt64(0) Else bytesVol = 0
                    If SqlReader.GetValue(1) IsNot DBNull.Value Then pktCount = SqlReader.GetInt64(1) Else pktCount = 0
                    Return {CType(bytesVol, String), CType(pktCount, String)}
                Loop
            End If
            'closing the connection
            sqlConnection.Close()
            Return {"0", "0"}
        Catch ex As Exception
            sqlConnection.Close()
            MsgBox(ex.Message)
            Return {"0", "0"}
        End Try
    End Function
End Class
