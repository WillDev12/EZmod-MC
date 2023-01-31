Public Class Setting
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim o As New FolderBrowserDialog

        If o.ShowDialog = DialogResult.OK Then

            TextBox1.Text = o.SelectedPath

        Else

        End If

    End Sub

    Private Sub Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.ModFolder
        TextBox2.Text = My.Settings.ResFolder
        TextBox3.Text = My.Settings.ShadeFolder
        TextBox4.Text = My.Settings.MCpath
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim o As New FolderBrowserDialog

        If o.ShowDialog = DialogResult.OK Then

            TextBox2.Text = o.SelectedPath

        Else

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim o As New FolderBrowserDialog

        If o.ShowDialog = DialogResult.OK Then

            TextBox3.Text = o.SelectedPath

        Else

        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim o As New FolderBrowserDialog

        If o.ShowDialog = DialogResult.OK Then

            TextBox4.Text = o.SelectedPath

        Else

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Settings.MCpath = TextBox4.Text
        My.Settings.ModFolder = TextBox1.Text
        My.Settings.ResFolder = TextBox2.Text
        My.Settings.ShadeFolder = TextBox3.Text
        Me.Close()
    End Sub
End Class