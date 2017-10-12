Public Class TextClock

    Private Sub TextClock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblClock.Dock = DockStyle.Fill
        lblClock.TextAlign = ContentAlignment.MiddleCenter

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = True ' lấy thời gian thực
        Timer1.Interval = 1000
        lblClock.Text = DateTime.Now.Hour.ToString("00") & ":" & _
            DateTime.Now.Minute.ToString("00") & ":" & _
            DateTime.Now.Second.ToString("00")

    End Sub
End Class
