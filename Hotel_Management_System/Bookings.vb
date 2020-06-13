Public Class Bookings
    Private Sub Bookings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim help As New Helper
        help.loadbooked(DataGridView1)
        DateTimePicker1.Hide()
        DateTimePicker1.MinDate = Date.Today




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim help As New Helper
        Dim query As String = " select * from booked where date < '" & Date.Today & "'"
        help.loadspecific(DataGridView1, query)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim help As New Helper
        Dim query As String = " select * from booked where date = '" & Date.Today & "'"
        help.loadspecific(DataGridView1, query)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim help As New Helper
        Dim query As String = " select * from booked where date > '" & Date.Today & "'"
        help.loadspecific(DataGridView1, query)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        DateTimePicker1.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim a As String = DataGridView1.CurrentRow.Cells(0).Value
        Dim b As Date = DateTimePicker1.Value
        Dim query As String = "update booked set date = '" & b & "' WHERE Id = '" & a & "'"
        Dim help As New Helper
        help.updateLogin(query)
        MsgBox("customer date postponded successfull")
        help.loadbooked(DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim help As New Helper
        help.loadbooked(DataGridView1)
    End Sub
End Class