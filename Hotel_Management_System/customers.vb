Imports System.IO

Public Class customers
    Public Err As New ErrorProvider
    Public helper As New Helper


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim obj As New homepage
        obj.stringpass = randnum.Text
        obj.stringpass1 = txtName.Text
        obj.ShowDialog()
        Me.Hide()

    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim change As New homepage
        Me.Hide()
        change.ShowDialog()

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim change As New customers
        Me.Hide()
        change.ShowDialog()

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim change As New AdminPanel
        Me.Hide()
        change.ShowDialog()

    End Sub

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
        helper.getCustomers(DataGridView1)
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

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        Dim opf As New OpenFileDialog
        opf.ShowDialog()
        Pbregis.Image = Image.FromFile(opf.FileName)

        generate_id(randnum)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim img As Byte()
        img = DataGridView1.CurrentRow.Cells(5).Value
        Dim mm As New MemoryStream(img)
        Pbregis.Image = Image.FromStream(mm)
        randnum.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        txtName.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        txtContact.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        txtAddress.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        txtRemarks.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString


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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim query As String = "delete from Customer where Id = '" & randnum.Text & "'"
            If (MessageBox.Show("Do you want to delete", "customer panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then
                helper.updateLogin(query)
                MsgBox("customer deleted successfully")
                helper.getCustomers(DataGridView1)
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

    
End Class