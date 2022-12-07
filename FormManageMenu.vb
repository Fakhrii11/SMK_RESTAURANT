Public Class FormManageMenu
    Sub kondisiAwal()
        Call koneksi()
        Da = New SqlClient.SqlDataAdapter("Select MenuID,Name,Price from Msmenu", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "Msmenu")
        DataGridView1.DataSource = (Ds.Tables("Msmenu"))
        Call disabledMenuTB()
        Call enabledBtnAdd()

    End Sub


    Sub enabledBtnAdd()
        Button1.Enabled = True
        Button1.FlatAppearance.BorderColor = Color.White
        Button1.BackColor = Color.White
    End Sub

    Sub disabledButtonAdd()
        Button1.Enabled = False
        Button1.FlatAppearance.BorderColor = Color.Gray
        Button1.BackColor = Color.Gray
    End Sub


    Sub disabledMenuTB()
        MenuIDTxt.Enabled = False
        MenuIDTxt.BackColor = Color.WhiteSmoke
        Call koneksi()
        cmd = New SqlClient.SqlCommand("SELECT MenuID FROM Msmenu WHERE MenuID = (SELECT MAX(MenuID) FROM Msmenu)", Conn)
        Rd = cmd.ExecuteReader()
        Rd.Read()
        Dim lastId As Integer = Rd.Item("MenuID")
        MenuIDTxt.Text = lastId + 1

        MenuIDTxt.ForeColor = Color.White
    End Sub

    Sub kosongkanData()
        NameTxt.Text = ""
        PriceTxt.Text = ""
        Label5.Text = ""
        PictureBox1.ImageLocation = ""
    End Sub

    Private Sub FormManageMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiAwal()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.Filter = "*.jpg|"
        OpenFileDialog1.ShowDialog()
        Label5.Text = OpenFileDialog1.FileName
        PictureBox1.ImageLocation = Label5.Text
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If NameTxt.Text = "" Or PriceTxt.Text = "" Or Label5.Text = "" Then
            MsgBox("Data harus diisi dengan lengkap")
        Else
            Call koneksi()
            Dim inputMenu As String
            inputMenu = "INSERT INTO Msmenu values ('" & NameTxt.Text & "','" & PriceTxt.Text & "','" & Label5.Text & "')"
            cmd = New SqlClient.SqlCommand(inputMenu, Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Menu telah diInput!")

            Call kondisiAwal()
            Call kosongkanData()


        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Call disabledButtonAdd()

        If e.RowIndex >= 0 Then
            Call koneksi()
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim menuId = selectedRow.Cells(0).Value
            cmd = New SqlClient.SqlCommand("SELECT * FROM Msmenu where MenuID='" & menuId & "' ", Conn)
            Rd = cmd.ExecuteReader()
            Rd.Read()
            If Rd.HasRows Then
                MenuIDTxt.Text = Rd.Item("MenuID")
                NameTxt.Text = Rd.Item("Name")
                PriceTxt.Text = Rd.Item("Price")
                Label5.Text = Rd.Item("Photo")
                PictureBox1.ImageLocation = Label5.Text
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call kondisiAwal()
        Call kosongkanData()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If NameTxt.Text = "" Or PriceTxt.Text = "" Or Label5.Text = "" Then
            MsgBox("Isi Data Dahulu")
        Else
            Call koneksi()
            cmd = New SqlClient.SqlCommand("UPDATE Msmenu SET Name='" & NameTxt.Text & "', Price='" & PriceTxt.Text & "', Photo='" & Label5.Text & "' where MenuID='" & MenuIDTxt.Text & "' ", Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data '" & NameTxt.Text & "' Berhasil DiEdit")
            Call kondisiAwal()
            Call kosongkanData()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If NameTxt.Text = "" Or PriceTxt.Text = "" Or Label5.Text = "" Then
            MsgBox("Isi Data Dahulu")
        Else
            Dim confirm = MsgBox("Yakin kids pengen hapus " & NameTxt.Text & " ?", MessageBoxButtons.YesNo, "Hapus")
            If confirm = DialogResult.Yes Then
                Call koneksi()
                cmd = New SqlClient.SqlCommand("DELETE from Msmenu where MenuID='" & MenuIDTxt.Text & "' ", Conn)
                cmd.ExecuteNonQuery()
                Call kondisiAwal()
                Call kosongkanData()
            End If
        End If
    End Sub

End Class