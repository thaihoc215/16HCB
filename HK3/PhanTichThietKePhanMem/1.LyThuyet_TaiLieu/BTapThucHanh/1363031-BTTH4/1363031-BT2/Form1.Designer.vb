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
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btnResume = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStop = New System.Windows.Forms.Label()
        Me.TextClock2 = New _1363031_BT2.TextClock()
        Me.TextClock1 = New _1363031_BT2.TextClock()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnStart.Font = New System.Drawing.Font("Modern No. 20", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(16, 176)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(88, 32)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnStop.Font = New System.Drawing.Font("Modern No. 20", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(352, 176)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(88, 32)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnPause
        '
        Me.btnPause.BackColor = System.Drawing.Color.Tomato
        Me.btnPause.Font = New System.Drawing.Font("Modern No. 20", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPause.Location = New System.Drawing.Point(136, 176)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(80, 32)
        Me.btnPause.TabIndex = 3
        Me.btnPause.Text = "Pause"
        Me.btnPause.UseVisualStyleBackColor = False
        '
        'btnResume
        '
        Me.btnResume.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnResume.Font = New System.Drawing.Font("Modern No. 20", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResume.Location = New System.Drawing.Point(248, 176)
        Me.btnResume.Name = "btnResume"
        Me.btnResume.Size = New System.Drawing.Size(80, 32)
        Me.btnResume.TabIndex = 4
        Me.btnResume.Text = "Resume"
        Me.btnResume.UseVisualStyleBackColor = False
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.ListBox1.ForeColor = System.Drawing.Color.Red
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 24
        Me.ListBox1.Location = New System.Drawing.Point(328, 16)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(96, 124)
        Me.ListBox1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 256)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Chương Trình Sẽ Kết Thúc Sau 1 Phút!"
        '
        'lblStop
        '
        Me.lblStop.AutoSize = True
        Me.lblStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.lblStop.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblStop.Location = New System.Drawing.Point(144, 224)
        Me.lblStop.Name = "lblStop"
        Me.lblStop.Size = New System.Drawing.Size(89, 20)
        Me.lblStop.TabIndex = 7
        Me.lblStop.Text = "Time Stop: "
        '
        'TextClock2
        '
        Me.TextClock2.Location = New System.Drawing.Point(205, 247)
        Me.TextClock2.Name = "TextClock2"
        Me.TextClock2.Size = New System.Drawing.Size(288, 127)
        Me.TextClock2.TabIndex = 8
        '
        'TextClock1
        '
        Me.TextClock1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TextClock1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.TextClock1.Location = New System.Drawing.Point(16, 16)
        Me.TextClock1.Name = "TextClock1"
        Me.TextClock1.Size = New System.Drawing.Size(306, 144)
        Me.TextClock1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 307)
        Me.Controls.Add(Me.TextClock2)
        Me.Controls.Add(Me.lblStop)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnResume)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.TextClock1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextClock1 As _1363031_BT2.TextClock
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents btnResume As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStop As System.Windows.Forms.Label
    Friend WithEvents TextClock2 As _1363031_BT2.TextClock

End Class
