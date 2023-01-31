Imports System.IO
Imports System.IO.Compression

Public Class ModManager

    Dim MCpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\.minecraft"
    Dim ezmodp = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod"
    Dim resfolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod\Backup\resource"
    Dim modfolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod\Backup"
    Dim shafolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod\Backup\Shaders"

    Dim dmodfolder = My.Settings.ModFolder
    Dim dresfolder = My.Settings.ResFolder
    Dim dshadefolder = My.Settings.ShadeFolder

    Private Sub ModManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim realname = ""

        If Directory.Exists(dmodfolder) Then

            For Each file As String In Directory.GetFiles(dmodfolder)

                realname = My.Computer.FileSystem.GetFileInfo(file).Name
                ListBox3.Items.Add(realname)

            Next

        Else

        End If

        For Each file As String In Directory.GetFiles(dresfolder)

            realname = My.Computer.FileSystem.GetFileInfo(file).Name
            ListBox2.Items.Add(realname)

        Next

        If Directory.Exists(dshadefolder) Then

            For Each file As String In Directory.GetFiles(dshadefolder)

                realname = My.Computer.FileSystem.GetFileInfo(file).Name
                ListBox1.Items.Add(realname)

            Next

        Else

        End If

    End Sub

    Private Sub Guna2RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2RadioButton2.CheckedChanged

        Dim realname As String

        If Guna2RadioButton2.Checked Then

            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()

            For Each file In Directory.GetFiles(modfolder)

                realname = My.Computer.FileSystem.GetFileInfo(file).Name
                ListBox3.Items.Add(realname)

            Next

            For Each file In Directory.GetFiles(resfolder)

                realname = My.Computer.FileSystem.GetFileInfo(file).Name
                ListBox2.Items.Add(realname)

            Next

            For Each file In Directory.GetFiles(shafolder)

                realname = My.Computer.FileSystem.GetFileInfo(file).Name
                ListBox1.Items.Add(realname)

            Next

        ElseIf Guna2RadioButton1.Checked Then

            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()

            If Directory.Exists(dshadefolder) Then

                For Each file In Directory.GetFiles(dshadefolder)

                    realname = My.Computer.FileSystem.GetFileInfo(file).Name
                    ListBox1.Items.Add(realname)

                Next

            End If

            If Directory.Exists(dmodfolder) Then

                For Each file In Directory.GetFiles(dmodfolder)

                    realname = My.Computer.FileSystem.GetFileInfo(file).Name
                    ListBox3.Items.Add(realname)

                Next

            End If

            For Each file In Directory.GetFiles(dresfolder)

                realname = My.Computer.FileSystem.GetFileInfo(file).Name
                ListBox2.Items.Add(realname)

            Next

        End If

    End Sub

    Private Sub ListBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles ListBox3.MouseClick
        ListBox2.SelectedItems.Clear()
        ListBox1.SelectedItems.Clear()
    End Sub

    Private Sub ListBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles ListBox2.MouseClick
        ListBox3.SelectedItems.Clear()
        ListBox1.SelectedItems.Clear()
    End Sub

    Private Sub ListBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDown
        ListBox3.SelectedItems.Clear()
        ListBox2.SelectedItems.Clear()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If Guna2RadioButton1.Checked Then
            MsgBox("File is already in Minecraft.", 64, "EZmod")
        Else

            If ListBox1.SelectedIndex >= 0 Then

                File.Move(shafolder & "\" & ListBox1.SelectedItem.ToString, dshadefolder & "\" & ListBox1.SelectedItem.ToString)
                ListBox1.Items.Remove(ListBox1.SelectedItem)

            End If

            If ListBox2.SelectedIndex >= 0 Then

                File.Move(resfolder & "\" & ListBox2.SelectedItem.ToString, dresfolder & "\" & ListBox2.SelectedItem.ToString)
                ListBox2.Items.Remove(ListBox2.SelectedItem)

            End If

            If ListBox3.SelectedIndex >= 0 Then

                File.Move(modfolder & "\" & ListBox3.SelectedItem.ToString, dmodfolder & "\" & ListBox3.SelectedItem.ToString)
                ListBox3.Items.Remove(ListBox3.SelectedItem)

            End If

        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click

        If Guna2RadioButton2.Checked Then
            MsgBox("File is not in Minecraft.", 64, "EZmod")
        Else

            If ListBox1.SelectedIndex >= 0 Then

                File.Move(dshadefolder & "\" & ListBox1.SelectedItem.ToString(), shafolder & "\" & ListBox1.SelectedItem.ToString)
                ListBox1.Items.Remove(ListBox1.SelectedItem)

            ElseIf ListBox2.SelectedIndex >= 0 Then

                File.Move(dresfolder & "\" & ListBox2.SelectedItem.ToString, resfolder & "\" & ListBox2.SelectedItem.ToString)
                ListBox2.Items.Remove(ListBox2.SelectedItem)

            ElseIf ListBox3.SelectedIndex >= 0 Then

                File.Move(dmodfolder & "\" & ListBox3.SelectedItem.ToString, modfolder & "\" & ListBox3.SelectedItem.ToString)
                ListBox3.Items.Remove(ListBox3.SelectedItem)

            End If


        End If

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then

            Backup.Guna2TextBox1.Text = OpenFileDialog1.FileName.ToString()
            Backup.ShowDialog()

        End If


    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click

        If Guna2CheckBox1.Checked Then

            If ListBox1.SelectedIndex >= 0 Then

                Dim selected = ListBox1.SelectedItem.ToString()

                If Guna2RadioButton1.Checked Then

                    File.Delete(dshadefolder & "\" & selected)

                Else

                    File.Delete(shafolder & "\" & selected)

                End If

                ListBox1.Items.Remove(ListBox1.SelectedItem)

            ElseIf ListBox2.SelectedIndex >= 0 Then

                Dim selected = ListBox2.SelectedItem.ToString()

                If Guna2RadioButton1.Checked Then

                    File.Delete(dresfolder & "\" & selected)

                Else

                    File.Delete(resfolder & "\" & selected)

                End If

                ListBox2.Items.Remove(ListBox2.SelectedItem)

            ElseIf ListBox3.SelectedIndex >= 0 Then

                Dim selected = ListBox3.SelectedItem.ToString()

                If Guna2RadioButton1.Checked Then

                    File.Delete(dmodfolder & "\" & selected)

                Else

                    File.Delete(modfolder & "\" & selected)

                End If

                ListBox3.Items.Remove(ListBox3.SelectedItem)

            End If

        Else

            If ListBox1.SelectedIndex >= 0 Then

                Dim x = MsgBox("Do you really wish to delete this file?  This action cannot be undone.", vbYesNo, "EZmod MC")

                If x = vbNo Then

                    Exit Sub

                Else

                End If

                Dim selected = ListBox1.SelectedItem.ToString()

                If Guna2RadioButton1.Checked Then

                    File.Delete(dshadefolder & "\" & selected)

                Else

                    File.Delete(shafolder & "\" & selected)

                End If

                ListBox1.Items.Remove(ListBox1.SelectedItem)

            ElseIf ListBox2.SelectedIndex >= 0 Then

                Dim x = MsgBox("Do you really wish to delete this file?  This action cannot be undone.", vbYesNo, "EZmod MC")

                If x = vbNo Then

                    Exit Sub

                Else

                End If

                Dim selected = ListBox2.SelectedItem.ToString()

                If Guna2RadioButton1.Checked Then

                    File.Delete(dresfolder & "\" & selected)

                Else

                    File.Delete(resfolder & "\" & selected)

                End If

                ListBox2.Items.Remove(ListBox2.SelectedItem)

            ElseIf ListBox3.SelectedIndex >= 0 Then

                Dim x = MsgBox("Do you really wish to delete this file?  This action cannot be undone.", vbYesNo, "EZmod MC")

                If x = vbNo Then

                    Exit Sub

                Else

                End If

                Dim selected = ListBox3.SelectedItem.ToString()

                If Guna2RadioButton1.Checked Then

                    File.Delete(dmodfolder & "\" & selected)

                Else

                    File.Delete(modfolder & "\" & selected)

                End If

                ListBox3.Items.Remove(ListBox3.SelectedItem)

            End If



        End If

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click

        Dim x = InputBox("Are you sure that you want to delete all of your backups? This cannot be undone!" & Environment.NewLine & "[Type DELETE to confirm]", "EZmod", "Type here")

        If x = "DELETE" Then

            If Directory.Exists(dmodfolder) Then

                For Each f In Directory.GetFiles(modfolder)

                    File.Delete(f)

                Next

            End If


            For Each f In Directory.GetFiles(resfolder)

                File.Delete(f)

            Next

            If Directory.Exists(dmodfolder) Then

                For Each f In Directory.GetFiles(shafolder)

                    File.Delete(f)

                Next

            End If

            If Guna2RadioButton1.Checked Then

                Else
                    ListBox1.Items.Clear()
                    ListBox2.Items.Clear()
                    ListBox3.Items.Clear()
                End If

            End If

    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click

        Dim x = MsgBox("Are you sure that you would like to export your backups?", vbYesNo, "EZmod")

        If x = vbYes Then

            If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then

                Dim locationf = FolderBrowserDialog1.SelectedPath

                ZipFile.CreateFromDirectory(modfolder, locationf & "\Export.zip", CompressionLevel.Optimal, False)

                MsgBox("Export saved to " & locationf & "\Export.zip", 64, "EZmod")

            End If

        End If


    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click

        Dim x = MsgBox("Are you sure that you would like to import previously saved backups? Doing so will overwrite what is currently saved.", vbYesNo, "EZmod")

        If x = vbYes Then

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then

                For Each f As String In Directory.GetFiles(modfolder)

                    File.Delete(f)

                Next

                For Each f As String In Directory.GetFiles(resfolder)

                    File.Delete(f)

                Next

                For Each f As String In Directory.GetFiles(shafolder)

                    File.Delete(f)

                Next

                ZipFile.ExtractToDirectory(OpenFileDialog1.FileName, modfolder)

                If Guna2RadioButton2.Checked Then

                    Dim realname As String

                    ListBox1.Items.Clear()
                    ListBox2.Items.Clear()
                    ListBox3.Items.Clear()

                    For Each file As String In Directory.GetFiles(modfolder)

                        realname = My.Computer.FileSystem.GetFileInfo(file).Name
                        ListBox3.Items.Add(realname)

                    Next

                    For Each file As String In Directory.GetFiles(resfolder)

                        realname = My.Computer.FileSystem.GetFileInfo(file).Name
                        ListBox2.Items.Add(realname)

                    Next

                    For Each file As String In Directory.GetFiles(shafolder)

                        realname = My.Computer.FileSystem.GetFileInfo(file).Name
                        ListBox1.Items.Add(realname)

                    Next

                    MsgBox("Backup opened", 64, "EZmod")

                Else

                End If


            End If

        End If

    End Sub
End Class