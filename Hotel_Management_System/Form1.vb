Public Class login2
    Dim sign_Indicator As Integer = 0
    Dim f1 As Boolean = False
    Dim s, x As String

    Private Sub btnTA1_Click(sender As Object, e As EventArgs) Handles btnTA1.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        Password.Font.Size.Equals(20)
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        f1 = True
    End Sub

    Private Sub btnTA2_Click(sender As Object, e As EventArgs) Handles btnTA2.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        f1 = True
    End Sub

    Private Sub btnTA3_Click(sender As Object, e As EventArgs) Handles btnTA3.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        f1 = True
    End Sub

    Private Sub btnTA4_Click(sender As Object, e As EventArgs) Handles btnTA4.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        f1 = True
    End Sub

    Private Sub btnTA5_Click(sender As Object, e As EventArgs) Handles btnTA5.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        f1 = True
    End Sub

    Private Sub btnTA6_Click(sender As Object, e As EventArgs) Handles btnTA6.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        f1 = True
    End Sub

    Private Sub btnTA7_Click(sender As Object, e As EventArgs) Handles btnTA7.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        f1 = True
    End Sub

    Private Sub btnTA8_Click(sender As Object, e As EventArgs) Handles btnTA8.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        f1 = True
    End Sub

    Private Sub btnTA9_Click(sender As Object, e As EventArgs) Handles btnTA9.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        f1 = True
    End Sub

    Private Sub btnTA0_Click(sender As Object, e As EventArgs) Handles btnTA0.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        f1 = True
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        s = Password.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        Password.Text = x
        x = ""
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'homepage.Show()
        'Me.Hide()

    End Sub

    Private Sub passwrd_forgot_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles passwrd_forgot.LinkClicked
        'changePassword.Show()
        'Me.Hide()

    End Sub
End Class