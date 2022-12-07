Public Class ViewOrder

    Public Sub order(id As String)
        TextBox1.Text = id
    End Sub

    Sub kondisiAwal()
        Call koneksi()
        'cmd = New SqlClient.SqlCommand("SELECT OrderID from Headerorder", Conn)
        'Rd = cmd.ExecuteReader

        'If Rd.HasRows Then
        'ComboBox1.Items.Clear()
        'Do While Rd.Read
        'ComboBox1.Items.Add(Rd("OrderID"))
        'Loop
        'End If

        'Rd.Close()

        Da = New SqlClient.SqlDataAdapter("SELECT MemberID,Name from Msmember", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "Msmember")

        ComboBox2.DataSource = (Ds.Tables("Msmember"))
        ComboBox2.ValueMember = "MemberID"
        ComboBox2.DisplayMember = "Name"


        Rd.Close()

    End Sub

    Private Sub ViewOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiAwal()
    End Sub

    Sub totalBeli()
        Dim tbeli As Integer
        For line As Integer = 0 To DataGridView1.Rows.Count - 1
            tbeli = tbeli + DataGridView1.Rows(line).Cells(2).Value
        Next
        Label4.Text = tbeli
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Call koneksi()

        Da = New SqlClient.SqlDataAdapter("SELECT Msmenu.Name,Detailorder.Qty,Detailorder.Qty * Detailorder.Price as Total from Msmenu INNER JOIN 
Detailorder ON Msmenu.MenuID = Detailorder.MenuID where OrderId='" & TextBox1.Text & "'", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "Msmenu,Detailorder")
        DataGridView1.DataSource = (Ds.Tables("Msmenu,Detailorder"))

        Call totalBeli()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()
        cmd = New SqlClient.SqlCommand("UPDATE Headerorder SET EmpeloyeeID='" & CashierNav.Label3.Text & "' , MemberID='" & ComboBox2.SelectedValue & "', Date='" & Format(Date.Now, "MM-dd-yyyy") & "'
,Payment='" & Label4.Text & "',kembali='" & bayarTxt.Text - Label4.Text & "',bayar='" & bayarTxt.Text & "' where OrderID='" & TextBox1.Text & "' ", Conn)
        cmd.ExecuteNonQuery()
        MsgBox("Pembayaran Selesai")
        Me.Close()

    End Sub
End Class