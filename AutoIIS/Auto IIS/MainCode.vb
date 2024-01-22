Imports System.Data.SqlClient
Imports System.Management
Imports Microsoft.Web.Administration
Imports System.Security.AccessControl
Imports System.IO

Public Class MainCode
    Public Shared ComaChar As Char = Chr(34)


    Public Shared Function StartCode() As Boolean
        Dim Requirements As Integer = 0
        Dim TextArray As String() = New String(8) {}
        TextArray = GeneralUtils.ArrayFromTextBox(TextArray)
        '0 = Connect | 1 = Database
        If Not CreateDB(TextArray(0), TextArray(1)) Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_DBName)
            UndoAll(TextArray(0), TextArray(1), TextArray(2), TextArray(4), TextArray(6), Requirements)
            Return False
        Else
            Requirements += 1
            AutoIIS.General_ProgressBar.Value += 5
        End If

        '2 = Username | 3 = Passworda
        If Not CreateUser(TextArray(2), TextArray(3), TextArray(0), TextArray(1)) Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_UserName)
            TextBoxUtils.TextBoxSetRed(AutoIIS.TextBox_Password)
            UndoAll(TextArray(0), TextArray(1), TextArray(2), TextArray(4), TextArray(6), Requirements)
            Return False
        Else
            Requirements += 1
            AutoIIS.General_ProgressBar.Value += 5
        End If

        '6 = FilePath
        If Not CreateAndCopyFiles(TextArray(6)) Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_FilePath)
            UndoAll(TextArray(0), TextArray(1), TextArray(2), TextArray(4), TextArray(6), Requirements)
            Return False
        Else
            Requirements += 1
            AutoIIS.General_ProgressBar.Value += 5
        End If

        '4 = WebName | 5 = Hostname | 6 = FilePath | 7 = SLL
        If Not CreateWebSite(TextArray(4), TextArray(5), TextArray(6)) Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_WebName)
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_HostName)
            UndoAll(TextArray(0), TextArray(1), TextArray(2), TextArray(4), TextArray(6), Requirements)
            Return False
        End If
        AutoIIS.General_ProgressBar.Value += 2
        Return True
    End Function


    Shared Function CreateDB(ServerName As String, DBName As String) As Boolean
        Try
            Using ServerConnection As SqlConnection = New SqlConnection("Server = " + ServerName + ";User ID=" + AutoIIS.dsjSettings.ServerUser + ";Password=" + AutoIIS.dsjSettings.ServerPassword + ";Integrated Security = True;")
                ServerConnection.Open()
                'Crea la DB en la conexión
                Try
                    AutoIIS.General_ProgressBar.Value += 5
                    Using cmd As SqlCommand = New SqlCommand("USE MASTER RESTORE FILELISTONLY FROM DISK = '" + AutoIIS.dsjSettings.DBSrcModel + "'
                    RESTORE DATABASE" + ComaChar.ToString + DBName + ComaChar.ToString + " FROM DISK='" + AutoIIS.dsjSettings.DBSrcModel + "'
                    WITH
                    MOVE '" + DefaultSettings.DBmdf + "' TO '" + AutoIIS.dsjSettings.BakPath + DBName + ".mdf',
                    MOVE '" + DefaultSettings.DBldf + "' TO '" + AutoIIS.dsjSettings.BakPath + DBName + "_log.ldf'", ServerConnection)
                        cmd.ExecuteNonQuery()
                        AutoIIS.General_ProgressBar.Value += 5
                    End Using
                Catch ex As Exception
                    GeneralUtils.ErrorConsole("Error en la restauración/copia de la DB (MainCode.CreateDB). " + ex.Message)
                    AlertType.StringMessage("Error", "Error en la restauración/copia" & vbNewLine & "de la DB (MainCode.CreateDB).")
                    Return False
                End Try
                ServerConnection.Close()
            End Using
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error durante la conexión al servidor (MainCode.CreateDB). " + ex.Message)
            AlertType.StringMessage("Error", "Error durante la conexión" & vbNewLine & "al servidor (MainCode.CreateDB).")
            Return False
        End Try
        GeneralUtils.ErrorConsole("Databse creada con éxito (MainCode.CreateDB).")
        Return True
    End Function

    Shared Function CreateUser(UserName As String, Password As String, ServerName As String, DBName As String) As Boolean
        Try
            Using ServerConnection As SqlConnection = New SqlConnection("Server = " + ServerName + ";Integrated Security = True;")
                ServerConnection.Open()
                AutoIIS.General_ProgressBar.Value += 5
                Try
                    Using cmd As SqlCommand = New SqlCommand(
                        "CREATE LOGIN " + ComaChar.ToString + UserName + ComaChar.ToString + " WITH PASSWORD = '" + Password + "', default_database = " + ComaChar.ToString + DBName + ComaChar.ToString, ServerConnection)
                        cmd.ExecuteNonQuery()
                    End Using
                    AutoIIS.General_ProgressBar.Value += 5
                Catch ex As Exception
                    GeneralUtils.ErrorConsole("Error al crear el usuario (MainCode.CreateUser). " + ex.Message)
                    AlertType.StringMessage("Error", "Error al crear el usuario" & vbNewLine & "asegurate de que no exista" & vbNewLine & " (MainCode.CreateUser).")
                    Return False
                End Try
                ServerConnection.Close()
            End Using
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error durante la creación del usuario (MainCode.CreateUser). " + ex.Message)
            AlertType.StringMessage("Error", "Error durante la creación" & vbNewLine & "del usuario (MainCode.CreateUser).")
            Return False
        End Try
        GeneralUtils.ErrorConsole("Usuario creado con éxito (MainCode.CreateUser).")
        Return True
    End Function


    Shared Function CreateAndCopyFiles(FilePath As String) As Boolean
        Try
            System.IO.Directory.CreateDirectory(FilePath)
            If My.Computer.FileSystem.DirectoryExists(FilePath) Then
                If CopyFiles(FilePath) Then
                    Return True
                End If
            End If
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error durante la creación/copia de las carpetas (MainCode.CreateAndCopyFiles). " + ex.Message)
            AlertType.StringMessage("Error", "Error durante la creación/copia" & vbNewLine & " de las carpetas en" & vbNewLine & "(MainCode.CreateAndCopyFiles).")
            Return False
        End Try
        GeneralUtils.ErrorConsole("Archivos creados con éxito (MainCode.CreateAndCopyFiles).")
        Return True
    End Function

    Shared Function CopyFiles(FilePath As String) As Boolean
        Try
            My.Computer.FileSystem.CopyDirectory(AutoIIS.dsjSettings.SrcModel, FilePath)
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error al copiar los archivos modelo a la carpeta (MainCode.CopyFiles). " + ex.Message)
            AlertType.StringMessage("Error", "Error al copiar los archivos" & vbNewLine & "modelo a la carpeta en" & vbNewLine & "(MainCode.CopyFiles).")
            Return False
        End Try
        GeneralUtils.ErrorConsole("Archivos copiados con éxito (MainCode.CopyFiles).")
        Return True
    End Function

    Shared Function CreateWebSite(WebName As String, Hostname As String, FilePath As String) As Boolean
        'Crea el IIS y lo configura
        If CreateIIS(WebName, Hostname, FilePath) Then
            If ConfigureIIS(FilePath) Then
                AutoIIS.General_ProgressBar.Value += 5
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Shared Function CreateIIS(WebName As String, Hostname As String, FilePath As String) As Boolean
        Try
            Using iisManager As ServerManager = New ServerManager()
                'Crea AppPool
                Try
                    Dim appPoolId As ApplicationPool = iisManager.ApplicationPools(DefaultSettings.IISApplicationPool)
                    If appPoolId Is Nothing Then
                        Dim appPool = iisManager.ApplicationPools.Add(DefaultSettings.IISApplicationPool)
                        appPool.ManagedPipelineMode = ManagedPipelineMode.Integrated
                        iisManager.CommitChanges()
                    End If
                Catch ex As Exception
                    GeneralUtils.ErrorConsole("Error durante la creación de la AppPool (MainCode.CreateWeBSite), es posible que ya exista una llamada " + DefaultSettings.IISApplicationPool + ". " + ex.Message)
                    Return False
                End Try
                Try
                    'Crea Site
                    iisManager.Sites.Add(WebName, DefaultSettings.IISProtocol, DefaultSettings.IISLink & Hostname, FilePath)
                    iisManager.Sites(WebName).ApplicationDefaults.ApplicationPoolName = DefaultSettings.IISApplicationPool
                    For Each item In iisManager.Sites(WebName).Applications
                        item.ApplicationPoolName = DefaultSettings.IISApplicationPool
                    Next
                    Dim config As Configuration = iisManager.GetApplicationHostConfiguration
                    'Activa autenticación anónima
                    'Dim anonymousAuthenticationSection As ConfigurationSection = config.GetSection("system.webServer/security/authentication/anonymousAuthentication", WebName)
                    'anonymousAuthenticationSection("enabled") = True
                    iisManager.CommitChanges()
                    AutoIIS.General_ProgressBar.Value += 5
                Catch ex As Exception
                    GeneralUtils.ErrorConsole("Error durante la creación del IIS (MainCode.CreateWeBSite). " + ex.Message)
                    Return False
                End Try

                If Not SSLCreate(iisManager, WebName, FilePath) Then
                    Return False
                End If
            End Using
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error total durante la creación del IIS (MainCode.CreateWeBSite). " + ex.Message)
            AlertType.StringMessage("Error", "Error total durante la creación" & vbNewLine & "del IIS (MainCode.CreateWeBSite)," & vbNewLine & "asegurate de que no exista.")
            Return False
        End Try
        GeneralUtils.ErrorConsole("IIS creado con éxito (MainCode.CreateIIS).")
        Return True
    End Function

    Public Shared Function ConfigureIIS(FilePath As String) As Boolean
        Dim SettingsPath As String = FilePath + "\settings.xml"
        Try
            My.Computer.FileSystem.CopyFile(DefaultSettings.AppPath & "\SRC\settings_src.xml", SettingsPath, True)
            'Edito el archivo xml como un txt
            EditAsTxt(SettingsPath, AutoIIS.Label_UserName.Text, "userfield")
            EditAsTxt(SettingsPath, AutoIIS.TextBox_Password.Text, "passwordfield")
            EditAsTxt(SettingsPath, AutoIIS.dsjSettings.ConnectionName + ",2433", "serverfield")
            EditAsTxt(SettingsPath, AutoIIS.Label_DBName.Text, "databasefield")
            AutoIIS.General_ProgressBar.Value += 5
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error el archivo " + SettingsPath + " no se pudo editar correctamente (MainCode.CreateWebSite.ConfigureIIS). " + ex.Message)
            AlertType.StringMessage("Error", "Error el archivo " + SettingsPath & vbNewLine & " no se pudo editar correctamente" & vbNewLine & "(MainCode.CreateWebSite.ConfigureIIS).")
            Return False
        End Try
        GeneralUtils.ErrorConsole("IIS settings.xml configurado con éxito (MainCode.ConfigureIIS).")
        Return True
    End Function


    Public Shared Sub EditAsTxt(SettingsPath As String, NewValue As String, OriginalValue As String)
        Try
            Dim fileReader As String = My.Computer.FileSystem.ReadAllText(SettingsPath).Replace(OriginalValue, NewValue)
            My.Computer.FileSystem.WriteAllText(SettingsPath, fileReader, False)
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error el archivo " + SettingsPath + " no se pudo editar correctamente (MainCode.CreateWebSite.XMLEditAsTxt). " + ex.Message)
            AlertType.StringMessage("Error", "Error el archivo " + SettingsPath & vbNewLine & " no se pudo editar correctamente" & vbNewLine & "(MainCode.CreateWebSite.XMLEditAsTxt).")
        End Try
    End Sub


    Shared Function SSLCreate(iisManager As ServerManager, WebName As String, FilePath As String) As Boolean
        FilePath += "\SSLcsv.csv"
        Try
            System.IO.File.Create(FilePath).Dispose()
            Using sw As New System.IO.StreamWriter(FilePath)
                sw.Write(iisManager.Sites(WebName).Id.ToString + ", " + WebName + ", " + WebName) 'DefaultSettings.FixedDomain.Substring(1) + ";"
            End Using
        Catch ex As Exception
            GeneralUtils.ErrorConsole(ex.Message)
            Return False
        End Try
        Try
            Dim cd As String = "cd C:\Program Files\CertifyTheWeb"
            Dim import As String = "certify importcsv " + FilePath
            'Dim import As String = "certify importcsv c:\temp\sites.csv"
            Dim renew As String = "certify renew"
            'Ejecuta el cmd y espera a que acabe
            Dim psi As New ProcessStartInfo With {
            .Verb = "runas",
            .FileName = "cmd.exe",
            .Arguments = String.Format("/k {0} & {1} & {2} & {3}", cd, import, renew, "exit")}
            Process.Start(psi)
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error en la ejecución de los comandos csv (MainCode.CreateWebSite.SSLCreate). " + ex.Message)
            Return False
        End Try
        GeneralUtils.ErrorConsole("SSL Instalado con éxito (MainCode.CreateWebSite.SSLCreate).")
        Return True
    End Function


    Shared Sub UndoAll(ServerName As String, DBName As String, User As String, WebName As String, FilePath As String, Requirements As Integer)
        Dim ServerConnection As SqlConnection = New SqlConnection("Server = " + ServerName + ";Integrated Security = True;")
        ServerConnection.Open()
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -")
        'Elimina la BD
        If Requirements >= 1 Then UndoDB(ServerConnection, DBName)
        'Eliminar el usuario SQL
        If Requirements >= 2 Then UndoUser(ServerConnection, User)

        ServerConnection.Close()
        'Eliminar la carpeta
        If Requirements >= 3 Then UndoFiles(FilePath)
        'Elimina IIS
        If Requirements >= 4 Then UndoIIS(WebName)
        If Requirements = 5 Then 'UndoSSL?
        End If
    End Sub


    Shared Sub UndoFiles(FilePath As String)
        Try
            My.Computer.FileSystem.DeleteDirectory(FilePath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            GeneralUtils.ErrorConsole("Archivos eliminados con éxito (MainCode.UndoAll.UndoFiles).")
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error durante el proceso de eliminación de fitxeros (MainCode.UndoAll.UndoFiles). " + ex.Message)
        End Try
    End Sub


    Shared Sub UndoDB(ServerConnection As SqlConnection, DBName As String)
        Using cmd As SqlCommand = New SqlCommand("DROP DATABASE " + ComaChar.ToString + DBName + ComaChar.ToString, ServerConnection)
            Try
                cmd.ExecuteNonQuery()
                GeneralUtils.ErrorConsole("Database eliminada con éxito (MainCode.UndoAll.UndoDB).")
            Catch ex As Exception
                GeneralUtils.ErrorConsole("Error al borrar la base de datos (MainCode.UndoAll.UndoDB)." + ex.Message)
            End Try
        End Using
    End Sub


    Shared Sub UndoUser(ServerConnection As SqlConnection, User As String)
        Try
            Using cmd As SqlCommand = New SqlCommand("DROP LOGIN " + ComaChar.ToString + User + ComaChar.ToString, ServerConnection)
                cmd.ExecuteNonQuery()
            End Using
            GeneralUtils.ErrorConsole("Usuario eliminado con éxito (MainCode.UndoAll.UndoUser).")
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error durante el proceso de eliminación del usuario (MainCode.UndoAll.UndoUser). " + ex.Message)
        End Try
    End Sub


    Shared Sub UndoIIS(WebName As String)
        Try
            Using iisManager As ServerManager = New ServerManager()
                Dim SiteIIS = iisManager.Sites(WebName)
                iisManager.Sites.Remove(SiteIIS)
                iisManager.CommitChanges()
                'Elimina AppPool
                Try
                    'Console.WriteLine(DefaultSettings.LogsTime + "AppPool eliminada con éxito (MainCode.UndoAll.UndoIIS).")
                Catch ex As Exception
                    GeneralUtils.ErrorConsole("Error durante el proceso de eliminación de la AppPool (MainCode.UndoAll.UndoIIS). " + ex.Message)
                End Try
            End Using
            GeneralUtils.ErrorConsole("IIS Site eliminado con éxito (MainCode.UndoAll.UndoIIS).")
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error durante el proceso de eliminación del sitio Web (MainCode.UndoAll.UndoIIS). " + ex.Message)
        End Try
    End Sub
End Class