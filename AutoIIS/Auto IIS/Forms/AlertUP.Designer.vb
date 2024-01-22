<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlertUP
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertUP))
        Me.Error_PictureBox = New System.Windows.Forms.PictureBox()
        Me.ErrorMsg = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ClosePicture = New System.Windows.Forms.PictureBox()
        Me.Timeout = New System.Windows.Forms.Timer(Me.components)
        Me.ShowTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CloseTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Done_PictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.Error_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClosePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Done_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Error_PictureBox
        '
        Me.Error_PictureBox.Location = New System.Drawing.Point(12, 12)
        Me.Error_PictureBox.Name = "Error_PictureBox"
        Me.Error_PictureBox.Size = New System.Drawing.Size(60, 60)
        Me.Error_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Error_PictureBox.TabIndex = 0
        Me.Error_PictureBox.TabStop = False
        Me.Error_PictureBox.Visible = False
        '
        'ErrorMsg
        '
        Me.ErrorMsg.AutoSize = True
        Me.ErrorMsg.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErrorMsg.ForeColor = System.Drawing.Color.White
        Me.ErrorMsg.Location = New System.Drawing.Point(78, 13)
        Me.ErrorMsg.Name = "ErrorMsg"
        Me.ErrorMsg.Size = New System.Drawing.Size(0, 21)
        Me.ErrorMsg.TabIndex = 1
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ClosePicture
        '
        Me.ClosePicture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ClosePicture.Image = CType(resources.GetObject("ClosePicture.Image"), System.Drawing.Image)
        Me.ClosePicture.Location = New System.Drawing.Point(336, 2)
        Me.ClosePicture.Name = "ClosePicture"
        Me.ClosePicture.Size = New System.Drawing.Size(32, 32)
        Me.ClosePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ClosePicture.TabIndex = 2
        Me.ClosePicture.TabStop = False
        '
        'Timeout
        '
        Me.Timeout.Enabled = True
        Me.Timeout.Interval = 5000
        '
        'ShowTimer
        '
        Me.ShowTimer.Enabled = True
        Me.ShowTimer.Interval = 25
        '
        'CloseTimer
        '
        Me.CloseTimer.Interval = 40
        '
        'Done_PictureBox
        '
        Me.Done_PictureBox.Location = New System.Drawing.Point(12, 12)
        Me.Done_PictureBox.Name = "Done_PictureBox"
        Me.Done_PictureBox.Size = New System.Drawing.Size(60, 60)
        Me.Done_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Done_PictureBox.TabIndex = 3
        Me.Done_PictureBox.TabStop = False
        Me.Done_PictureBox.Visible = False
        '
        'AlertUP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(370, 110)
        Me.Controls.Add(Me.Done_PictureBox)
        Me.Controls.Add(Me.ClosePicture)
        Me.Controls.Add(Me.ErrorMsg)
        Me.Controls.Add(Me.Error_PictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AlertUP"
        Me.Opacity = 0.95R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Alert"
        CType(Me.Error_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClosePicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Done_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Error_PictureBox As PictureBox
    Friend WithEvents ErrorMsg As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ClosePicture As PictureBox
    Friend WithEvents Timeout As Timer
    Friend WithEvents ShowTimer As Timer
    Friend WithEvents CloseTimer As Timer
    Friend WithEvents Done_PictureBox As PictureBox
End Class
