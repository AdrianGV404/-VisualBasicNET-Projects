<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.MinimizeButton = New System.Windows.Forms.Button()
        Me.panel = New System.Windows.Forms.Panel()
        Me.EEO = New System.Windows.Forms.CheckBox()
        Me.StartApp = New System.Windows.Forms.Button()
        Me.idEmpresaDestino = New System.Windows.Forms.TextBox()
        Me.dataBaseDestino = New System.Windows.Forms.TextBox()
        Me.serverDestino = New System.Windows.Forms.TextBox()
        Me.idEmpresaOrigen = New System.Windows.Forms.TextBox()
        Me.dataBaseOrigen = New System.Windows.Forms.TextBox()
        Me.serverOrigen = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'CloseButton
        '
        Me.CloseButton.FlatAppearance.BorderSize = 0
        Me.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.ForeColor = System.Drawing.Color.White
        Me.CloseButton.Location = New System.Drawing.Point(674, 0)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(56, 38)
        Me.CloseButton.TabIndex = 9
        Me.CloseButton.TabStop = False
        Me.CloseButton.Text = "X"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'MinimizeButton
        '
        Me.MinimizeButton.FlatAppearance.BorderSize = 0
        Me.MinimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MinimizeButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimizeButton.ForeColor = System.Drawing.Color.White
        Me.MinimizeButton.Location = New System.Drawing.Point(618, -10)
        Me.MinimizeButton.Name = "MinimizeButton"
        Me.MinimizeButton.Size = New System.Drawing.Size(56, 48)
        Me.MinimizeButton.TabIndex = 8
        Me.MinimizeButton.TabStop = False
        Me.MinimizeButton.Text = "__"
        Me.MinimizeButton.UseVisualStyleBackColor = True
        '
        'panel
        '
        Me.panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panel.Controls.Add(Me.EEO)
        Me.panel.Controls.Add(Me.StartApp)
        Me.panel.Controls.Add(Me.idEmpresaDestino)
        Me.panel.Controls.Add(Me.dataBaseDestino)
        Me.panel.Controls.Add(Me.serverDestino)
        Me.panel.Controls.Add(Me.idEmpresaOrigen)
        Me.panel.Controls.Add(Me.dataBaseOrigen)
        Me.panel.Controls.Add(Me.serverOrigen)
        Me.panel.Controls.Add(Me.Label2)
        Me.panel.Controls.Add(Me.Label1)
        Me.panel.Location = New System.Drawing.Point(1, 39)
        Me.panel.Name = "panel"
        Me.panel.Size = New System.Drawing.Size(728, 410)
        Me.panel.TabIndex = 12
        Me.panel.TabStop = True
        '
        'EEO
        '
        Me.EEO.AutoSize = True
        Me.EEO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EEO.FlatAppearance.BorderSize = 0
        Me.EEO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EEO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.EEO.Location = New System.Drawing.Point(72, 330)
        Me.EEO.Name = "EEO"
        Me.EEO.Size = New System.Drawing.Size(188, 19)
        Me.EEO.TabIndex = 12
        Me.EEO.TabStop = False
        Me.EEO.Text = "Eliminar Empresa Origen"
        Me.EEO.UseVisualStyleBackColor = True
        '
        'StartApp
        '
        Me.StartApp.BackColor = System.Drawing.Color.Transparent
        Me.StartApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.StartApp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.StartApp.FlatAppearance.BorderSize = 0
        Me.StartApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StartApp.ForeColor = System.Drawing.Color.Transparent
        Me.StartApp.Image = CType(resources.GetObject("StartApp.Image"), System.Drawing.Image)
        Me.StartApp.Location = New System.Drawing.Point(327, 172)
        Me.StartApp.Name = "StartApp"
        Me.StartApp.Size = New System.Drawing.Size(74, 74)
        Me.StartApp.TabIndex = 1
        Me.StartApp.TabStop = False
        Me.StartApp.UseVisualStyleBackColor = False
        '
        'idEmpresaDestino
        '
        Me.idEmpresaDestino.AcceptsReturn = True
        Me.idEmpresaDestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.idEmpresaDestino.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.idEmpresaDestino.Font = New System.Drawing.Font("Nirmala UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idEmpresaDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.idEmpresaDestino.Location = New System.Drawing.Point(426, 266)
        Me.idEmpresaDestino.Name = "idEmpresaDestino"
        Me.idEmpresaDestino.Size = New System.Drawing.Size(221, 18)
        Me.idEmpresaDestino.TabIndex = 7
        Me.idEmpresaDestino.Text = "idEmpresa"
        '
        'dataBaseDestino
        '
        Me.dataBaseDestino.AcceptsReturn = True
        Me.dataBaseDestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dataBaseDestino.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dataBaseDestino.Font = New System.Drawing.Font("Nirmala UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataBaseDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.dataBaseDestino.Location = New System.Drawing.Point(426, 200)
        Me.dataBaseDestino.Name = "dataBaseDestino"
        Me.dataBaseDestino.Size = New System.Drawing.Size(221, 18)
        Me.dataBaseDestino.TabIndex = 6
        Me.dataBaseDestino.Text = "DataBase"
        '
        'serverDestino
        '
        Me.serverDestino.AcceptsReturn = True
        Me.serverDestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.serverDestino.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.serverDestino.Font = New System.Drawing.Font("Nirmala UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serverDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.serverDestino.Location = New System.Drawing.Point(426, 130)
        Me.serverDestino.Name = "serverDestino"
        Me.serverDestino.Size = New System.Drawing.Size(221, 18)
        Me.serverDestino.TabIndex = 5
        Me.serverDestino.Text = "Servidor"
        '
        'idEmpresaOrigen
        '
        Me.idEmpresaOrigen.AcceptsReturn = True
        Me.idEmpresaOrigen.BackColor = System.Drawing.Color.WhiteSmoke
        Me.idEmpresaOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.idEmpresaOrigen.Font = New System.Drawing.Font("Nirmala UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idEmpresaOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.idEmpresaOrigen.Location = New System.Drawing.Point(72, 266)
        Me.idEmpresaOrigen.Name = "idEmpresaOrigen"
        Me.idEmpresaOrigen.Size = New System.Drawing.Size(221, 18)
        Me.idEmpresaOrigen.TabIndex = 4
        Me.idEmpresaOrigen.Text = "idEmpresa"
        '
        'dataBaseOrigen
        '
        Me.dataBaseOrigen.AcceptsReturn = True
        Me.dataBaseOrigen.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dataBaseOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dataBaseOrigen.Font = New System.Drawing.Font("Nirmala UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataBaseOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.dataBaseOrigen.Location = New System.Drawing.Point(72, 200)
        Me.dataBaseOrigen.Name = "dataBaseOrigen"
        Me.dataBaseOrigen.Size = New System.Drawing.Size(221, 18)
        Me.dataBaseOrigen.TabIndex = 3
        Me.dataBaseOrigen.Text = "DataBase"
        '
        'serverOrigen
        '
        Me.serverOrigen.AcceptsReturn = True
        Me.serverOrigen.BackColor = System.Drawing.Color.WhiteSmoke
        Me.serverOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.serverOrigen.Font = New System.Drawing.Font("Nirmala UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serverOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.serverOrigen.Location = New System.Drawing.Point(72, 130)
        Me.serverOrigen.Name = "serverOrigen"
        Me.serverOrigen.Size = New System.Drawing.Size(221, 18)
        Me.serverOrigen.TabIndex = 2
        Me.serverOrigen.Text = "Servidor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Black", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(456, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 45)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "DESTINO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Black", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(115, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 45)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ORIGEN"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(730, 450)
        Me.Controls.Add(Me.panel)
        Me.Controls.Add(Me.MinimizeButton)
        Me.Controls.Add(Me.CloseButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.ShowIcon = False
        Me.Text = "TCM - Ten Company Migration"
        Me.panel.ResumeLayout(False)
        Me.panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CloseButton As Button
    Friend WithEvents MinimizeButton As Button
    Friend WithEvents panel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents serverOrigen As TextBox
    Friend WithEvents dataBaseOrigen As TextBox
    Friend WithEvents idEmpresaDestino As TextBox
    Friend WithEvents dataBaseDestino As TextBox
    Friend WithEvents serverDestino As TextBox
    Friend WithEvents idEmpresaOrigen As TextBox
    Friend WithEvents StartApp As Button
    Friend WithEvents EEO As CheckBox
End Class
