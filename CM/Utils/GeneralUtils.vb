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
End Class
