
Public Class MainForm
    'Boolean público para eliminar la Empresa de origen
    Public eeoBolean As Boolean = False
    'Botón Minimizar
    Private Sub MinimizeButton_Click(sender As Object, e As EventArgs) Handles MinimizeButton.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'Botón Cerrar
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub


    'Dibuja la línea divisoria en el centro
    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles panel.Paint
        Dim myPen As Pen
        myPen = New Pen(Color.FromArgb(55, 70, 80), 4)
        e.Graphics.DrawLine(myPen, 362, 500, 362, 0)
        'Asignar estilos al button
        StartApp.TabStop = False
        StartApp.FlatAppearance.BorderSize = 0
        StartApp.FlatAppearance.CheckedBackColor = Color.Transparent
        StartApp.FlatAppearance.MouseDownBackColor = Color.Transparent
        StartApp.FlatAppearance.MouseOverBackColor = Color.Transparent
    End Sub


    'Código para poder arrastrar la ventana desde la parte superior
    Dim IsDraggingForm As Boolean = False
    Private MousePos As New System.Drawing.Point(0, 0)
    Private Sub MainForm_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            IsDraggingForm = True
            MousePos = e.Location
        End If
    End Sub

    Private Sub MainForm_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If IsDraggingForm Then
            Dim temp As Point = New Point(Me.Location + (e.Location - MousePos))
            Me.Location = temp
        End If
    End Sub

    Private Sub MainForm_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then IsDraggingForm = False
    End Sub


    'Botón que inicia el proceso de validación de datos
#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub btnMigrar_Click(sender As Object, e As EventArgs) Handles StartApp.Click
        serverOrigen.Select()
        Cursor = Cursors.AppStarting
        Application.DoEvents()
        'panel.Focus()
        'Comprueba el input y que su contenido es válido
        If InputValidate.Input() Then
            'Empieza conexión (redirigir a validate)
            If InputValidate.Settings Then
                EEO.CheckState = False
                'MsgBox("Empresa migrada con éxito.", MessageBoxIcon.Information)
                AlertType.StringMessage("Success", vbNewLine & "Empresa migrada con éxito.")
            Else
                Cursor = Cursors.Default
                AlertType.StringMessage("Error", vbNewLine & "La Empresa no se ha migrado.")
                Exit Sub
            End If
        Else
            Cursor = Cursors.Default
            Exit Sub
        End If
        Cursor = Cursors.Default
    End Sub

    'Código para LostFocus y GotFocus
    '----------------------------------------------serverOrigen | serverDestino----------------------------------------------------
#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub serverOrigen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles serverOrigen.LostFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.LostFocusText(serverOrigen, "Servidor")
    End Sub
#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub serverOrigen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles serverOrigen.GotFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.FocusText(serverOrigen, "Servidor")
    End Sub

#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub serverDestino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles serverDestino.LostFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.LostFocusText(serverDestino, "Servidor")
    End Sub
#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub serverDestino_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles serverDestino.GotFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.FocusText(serverDestino, "Servidor")
    End Sub
    '----------------------------------------------dataBaseOrigen | dataBaseDestino----------------------------------------------------
#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub dataBaseOrigen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataBaseOrigen.LostFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.LostFocusText(dataBaseOrigen, "DataBase")
    End Sub
#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub dataBaseOrigen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataBaseOrigen.GotFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.FocusText(dataBaseOrigen, "DataBase")
    End Sub

#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub dataBaseDestino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataBaseDestino.LostFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.LostFocusText(dataBaseDestino, "DataBase")
    End Sub
#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub dataBaseDestino_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataBaseDestino.GotFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.FocusText(dataBaseDestino, "DataBase")
    End Sub
    '----------------------------------------------idEmpresaOrigen | idEmpresaDestino----------------------------------------------------
#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub idEmpresaOrigen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles idEmpresaOrigen.LostFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.LostFocusText(idEmpresaOrigen, "idEmpresa")
    End Sub
#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub idEmpresaOrigen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles idEmpresaOrigen.GotFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.FocusText(idEmpresaOrigen, "idEmpresa")
    End Sub

#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub idEmpresaDestino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles idEmpresaDestino.LostFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.LostFocusText(idEmpresaDestino, "idEmpresa")
    End Sub
#Disable Warning IDE1006 ' Estilos de nombres
    Private Sub idEmpresaDestino_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles idEmpresaDestino.GotFocus
#Enable Warning IDE1006 ' Estilos de nombres
        FocusUtils.FocusText(idEmpresaDestino, "idEmpresa")
    End Sub


    'Al pulsar enter ejecuta el mismo código que btnMigrar
    Private Sub ServerOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles serverOrigen.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btnMigrar_Click(sender, e)
        End Select
    End Sub
    Private Sub DataBaseOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles dataBaseOrigen.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btnMigrar_Click(sender, e)
        End Select
    End Sub
    Private Sub IdEmpresaOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles idEmpresaOrigen.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btnMigrar_Click(sender, e)
        End Select
    End Sub
    Private Sub ServerDestino_KeyDown(sender As Object, e As KeyEventArgs) Handles serverDestino.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btnMigrar_Click(sender, e)
        End Select
    End Sub
    Private Sub DataBaseDestino_KeyDown(sender As Object, e As KeyEventArgs) Handles dataBaseDestino.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btnMigrar_Click(sender, e)
        End Select
    End Sub
    Private Sub IdEmpresaDestino_KeyDown(sender As Object, e As KeyEventArgs) Handles idEmpresaDestino.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                btnMigrar_Click(sender, e)
        End Select
    End Sub

    'Cambiar imagen del button StartApp

    Private Sub EEO_CheckedChanged(sender As Object, e As EventArgs) Handles EEO.CheckedChanged
        If EEO.Checked Then
            'Eliminar tabla origen i mostrar aviso
            Dim ask As MsgBoxResult = MessageBox.Show("Marcar esta opción eliminará definitivamente la Empresa de la Base de Datos Origen.
Estás seguro?", "CM", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If ask = MsgBoxResult.Yes Then
                eeoBolean = True
            Else
                EEO.CheckState = False
            End If
        End If
    End Sub

    Private Sub EEO_Enter(sender As Object, e As EventArgs) Handles EEO.Enter
        EEO.ForeColor = Color.FromArgb(120, 120, 120)
    End Sub

    Private Sub EEO_Leave(sender As Object, e As EventArgs) Handles EEO.Leave
        EEO.ForeColor = Color.FromArgb(171, 171, 171)
    End Sub

End Class
