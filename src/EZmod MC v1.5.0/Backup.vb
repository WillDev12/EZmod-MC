Imports System.IO
Public Class Backup

    Dim MCpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\.minecraft"
    Dim ezmodp = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod"
    Dim resfolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod\Backup\resource"
    Dim modfolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod\Backup"
    Dim shafolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod\Backup\Shaders"

    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.Close()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        Dim filename = My.Computer.FileSystem.GetFileInfo(Guna2TextBox1.Text).Name

        If ModManager.Guna2RadioButton1.Checked Then

            If Guna2RadioButton1.Checked Then
                File.Copy(Guna2TextBox1.Text, modfolder & "\" & filename)
            ElseIf Guna2RadioButton2.Checked Then
                File.Copy(Guna2TextBox1.Text, resfolder & "\" & filename)
            ElseIf Guna2RadioButton3.Checked Then
                File.Copy(Guna2TextBox1.Text, shafolder & "\" & filename)
            End If

        Else

            If Guna2RadioButton1.Checked Then
                File.Copy(Guna2TextBox1.Text, modfolder & "\" & filename)
                ModManager.ListBox3.Items.Add(filename)
            ElseIf Guna2RadioButton2.Checked Then
                File.Copy(Guna2TextBox1.Text, resfolder & "\" & filename)
                ModManager.ListBox2.Items.Add(filename)
            ElseIf Guna2RadioButton3.Checked Then
                File.Copy(Guna2TextBox1.Text, shafolder & "\" & filename)
                ModManager.ListBox1.Items.Add(filename)
            End If

        End If

        MsgBox("New backup created", 64, "EZmod MC")
        Me.Close()

    End Sub
End Class