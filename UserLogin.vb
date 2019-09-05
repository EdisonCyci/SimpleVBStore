Imports System.Data.SqlClient

Public Class UserLogin
    Private con As SqlConnection
    Private cmd As SqlCommand
    Private da As SqlDataAdapter
    Private ds As DataSet
    Private cb As SqlCommandBuilder 'is required for insert, update or delete
    Private dr As DataRow


   
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim db As New DataClasses1DataContext

        Try
            Dim loggin = From xr In db.Users1s
        Where (xr.username = UsernameTextBox.Text And xr.password = PasswordTextBox.Text)

            If loggin.First.username = UsernameTextBox.Text Then
                MDIParent1.Show()
            Else
                MessageBox.Show("Incorrect log in credentials")

            End If

        Catch ex As System.InvalidOperationException
            MessageBox.Show("Incorrect log in credentials")
        End Try


        




    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        UsernameTextBox.Clear()
        PasswordTextBox.Clear()
        UserRegistration.Show()

    End Sub

    Private Sub UserLogin_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        UsernameTextBox.Clear()
        PasswordTextBox.Clear()
    End Sub


    
    Private Sub UserLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        UsernameTextBox.Clear()
        PasswordTextBox.Clear()
    End Sub
End Class
