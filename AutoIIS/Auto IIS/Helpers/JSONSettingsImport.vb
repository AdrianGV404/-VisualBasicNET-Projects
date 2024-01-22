Public Class JSONSettingsImport
    Public ConnectionName As String = ""
    Public FilePath As String = ""
    Public SSL As String = ""
    'DefaultSettings.PathR + String se puede eliminar si se reemplaza por una ruta completa
    Public DBSrcModel As String = ""
    Public SrcModel As String = ""
    Public BakPath As String = ""
    Public ServerUser As String = ""
    Public ServerPassword As String = ""

    Public Sub New()
    End Sub
    Public Sub New(ConnectionName As String, FilePath As String, SSL As String, DBSrcModel As String, SrcModel As String, BakPath As String, ServerUser As String, ServerPassword As String)
        Me.ConnectionName = ConnectionName
        Me.FilePath = FilePath
        Me.SSL = SSL
        Me.DBSrcModel = DBSrcModel
        Me.SrcModel = SrcModel
        Me.BakPath = BakPath
        Me.ServerUser = ServerUser
        Me.ServerPassword = ServerPassword
    End Sub
End Class
