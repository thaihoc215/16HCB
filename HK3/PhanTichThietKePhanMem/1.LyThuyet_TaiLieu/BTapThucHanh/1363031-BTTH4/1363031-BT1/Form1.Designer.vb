<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.TextClock1 = New _1363031_BT1.TextClock()
        Me.DigitTextBox1 = New _1363031_BT1.DigitTextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label1.Location = New System.Drawing.Point(128, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Textbox chỉ nhập số: "
        '
        'TextClock1
        '
        Me.TextClock1.Location = New System.Drawing.Point(64, 152)
        Me.TextClock1.Name = "TextClock1"
        Me.TextClock1.Size = New System.Drawing.Size(296, 80)
        Me.TextClock1.TabIndex = 2
        '
        'DigitTextBox1
        '
        Me.DigitTextBox1.Location = New System.Drawing.Point(64, 40)
        Me.DigitTextBox1.Name = "DigitTextBox1"
        Me.DigitTextBox1.Size = New System.Drawing.Size(322, 104)
        Me.DigitTextBox1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 261)
        Me.Controls.Add(Me.TextClock1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DigitTextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DigitTextBox1 As _1363031_BT1.DigitTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextClock1 As _1363031_BT1.TextClock

End Class
