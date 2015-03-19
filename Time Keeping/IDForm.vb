Public Class IDForm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Mycon()

        rs = New ADODB.Recordset
        rs.Open("SELECT * from tblEmpInfo where EmpNum='" & TextBox1.Text & "' and pinCOde='" & TextBox2.Text & "'", con, 1, 2)
        If rs.EOF Then
            MsgBox("Access Denied")
        Else
            History.lblName.Text = rs.Fields("Lastname").Value + ", " + rs.Fields("Firstname").Value + "," + rs.Fields("midname").Value
            History.lblNum.Text = rs.Fields("empNum").Value
            History.Show()
            Me.Close()
        End If


        rs = Nothing
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Close()
        TimeForm.Enabled = True
    End Sub

    Private Sub IDForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 250
        Me.Left = 300
    End Sub
End Class