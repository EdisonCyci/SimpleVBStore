Public Class UserRegistration
    Private db As New DataClasses1DataContext
    Private Sub UserRegistration_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        UserLogin.Hide()

    End Sub

    Private Sub btnRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRegister.Click

        If txtUsername.Text.Trim <> String.Empty _
            AndAlso txtPassword.Text.Trim <> String.Empty _
            AndAlso txtFirstName.Text.Trim <> String.Empty _
            AndAlso txtLastName.Text.Trim <> String.Empty _
            AndAlso txtemail.Text.Trim <> String.Empty Then

            Dim i As New Users1 With {
             .username = txtUsername.Text,
             .password = txtPassword.Text,
             .firstname = txtFirstName.Text,
             .lastname = txtLastName.Text,
             .email = txtemail.Text}
            Dim updateUsers = (From list In db.Users1s).ToList()(0)
            db.Users1s.InsertOnSubmit(i)
            db.SubmitChanges()

            UserLogin.Show()
            Me.Close()

        End If
    End Sub
End Class