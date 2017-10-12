Public Class DigitTextBox

    Private Sub txtInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInput.KeyPress
        'Kiểm tra kí tự nhập vào 
        If (Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub
End Class
