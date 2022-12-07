<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePswrd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OldPW = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ConfirmPW = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NewPW = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(204, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(292, 45)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Change Password"
        '
        'OldPW
        '
        Me.OldPW.Location = New System.Drawing.Point(270, 96)
        Me.OldPW.Name = "OldPW"
        Me.OldPW.Size = New System.Drawing.Size(306, 27)
        Me.OldPW.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(55, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 31)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Old Password"
        '
        'ConfirmPW
        '
        Me.ConfirmPW.Location = New System.Drawing.Point(270, 201)
        Me.ConfirmPW.Name = "ConfirmPW"
        Me.ConfirmPW.Size = New System.Drawing.Size(306, 27)
        Me.ConfirmPW.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(55, 197)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(197, 31)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Confirm Password"
        '
        'NewPW
        '
        Me.NewPW.Location = New System.Drawing.Point(270, 148)
        Me.NewPW.Name = "NewPW"
        Me.NewPW.Size = New System.Drawing.Size(306, 27)
        Me.NewPW.TabIndex = 58
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(55, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 31)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "New Password"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(270, 253)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 53)
        Me.Button1.TabIndex = 63
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(270, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 20)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Enter untuk konfirmasi "
        '
        'ChangePswrd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(705, 329)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.OldPW)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ConfirmPW)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NewPW)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ChangePswrd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChangePswrd"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents OldPW As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ConfirmPW As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NewPW As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
End Class
