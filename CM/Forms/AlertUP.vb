Public Class AlertUP
    Private Sub ErrorPopUpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Error_PictureBox.Visible = False
        Done_PictureBox.Visible = False
        ClosePicture.Visible = False
        ErrorMsg.Visible = False
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
            ClosePicture.Visible = True
            ErrorMsg.Visible = True
            If BackColor = Color.FromArgb(220, 13, 40) Then
                Error_PictureBox.Image = My.Resources.ImgResource.error_icon
                Done_PictureBox.Visible = False
                Error_PictureBox.Visible = True
            Else
                If BackColor = Color.SeaGreen Then
                    Done_PictureBox.Image = My.Resources.ImgResource.done_icon
                    Error_PictureBox.Visible = False
                    Done_PictureBox.Visible = True
                End If
            End If
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