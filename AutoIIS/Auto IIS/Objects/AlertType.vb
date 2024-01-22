Public Class AlertType
    Public Shared Sub StringMessage(Type As String, Text As String)
        'Según el tipo de error mostrará una alerta u otra
        Type = Type.ToLower()
        Select Case Type
            Case "error"
                AlertUP.Size = New System.Drawing.Size(370, 110)
                AlertUP.BackColor = Color.FromArgb(220, 13, 40)
                AlertUP.Done_PictureBox.Visible = False
                AlertUP.Error_PictureBox.Visible = True
                AlertUP.ErrorMsg.Text = Text & vbNewLine & "Ver new_logs.txt para más detalles."
                AutoIIS.General_ProgressBar.Hide()
                AutoIIS.General_ProgressBar.Value = 0
            Case "success"
                AlertUP.Size = New System.Drawing.Size(370, 90)
                AlertUP.BackColor = Color.SeaGreen
                AlertUP.Error_PictureBox.Visible = False
                AlertUP.Done_PictureBox.Visible = True
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