Public Class ManageOrder
    Sub kondisiAwal()
        Call koneksi()
        Da = New SqlClient.SqlDataAdapter("SELECT Headerorder.OrderID,Msmember.Name,Headerorder.Date,Headerorder.Payment,
Headerorder.bayar,Headerorder.kembali from Msmember INNER JOIN Headerorder ON Msmember.MemberID = Headerorder.MemberID", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "Msmember,Headerorder")
        DataGridView1.DataSource = Ds.Tables("Msmember,Headerorder")

        'FormatCurrency(DataGridView1.Columns(4))
        DataGridView1.Columns(3).DefaultCellStyle.Format = "Rp ###,###"
        DataGridView1.Columns(4).DefaultCellStyle.Format = "Rp ###,###"
        DataGridView1.Columns(5).DefaultCellStyle.Format = "Rp ###,###"
        ' DataGridView1.Columns(4).DefaultCellStyle.Format = 

    End Sub
    Private Sub ManageOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiAwal()

        Dim btn As DataGridViewButtonColumn = New DataGridViewButtonColumn()

        btn.HeaderText = "Action"
        btn.Text = "Delete"
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True
        btn.DefaultCellStyle.ForeColor = Color.Maroon

        DataGridView1.Columns.Add(btn)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 6 Then
            Call koneksi()
            Dim confirm = MsgBox("Yakin ingin hapus?", MessageBoxButtons.YesNo, "Delete")
            If confirm = DialogResult.Yes Then
                cmd = New SqlClient.SqlCommand("Delete from Headerorder where OrderID='" & DataGridView1.Rows(e.RowIndex).Cells(0).Value & "'", Conn)
                cmd.ExecuteNonQuery()
                MsgBox("Succeed")
                Call kondisiAwal()

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()

        Dim dtdate1 As DateTime = DateTime.Parse(dt1.Text)

        Dim dtdate2 As DateTime = DateTime.Parse(dt2.Text)

        cmd = New SqlClient.SqlCommand("SELECT Headerorder.OrderID,Msmember.Name,Headerorder.Date,Headerorder.Payment,
Headerorder.bayar,Headerorder.kembali from Msmember INNER JOIN Headerorder ON Msmember.MemberID = Headerorder.MemberID
where Headerorder.Date between '" & dtdate1.ToString("MM-dd-yyyy") & "' and '" & dtdate2.ToString("MM-dd-yyyy") & "' order by Headerorder.Date desc", Conn)

        Da = New SqlClient.SqlDataAdapter
        Da.SelectCommand = cmd

        Ds = New DataSet

        Ds.Clear()

        Da.Fill(Ds, "Msmember,Headerorder")
        DataGridView1.DataSource = Ds.Tables("Msmember,Headerorder")

    End Sub
End Class