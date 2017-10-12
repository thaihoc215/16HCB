Public Class TextClock
    Dim _time As ThoiGian = New ThoiGian()
   
    Private Sub TextClock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblClock.Dock = DockStyle.Fill
        lblClock.TextAlign = ContentAlignment.MiddleCenter
    End Sub
    Public Event KhiDung(tg As ThoiGian)
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ' lấy thời gian thực
        'gio xem vong chay cua event
        Timer1.Interval = 100
        lblClock.Text = _time.LayPhut.ToString("00") & ":" & _time.LayGiay().ToString("00")
        _time.LayGiay() += 1
        If _time.LayGiay() = 60 Then
            _time.LayGiay() = 0
            _time.LayPhut() += 1
        End If
        RaiseEvent KhiDung(_time)
    End Sub

    Public Sub _BatDau()
        _time = New ThoiGian()
        Timer1.Enabled = True
        Timer1.Start()
        Form1.ListBox1.Items.Clear()


    End Sub
    Public Sub _KetThuc()
        Timer1.Stop()
        _time = New ThoiGian()
    End Sub

    Public Sub _Pause()
        Timer1.Stop()
        Dim str As String = _time.LayPhut.ToString("00") & ":" & (_time.LayGiay() - 1).ToString("00")
        Form1.ListBox1.Items.Add(str)

    End Sub

    Public Sub _Resume()
        If (_time.LayGiay <> 0 Or _time.LayPhut <> 0) Then
            Timer1.Start()
        End If
    End Sub

    Private Sub lblClock_Click(sender As Object, e As EventArgs) Handles lblClock.Click

    End Sub
End Class

Public Class ThoiGian
    Private _second As Long
    Private _minute As Long
    Public Sub New()
        _second = 0
        _minute = 0
    End Sub
    Public Property LayPhut() As Integer
        Set(value As Integer)
            _minute = value
        End Set
        Get
            LayPhut = _minute
        End Get
    End Property
    Public Property LayGiay() As Integer
        Set(value As Integer)
            _second = value
        End Set
        Get
            LayGiay = _second
        End Get
    End Property

    'khai báo delegate
    Public Delegate Function Sosanh(ByVal str As Object, ByVal str1 As Object) As Boolean
    'hàm0
    Public Shared Function DongChuongTrinh(ByVal str As Object, ByVal str1 As Object) As Boolean
        If Convert.ToString(str) = Convert.ToString(str1) Then
            Return True
        Else
            Return False
        End If
    End Function
    'sử dụng delegate để bắt thời gian
    Public Shared Sub BatThoiGian(ByVal tmp1 As Object, ByVal tmp2 As Object, ByVal cmp As Sosanh)
        If cmp(tmp1, tmp2) = True Then
            Form1.TextClock1.Timer1.Stop()
            MessageBox.Show("Hết Thời Gian!!!Chuong Trình Kết Thúc!!!")
            Form1.Close()
        End If

    End Sub
End Class

