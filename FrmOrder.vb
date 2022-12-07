Public Class FrmOrder
    Sub kondisiAwal()
        Call koneksi()
        Da = New SqlClient.SqlDataAdapter("Select MenuID,Name,Price from Msmenu", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "Msmenu")
        DataGridView1.DataSource = (Ds.Tables("Msmenu"))

        DataGridView1.Columns(0).Visible = False
        TextBox1.Enabled = False
        Button3.Enabled = False
        Call randomNum()

        Button4.Visible = False
        Button5.Visible = False
        Button1.Enabled = True
        Label5.Visible = False
    End Sub
    Sub randomNum()
        Randomize()
        Dim angkaMax As Integer = 2000000
        Dim acak As Integer = CInt(Int(angkaMax * Rnd()) + 1)
        Label8.Text = acak
    End Sub

    Private Sub FrmOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiAwal()
    End Sub

    Private Sub loadDgv2()
        Da = New SqlClient.SqlDataAdapter("Select * from Detailorder where OrderId='" & Label8.Text & "'", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "Detailorder")
        DataGridView2.DataSource = (Ds.Tables("Detailorder"))
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Call koneksi()

        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim menuId = selectedRow.Cells(0).Value
            cmd = New SqlClient.SqlCommand("SELECT * FROM Msmenu where MenuID='" & menuId & "' ", Conn)
            Rd = cmd.ExecuteReader()
            Rd.Read()
            If Rd.HasRows Then
                MenuName.Text = Rd.Item("Name")
                TextBox1.Text = Rd("MenuID")
                Label6.Text = Rd.Item("Photo")
                PictureBox1.ImageLocation = Label6.Text
                Label6.Visible = False
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                PriceTxt.Text = Rd.Item("Price")

                Button4.Visible = False
                Button5.Visible = False
                Button1.Enabled = True
                Label5.Text = ""
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If
    End Sub

    Sub kosongkanData()
        MenuName.Text = ""
        QtyTxt.Text = ""
        PriceTxt.Text = ""
        TextBox1.Text = ""
        Label6.Text = ""
        PictureBox1.ImageLocation = Label6.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If QtyTxt.Text = "" Or TextBox1.Text = "" Or MenuName.Text = "" Or PriceTxt.Text = "" Then
            MsgBox("Isi Data!!!")
        Else
            Call koneksi()
            cmd = New SqlClient.SqlCommand("INSERT INTO Detailorder values('" & Label8.Text & "','" & TextBox1.Text & "','" & QtyTxt.Text & "','" & PriceTxt.Text & "')", Conn)
            cmd.ExecuteNonQuery()
            Call kosongkanData()
            Button3.Enabled = True
            Da = New SqlClient.SqlDataAdapter("Select * from Detailorder where OrderId='" & Label8.Text & "'", Conn)
            Ds = New DataSet
            Ds.Clear()
            Da.Fill(Ds, "Detailorder")
            DataGridView2.DataSource = (Ds.Tables("Detailorder"))
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call koneksi()
        Dim orderId As Integer = Label8.Text
        cmd = New SqlClient.SqlCommand("INSERT INTO Headerorder values ('" & orderId & "','','','','','','')", Conn)
        cmd.ExecuteNonQuery()

        MsgBox("Success")
        Call kondisiAwal()
        Call kosongkanData()
        ViewOrder.Show()
        ViewOrder.order(orderId)
        Call randomNum()
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Call koneksi()

        If e.RowIndex >= 0 Then

            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView2.Rows(e.RowIndex)
            Dim orderid = selectedRow.Cells(0).Value
            cmd = New SqlClient.SqlCommand("SELECT * FROM Detailorder where Detailid='" & orderid & "' ", Conn)
            Rd = cmd.ExecuteReader()
            Rd.Read()
            If Rd.HasRows Then
                TextBox1.Text = Rd("MenuID")
                PriceTxt.Text = Rd.Item("Price")
                QtyTxt.Text = Rd.Item("Qty")
                Label5.Text = Rd.Item("Detailid")
                Button4.Visible = True
                Button5.Visible = True
                Button1.Enabled = False
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If QtyTxt.Text = "" Or TextBox1.Text = "" Or PriceTxt.Text = "" Then
            MsgBox("Isi Data!!!")
        Else
            Call koneksi()
            cmd = New SqlClient.SqlCommand("Update Detailorder SET Qty='" & QtyTxt.Text & "',Price='" & PriceTxt.Text & "' ", Conn)
            cmd.ExecuteNonQuery()
            Call kosongkanData()
            Call loadDgv2()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call kondisiAwal()
        Call loadDgv2()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If QtyTxt.Text = "" Or TextBox1.Text = "" Or PriceTxt.Text = "" Then
            MsgBox("Isi Data!!!")
        Else
            Call koneksi()
            Dim confirm = MsgBox("Anda Yakin?", MessageBoxButtons.YesNo, "Hapus")
            If confirm = DialogResult.Yes Then
                cmd = New SqlClient.SqlCommand("Delete from Detailorder where Detailid='" & Label5.Text & "'", Conn)
                cmd.ExecuteNonQuery()
                Call kosongkanData()
                Call loadDgv2()
            End If

        End If
    End Sub

End Class