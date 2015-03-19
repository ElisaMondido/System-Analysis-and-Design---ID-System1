Module Module1
    Public rs As New ADODB.Recordset
    Public con As New ADODB.Connection
    Public com As New ADODB.Command
    Public Sub Mycon()
        rs = New ADODB.Recordset
        con = New ADODB.Connection
        com = New ADODB.Command
        con.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=TimeKeeping"
        con.Open()
        com.ActiveConnection = con

    End Sub
End Module
