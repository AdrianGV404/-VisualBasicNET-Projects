Public Class FocusUtils
    Public Shared Sub FocusText(TextBoxName As TextBox, Text As String)
        'Comprueba si el el texto pasado por parámtero y el color coinciden con el del textbox, si es así elimina el contenido
        Try
            If TextBoxName.Text.Trim.Equals(Text) And TextBoxName.ForeColor.Equals(Color.FromArgb(171, 171, 171)) Then
                TextBoxName.ForeColor = Color.FromArgb(105, 105, 105)
                TextBoxName.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Public Shared Sub LostFocusText(TextBoxName As TextBox, Text As String)
        'Comprueba que el textbox este vació, si es así le asigna color y le pone el texto pasado por parámetro
        Try
            If TextBoxName.Text.Trim.Equals("") Then
                TextBoxName.ForeColor = Color.FromArgb(171, 171, 171)
                TextBoxName.Text = Text
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class