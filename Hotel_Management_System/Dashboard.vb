Imports System.IO
Public Class Dashboard
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        AdminPanel.Hide()

        customersPanel.Hide()
        Panel3.Hide()



        Bookings.Hide()
        ReservationBooking.Show()




    End Sub


    Private Sub LinkLabel2_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

        Panel3.Hide()


        customersPanel.Hide()
        Panel3.Hide()



        Bookings.Hide()
        ReservationBooking.Hide()
        AdminPanel.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        AdminPanel.Hide()


        customersPanel.Show()
        Panel3.Hide()



        Bookings.Hide()
        ReservationBooking.Hide()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        AdminPanel.Hide()


        customersPanel.Hide()

        Panel3.Show()



        Bookings.Hide()
        ReservationBooking.Hide()
    End Sub

    Private Sub saveUser_Click(sender As Object, e As EventArgs) Handles saveUser.Click
        If (ComboBox3.Text = "Select Member Role") Then
            MsgBox("select member role")
            Exit Sub

        End If
        Dim help As New Helper
        help.insertUser(userName, userAddress, userContact, ComboBox1, userPass, pbUserImage)
        MsgBox("user has been inserted successfully")

        userAddress.Clear()
        userContact.Clear()
        userName.Clear()
        userPass.Clear()
        ComboBox1.Text = "Select Member Role"
        pbUserImage.Image = Nothing
    End Sub

    Private Sub btnSelUserImage_Click(sender As Object, e As EventArgs) Handles btnSelUserImage.Click
        Try


            Dim opf As New OpenFileDialog
            opf.ShowDialog()
            pbUserImage.Image = Image.FromFile(opf.FileName)
        Catch ex As Exception
            MsgBox("please select an image")
        End Try
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim help As New Helper
        Timer1.Start()
        Timer2.Start()
        help.getUsers(dgvUsers)
        help.getIncomes(DataGridView7)
        help.getexpenses(DataGridView6)
        calculate(DataGridView7, TextBox17)
        calculate(DataGridView6, TextBox15)
        Dim hold As Decimal = TextBox17.Text - TextBox15.Text
        TextBox16.Text = hold
        NumericUpDown1.Value = 1



        help.loadRooms(DataGridView1)
    End Sub



    Public Sub calculate(dgv As DataGridView, txt As TextBox)
        Dim colsum As Decimal
        For Each R As DataGridViewRow In dgv.Rows
            colsum += R.Cells(2).Value

        Next
        txt.Text = colsum
    End Sub
    Private Sub userPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles userPass.KeyPress, userContact.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub userName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles userName.KeyPress
        If Char.IsLetter(e.KeyChar) = False And Char.IsWhiteSpace(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub delUser_Click(sender As Object, e As EventArgs) Handles delUser.Click
        Dim helper As New Helper
        Try

            Dim query As String = "delete from Login where User_Name = '" & userName.Text & "'"
            If (MessageBox.Show("Do you want to delete", "customer panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then
                helper.updateLogin(query)
                MsgBox("User deleted successfully")
                helper.getUsers(dgvUsers)

                'clear fields

                userAddress.Clear()
                userContact.Clear()
                userName.Clear()
                userPass.Clear()
                ComboBox1.Text = "Select Member Role"
                pbUserImage.Image = Nothing
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        Dim help As New Helper
        verifyFields(ComboBox4, TextBox19, TextBox18)
        help.InsertMoney(TextBox18.Text, ComboBox4.Text, Date.Now, TextBox19.Text)
        If (ComboBox4.Text.Equals("income")) Then
            MsgBox("income inserted successfully")
        Else
            MsgBox("expenses inserted successfully")
        End If

        help.getexpenses(DataGridView6)
        calculate(DataGridView6, TextBox15)
        calculate(DataGridView7, TextBox17)
        TextBox19.Clear()
        TextBox18.Clear()
    End Sub
    Private Sub dgvUsers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellDoubleClick
        Dim img As Byte()
        img = dgvUsers.CurrentRow.Cells(5).Value
        Dim mm As New MemoryStream(img)
        pbUserImage.Image = Image.FromStream(mm)
        userName.Text = dgvUsers.CurrentRow.Cells(0).Value.ToString
        userAddress.Text = dgvUsers.CurrentRow.Cells(1).Value.ToString
        ComboBox3.Text = dgvUsers.CurrentRow.Cells(3).Value.ToString
        userContact.Text = dgvUsers.CurrentRow.Cells(2).Value.ToString
        userPass.Text = dgvUsers.CurrentRow.Cells(4).Value.ToString
    End Sub
    Public Sub verifyFields(cmb As ComboBox, txt1 As TextBox, txt2 As TextBox)
        If (cmb.Text = "Transaction Type" Or txt1.Text = Nothing Or txt2.Text = Nothing) Then
            MsgBox("please fill all fields")
            Exit Sub

        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        calculate(DataGridView7, TextBox17)
        calculate(DataGridView6, TextBox15)
        Dim hold As Decimal = TextBox17.Text - TextBox15.Text
        TextBox16.Text = hold


    End Sub

    Private Sub btnCapture1_Click(sender As Object, e As EventArgs) Handles btnCapture1.Click
        Dim opf As New OpenFileDialog
        opf.ShowDialog()
        Pbregis.Image = Image.FromFile(opf.FileName)

        generate_id(randnum)
    End Sub

    Private Sub btnDelete1_Click(sender As Object, e As EventArgs) Handles btnDelete1.Click
        Try
            Dim query As String = "delete from Customer where Id = '" & randnum.Text & "'"
            If (MessageBox.Show("Do you want to delete", "customer panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then
                helper.updateLogin(query)
                MsgBox("customer deleted successfully")
                helper.getCustomers(DataGridView4)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Public Err As New ErrorProvider
    Public helper As New Helper











    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim help As New Helper

            If txtName.Text = Nothing Then
                Err.SetError(txtName, "field rquired")
                Exit Sub
            End If
            If txtContact.Text = Nothing Then
                Err.SetError(txtContact, "field rquired")
                Exit Sub
            End If
            If txtAddress.Text = Nothing Then
                Err.SetError(txtAddress, "field rquired")
                Exit Sub
            End If
            help.insertCustomer(randnum.Text, txtName, txtAddress, txtContact, txtRemarks, Pbregis)
            help.getCustomers(DataGridView1)



        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub








    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Err.SetError(txtName, "")
    End Sub

    Private Sub txtContact_TextChanged(sender As Object, e As EventArgs) Handles txtContact.TextChanged
        Err.SetError(txtContact, "")
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged, txtRemarks.TextChanged
        Err.SetError(txtAddress, "")
    End Sub

    Private Sub customers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        helper.getCustomers(DataGridView4)
        Dim home_page As New homepage
        home_page.Close()

        randnum.Hide()
        rbMale.Enabled = True
        generate_id(randnum)

    End Sub

    Public Sub generate_id(randomField)
        Dim rn As New Random
        Dim customerId As String = "HMS"
        randomField.text = customerId + rn.Next(1, 100000).ToString






    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture1.Click
        Dim opf As New OpenFileDialog
        opf.ShowDialog()
        Pbregis.Image = Image.FromFile(opf.FileName)

        generate_id(randnum)
    End Sub

    Private Sub DataGridView4_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellDoubleClick
        Dim img As Byte()
        img = DataGridView4.CurrentRow.Cells(5).Value
        Dim mm As New MemoryStream(img)
        Pbregis.Image = Image.FromStream(mm)
        randnum.Text = DataGridView4.CurrentRow.Cells(0).Value.ToString
        txtName.Text = DataGridView4.CurrentRow.Cells(1).Value.ToString
        txtContact.Text = DataGridView4.CurrentRow.Cells(3).Value.ToString
        txtAddress.Text = DataGridView4.CurrentRow.Cells(2).Value.ToString
        txtRemarks.Text = DataGridView4.CurrentRow.Cells(4).Value.ToString


    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtAddress.Text = Nothing
        txtContact.Text = Nothing
        txtName.Text = Nothing
        txtRemarks.Text = Nothing
        Pbregis.Image = Nothing
    End Sub

    Private Sub txbsearch_TextChanged(sender As Object, e As EventArgs) Handles txbsearch.TextChanged
        helper.search(txbsearch.Text, DataGridView1)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete1.Click
        Try
            Dim query As String = "delete from Customer where Id = '" & randnum.Text & "'"
            If (MessageBox.Show("Do you want to delete", "customer panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then
                helper.updateLogin(query)
                MsgBox("customer deleted successfully")
                helper.getCustomers(DataGridView4)
            End If


        Catch ex As Exception

        End Try
    End Sub
    Function getName() As String

        Return txtName.Text
    End Function

    Private Sub txtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRemarks.KeyPress, txtName.KeyPress
        If Char.IsLetter(e.KeyChar) = False And Char.IsWhiteSpace(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click


        Panel3.Hide()


        customersPanel.Hide()
        Panel3.Hide()



        Bookings.Hide()
        ReservationBooking.Show()
        AdminPanel.Hide()
        TextBox2.Text = txtName.Text
        TextBox1.Text = randnum.Text

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim help As New Helper
        help.loadRooms(DataGridView1)
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
        Timer2.Enabled = True
        Dim customer As New customers


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



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim help As New Helper
            Dim query As String = "select Room_Name,Room_Type,Price,Status from Rooms where Room_Type ='" & ComboBox1.Text & "' AND Status = '" & ComboBox2.Text & "'"
            help.loadRooms2(DataGridView1, query)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim help As New Helper
        help.loadRooms(DataGridView1)

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        helper.getCustomers(DataGridView4)
        helper.getUsers(dgvUsers)

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


End Class