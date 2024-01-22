Imports System.Data.SqlClient
Imports System.Management
Public Class ValidateSettings
    Public Shared Function CheckSettings() As Boolean
        Dim TextArray As String() = New String(8) {}
        TextArray = GeneralUtils.ArrayFromTextBox(TextArray)
        If Not CheckServerName(TextArray(0)) Then
            Console.WriteLine("Error al conectarse al servidor, comprueba ConnectionName en DefaultSettings. ")
            Return False
        End If
        AutoIIS.General_ProgressBar.Value += 2
        If Not CheckDBName(TextArray(1), TextArray(0)) Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_DBName)
            Return False
        End If
        AutoIIS.General_ProgressBar.Value += 2
        If Not CheckUser(TextArray(2), TextArray(0), TextArray(1)) Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_UserName)
            Return False
        End If
        If Not CheckPassword(TextArray(3)) Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.TextBox_Password)
            Return False
        End If
        AutoIIS.General_ProgressBar.Value += 5
        If Not CheckWebName(TextArray(4)) Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_WebName)
            Return False
        End If
        AutoIIS.General_ProgressBar.Value += 5
        If Not CheckHostname(TextArray(5)) Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_HostName)
            Return False
        End If
        AutoIIS.General_ProgressBar.Value += 5
        If Not CheckFilePath() Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_FilePath)
            Return False
        End If
        AutoIIS.General_ProgressBar.Value += 2
        If Not CheckSSL() Then
            TextBoxUtils.TextBoxSetRed(AutoIIS.Label_SSL)
            Return False
        End If
        AutoIIS.General_ProgressBar.Value += 5
        Return True
    End Function


    Shared Function CheckServerName(ServerName As String) As Boolean
        Dim Valid As Boolean = False
        Try
            AutoIIS.General_ProgressBar.Value += 1
            'Sólo comprueba que se pueda conectar, para su posterior uso sin fallos
            Using ServerConnection As SqlConnection = New SqlConnection("Server = " + ServerName + ";User ID=" + AutoIIS.dsjSettings.ServerUser + ";Password=" + AutoIIS.dsjSettings.ServerPassword + ";Integrated Security = True;")
                ServerConnection.Open()
                AutoIIS.General_ProgressBar.Value += 1
                Valid = True
                ServerConnection.Close()
                AutoIIS.General_ProgressBar.Value += 1
            End Using
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error durante la conexión al servidor (ValidateSettings.CheckServerName). " + ex.Message)
            AlertType.StringMessage("Error", "Error durante la conexión al" & vbNewLine & "servidor.")
            Return Valid
        End Try
        Return Valid
    End Function


    Shared Function CheckDBName(DBName As String, ServerName As String) As Boolean
        Dim Valid As Boolean = False
        Try
            Using ServerConnection As SqlConnection = New SqlConnection("Server = " + ServerName + ";Integrated Security = True;")
                ServerConnection.Open()
                AutoIIS.General_ProgressBar.Value += 1
                Try
                    'Comprueba que la base de datos no exista
                    Using cmd As SqlCommand = New SqlCommand("
                    declare @dbname varchar(128)
                	set @dbname = N'" + DBName + "'
                       select name from master.dbo.sysdatabases 
                        where ('[' + name + ']' = @dbname or name = @dbname)", ServerConnection)
                        Dim RowsReturned As Integer = cmd.ExecuteScalar()
                        AutoIIS.General_ProgressBar.Value += 1
                        If RowsReturned = 0 Then
                            Valid = True
                        End If
                        AutoIIS.General_ProgressBar.Value += 1
                    End Using
                Catch ex As Exception
                    TextBoxUtils.TextBoxSetRed(AutoIIS.Label_DBName)
                    GeneralUtils.ErrorConsole("Error durante la comprobación del nombre de la BD  (ValidateSettings.CheckDBName). " + ex.Message)
                    AlertType.StringMessage("Error", "Error durante la comprobación" & vbNewLine & "del nombre de la BD." & vbNewLine & "La BD indicada ya existe.")
                    Return Valid
                End Try
                ServerConnection.Close()
            End Using
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error durante la conexión al servidor (ValidateSettings.CheckDBName). " + ex.Message)
            AlertType.StringMessage("Error", "Error durante la conexión" & vbNewLine & "al servidor.")
            Return Valid
        End Try
        Return Valid
    End Function


    Shared Function CheckUser(User As String, ServerName As String, DBName As String) As Boolean
        Dim Valid As Boolean = CorrectFormat.DenySpecialCaracters(User)
        Try
            'Comprueba que los caracteres introducidos sean válidos y el login no exista en la BD
            If Valid Then
                Valid = False
                Try
                    AutoIIS.General_ProgressBar.Value += 1
                    Using ServerConnection As SqlConnection = New SqlConnection("Server = " + ServerName + ";Integrated Security = True;")
                        ServerConnection.Open()
                        AutoIIS.General_ProgressBar.Value += 1
                        Try
                            Using cmd As SqlCommand = New SqlCommand("select loginname from master.dbo.syslogins where name = '" + User + "'", ServerConnection)
                                Dim RowsReturned As Integer = cmd.ExecuteScalar()
                                AutoIIS.General_ProgressBar.Value += 1
                                If RowsReturned = 0 Then
                                    Return True
                                End If
                                AutoIIS.General_ProgressBar.Value += 2
                            End Using
                        Catch ex As Exception
                            GeneralUtils.ErrorConsole("Error durante la comprobación del usuario (ValidateSettings.CheckUser). " + ex.Message)
                            AlertType.StringMessage("Error", "Error en la comprobación" & vbNewLine & "del usuario. Asegurate de que" & vbNewLine & "el usuario no exista.")
                            Return False
                        End Try
                        ServerConnection.Close()
                    End Using
                Catch ex As Exception
                    GeneralUtils.ErrorConsole("Error durante la conexión al servidor (ValidateSettings.CheckUser). " + ex.Message)
                    AlertType.StringMessage("Error", "Error durante la conexión" & vbNewLine & "al servidor")
                    Return False
                End Try
            Else
                GeneralUtils.ErrorConsole("Carácter no valido en (ValidateSettings.CheckUser).")
                AlertType.StringMessage("Error", "Carácter no valido" & vbNewLine & "para el usuario.")
                Return False
            End If
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error durante la comprobación de los caracteres. " + ex.Message)
            AlertType.StringMessage("Error", "Error en la comprobación" & vbNewLine & "de los caracteres.")
            Return False
        End Try
        Return True
    End Function


    Shared Function CheckPassword(Password As String) As Boolean
        'Comprueba que la contraseña pase unos requisitos (se ven claramente en la función)
        If Password.Equals(AutoIIS.Label_UserName.Text) Then
            GeneralUtils.ErrorConsole("La contraseña no puede ser igual al usuario (ValidateSettings.CheckPassword). ")
            AlertType.StringMessage("Error", "La contraseña no puede" & vbNewLine & "ser igual al usuario.")
            TextBoxUtils.TextBoxSetRed(AutoIIS.TextBox_Password)
            Return False
        Else
            Return True
        End If
    End Function


    Shared Function CheckWebName(ServerName As String) As Boolean
        'Comprueba que el nombre de la web tenga almenos 2 puntos i que entre ellos hayan letras o números
        Dim Valid As Boolean = CorrectFormat.DomainFormat(ServerName, 2)
        Return Valid
    End Function


    Shared Function CheckHostname(Hostname As String) As Boolean
        Dim Valid As Boolean = CorrectFormat.DenySpecialCaracters(Hostname)
        If Not Valid Then
            GeneralUtils.ErrorConsole("Carácter no valido en (ValidateSettings.CheckHostname). ")
            AlertType.StringMessage("Error", "Carácter no válido.")
            Return Valid
        End If
        'No se como comprobar que sea valido
        Return Valid
    End Function


    Shared Function CheckFilePath() As Boolean
        'Únicamente se confirma que la ruta indicada exista
        If My.Computer.FileSystem.DirectoryExists(DefaultSettings.FilePathHelper) Then
            AutoIIS.General_ProgressBar.Value += 3
        Else
            GeneralUtils.ErrorConsole("La ruta de la carpeta no existe, '" + DefaultSettings.FilePathHelper + "' (ValidateSettings.CheckFilePath).")
            AlertType.StringMessage("Error", "La ruta de la carpeta no existe.")
            Return False
        End If
        Return True
    End Function


    Shared Function CheckSSL() As Boolean
        If My.Computer.FileSystem.FileExists(AutoIIS.Label_SSL.Text) Then
            Return True
        Else
            GeneralUtils.ErrorConsole("No se ha encontrado ningún exe en la ruta indicada (ValidateSettings.CheckSSL).")
            AlertType.StringMessage("Error", "No se ha encontrado ningún" & vbNewLine & " .exe en la ruta indicada.")
            Return False
        End If
    End Function
End Class