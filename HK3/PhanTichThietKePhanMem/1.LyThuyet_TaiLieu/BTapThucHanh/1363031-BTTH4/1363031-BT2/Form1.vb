Public Class Form1
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        TextClock1._BatDau()
        btnPause.Show()
        btnResume.Show()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        TextClock1._KetThuc()
        btnPause.Hide()
        btnResume.Hide()
        lblStop.Text += TextClock1.lblClock.Text
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        TextClock1._Pause()
    End Sub

    Private Sub btnResume_Click(sender As Object, e As EventArgs) Handles btnResume.Click
        TextClock1._Resume()
    End Sub
    Private Sub KhiDungLai(_time As ThoiGian) Handles TextClock1.KhiDung 'add handles kieu nay cung dc
        'thay ko, khi cu nhay 1 giay la no nhay ve ham nay, kiem tra xem dung bang cai thoi gian (vd 1 phut) thi dung lai
        'rooif minh goi cai ham nay vao dau anh, hay de vay thoi, giong nhu nay anh khai bao o duoi form load a???
        '....thi xu ly cai yeu cau Xây dựng delegate và event cho phép xử lý khi đồng hồ chạy đến 1 giá trị cho trước
        'o trong ham nay
        'Hieu 1 cai event va delegate la nhu the nay: Khi dang chayj xu ly trong TextClock1
        'No se tu dong tra ve gia tri time(ThoiGian) ta dung ham nay de kiem tra, neu
        'neu dung cai gia tri can dung lai thi goi hanh dong stop oke
        'à ý em hỏi là giờ nó tự bắt event, hay mình phải gọi nó ở đâu nữa, như dưới form load hay đâu đó???
        'co ham nay thi ko can doan Handles TextClock1.KhiDung tu dong no se hieu bat su kien
        'Ok anh, để e thử xem sao 
        ThoiGian.BatThoiGian(TextClock1.lblClock.Text(), "01:00", AddressOf ThoiGian.DongChuongTrinh)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    'Cai yeu cau la dung event và delegate xu ly truyen du lieu tu cai nay qua cai khac thoy
    'Con cai so sanh do e viet ben nao cung dc, vi du ben kia gui ve thoi gian, ben nay xu ly xem
    'dung chua de quyet dinh dung hay tiep tuc.......
    'Mà em chưa truyền được giá trị qua a ơi, nó mới .có chạy đồng hồ à, chưa truyền qua để so sánh với 

    'với g'ía trị của label được????
    'oke gio lam cai do
    'xu dung event nhu v, trong cai khidunglai benform 1 lien ket voi thang delegate laf oke




End Class
