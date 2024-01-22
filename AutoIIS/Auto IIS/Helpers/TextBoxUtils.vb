Public Class TextBoxUtils
    Public Shared Sub FocusText(TextBoxName As TextBox, Text As String)
        'Establece un color y un fondo a la textbox pasada por parametro cuando se seleciona
        Try
            If TextBoxName.Text.Equals(Text) And TextBoxName.ForeColor <> Color.Black Then
                TextBoxName.ForeColor = Color.Black
                TextBoxName.BackColor = Color.FromArgb(240, 246, 255)
                TextBoxName.Clear()
            End If
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error en TextBoxUtils.FocusText. " + ex.Message)
        End Try
    End Sub


    Public Shared Sub LostFocusText(TextBoxName As TextBox, Text As String)
        'Establece un color y un fondo a la textbox pasada por parametro cuando se desseleciona
        Try
            If TextBoxName.Text.Equals("") Then
                TextBoxName.ForeColor = Color.FromArgb(175, 175, 175)
                TextBoxName.BackColor = Color.FromArgb(240, 246, 255)
                TextBoxName.Text = Text
            End If
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error en TextBoxUtils.LostFocusText. " + ex.Message)
        End Try
    End Sub


    Public Shared Sub TextBoxSetRed(Box As Object)
        'Pinta una textbox pasada por parametro de rojo
        Box.BackColor = Color.FromArgb(255, 180, 173)
        Box.ForeColor = Color.Black
    End Sub


    Public Shared Sub TextFromBFDtoTextBox(Box As TextBox, FBD As FolderBrowserDialog, Text As String)
        Try
            Box.Text = PathTools.BrowserSelectPath(FBD)
            If Box.Text = "" Then
                TextBoxUtils.LostFocusText(Box, Text)
            End If
            Box.ForeColor = Color.Black
            Box.BackColor = Color.FromArgb(240, 246, 255)
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error al cambiar el color de TextBox en TextBoxUtils.TextFromBFDtoTextBox(). " + ex.Message)
        End Try
    End Sub


    Public Shared Sub SetDefaultColorWitchBlack()
        AutoIIS.TextBox_Enterprise.ForeColor = Color.Black
        AutoIIS.TextBox_Enterprise.BackColor = Color.FromArgb(240, 246, 255)
        AutoIIS.TextBox_Password.ForeColor = Color.Black
        AutoIIS.TextBox_Password.BackColor = Color.FromArgb(240, 246, 255)

        AutoIIS.Label_WebName.ForeColor = Color.Black
        AutoIIS.Label_HostName.ForeColor = Color.Black
        AutoIIS.Label_DBName.ForeColor = Color.Black
        AutoIIS.Label_FilePath.ForeColor = Color.Black
        AutoIIS.Label_UserName.ForeColor = Color.Black
        AutoIIS.Label_SSL.ForeColor = Color.Black
    End Sub


    Public Shared Sub SetInitialText(PasswordString As String)
        TextBoxUtils.LostFocusText(AutoIIS.TextBox_Enterprise, DefaultSettings.EnterpriseName)
        AutoIIS.TextBox_Password.Text = PasswordString
    End Sub
End Class