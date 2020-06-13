Public Class ReservationDetails
    Public Property roomName As String

    Private Sub ReservationDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False

        TextBox5.Text = roomName
        Dim helper As New Helper
        Dim status As String = "Booked"

        Dim query As String = "select * from Rooms where Room_Name = '" & TextBox5.Text & "' AND Status ='" & status & "' "
        helper.checkrooms(TextBox1, TextBox2, TextBox3, TextBox4, query)
        Dim query2 As String = "select date from booked where id = '" & TextBox1.Text & "'"
        helper.checkrooms2(query2, DateTimePicker1)

        If (DateTimePicker1.Value.Equals(Date.Today)) Then
            MessageBox.Show("customer date is due please check him out or visit the check booking panel and postpone the date", "customer manager", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Button1.Enabled = True


        End If


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim query As String = "update Rooms set res_code ='" & TextBox1.Text & "',customer_name = '" & TextBox2.Text & "' where Room_Name = ' " & TextBox3.Text & "' "
        Dim obj As New Helper
        obj.updateLogin(query)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim help As New Helper
        Dim val As String = "NULL"
        Dim val2 As String = "Available"
        Try
            Dim query1 As String = "delete from Booked where Id = '" & TextBox1.Text & "' AND Room_name = '" & TextBox3.Text & "' "
            Dim query2 As String = "delete from Bookings where Id = '" & TextBox1.Text & "'AND Room_name = '" & TextBox3.Text & "'"
            Dim query3 As String = "update Rooms set res_code ='" & val & "',Status ='" & val2 & "',customer_name ='" & val & "'where res_code = '" & TextBox1.Text & "' AND Room_name = '" & TextBox3.Text & "'"
            help.updateLogin(query1)
            help.updateLogin(query2)
            help.updateLogin(query3)
            MessageBox.Show("Customer checked out successfully", "Customer manager", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim help As New Helper
        Dim val As String = "NULL"
        Dim val2 As String = "Available"
        Try
            Dim query1 As String = "delete from Booked where Id = '" & TextBox1.Text & "' AND Room_name = '" & TextBox3.Text & "' "
            Dim query2 As String = "delete from Bookings where Id = '" & TextBox1.Text & "'AND Room_name = '" & TextBox3.Text & "'"
            Dim query3 As String = "update Rooms set res_code ='" & val & "',Status ='" & val2 & "',customer_name ='" & val & "'where res_code = '" & TextBox1.Text & "' AND Room_name = '" & TextBox3.Text & "'"
            help.updateLogin(query1)
            help.updateLogin(query2)
            help.updateLogin(query3)
            MessageBox.Show("Booking cancelled successfully", "Customer manager", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MsgBox("i will delete the payement from the transaction database")
            Me.Hide()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class