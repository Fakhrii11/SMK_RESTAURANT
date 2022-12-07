Public Class ChangePswrd
    Public getID As String
    Private Sub ChangePswrd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewPW.Enabled = False
        ConfirmPW.Enabled = False
    End Sub
    Private Sub OldPW_KeyPress(sender As Object, e As KeyPressEventArgs) Handles OldPW.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            cmd = New SqlClient.SqlCommand("SELECT * FROM Msemployee where EmployeeID='" & getID & "' and Password='" & OldPW.Text & "' ", Conn)
            Rd = cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                NewPW.Enabled = True
                ConfirmPW.Enabled = True
            Else
                MsgBox("Password Lama Salah")
                OldPW.Text = ""
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If NewPW.Text = "" Or ConfirmPW.Text = "" Then
            MsgBox("Password Baru dan Konfirmasi Harus Sama")
        Else
            If NewPW.Text <> ConfirmPW.Text Then
                MsgBox("Password Baru dan Confirm Harus Sama")
            Else
                Call koneksi()
                cmd = New SqlClient.SqlCommand("UPDATE Msemployee set Password='" & ConfirmPW.Text & "' where EmployeeID='" & getID & "' ", Conn)
                cmd.ExecuteNonQuery()
                MsgBox("Password Berhasil Diganti")
                Me.Close()
            End If
        End If
    End Sub

End Class