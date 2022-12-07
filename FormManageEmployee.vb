Public Class FormManageEmployee

    Sub kondisiAwal()
        Call koneksi()
        Da = New SqlClient.SqlDataAdapter("Select EmployeeID,Name,Email,Handphone,Position from Msemployee", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "Msemployee")

        DataGridView1.DataSource = (Ds.Tables("Msemployee"))

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("chef")
        ComboBox1.Items.Add("cashier")
        ComboBox1.Items.Add("admin")
        Call kosongkanData()
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

    Sub kosongkanData()
        NameTxt.Text = ""
        EmployeeTXT.Text = ""
        EmailTxt.Text = ""
        HandphoneTxt.Text = ""
        ComboBox1.Text = ""
        PasswordTxt.Text = ""
    End Sub

    Private Sub FormManageEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiAwal()
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()
        If EmployeeTXT.Text = "" Or NameTxt.Text = "" Or EmailTxt.Text = "" Or HandphoneTxt.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Isi data terlebih dahulu!!")
        Else
            Dim InputData As String = "INSERT INTO Msemployee VALUES ('" & EmployeeTXT.Text & "','" & NameTxt.Text & "','" & EmailTxt.Text & "','" & PasswordTxt.Text & "','" & HandphoneTxt.Text & "' ,'" & ComboBox1.Text & "') "
            cmd = New SqlClient.SqlCommand(InputData, Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil DiInput!!")
            Call kondisiAwal()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call koneksi()
        If EmployeeTXT.Text = "" Or NameTxt.Text = "" Or EmailTxt.Text = "" Or HandphoneTxt.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Isi data terlebih dahulu!!")
        Else
            Dim EditData As String = "Update Msemployee set Name='" & NameTxt.Text & "', Email='" & EmailTxt.Text & "', password='" & PasswordTxt.Text & "', Handphone='" & HandphoneTxt.Text & "' , Position='" & ComboBox1.Text & "' where EmployeeID='" & EmployeeTXT.Text & "' "
            cmd = New SqlClient.SqlCommand(EditData, Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil DiEdit!!")
            Call kondisiAwal()
        End If
    End Sub


    Private Sub EmployeeTXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmployeeTXT.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            cmd = New SqlClient.SqlCommand("SELECT * FROM Msemployee where EmployeeID='" & EmployeeTXT.Text & "' ", Conn)
            Rd = cmd.ExecuteReader()
            Rd.Read()
            If Rd.HasRows Then
                NameTxt.Text = Rd.Item("Name")
                EmailTxt.Text = Rd.Item("Email")
                PasswordTxt.Text = Rd.Item("password")
                HandphoneTxt.Text = Rd.Item("Handphone")
                ComboBox1.Text = Rd.Item("Position")
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call koneksi()
        If EmployeeTXT.Text = "" Or NameTxt.Text = "" Or EmailTxt.Text = "" Or HandphoneTxt.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Isi data terlebih dahulu!!")
        Else
            Dim confirm = MsgBox("Yakin kids pengen hapus " & NameTxt.Text & " ?", MessageBoxButtons.YesNo, "Hapus")
            If confirm = DialogResult.Yes Then
                Dim DeleteData As String = "Delete from Msemployee where EmployeeID='" & EmployeeTXT.Text & "' "
                cmd = New SqlClient.SqlCommand(DeleteData, Conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Dihapus!!")
                Call kondisiAwal()
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call kondisiAwal()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Call disabledButtonAdd()
        Dim selectedRow As DataGridViewRow

        If e.RowIndex >= 0 Then
            selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim employeeID = selectedRow.Cells(0).Value
            Call koneksi()
            cmd = New SqlClient.SqlCommand("SELECT * FROM Msemployee where EmployeeID='" & employeeID & "' ", Conn)
            Rd = cmd.ExecuteReader()
            Rd.Read()
            If Rd.HasRows Then
                EmployeeTXT.Text = Rd.Item("EmployeeID")
                NameTxt.Text = Rd.Item("Name")
                EmailTxt.Text = Rd.Item("Email")
                PasswordTxt.Text = Rd.Item("password")
                HandphoneTxt.Text = Rd.Item("Handphone")
                ComboBox1.Text = Rd.Item("Position")
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If

    End Sub

End Class