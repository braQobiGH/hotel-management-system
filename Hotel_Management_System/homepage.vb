Public Class homepage
    Public Property stringpass As String

    Public Property stringpass1 As String
   
  
   
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim change As New AdminPanel
        Me.Hide()
        change.ShowDialog()



    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

        Dim change As New customers
        Me.Hide()
        change.ShowDialog()


    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click


        Dim change As New ReservationDetails
        change.roomName = Button23.Text

        change.ShowDialog()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim change As New ReservationDetails
        change.roomName = Button5.Text

        change.ShowDialog()
      
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim change As New ReservationDetails
        change.roomName = Button6.Text

        change.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim change As New ReservationDetails
        change.roomName = Button7.Text

        change.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim change As New ReservationDetails
        change.roomName = Button8.Text

        change.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim change As New ReservationDetails
        change.roomName = Button9.Text

        change.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim change As New ReservationDetails
        change.roomName = Button10.Text

        change.ShowDialog()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Dim change As New ReservationDetails
        change.roomName = Button24.Text

        change.ShowDialog()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim change As New ReservationDetails
        change.roomName = Button11.Text

        change.ShowDialog()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim change As New ReservationDetails
        change.roomName = Button12.Text

        change.ShowDialog()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim change As New ReservationDetails
        change.roomName = Button13.Text

        change.ShowDialog()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim change As New ReservationDetails
        change.roomName = Button14.Text

        change.ShowDialog()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim change As New ReservationDetails
        change.roomName = Button15.Text

        change.ShowDialog()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim change As New ReservationDetails
        change.roomName = Button16.Text

        change.ShowDialog()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim change As New ReservationDetails
        change.roomName = Button25.Text

        change.ShowDialog()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim change As New ReservationDetails
        change.roomName = Button17.Text

        change.ShowDialog()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim change As New ReservationDetails
        change.roomName = Button18.Text

        change.ShowDialog()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim change As New ReservationDetails
        change.roomName = Button19.Text

        change.ShowDialog()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim change As New ReservationDetails
        change.roomName = Button20.Text

        change.ShowDialog()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim change As New ReservationDetails
        change.roomName = Button21.Text

        change.ShowDialog()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim change As New ReservationDetails
        change.roomName = Button22.Text

        change.ShowDialog()
    End Sub

    Private Sub homepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Dim customer As New customers
        TextBox1.Text = stringpass
        TextBox2.Text = stringpass1

        NumericUpDown1.Value = 1
        Dim help As New Helper


        help.loadRooms(DataGridView1)

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick



        TextBox3.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        TextBox4.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        TextBox5.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        If (NumericUpDown1.Value.Equals(1)) Then
            TextBox7.Text = TextBox5.Text
        Else
            TextBox7.Text = TextBox5.Text * NumericUpDown1.Value.ToString + ".00"


        End If

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If (NumericUpDown1.Value.Equals(1)) Then
            TextBox7.Text = TextBox5.Text
        Else
            TextBox7.Text = TextBox5.Text * NumericUpDown1.Value.ToString

            TextBox7.Text += ".000"
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim obj As New Helper
        obj.bookings(TextBox1.Text, TextBox2, TextBox3, TextBox4, TextBox5, NumericUpDown1, TextBox7)
        obj.getBookings(DataGridView2, TextBox1.Text, TextBox3)
        calculate(DataGridView2, TextBox8, TextBox9, TextBox10)

    End Sub


    Public Sub calculate(dgv As DataGridView, txt As TextBox, vat As TextBox, total As TextBox)
        Dim colsum As Decimal
        Dim vatcal As Decimal
        For Each R As DataGridViewRow In dgv.Rows
            colsum += R.Cells(4).Value

        Next
        txt.Text = colsum
        txt.Text += ".00"

        vatcal = 3 / 100 * colsum
        vat.Text = vatcal
        vat.Text += "00"

        total.Text = vatcal + colsum
        total.Text += "00"

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim obj As New Helper
        Dim status As String = "Booked"
        Dim dt As Date = DateAdd("d", NumericUpDown1.Value, Date.Today)



        Dim query As String = "INSERT INTO Booked (Id,Room_name,User_name,NumberOfRoom,Total_price,VAT,date) values('" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox2.Text & "','" & DataGridView2.Rows.Count.ToString & "','" & TextBox10.Text & "','" & TextBox9.Text & "','" & dt & "')"
        obj.booked(query)

        Dim query2 As String = "update Rooms set Status ='" & status & "',res_code ='" & TextBox1.Text & "', customer_name ='" & TextBox2.Text & "' where Room_Name ='" & TextBox3.Text & "'"
        obj.updateRoomStatus(query2)

        MsgBox("Booking Successful")
        obj.loadRooms(DataGridView1)
        obj.InsertMoney(TextBox1.Text, "income", Date.Today, TextBox10.Text)

    End Sub
   
    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Try
            Dim inss As New Helper
            Dim cusId As String = DataGridView2.CurrentRow.Cells(0).Value.ToString
            Dim query As String = "delete from bookings where Room_Name ='" & cusId & "'"
            If (MessageBox.Show("Do you really want to delete", "booking,", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then
                inss.updateLogin(query)
                inss.loadBookings(DataGridView2, TextBox1.Text)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        'Dim change As New login
        'change.ShowDialog()
        'Me.Hide()

    End Sub

    Private Sub btncheck_Click(sender As Object, e As EventArgs) Handles btncheck.Click
        Try
            Dim help As New Helper
            Dim query As String = "select Room_Name,Room_Type,Price,Status from Rooms where Room_Type ='" & ComboBox1.Text & "' AND Status = '" & ComboBox2.Text & "'"
            help.loadRooms2(DataGridView1, query)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Dim help As New Helper
        help.loadRooms(DataGridView1)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        Dim help As New Helper
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 1", Button23)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 2", Button5)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 3", Button6)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 4", Button7)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 5", Button8)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 6", Button9)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 7", Button10)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 8", Button24)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 9", Button11)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 10", Button12)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 11", Button13)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 12", Button14)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 13", Button15)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 14", Button16)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 15", Button25)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 16", Button17)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 17", Button18)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 18", Button19)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 19", Button20)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 20", Button21)
        help.buttonImage(PictureBox2, PictureBox3, PictureBox4, "Room 21", Button22)

    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim change As New Bookings
        change.ShowDialog()

    End Sub
End Class