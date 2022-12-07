Public Class FormManageMember
    Sub kondisiAwal()
        Call koneksi()
        Da = New SqlClient.SqlDataAdapter("Select MemberID,Name,Email,Handphone,JoinDate from Msmember", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "Msmember")

        DataGridView1.DataSource = (Ds.Tables("Msmember"))
        Call enabledBtnAdd()

        '   If (Ds.Tables(0).Rows.Count > 0) Then
        '  Call autoId()
        ' End If

    End Sub

    'Sub autoId()
    'Dim tmp_id = Ds.Tables(0).Rows(0)("MemberID").ToString().Substring(3, 3)
    'Dim new_id As Integer = CInt(tmp_id) + 1
    '   MemberTXT.Text = "MBR" & new_id.ToString("000")
    'End Sub

    Private Sub FormManageMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        kondisiAwal()
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
        MemberTXT.Text = ""
        NameTxt.Text = ""
        EmailTxt.Text = ""
        HandphoneTxt.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MemberTXT.Text = "" Or NameTxt.Text = "" Or EmailTxt.Text = "" Or HandphoneTxt.Text = "" Then
            MsgBox("Isi Data Dahulu")
        Else
            Call koneksi()
            cmd = New SqlClient.SqlCommand("INSERT INTO Msmember values ('" & MemberTXT.Text & "','" & NameTxt.Text & "','" & EmailTxt.Text & "','" & HandphoneTxt.Text & "','" & Format(Date.Now, "MM-dd-yyyy") & "') ", Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Member Berhasil DItambah")
            Call kondisiAwal()
            Call kosongkanData()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MemberTXT.Text = "" Or NameTxt.Text = "" Or EmailTxt.Text = "" Or HandphoneTxt.Text = "" Then
            MsgBox("Isi Data Dahulu")
        Else
            Call koneksi()
            cmd = New SqlClient.SqlCommand("UPDATE Msmember SET Name='" & NameTxt.Text & "',Email='" & EmailTxt.Text & "',Handphone='" & HandphoneTxt.Text & "' where MemberID='" & MemberTXT.Text & "' ", Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Success", Title:="Edit")
            Call kondisiAwal()
            Call kosongkanData()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Call disabledButtonAdd()

        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim memberID = selectedRow.Cells(0).Value
            Call koneksi()
            cmd = New SqlClient.SqlCommand("SELECT * FROM Msmember where MemberID='" & memberID & "' ", Conn)
            Rd = cmd.ExecuteReader()
            Rd.Read()
            If Rd.HasRows Then
                MemberTXT.Text = Rd.Item("MemberID")
                NameTxt.Text = Rd.Item("Name")
                EmailTxt.Text = Rd.Item("Email")
                HandphoneTxt.Text = Rd.Item("Handphone")
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call kondisiAwal()
        Call kosongkanData()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If MemberTXT.Text = "" Or NameTxt.Text = "" Or EmailTxt.Text = "" Or HandphoneTxt.Text = "" Then
            MsgBox("Isi Data Dahulu")
        Else
            Dim confirm = MsgBox("Kamu yakin?", MessageBoxButtons.YesNo, Title:="Delete")
            If confirm = DialogResult.Yes Then
                Call koneksi()
                cmd = New SqlClient.SqlCommand("delete from Msmember where MemberID='" & MemberTXT.Text & "' ", Conn)
                cmd.ExecuteNonQuery()
                Call kondisiAwal()
                Call kosongkanData()
            End If
        End If

    End Sub
End Class