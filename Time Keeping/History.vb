Public Class History

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TimeForm.Enabled = True
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call Mycon()
        Dim i As Integer
        rs = New ADODB.Recordset
        rs.Open("SELECT * from tbl_Log where empNum='" & lblNum.Text & "' ", con, 1, 2)
        If rs.EOF Then
            MsgBox("No Data Found")
            ListView1.Items.Clear()
            i = 0
        Else
            ListView1.Items.Clear()
            Do While Not rs.EOF
                ListView1.Items.Add(rs.Fields("DateNow").Value)
                ListView1.Items(i).SubItems.Add(rs.Fields("TimeIn").Value)
                ListView1.Items(i).SubItems.Add(rs.Fields("TimeOut").Value)
                ListView1.Items(i).SubItems.Add(rs.Fields("day").Value)
                rs.MoveNext()
                i = i + 1

            Loop


        End If
        rs = Nothing

    End Sub

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 250
        Me.Left = 300
    End Sub

    Private Sub RectangleShape1_Click(sender As Object, e As EventArgs) Handles RectangleShape1.Click

    End Sub
End Class