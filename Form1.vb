Imports System.ComponentModel

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Isilah dengan benar")
        Else
            Call koneksi()
            cmd = New SqlClient.SqlCommand("Select * from Msemployee where Email='" & TextBox1.Text & "'and password='" & TextBox2.Text & "'  ", Conn)
            Rd = cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                MsgBox("Kode atau Password Salah", Title:="Warning")
            Else
                If Rd("Position").ToString = "admin" Then
                    Me.Hide()
                    AdminNav.Show()
                    AdminNav.setData(" " & Rd("Name").ToString & " ", Rd("EmployeeID"))
                ElseIf Rd("Position").ToString = "cashier" Then
                    Me.Hide()
                    CashierNav.Show()
                    CashierNav.setData(Rd("Name"), Rd("EmployeeID"))
                End If
                Call kosongkanTextbox()
            End If
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.PasswordChar = "*"

    End Sub

    Sub kosongkanTextbox()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
            CheckBox1.Text = "Hide"
        Else
            TextBox2.PasswordChar = "*"
            CheckBox1.Text = "Show"
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub
End Class
