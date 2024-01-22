Public Class PathTools
    Public Shared Function BrowserSelectPath(FolderBrowserDialog As FolderBrowserDialog) As String
        'Seleciona una ruta con FolderBrowserDialog y la devuelve
        Dim Path As String = ""
        Try
            FolderBrowserDialog.ShowDialog()
            Path = FolderBrowserDialog.SelectedPath
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error al selecionar la ruta PathTools.BrowserSelectedPath()." + ex.Message)
        End Try
        Return Path
    End Function
End Class