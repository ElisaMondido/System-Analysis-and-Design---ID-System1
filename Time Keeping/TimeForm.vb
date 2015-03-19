Public Class TimeForm

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Mycon()
        lblstudpic.Text = "C:\Users\kenneth\Desktop\Time In\LOGO1.png"
        studPic.ImageLocation = lblstudpic.Text
        Dim i As Integer
        rs = New ADODB.Recordset
        rs.Open("SELECT * from tbl_log where stat=0 AND DateNow='" & DateValue(Now) & "'", con, 1, 2)
        If rs.EOF Then
            ListView1.Items.Clear()
            i = 0
        Else
            ListView1.Items.Clear()
            Do While Not rs.EOF
                ListView1.Items.Add(rs.Fields("Fname").Value)
                ListView1.Items(i).SubItems.Add(rs.Fields("TimeIn").Value)
                rs.MoveNext()
                i = i + 1
            Loop
        End If
        rs = Nothing

    End Sub

    Private Sub txtEmpNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmpNum.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True

            If txtEmpNum.Text = "" Then
                MsgBox("Please Enter your Employee Number")
                Exit Sub

            End If

            rs = New ADODB.Recordset
            rs.Open("SELECT * from tblEmpInfo where empNum='" & txtEmpNum.Text & "'", con, 1, 2)
            If rs.EOF Then
                MsgBox("Access Denied!")
                lblName.Text = ""
                lblDepartment.Text = ""
                lblPosition.Text = ""
                lblstudpic.Text = "C:\Users\kenneth\Desktop\Time In\LOGO1.png"
                studPic.ImageLocation = lblstudpic.Text
                TextBox2.Visible = False

            Else
                lblName.Text = rs.Fields("lastname").Value & "," & rs.Fields("firstname").Value & ", " & rs.Fields("midname").Value
                lblDepartment.Text = rs.Fields("dept").Value
                lblPosition.Text = rs.Fields("position").Value
                lblstudpic.Text = rs.Fields("picPath").Value

                rs = New ADODB.Recordset
                rs.Open("SELECT * from tblAnnounce where studnum='" & txtEmpNum.Text & "'", con, 1, 2)
                If rs.EOF Then
                    TextBox2.Text = ""
                    TextBox2.Visible = False
                Else
                    TextBox2.Visible = True
                    TextBox2.Text = rs.Fields("message").Value
                End If
                rs = Nothing



            End If
            rs = Nothing
            studPic.ImageLocation = lblstudpic.Text

            rs = New ADODB.Recordset
            rs.Open("SELECT * from tbl_log  where empNum='" & txtEmpNum.Text & "' AND DateNow ='" & DateValue(Now) & "' and stat=0", con, 1, 2)
            If rs.EOF Then
                rs = New ADODB.Recordset
                rs.Open("SELECT * from tbl_Log", con, 1, 2)
                rs.AddNew()
                rs.Fields("EmpNUm").Value = txtEmpNum.Text
                rs.Fields("Fname").Value = lblName.Text
                rs.Fields("TimeIn").Value = TimeValue(Now)
                rs.Fields("TimeOut").Value = "--"
                rs.Fields("dateNow").Value = DateValue(Now)
                rs.Fields("day").Value = lblDay.Text
                rs.Fields("Stat").Value = 0
                rs.Update()
                rs = Nothing


                rs = Nothing
            Else

                rs = New ADODB.Recordset
                rs.Open("SELECT * from tbl_Log WHERE empNum='" & txtEmpNum.Text & "' and stat=0 and dateNow='" & DateValue(Now) & "' ", con, 1, 2)
                rs.Fields("TimeOut").Value = TimeValue(Now)
                rs.Fields("stat").Value = 1
                rs.Update()
                rs = Nothing
            End If


            Dim i As Integer
            rs = New ADODB.Recordset
            rs.Open("SELECT * from tbl_log where stat=0 AND DateNow='" & DateValue(Now) & "'", con, 1, 2)
            If rs.EOF Then
                ListView1.Items.Clear()
                i = 0
            Else
                ListView1.Items.Clear()
                Do While Not rs.EOF
                    ListView1.Items.Add(rs.Fields("Fname").Value)
                    ListView1.Items(i).SubItems.Add(rs.Fields("TimeIn").Value)
                    rs.MoveNext()
                    i = i + 1

                Loop
            End If
            rs = Nothing


        Else
        End If
    End Sub


    Private Sub txtEmpNum_TextChanged(sender As Object, e As EventArgs) Handles txtEmpNum.TextChanged

    End Sub

    Private Sub lblstudpic_Click(sender As Object, e As EventArgs) Handles lblstudpic.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDay.Text = WeekdayName(Weekday(DateValue(Now)))
        lblDate.Text = Format(DateValue(Now), "MMMM dd, yyyy")
        lblTime.Text = TimeValue(Now)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Enabled = False

        IDForm.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

        GroupBox1.Visible = True


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        rs = New ADODB.Recordset
        rs.Open("SELeCT * from tbl_UserAdmin where password='" & TextBox1.Text & "'", con, 1, 2)
        If rs.EOF Then
            MsgBox("Access Denied")
        Else
            Me.Close()
        End If
        rs = Nothing

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        GroupBox1.Visible = False
    End Sub

    Private Sub lblTime_Click(sender As Object, e As EventArgs) Handles lblTime.Click

    End Sub
End Class
