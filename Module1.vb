Imports System.Data.SqlClient
Module Module1

    Public Conn As SqlConnection
    Public Da As SqlDataAdapter
    Public Rd As SqlDataReader
    Public Ds As DataSet
    Public cmd As SqlCommand

    Public MyDB As String

    Public Sub koneksi()
        MyDB = "Data Source=RII;initial catalog=db_project;integrated security=true"
        Conn = New SqlConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub

End Module
