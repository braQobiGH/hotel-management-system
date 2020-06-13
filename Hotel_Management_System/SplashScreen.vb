Public Class splashscreen

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = ProgressBar1.Value + 5
        Label1.Text = ProgressBar1.Value & "%"
        Label8.Text = "Loading..."

        If (ProgressBar1.Value = ProgressBar1.Maximum) Then
            Timer1.Enabled = False
            Me.Hide()
            login.Show()

        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub splashscreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label8.ForeColor = Color.White
    End Sub
End Class