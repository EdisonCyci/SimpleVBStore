Public Class NewStockItem
    Private db As New DataClasses1DataContext
    Private Sub btnAddNewItem_Click(sender As System.Object, e As System.EventArgs) Handles btnAddNewItem.Click
        Me.MdiParent = MDIParent1
        Try
            If txtItemId.Text.Trim <> String.Empty _
                AndAlso txtDescription.Text.Trim <> String.Empty _
                AndAlso txtPrice.Text.Trim <> String.Empty _
                AndAlso txtQuantity.Text.Trim <> String.Empty Then

                Dim i As New Item With {
                 .ItemId = txtItemId.Text,
                 .Description = txtDescription.Text,
                 .Price = txtPrice.Text,
                 .Quantity = txtQuantity.Text}
                Dim updateItems = (From list In db.Items).ToList()(0)
                db.Items.InsertOnSubmit(i)
                db.SubmitChanges()
            End If
            Catch ex As System.InvalidOperationException
            MessageBox.Show("Incorrect ItemId(it is primary key so watch out for duplicates.)")
        End Try

        Me.Close()


    End Sub

    
    Private Sub NewStockItem_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class