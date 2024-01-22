
Imports System.IO
Public Class AutoIIS

    'Creo un archivo logs para Console.WriteLine

    Public Shared dsjSettings As New JSONSettingsImport


    Public Shared PasswordString As String = GeneralUtils.RandomPassword(10)


    Private Sub AutoIIS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadImages()
            dsjSettings = LoadSettings()
            If dsjSettings Is Nothing Then
                Throw New Exception("No ha podido cargar los settings")
            End If
            TextBox_Password.UseSystemPasswordChar = Not TextBox_Password.UseSystemPasswordChar
            TextBox_Password.ForeColor = Color.Black

            LoadText()
        Catch ex As Exception
            GeneralUtils.ErrorConsole(ex.Message)
        End Try
    End Sub


    Public Shared Function LoadSettings() As JSONSettingsImport
        Try
            Dim JsonFile As String = My.Application.Info.DirectoryPath + "\DefaultSettingsJSON.json"
            Dim JsonObj As New JSONSettingsImport()

            If My.Computer.FileSystem.FileExists(JsonFile) Then
                Dim allText As String = My.Computer.FileSystem.ReadAllText(JsonFile)
                JsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JSONSettingsImport)(allText)
                If Not JsonObj.FilePath.Contains("\") Then JsonObj.FilePath += "\"
                If Not JsonObj.BakPath.Contains("\") Then JsonObj.BakPath += "\"
                If Not JsonObj.ServerUser Is Nothing Then JsonObj.ServerUser = "SERVERUSER"
                If Not JsonObj.ServerPassword Is Nothing Then JsonObj.ServerPassword = "SERVER_PASSWORD"
            Else
                JsonObj = New JSONSettingsImport(
                "(local)",
                "E:\",
                "C:\Program Files\CertifyTheWeb\Certify.UI.exe",
                DefaultSettings.AppPath + "\SRC\DB\t3Backup.bak",
                DefaultSettings.AppPath & "\SRC\Files",
                "C:\ServerT3\DB\",
                "SERVERUSER",
                "SERVER_PASSWORD")
                Dim JsonConvert As String = Newtonsoft.Json.JsonConvert.SerializeObject(JsonObj, Newtonsoft.Json.Formatting.Indented)
                Try
                    Using SW As New StreamWriter(JsonFile)
                        SW.Write(JsonConvert)
                        SW.Close()
                    End Using
                Catch ex As Exception
                    GeneralUtils.ErrorConsole(ex.Message)
                    Return Nothing
                End Try
            End If
            DefaultSettings.FilePathHelper = JsonObj.FilePath
            Return JsonObj
        Catch ex As Exception
            GeneralUtils.ErrorConsole(ex.Message)
            Return Nothing
        End Try
    End Function


    Private Sub LoadImages()
        Try
            SQLPicture.Image = My.Resources.ImgResource.SQL_Resize
            IISPicture.Image = My.Resources.ImgResource.IIS_Resize
            T3Picture.Image = My.Resources.ImgResource.T3_Resize
            Instalar.Image = My.Resources.ImgResource.install_icon.GetThumbnailImage(20, 20, Nothing, IntPtr.Zero)
            Instalar.Image = My.Resources.ImgResource.install_icon.GetThumbnailImage(20, 20, Nothing, IntPtr.Zero)
            Eliminar.Image = My.Resources.ImgResource.trash.GetThumbnailImage(20, 20, Nothing, IntPtr.Zero)
        Catch ex As Exception
            GeneralUtils.ErrorConsole(ex.Message)
        End Try
    End Sub


    Private Sub LoadText()
        Try
            TextBoxUtils.SetInitialText(PasswordString)
            Label_HostName.Text = "Empresa.NAME.es"
            Label_HostName.ForeColor = Color.FromArgb(175, 175, 175)
            Label_WebName.Text = "Empresa.NAME.es"
            Label_WebName.ForeColor = Color.FromArgb(175, 175, 175)
            Label_DBName.Text = "Empresa" + DefaultSettings.FixedDomainDB
            Label_DBName.ForeColor = Color.FromArgb(175, 175, 175)
            Label_UserName.Text = "Empresa" + DefaultSettings.ServiceDomainDB
            Label_UserName.ForeColor = Color.FromArgb(175, 175, 175)
            Label_FilePath.Text = dsjSettings.FilePath + "Empresa" + DefaultSettings.ServiceDomain
            Label_FilePath.ForeColor = Color.FromArgb(175, 175, 175)
            Label_SSL.Text = "C:\Program Files\CertifyTheWeb\Certify.UI.exe"
            Label_SSL.ForeColor = Color.FromArgb(175, 175, 175)
        Catch ex As Exception
            GeneralUtils.ErrorConsole(ex.Message)
        End Try
    End Sub


    Private Sub Instalar_Click(sender As Object, e As EventArgs) Handles Instalar.Click
        Json_Reload.Visible = False
        OnClickStartCode()
        Json_Reload.Visible = True
    End Sub


    Private Sub OnClickStartCode()
        General_ProgressBar.Show()
        TextBoxUtils.SetDefaultColorWitchBlack()
        Cursor.Current = Cursors.AppStarting

        If ValidateSettings.CheckSettings() Then
            General_ProgressBar.Value += 10
            Cursor.Current = Cursors.Default

            If MainCode.StartCode() Then
                General_ProgressBar.Hide()
                General_ProgressBar.Value = 0
                AlertType.StringMessage("Success", "IIS creado con éxito.")
            Else
                AlertType.StringMessage("Error", "Algo ha fallado durante" & vbNewLine & "la instalación (MainCode.StartCode).")
            End If
        End If
    End Sub


    Private Sub Minimize_Button_Click(sender As Object, e As EventArgs) Handles Minimize_Button.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    Private Sub Button_Close_Click(sender As Object, e As EventArgs) Handles Close_Button.Click
        'Cierra este form y cierra las alertas en caso de que esten abiertas
        AlertType.AlertUpClose()
        Me.Close()
        'Si se ha hecho algun proceso erroneo o algo llamar al botón cancelar
    End Sub


    'Funciones necesarias para arrastrar la ventana al ser FormBorderStyle = None
    Dim IsDraggingForm As Boolean = False
    Private MousePos As New System.Drawing.Point(0, 0)
    Private Sub MyBase_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            IsDraggingForm = True
            MousePos = e.Location
        End If
    End Sub

    Private Sub MyBase_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        If IsDraggingForm Then
            Dim temp As Point = New Point(Me.Location + (e.Location - MousePos))
            Me.Location = temp
        End If
    End Sub

    Private Sub MyBase_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then IsDraggingForm = False
    End Sub


    Private Sub Blue_Top_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Blue_Top.MouseDown
        If e.Button = MouseButtons.Left Then
            IsDraggingForm = True
            MousePos = e.Location
        End If
    End Sub

    Private Sub Blue_Top_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Blue_Top.MouseMove
        If IsDraggingForm Then
            Dim temp As Point = New Point(Me.Location + (e.Location - MousePos))
            Me.Location = temp
        End If
    End Sub

    Private Sub Blue_Top_MouseUp(sender As Object, e As MouseEventArgs) Handles Blue_Top.MouseUp
        If e.Button = MouseButtons.Left Then IsDraggingForm = False
    End Sub

    Private Sub Button_NewPassword_Click(sender As Object, e As EventArgs) Handles Button_NewPassword.Click
        PasswordString = GeneralUtils.RandomPassword(10)
        TextBox_Password.Text = PasswordString
    End Sub

    Private Sub TextBox_Enterprise_GotFocus(sender As Object, e As EventArgs) Handles TextBox_Enterprise.GotFocus
        TextBoxUtils.FocusText(TextBox_Enterprise, DefaultSettings.EnterpriseName)
    End Sub
    Private Sub TextBox_Enterprise_LostFocus(sender As Object, e As EventArgs) Handles TextBox_Enterprise.LostFocus

        If TextBox_Enterprise.Text Is "" Then
            DefaultSettings.EnterpriseName = "Nombre de la empresa"
            Label_HostName.Text = "Empresa.NAME.es"
            Label_HostName.ForeColor = Color.FromArgb(175, 175, 175)
            Label_WebName.Text = "Empresa.NAME.es"
            Label_WebName.ForeColor = Color.FromArgb(175, 175, 175)
            Label_DBName.Text = "Empresa" + DefaultSettings.FixedDomainDB
            Label_DBName.ForeColor = Color.FromArgb(175, 175, 175)
            Label_UserName.Text = "Empresa" + DefaultSettings.ServiceDomainDB
            Label_UserName.ForeColor = Color.FromArgb(175, 175, 175)
            Label_FilePath.Text = DefaultSettings.FilePathHelper + Label_UserName.Text
            Label_FilePath.ForeColor = Color.FromArgb(175, 175, 175)
        Else
            DefaultSettings.EnterpriseName = TextBox_Enterprise.Text

            Label_HostName.Text = DefaultSettings.EnterpriseName + DefaultSettings.FixedDomain
            Label_HostName.ForeColor = Color.Black

            Label_WebName.Text = Label_HostName.Text
            Label_WebName.ForeColor = Color.Black
            DefaultSettings.WebName = Label_WebName.Text

            Label_DBName.Text = DefaultSettings.EnterpriseName + DefaultSettings.FixedDomainDB
            Label_DBName.ForeColor = Color.Black
            DefaultSettings.DatabaseName = Label_DBName.Text

            Label_UserName.Text = DefaultSettings.EnterpriseName + DefaultSettings.ServiceDomainDB
            Label_UserName.ForeColor = Color.Black
            DefaultSettings.UserName = Label_UserName.Text
            dsjSettings.FilePath = DefaultSettings.FilePathHelper + Label_UserName.Text
            Label_FilePath.Text = dsjSettings.FilePath
            Label_FilePath.ForeColor = Color.Black
        End If
        TextBoxUtils.LostFocusText(TextBox_Enterprise, DefaultSettings.EnterpriseName)
    End Sub

    Private Sub TextBox_Password_GotFocus(sender As Object, e As EventArgs) Handles TextBox_Password.GotFocus
        TextBoxUtils.FocusText(TextBox_Password, PasswordString)
    End Sub
    Private Sub TextBox_Password_LostFocus(sender As Object, e As EventArgs) Handles TextBox_Password.LostFocus
        TextBoxUtils.LostFocusText(TextBox_Password, PasswordString)
    End Sub

    Private Sub ShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPassword.CheckedChanged
        TextBox_Password.UseSystemPasswordChar = Not TextBox_Password.UseSystemPasswordChar
        TextBox_Password.ForeColor = Color.Black
    End Sub

    Private Sub Button_NewPassword_MouseHover(sender As Object, e As EventArgs) Handles Button_NewPassword.MouseHover
        GeneralUtils.ToolTipShow(Button_NewPassword, "Generar una nueva contraseña")
    End Sub

    Private Sub DescargarCertify_Click(sender As Object, e As EventArgs) Handles DescargarCertify.Click
        Process.Start("https://certifytheweb.s3.amazonaws.com/downloads/CertifyTheWebSetup.exe")
    End Sub

    Private Sub Json_Reload_Click(sender As Object, e As EventArgs) Handles Json_Reload.Click
        Try
            LoadImages()
            dsjSettings = LoadSettings()
            If dsjSettings Is Nothing Then
                Throw New Exception("No ha podido cargar los settings")
            Else
                AlertType.StringMessage("Success", "JSON Cargado con éxito.")
            End If
        Catch ex As Exception
            GeneralUtils.ErrorConsole(ex.Message)
        End Try
    End Sub

    Private Sub Label_SSL_MouseHover(sender As Object, e As EventArgs) Handles Label_SSL.MouseHover
        GeneralUtils.ToolTipShow(Label_SSL, "Ruta donde se ha instalado CertifyTheWeb (tiene que ser el .exe) " & vbNewLine & Label_SSL.Text)
    End Sub

    Private Sub Json_Reload_MouseHover(sender As Object, e As EventArgs) Handles Json_Reload.MouseHover
        GeneralUtils.ToolTipShow(Json_Reload, "Recargar configuraciones del archivo JsonSettingsImport")
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click
        Dim result As Integer = MessageBox.Show("Se borraran todos los datos asociados a esta Empresa, deseas continuar?", "Auto IIS", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
        ElseIf result = DialogResult.No Then
        ElseIf result = DialogResult.Yes Then
            result = MessageBox.Show("Estás seguro?", "Auto IIS", MessageBoxButtons.YesNo)
            If result = DialogResult.Cancel Then
            ElseIf result = DialogResult.No Then
            ElseIf result = DialogResult.Yes Then
                MainCode.UndoAll(dsjSettings.ConnectionName, Label_DBName.Text, Label_UserName.Text, Label_WebName.Text, Label_FilePath.Text, 5)
                AlertType.StringMessage("Success", "Archivos eliminados con." & vbNewLine & "éxito.")
            End If
        End If
    End Sub

    Private Sub TextBox_Enterprise_MouseHover(sender As Object, e As EventArgs) Handles TextBox_Enterprise.MouseHover
        GeneralUtils.ToolTipShow(TextBox_Enterprise, "Nombre de la Empresa")
    End Sub

    Private Sub TextBox_Password_MouseHover(sender As Object, e As EventArgs) Handles TextBox_Password.MouseHover
        GeneralUtils.ToolTipShow(TextBox_Password, "Contraseña para el usuario de la nueva BD")
    End Sub

    Private Sub Label_DBName_MouseHover(sender As Object, e As EventArgs) Handles Label_DBName.MouseHover
        GeneralUtils.ToolTipShow(Label_DBName, "Nombre para la nueva base de datos (depende del nombre de la empresa)")
    End Sub

    Private Sub Label_UserName_MouseHover(sender As Object, e As EventArgs) Handles Label_UserName.MouseHover
        GeneralUtils.ToolTipShow(Label_UserName, "Nombre para el nuevo usuario de la base de datos (depende del nombre de la empresa)")
    End Sub

    Private Sub Label_WebName_MouseHover(sender As Object, e As EventArgs) Handles Label_WebName.MouseHover
        GeneralUtils.ToolTipShow(Label_WebName, "Nombre con el que se referira en el IIS al nuevo sitio (depende del nombre de la empresa)")
    End Sub

    Private Sub Label_HostName_MouseHover(sender As Object, e As EventArgs) Handles Label_HostName.MouseHover
        GeneralUtils.ToolTipShow(Label_HostName, "Dirección con la cual se accederá al sitio (depende del nombre de la empresa)")
    End Sub

    Private Sub Label_FilePath_MouseHover(sender As Object, e As EventArgs) Handles Label_FilePath.MouseHover
        GeneralUtils.ToolTipShow(Label_FilePath, "Ruta donde se guardaran todos los archivos del nuevo sitio (depende del nombre de la empresa)")
    End Sub

    Private Sub Eliminar_MouseHover(sender As Object, e As EventArgs) Handles Eliminar.MouseHover
        GeneralUtils.ToolTipShow(Eliminar, "Elimina todos los archivos, carpetas, BD + usuario y sitio IIS (depende del nombre de la empresa)")
    End Sub
End Class