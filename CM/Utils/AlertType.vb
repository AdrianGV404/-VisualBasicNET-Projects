Public Class AlertType
    Public Shared Sub StringMessage(Type As String, Text As String)
        'Según el tipo de error mostrará una alerta u otra
        Type = Type.ToLower()
        Select Case Type
            Case "error"
                AlertUP.Size = New System.Drawing.Size(370, 90)
                AlertUP.BackColor = Color.FromArgb(220, 13, 40)
                AlertUP.ErrorMsg.Text = Text
            Case "success"
                AlertUP.Size = New System.Drawing.Size(370, 90)
                AlertUP.BackColor = Color.SeaGreen
                AlertUP.ErrorMsg.Text = Text
        End Select
        AlertUP.ResetAlert()
        AlertUP.Show()
    End Sub


    Public Shared Sub AlertUpClose()
        If Application.OpenForms().OfType(Of AlertUP).Any Then
            AlertUP.Close()
        End If
    End Sub
End Class