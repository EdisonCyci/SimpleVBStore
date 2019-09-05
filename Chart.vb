Imports System.Data.SqlClient

Public Class Chart
    Private db As New DataClasses1DataContext

    Private Function fresku()
        Dim itemlist1 = From list In db.Baskets
                        Select list.Description, list.Price, list.Quantity
        DataGridView1.DataSource = itemlist1
        Return Nothing
    End Function

    Private Sub Chart_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent1
        Dim itemlist = From list In db.Items
                       Select list.Description

        ComboBox1.DataSource = itemlist
        fresku()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim selectedq = From list In db.Items
            Where (list.Description = ComboBox1.SelectedItem.ToString)
        Dim quantity As Integer
        Do Until quantity > 0 And quantity < selectedq.First.Quantity
            Integer.TryParse(InputBox("Enter quantity (stock: " & selectedq.First.Quantity.ToString & " )"), quantity)
        Loop
        Dim i As New Basket With {
         .ItemID = selectedq.First.ItemId,
         .Description = selectedq.First.Description,
         .Price = selectedq.First.Price,
         .Quantity = quantity,
         .Date = DateTime.Now}
        Dim updateStock = (From list In db.Items
                  Where list.ItemId = selectedq.First.ItemId).ToList()(0)
        

        updateStock.Quantity -= quantity
        db.Baskets.InsertOnSubmit(i)
        db.SubmitChanges()
        fresku()



    End Sub


    Private Sub btnProcess_Click(sender As System.Object, e As System.EventArgs) Handles btnProcess.Click

        Dim selectedq = From list In db.Baskets
        For value As Integer = 0 To selectedq.Count - 1
            Dim i As New SaleRecord With {
             .ItemID = selectedq.First.ItemID,
             .Description = selectedq.First.Description,
             .Price = selectedq.First.Price,
             .Quantity = selectedq.First.Quantity,
             .Date = DateTime.Now}
            Dim delete = (From bb In db.Baskets
                        Where bb.ItemID = selectedq.First.ItemID).ToList()(0)

            db.SaleRecords.InsertOnSubmit(i)

            db.Baskets.DeleteOnSubmit(delete)
            db.SubmitChanges()
            selectedq = From list In db.Baskets
        Next
        fresku()
    End Sub

End Class
