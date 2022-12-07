Public Class Splash
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Start()
        ProgressBar1.Value += 1
        If ProgressBar1.Value <= 10 Then
            Label2.Text = "Initalizing System"
        ElseIf ProgressBar1.Value <= 30 Then
            Label2.Text = "Loading All Components"
        ElseIf ProgressBar1.Value <= 50 Then
            Label2.Text = "Loading All Components"
        ElseIf ProgressBar1.Value <= 70 Then
            Label2.Text = "Please Wait"
        ElseIf ProgressBar1.Value <= 100 Then
            Label2.Text = "Welcome to SMK Restaurant"

            If ProgressBar1.Value = 100 Then
                Timer1.Dispose()
                Me.Hide()
                Form1.Show()
            End If


        End If
    End Sub

    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class