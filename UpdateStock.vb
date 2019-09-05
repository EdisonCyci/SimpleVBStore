Public Class UpdateStock

    Private db As New DataClasses1DataContext

    Private Function fresku()
        Dim itemlist1 = From list In db.Items
                        Select list.Description, list.Price, list.Quantity
        DataGridView1.DataSource = itemlist1
        Return Nothing
    End Function

    Private Sub UpdateStock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProjectDataSet1.Items' table. You can move, or remove it, as needed.
        Me.ItemsTableAdapter.Fill(Me.ProjectDataSet1.Items)
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
        Do Until quantity > 0
            Integer.TryParse(InputBox("Enter quantity to be added to stock: "), quantity)
        Loop
        Dim i As New Basket With {
         .ItemID = selectedq.First.ItemId,
         .Description = selectedq.First.Description,
         .Price = selectedq.First.Price,
         .Quantity = quantity,
         .Date = DateTime.Now}
        Dim updateStock = (From list In db.Items
                  Where list.ItemId = selectedq.First.ItemId).ToList()(0)


        updateStock.Quantity += quantity
        fresku()



    End Sub

    Private Sub btnAddNewItem_Click(sender As System.Object, e As System.EventArgs) Handles btnAddNewItem.Click
        NewStockItem.Show()

    End Sub
End Class