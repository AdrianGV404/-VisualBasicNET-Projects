Public Class AlertUP
    Private Sub ErrorPopUpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Error_PictureBox.Image = My.Resources.ImgResource.error_icon
            Done_PictureBox.Image = My.Resources.ImgResource.done_icon
        Catch ex As Exception
            GeneralUtils.ErrorConsole(ex.Message)
        End Try
        GeneralUtils.FormRoundedBorder(Me)
        Me.Top = -1 * (Me.Height)
        Me.Left = Screen.PrimaryScreen.Bounds.Width - Me.Width - 60
        Me.FormBorderStyle = FormBorderStyle.None
        ShowTimer.Start()
    End Sub

    Private Sub ClosePicture_Click(sender As Object, e As EventArgs) Handles ClosePicture.Click
        CloseTimer.Start()
    End Sub

    Private Sub Timeout_Tick(sender As Object, e As EventArgs) Handles Timeout.Tick
        CloseTimer.Start()
    End Sub

    Dim interval As Integer = 0
    Private Sub ShowTimer_Tick(sender As Object, e As EventArgs) Handles ShowTimer.Tick
        If Me.Top < 60 Then
            Me.Top += interval
            interval += 2
        Else
            ShowTimer.Stop()
        End If
    End Sub

    Private Sub CloseTimer_Tick(sender As Object, e As EventArgs) Handles CloseTimer.Tick
        If Me.Opacity > 0 Then
            Me.Opacity -= 0.08
        Else
            Me.Close()
        End If
    End Sub

    Public Shared Sub ResetAlert()
        AlertUP.Timeout.Enabled = False
        AlertUP.Timeout.Enabled = True
        AlertUP.CloseTimer.Stop()
        AlertUP.Opacity = 95
    End Sub

End Class