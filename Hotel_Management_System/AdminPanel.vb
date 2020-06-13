Imports System.IO
Public Class AdminPanel

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim help As New Helper
        help.insertUser(TextBox1, TextBox7, TextBox3, ComboBox1, TextBox2, PictureBox1)
        MsgBox("user has been inserted successfully")

        TextBox1.Clear()
        TextBox7.Clear()
        TextBox3.Clear()
        TextBox2.Clear()
        ComboBox1.Text = "Membership type"
        PictureBox1.Image = Nothing
    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        Try


            Dim opf As New OpenFileDialog
            opf.ShowDialog()
            PictureBox1.Image = Image.FromFile(opf.FileName)
        Catch ex As Exception
            MsgBox("please select an image")
        End Try
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress, TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsLetter(e.KeyChar) = False And Char.IsWhiteSpace(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub AdminPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim help As New Helper
        help.getUsers(DataGridView1)
        help.getIncomes(DataGridView5)
        help.getexpenses(DataGridView2)
        calculate(DataGridView5, TextBox4)
        calculate(DataGridView2, TextBox10)
        Dim hold As Decimal = TextBox4.Text - TextBox10.Text
        TextBox9.Text = hold
    End Sub


    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim img As Byte()
        img = DataGridView1.CurrentRow.Cells(5).Value
        Dim mm As New MemoryStream(img)
        PictureBox1.Image = Image.FromStream(mm)
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        TextBox7.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        ComboBox1.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        TextBox2.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim helper As New Helper
        Try

            Dim query As String = "delete from Login where User_Name = '" & TextBox1.Text & "'"
            If (MessageBox.Show("Do you want to delete", "customer panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then
                Helper.updateLogin(query)
                MsgBox("User deleted successfully")
                helper.getUsers(DataGridView1)

                'clear fields

                TextBox1.Clear()
                TextBox7.Clear()
                TextBox3.Clear()
                TextBox2.Clear()
                ComboBox1.Text = "Membership type"
                PictureBox1.Image = Nothing
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim help As New Helper
        verifyFields(ComboBox4, TextBox5, TextBox6)
        help.InsertMoney(TextBox6.Text, ComboBox4.Text, Date.Now, TextBox5.Text)
        If (ComboBox4.Text.Equals("income")) Then
            MsgBox("income inserted successfully")
        Else
            MsgBox("expenses inserted successfully")
        End If

        help.getexpenses(DataGridView2)


    End Sub

    Public Sub verifyFields(cmb As ComboBox, txt1 As TextBox, txt2 As TextBox)
        If (cmb.Text = "Transaction Type" Or txt1.Text = Nothing Or txt2.Text = Nothing) Then
            MsgBox("please fill all fields")
            Exit Sub

        End If

    End Sub
    Public Sub calculate(dgv As DataGridView, txt As TextBox)
        Dim colsum As Decimal
        For Each R As DataGridViewRow In dgv.Rows
            colsum += R.Cells(2).Value

        Next
        txt.Text = colsum
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub
End Class