Public Class Add_Picture

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim opf As New OpenFileDialog
        opf.ShowDialog()
        PictureBox1.Image = Image.FromFile(opf.FileName)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim help As New Helper
        help.insertImage(TextBox2.Text, PictureBox1, TextBox1.Text)
    End Sub
End Class