Imports System.IO

Public Class GeneralUtils
    Public Shared Sub FormRoundedBorder(form As Form)
        'Redondea los bordes del formulario pasado por parámetro
        form.FormBorderStyle = FormBorderStyle.None
        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 10, 10), 180, 90)
        p.AddLine(10, 0, form.Width - 10, 0)
        p.AddArc(New Rectangle(form.Width - 10, 0, 10, 10), -90, 90)
        p.AddLine(form.Width, 10, form.Width, form.Height - 10)
        p.AddArc(New Rectangle(form.Width - 10, form.Height - 10, 10, 10), 0, 90)
        p.AddLine(form.Width - 10, form.Height, 10, form.Height)
        p.AddArc(New Rectangle(0, form.Height - 10, 10, 10), 90, 90)
        p.CloseFigure()
        form.Region = New Region(p)
    End Sub


    Public Shared Sub ToolTipShow(ShowOn As Object, msg As String)
        'Creo una tooltip para el objecto pasado por parámetro y su texto
#Disable Warning IDE0017 ' Simplificar la inicialización de objetos
        Dim tip As New ToolTip
#Enable Warning IDE0017 ' Simplificar la inicialización de objetos
        tip.UseFading = True
        tip.UseAnimation = True
        tip.IsBalloon = True
        tip.ShowAlways = True
        tip.AutoPopDelay = 5000
        tip.InitialDelay = 400
        tip.ReshowDelay = 500
        tip.SetToolTip(ShowOn, msg)
    End Sub


    Public Shared Function InsertStringToStringArray(Text As String, ArrayName As String(), Position As Integer) As Integer
        'Inserta un String en un Array de String incrementando el índice
        ArrayName(Position) = Text
        Position += 1
        Return Position
    End Function



    Shared Function ArrayFromTextBox(TextArray As String()) As String()
        'Guarda los valores de los textbox en un array de String
        Try
            Dim Position As Integer = 0

            Position = GeneralUtils.InsertStringToStringArray(AutoIIS.dsjSettings.ConnectionName, TextArray, Position)

            Dim DBName As String = AutoIIS.Label_DBName.Text
            Position = GeneralUtils.InsertStringToStringArray(DBName, TextArray, Position)

            Dim User As String = AutoIIS.Label_UserName.Text
            Position = GeneralUtils.InsertStringToStringArray(User, TextArray, Position)

            Dim Password As String = AutoIIS.TextBox_Password.Text
            Position = GeneralUtils.InsertStringToStringArray(Password, TextArray, Position)

            Dim WebName As String = AutoIIS.Label_WebName.Text
            Position = GeneralUtils.InsertStringToStringArray(WebName, TextArray, Position)

            Dim Hostname As String = AutoIIS.Label_HostName.Text
            Position = GeneralUtils.InsertStringToStringArray(Hostname, TextArray, Position)

            Dim FilePath As String = AutoIIS.Label_FilePath.Text
            Position = GeneralUtils.InsertStringToStringArray(FilePath, TextArray, Position)

        Catch ex As Exception
            ErrorConsole("Error en Function ArrayFromTextBox. " + ex.Message)
            AlertType.StringMessage("Error", "Error interno en:" & vbNewLine & "Validate.ArrayFromTextBox")
        End Try
        Return TextArray
    End Function


    Shared Function RandomPassword(PasswordLength As Integer) As String
        'Genera un password aleatorio
        Dim TextString As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789#$%&+-./^_`´|~"
        Dim RandomNumber As New Random
        Dim Password As String = ""
        For i As Integer = 1 To PasswordLength
            Dim idx As Integer = RandomNumber.Next(0, TextString.Length)
            Password += TextString.Substring(idx, 1)
        Next

        Return Password
    End Function
    Public Shared Sub ErrorConsole(Text As String)
        Dim strMessage As String = "[" + Today + " | " + TimeOfDay.ToString("h:mm:ss tt") + " ] " + Text
        SaveLogs(strMessage)
    End Sub


    Public Shared Sub SaveLogs(strMessage As String)
        Try
            Dim newlogs As String = DefaultSettings.AppPath & "\new_logs.txt"
            Dim generallogs As String = DefaultSettings.AppPath & "\general_logs.txt"

            Dim myFileStream As FileStream = New FileStream("new_logs.txt", FileMode.Create)
            Dim myStream As StreamWriter = New StreamWriter(myFileStream)
            myStream.Write(strMessage)
            myStream.Close()
            myFileStream.Close()
            'Escribe los nuevos errores en el general, y si el general no existe lo crea de nuevo
            If Not System.IO.File.Exists(generallogs) Then
                File.Create(generallogs).Dispose()
            End If
            If System.IO.File.Exists(generallogs) Then
                Using reader As TextReader = New StreamReader(newlogs)
                    Dim contents As String = reader.ReadToEnd
                    Using writer As New System.IO.StreamWriter(generallogs, System.IO.FileMode.Append)
                        writer.Write(contents)
                    End Using
                End Using
            End If
        Catch ex As Exception
            GeneralUtils.ErrorConsole(ex.Message)
            MsgBox("Error durante el guardado de log.")
        End Try
    End Sub

End Class
