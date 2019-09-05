Public Class TotalSalesReport

    Private Sub TotalSalesReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProjectDataSet1.SaleRecords' table. You can move, or remove it, as needed.
        Me.SaleRecordsTableAdapter.Fill(Me.ProjectDataSet1.SaleRecords)
        'TODO: This line of code loads data into the 'ProjectDataSet1.Items' table. You can move, or remove it, as needed.
        Me.MdiParent = MDIParent1
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class