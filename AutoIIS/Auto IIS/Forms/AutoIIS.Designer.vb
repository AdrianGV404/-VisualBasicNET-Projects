<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AutoIIS
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutoIIS))
        Me.T3Picture = New System.Windows.Forms.PictureBox()
        Me.AppName = New System.Windows.Forms.Label()
        Me.Close_Button = New System.Windows.Forms.Button()
        Me.Minimize_Button = New System.Windows.Forms.Button()
        Me.Blue_Top = New System.Windows.Forms.Panel()
        Me.SQL_Title = New System.Windows.Forms.Label()
        Me.SQLPicture = New System.Windows.Forms.PictureBox()
        Me.IIS_Title = New System.Windows.Forms.Label()
        Me.IISPicture = New System.Windows.Forms.PictureBox()
        Me.InputPanel = New System.Windows.Forms.Panel()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.Label_SSL = New System.Windows.Forms.Label()
        Me.Json_Reload = New System.Windows.Forms.Button()
        Me.General_ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.DescargarCertify = New System.Windows.Forms.Button()
        Me.Button_NewPassword = New System.Windows.Forms.Button()
        Me.Label_FilePath = New System.Windows.Forms.Label()
        Me.Label_UserName = New System.Windows.Forms.Label()
        Me.Label_DBName = New System.Windows.Forms.Label()
        Me.ShowPassword = New System.Windows.Forms.CheckBox()
        Me.Label_HostName = New System.Windows.Forms.Label()
        Me.Label_WebName = New System.Windows.Forms.Label()
        Me.InfoInput8 = New System.Windows.Forms.Label()
        Me.InfoInput7 = New System.Windows.Forms.Label()
        Me.InfoInput6 = New System.Windows.Forms.Label()
        Me.InfoInput5 = New System.Windows.Forms.Label()
        Me.Title_Info = New System.Windows.Forms.Label()
        Me.TextBox_Password = New System.Windows.Forms.TextBox()
        Me.InfoInput4 = New System.Windows.Forms.Label()
        Me.InfoInput3 = New System.Windows.Forms.Label()
        Me.Title_User = New System.Windows.Forms.Label()
        Me.InfoInput2 = New System.Windows.Forms.Label()
        Me.TextBox_Enterprise = New System.Windows.Forms.TextBox()
        Me.InfoInput1 = New System.Windows.Forms.Label()
        Me.Title_Conect = New System.Windows.Forms.Label()
        Me.Instalar = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.T3Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Blue_Top.SuspendLayout()
        CType(Me.SQLPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IISPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InputPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'T3Picture
        '
        Me.T3Picture.Location = New System.Drawing.Point(6, 3)
        Me.T3Picture.Name = "T3Picture"
        Me.T3Picture.Size = New System.Drawing.Size(32, 32)
        Me.T3Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.T3Picture.TabIndex = 16
        Me.T3Picture.TabStop = False
        '
        'AppName
        '
        Me.AppName.AutoSize = True
        Me.AppName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.AppName.ForeColor = System.Drawing.Color.White
        Me.AppName.Location = New System.Drawing.Point(44, 9)
        Me.AppName.Name = "AppName"
        Me.AppName.Size = New System.Drawing.Size(90, 25)
        Me.AppName.TabIndex = 13
        Me.AppName.Text = "Auto IIS"
        Me.AppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Close_Button
        '
        Me.Close_Button.FlatAppearance.BorderSize = 0
        Me.Close_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Close_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.Close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_Button.ForeColor = System.Drawing.Color.White
        Me.Close_Button.Location = New System.Drawing.Point(660, 0)
        Me.Close_Button.Name = "Close_Button"
        Me.Close_Button.Size = New System.Drawing.Size(56, 38)
        Me.Close_Button.TabIndex = 10
        Me.Close_Button.Text = "X"
        Me.Close_Button.UseCompatibleTextRendering = True
        Me.Close_Button.UseMnemonic = False
        Me.Close_Button.UseVisualStyleBackColor = False
        '
        'Minimize_Button
        '
        Me.Minimize_Button.FlatAppearance.BorderSize = 0
        Me.Minimize_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Minimize_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Minimize_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Minimize_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Minimize_Button.ForeColor = System.Drawing.Color.White
        Me.Minimize_Button.Location = New System.Drawing.Point(606, -2)
        Me.Minimize_Button.Name = "Minimize_Button"
        Me.Minimize_Button.Size = New System.Drawing.Size(54, 40)
        Me.Minimize_Button.TabIndex = 9
        Me.Minimize_Button.Text = "_"
        Me.Minimize_Button.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Minimize_Button.UseCompatibleTextRendering = True
        Me.Minimize_Button.UseMnemonic = False
        Me.Minimize_Button.UseVisualStyleBackColor = False
        '
        'Blue_Top
        '
        Me.Blue_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Blue_Top.Controls.Add(Me.SQL_Title)
        Me.Blue_Top.Controls.Add(Me.SQLPicture)
        Me.Blue_Top.Controls.Add(Me.IIS_Title)
        Me.Blue_Top.Controls.Add(Me.IISPicture)
        Me.Blue_Top.Location = New System.Drawing.Point(0, 37)
        Me.Blue_Top.Name = "Blue_Top"
        Me.Blue_Top.Size = New System.Drawing.Size(716, 107)
        Me.Blue_Top.TabIndex = 16
        '
        'SQL_Title
        '
        Me.SQL_Title.AutoSize = True
        Me.SQL_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SQL_Title.ForeColor = System.Drawing.Color.White
        Me.SQL_Title.Location = New System.Drawing.Point(75, 34)
        Me.SQL_Title.Name = "SQL_Title"
        Me.SQL_Title.Size = New System.Drawing.Size(88, 39)
        Me.SQL_Title.TabIndex = 14
        Me.SQL_Title.Text = "SQL"
        Me.SQL_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SQLPicture
        '
        Me.SQLPicture.BackColor = System.Drawing.Color.Transparent
        Me.SQLPicture.InitialImage = Nothing
        Me.SQLPicture.Location = New System.Drawing.Point(180, 13)
        Me.SQLPicture.Name = "SQLPicture"
        Me.SQLPicture.Size = New System.Drawing.Size(70, 77)
        Me.SQLPicture.TabIndex = 13
        Me.SQLPicture.TabStop = False
        '
        'IIS_Title
        '
        Me.IIS_Title.AutoSize = True
        Me.IIS_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IIS_Title.ForeColor = System.Drawing.Color.White
        Me.IIS_Title.Location = New System.Drawing.Point(441, 34)
        Me.IIS_Title.Name = "IIS_Title"
        Me.IIS_Title.Size = New System.Drawing.Size(63, 39)
        Me.IIS_Title.TabIndex = 15
        Me.IIS_Title.Text = "IIS"
        Me.IIS_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IISPicture
        '
        Me.IISPicture.BackColor = System.Drawing.Color.Transparent
        Me.IISPicture.InitialImage = Nothing
        Me.IISPicture.Location = New System.Drawing.Point(510, 10)
        Me.IISPicture.Name = "IISPicture"
        Me.IISPicture.Size = New System.Drawing.Size(80, 80)
        Me.IISPicture.TabIndex = 14
        Me.IISPicture.TabStop = False
        '
        'InputPanel
        '
        Me.InputPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.InputPanel.Controls.Add(Me.Eliminar)
        Me.InputPanel.Controls.Add(Me.Label_SSL)
        Me.InputPanel.Controls.Add(Me.Json_Reload)
        Me.InputPanel.Controls.Add(Me.General_ProgressBar)
        Me.InputPanel.Controls.Add(Me.DescargarCertify)
        Me.InputPanel.Controls.Add(Me.Button_NewPassword)
        Me.InputPanel.Controls.Add(Me.Label_FilePath)
        Me.InputPanel.Controls.Add(Me.Label_UserName)
        Me.InputPanel.Controls.Add(Me.Label_DBName)
        Me.InputPanel.Controls.Add(Me.ShowPassword)
        Me.InputPanel.Controls.Add(Me.Label_HostName)
        Me.InputPanel.Controls.Add(Me.Label_WebName)
        Me.InputPanel.Controls.Add(Me.InfoInput8)
        Me.InputPanel.Controls.Add(Me.InfoInput7)
        Me.InputPanel.Controls.Add(Me.InfoInput6)
        Me.InputPanel.Controls.Add(Me.InfoInput5)
        Me.InputPanel.Controls.Add(Me.Title_Info)
        Me.InputPanel.Controls.Add(Me.TextBox_Password)
        Me.InputPanel.Controls.Add(Me.InfoInput4)
        Me.InputPanel.Controls.Add(Me.InfoInput3)
        Me.InputPanel.Controls.Add(Me.Title_User)
        Me.InputPanel.Controls.Add(Me.InfoInput2)
        Me.InputPanel.Controls.Add(Me.TextBox_Enterprise)
        Me.InputPanel.Controls.Add(Me.InfoInput1)
        Me.InputPanel.Controls.Add(Me.Title_Conect)
        Me.InputPanel.Controls.Add(Me.Instalar)
        Me.InputPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.InputPanel.Location = New System.Drawing.Point(2, 144)
        Me.InputPanel.Name = "InputPanel"
        Me.InputPanel.Size = New System.Drawing.Size(712, 414)
        Me.InputPanel.TabIndex = 17
        '
        'Eliminar
        '
        Me.Eliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Eliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Eliminar.Location = New System.Drawing.Point(546, 373)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(148, 32)
        Me.Eliminar.TabIndex = 61
        Me.Eliminar.Text = "Eliminar Empresa"
        Me.Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Eliminar.UseVisualStyleBackColor = False
        '
        'Label_SSL
        '
        Me.Label_SSL.AutoSize = True
        Me.Label_SSL.Location = New System.Drawing.Point(431, 251)
        Me.Label_SSL.MaximumSize = New System.Drawing.Size(230, 20)
        Me.Label_SSL.Name = "Label_SSL"
        Me.Label_SSL.Size = New System.Drawing.Size(59, 13)
        Me.Label_SSL.TabIndex = 59
        Me.Label_SSL.Text = "Label_SSL"
        '
        'Json_Reload
        '
        Me.Json_Reload.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Json_Reload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Json_Reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Json_Reload.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Json_Reload.Location = New System.Drawing.Point(311, 373)
        Me.Json_Reload.Name = "Json_Reload"
        Me.Json_Reload.Size = New System.Drawing.Size(133, 32)
        Me.Json_Reload.TabIndex = 58
        Me.Json_Reload.Text = "Recargar JSON"
        Me.Json_Reload.UseVisualStyleBackColor = False
        '
        'General_ProgressBar
        '
        Me.General_ProgressBar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.General_ProgressBar.Location = New System.Drawing.Point(74, 373)
        Me.General_ProgressBar.Name = "General_ProgressBar"
        Me.General_ProgressBar.Size = New System.Drawing.Size(364, 23)
        Me.General_ProgressBar.TabIndex = 11
        Me.General_ProgressBar.Visible = False
        '
        'DescargarCertify
        '
        Me.DescargarCertify.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DescargarCertify.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DescargarCertify.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.DescargarCertify.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.DescargarCertify.Location = New System.Drawing.Point(434, 271)
        Me.DescargarCertify.Name = "DescargarCertify"
        Me.DescargarCertify.Size = New System.Drawing.Size(170, 24)
        Me.DescargarCertify.TabIndex = 57
        Me.DescargarCertify.Text = "Descargar CertifyTheWeb.exe"
        Me.DescargarCertify.UseVisualStyleBackColor = False
        '
        'Button_NewPassword
        '
        Me.Button_NewPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button_NewPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_NewPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Button_NewPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Button_NewPassword.Location = New System.Drawing.Point(186, 274)
        Me.Button_NewPassword.Name = "Button_NewPassword"
        Me.Button_NewPassword.Size = New System.Drawing.Size(58, 22)
        Me.Button_NewPassword.TabIndex = 2
        Me.Button_NewPassword.Text = "Generar"
        Me.Button_NewPassword.UseVisualStyleBackColor = False
        '
        'Label_FilePath
        '
        Me.Label_FilePath.AutoSize = True
        Me.Label_FilePath.Location = New System.Drawing.Point(431, 197)
        Me.Label_FilePath.Name = "Label_FilePath"
        Me.Label_FilePath.Size = New System.Drawing.Size(77, 13)
        Me.Label_FilePath.TabIndex = 56
        Me.Label_FilePath.Text = "Label_FilePath"
        '
        'Label_UserName
        '
        Me.Label_UserName.AutoSize = True
        Me.Label_UserName.Location = New System.Drawing.Point(71, 232)
        Me.Label_UserName.Name = "Label_UserName"
        Me.Label_UserName.Size = New System.Drawing.Size(89, 13)
        Me.Label_UserName.TabIndex = 55
        Me.Label_UserName.Text = "Label_UserName"
        '
        'Label_DBName
        '
        Me.Label_DBName.AutoSize = True
        Me.Label_DBName.Location = New System.Drawing.Point(71, 148)
        Me.Label_DBName.Name = "Label_DBName"
        Me.Label_DBName.Size = New System.Drawing.Size(82, 13)
        Me.Label_DBName.TabIndex = 54
        Me.Label_DBName.Text = "Label_BDName"
        '
        'ShowPassword
        '
        Me.ShowPassword.AutoSize = True
        Me.ShowPassword.Checked = True
        Me.ShowPassword.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowPassword.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ShowPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ShowPassword.Location = New System.Drawing.Point(74, 302)
        Me.ShowPassword.Name = "ShowPassword"
        Me.ShowPassword.Size = New System.Drawing.Size(150, 21)
        Me.ShowPassword.TabIndex = 3
        Me.ShowPassword.Text = "Mostrar contraseña"
        Me.ShowPassword.UseVisualStyleBackColor = True
        '
        'Label_HostName
        '
        Me.Label_HostName.AutoSize = True
        Me.Label_HostName.Location = New System.Drawing.Point(431, 144)
        Me.Label_HostName.Name = "Label_HostName"
        Me.Label_HostName.Size = New System.Drawing.Size(89, 13)
        Me.Label_HostName.TabIndex = 52
        Me.Label_HostName.Text = "Label_HostName"
        '
        'Label_WebName
        '
        Me.Label_WebName.AutoSize = True
        Me.Label_WebName.Location = New System.Drawing.Point(431, 87)
        Me.Label_WebName.Name = "Label_WebName"
        Me.Label_WebName.Size = New System.Drawing.Size(90, 13)
        Me.Label_WebName.TabIndex = 51
        Me.Label_WebName.Text = "Label_WebName"
        '
        'InfoInput8
        '
        Me.InfoInput8.AutoSize = True
        Me.InfoInput8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoInput8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.InfoInput8.Location = New System.Drawing.Point(430, 223)
        Me.InfoInput8.Name = "InfoInput8"
        Me.InfoInput8.Size = New System.Drawing.Size(159, 20)
        Me.InfoInput8.TabIndex = 49
        Me.InfoInput8.Text = "Certificado SSL (exe)"
        Me.InfoInput8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InfoInput7
        '
        Me.InfoInput7.AutoSize = True
        Me.InfoInput7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoInput7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.InfoInput7.Location = New System.Drawing.Point(430, 166)
        Me.InfoInput7.Name = "InfoInput7"
        Me.InfoInput7.Size = New System.Drawing.Size(154, 20)
        Me.InfoInput7.TabIndex = 46
        Me.InfoInput7.Text = "Ruta para la carpeta"
        Me.InfoInput7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InfoInput6
        '
        Me.InfoInput6.AutoSize = True
        Me.InfoInput6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoInput6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.InfoInput6.Location = New System.Drawing.Point(430, 112)
        Me.InfoInput6.Name = "InfoInput6"
        Me.InfoInput6.Size = New System.Drawing.Size(125, 20)
        Me.InfoInput6.TabIndex = 44
        Me.InfoInput6.Text = "Nombre del host"
        Me.InfoInput6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InfoInput5
        '
        Me.InfoInput5.AutoSize = True
        Me.InfoInput5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoInput5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.InfoInput5.Location = New System.Drawing.Point(430, 57)
        Me.InfoInput5.Name = "InfoInput5"
        Me.InfoInput5.Size = New System.Drawing.Size(122, 20)
        Me.InfoInput5.TabIndex = 42
        Me.InfoInput5.Text = "Nombre del sitio"
        Me.InfoInput5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Title_Info
        '
        Me.Title_Info.AutoSize = True
        Me.Title_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_Info.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Title_Info.Location = New System.Drawing.Point(429, 16)
        Me.Title_Info.Name = "Title_Info"
        Me.Title_Info.Size = New System.Drawing.Size(126, 29)
        Me.Title_Info.TabIndex = 41
        Me.Title_Info.Text = "Sitio Web"
        Me.Title_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox_Password
        '
        Me.TextBox_Password.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_Password.Location = New System.Drawing.Point(74, 275)
        Me.TextBox_Password.Name = "TextBox_Password"
        Me.TextBox_Password.Size = New System.Drawing.Size(112, 20)
        Me.TextBox_Password.TabIndex = 1
        '
        'InfoInput4
        '
        Me.InfoInput4.AutoSize = True
        Me.InfoInput4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoInput4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.InfoInput4.Location = New System.Drawing.Point(70, 251)
        Me.InfoInput4.Name = "InfoInput4"
        Me.InfoInput4.Size = New System.Drawing.Size(167, 20)
        Me.InfoInput4.TabIndex = 39
        Me.InfoInput4.Text = "Contraseña (aleatoria)"
        Me.InfoInput4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InfoInput3
        '
        Me.InfoInput3.AutoSize = True
        Me.InfoInput3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoInput3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.InfoInput3.Location = New System.Drawing.Point(70, 201)
        Me.InfoInput3.Name = "InfoInput3"
        Me.InfoInput3.Size = New System.Drawing.Size(174, 20)
        Me.InfoInput3.TabIndex = 37
        Me.InfoInput3.Text = "Nombre del nuevo login"
        Me.InfoInput3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Title_User
        '
        Me.Title_User.AutoSize = True
        Me.Title_User.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_User.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Title_User.Location = New System.Drawing.Point(69, 168)
        Me.Title_User.Name = "Title_User"
        Me.Title_User.Size = New System.Drawing.Size(136, 29)
        Me.Title_User.TabIndex = 36
        Me.Title_User.Text = "SQL Login"
        Me.Title_User.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InfoInput2
        '
        Me.InfoInput2.AutoSize = True
        Me.InfoInput2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoInput2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.InfoInput2.Location = New System.Drawing.Point(70, 116)
        Me.InfoInput2.Name = "InfoInput2"
        Me.InfoInput2.Size = New System.Drawing.Size(177, 20)
        Me.InfoInput2.TabIndex = 34
        Me.InfoInput2.Text = "Nombre de la nueva BD"
        Me.InfoInput2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox_Enterprise
        '
        Me.TextBox_Enterprise.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextBox_Enterprise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_Enterprise.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox_Enterprise.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox_Enterprise.Location = New System.Drawing.Point(74, 57)
        Me.TextBox_Enterprise.Name = "TextBox_Enterprise"
        Me.TextBox_Enterprise.Size = New System.Drawing.Size(170, 20)
        Me.TextBox_Enterprise.TabIndex = 0
        '
        'InfoInput1
        '
        Me.InfoInput1.AutoSize = True
        Me.InfoInput1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.InfoInput1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.InfoInput1.Location = New System.Drawing.Point(69, 16)
        Me.InfoInput1.Name = "InfoInput1"
        Me.InfoInput1.Size = New System.Drawing.Size(117, 29)
        Me.InfoInput1.TabIndex = 32
        Me.InfoInput1.Text = "Empresa"
        Me.InfoInput1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Title_Conect
        '
        Me.Title_Conect.AutoSize = True
        Me.Title_Conect.Cursor = System.Windows.Forms.Cursors.Default
        Me.Title_Conect.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_Conect.ForeColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Title_Conect.Location = New System.Drawing.Point(69, 80)
        Me.Title_Conect.Name = "Title_Conect"
        Me.Title_Conect.Size = New System.Drawing.Size(181, 29)
        Me.Title_Conect.TabIndex = 31
        Me.Title_Conect.Text = "Conexión SQL"
        Me.Title_Conect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Instalar
        '
        Me.Instalar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Instalar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Instalar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Instalar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Instalar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Instalar.ForeColor = System.Drawing.Color.Black
        Me.Instalar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Instalar.Location = New System.Drawing.Point(450, 373)
        Me.Instalar.Name = "Instalar"
        Me.Instalar.Size = New System.Drawing.Size(90, 32)
        Me.Instalar.TabIndex = 7
        Me.Instalar.Text = " Instalar"
        Me.Instalar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Instalar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "es.png")
        Me.ImageList1.Images.SetKeyName(1, "catalonia.png")
        '
        'AutoIIS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(716, 560)
        Me.Controls.Add(Me.InputPanel)
        Me.Controls.Add(Me.Blue_Top)
        Me.Controls.Add(Me.Minimize_Button)
        Me.Controls.Add(Me.Close_Button)
        Me.Controls.Add(Me.AppName)
        Me.Controls.Add(Me.T3Picture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AutoIIS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auto IIS"
        CType(Me.T3Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Blue_Top.ResumeLayout(False)
        Me.Blue_Top.PerformLayout()
        CType(Me.SQLPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IISPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InputPanel.ResumeLayout(False)
        Me.InputPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents T3Picture As PictureBox
    Friend WithEvents AppName As Label
    Friend WithEvents Close_Button As Button
    Friend WithEvents Minimize_Button As Button
    Friend WithEvents Blue_Top As Panel
    Friend WithEvents SQL_Title As Label
    Friend WithEvents SQLPicture As PictureBox
    Friend WithEvents IIS_Title As Label
    Friend WithEvents IISPicture As PictureBox
    Friend WithEvents InputPanel As Panel
    Friend WithEvents Instalar As Button
    Friend WithEvents Title_Conect As Label
    Friend WithEvents InfoInput1 As Label
    Friend WithEvents TextBox_Enterprise As TextBox
    Friend WithEvents InfoInput2 As Label
    Friend WithEvents Title_User As Label
    Friend WithEvents InfoInput3 As Label
    Friend WithEvents InfoInput4 As Label
    Friend WithEvents TextBox_Password As TextBox
    Friend WithEvents Title_Info As Label
    Friend WithEvents InfoInput5 As Label
    Friend WithEvents InfoInput6 As Label
    Friend WithEvents InfoInput7 As Label
    Friend WithEvents InfoInput8 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label_WebName As Label
    Friend WithEvents Label_HostName As Label
    Friend WithEvents ShowPassword As CheckBox
    Friend WithEvents Label_DBName As Label
    Friend WithEvents Label_UserName As Label
    Friend WithEvents Label_FilePath As Label
    Friend WithEvents Button_NewPassword As Button
    Friend WithEvents DescargarCertify As Button
    Friend WithEvents General_ProgressBar As ProgressBar
    Friend WithEvents Json_Reload As Button
    Friend WithEvents Label_SSL As Label
    Friend WithEvents Eliminar As Button
End Class
