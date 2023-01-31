Imports IniParser
Imports System.IO

Public Class Files

    Dim modf = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod\Backup",
        resf = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod\Backup\resource",
        shaf = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod\Backup\Shaders"

    Private Sub FileBrowser_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles FileBrowser.MouseDoubleClick

        Dim SI = FileBrowser.SelectedItem.ToString()

        If SI = "Backup Mods" Then

            BrowserChange("BM")

        ElseIf SI = "Backup Resources" Then

            BrowserChange("BR")

        ElseIf SI = "Backup Shaders" Then

            BrowserChange("BS")

        Else

            BrowserChange("File")

        End If

    End Sub

    Private Sub Guna2PictureBox4_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox4.Click

        BrowserChange("Home")

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click

        FileEdit("New")

    End Sub

    Private Sub Files_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BrowserChange("Home")

    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click

        FileEdit("Remove")

    End Sub

    Private Sub Guna2PictureBox3_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox3.Click
        FileEdit("Clear")
    End Sub

    ''Browser subs

    Private Sub BrowserChange(var As String)

        Dim f As String,
            rn As String

        Select Case var
            Case "BM"

                FileBrowser.Items.Clear()
                Guna2TextBox1.Text = modf

                For Each f In Directory.GetFiles(modf)

                    rn = My.Computer.FileSystem.GetFileInfo(f).Name
                    FileBrowser.Items.Add("%BACKUP%\MODS\" & rn)

                Next

            Case "BR"

                FileBrowser.Items.Clear()
                Guna2TextBox1.Text = resf

                For Each f In Directory.GetFiles(resf)

                    rn = My.Computer.FileSystem.GetFileInfo(f).Name
                    FileBrowser.Items.Add("%BACKUP%\RESOURCEPACKS\" & rn)

                Next

            Case "BS"

                FileBrowser.Items.Clear()
                Guna2TextBox1.Text = shaf

                For Each f In Directory.GetFiles(shaf)

                    rn = My.Computer.FileSystem.GetFileInfo(f).Name
                    FileBrowser.Items.Add("%BACKUP%\SHADERS\" & rn)

                Next

            Case "File"

                Dim SI = FileBrowser.SelectedItem.ToString()

                Dim path = Guna2TextBox1.Text & "\" & SI.Replace("%BACKUP%\MODS\", "").Replace("%BACKUP%\RESOURCEPACKS\", "").Replace("%BACKUP%\SHADERS\", ""),
                    extention = My.Computer.FileSystem.GetFileInfo(path).Extension,
                    name = My.Computer.FileSystem.GetFileInfo(path).Name,
                    length = My.Computer.FileSystem.GetFileInfo(path).Length,
                    attrib = My.Computer.FileSystem.GetFileInfo(path).Attributes,
                    ct = My.Computer.FileSystem.GetFileInfo(path).CreationTime


                MsgBox("Filename: " & name & Environment.NewLine & "Extension: " & extention & Environment.NewLine & "Directory: " & Guna2TextBox1.Text & Environment.NewLine & "Length: " & length & Environment.NewLine & "Attributes: " & attrib & Environment.NewLine & "Creationtime: " & ct, 64, "File info:" & name)


            Case "Home"

                FileBrowser.Items.Clear()

                FileBrowser.Items.Add("Backup Mods")
                FileBrowser.Items.Add("Backup Resources")
                FileBrowser.Items.Add("Backup Shaders")

                Guna2TextBox1.Text = "Directory paths of the desired folder will appear here."

        End Select

    End Sub

    Private Sub FileEdit(type As String)

        Dim SI As String,
            FO = Guna2TextBox1.Text

        If FO = "Directory paths of the desired folder will appear here." Then

            MsgBox("Cannot edit files if no folder is selected", 16, "EZmod")
            Exit Sub

        Else

            Select Case type
                Case "New"

                    OpenFileDialog1.Multiselect = True

                    If OpenFileDialog1.ShowDialog = DialogResult.OK Then


                        For x = 0 To OpenFileDialog1.FileNames.Count - 1

                            File.Copy(OpenFileDialog1.FileNames(x), FO & "\" & My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileNames(x)).Name)

                        Next

                        FileBrowser.Items.Clear()
                        Dim rn As String

                        If FO = modf Then

                            For Each f As String In Directory.GetFiles(FO)

                                rn = My.Computer.FileSystem.GetFileInfo(f).Name
                                FileBrowser.Items.Add("%BACKUP&\MODS\" & rn)

                            Next

                        ElseIf FO = resf Then

                            For Each f As String In Directory.GetFiles(FO)

                                rn = My.Computer.FileSystem.GetFileInfo(f).Name
                                FileBrowser.Items.Add("%BACKUP&\RESOURCEPACKS\" & rn)

                            Next

                        ElseIf FO = shaf Then

                            For Each f As String In Directory.GetFiles(FO)

                                rn = My.Computer.FileSystem.GetFileInfo(f).Name
                                FileBrowser.Items.Add("%BACKUP&\SHADERS\" & rn)

                            Next

                        End If

                    Else

                    End If

                Case "Remove"

                    If FileBrowser.SelectedIndex <= 0 Then

                        MsgBox("Cannot edit files if no file is selected.", 16, "EZmod")
                        Exit Sub

                    End If

                    SI = FileBrowser.SelectedItem.ToString().Replace("%BACKUP%\MODS\", "").Replace("%BACKUP%\RESOURCEPACKS\", "").Replace("%BACKUP%\SHADERS\", "")

                    Dim x = MsgBox("Are you sure that you would like to delete this file?", vbYesNo, "EZmod")

                    If x = vbYes Then

                        File.Delete(Guna2TextBox1.Text & "\" & SI)

                        FileBrowser.Items.Remove(FileBrowser.SelectedItem)

                    Else
                        Exit Sub
                    End If

                Case "Clear"

                    Dim x = InputBox("Are you sure that you would like to clear this folder? This action cannot be undone. [Type DELETE to continue.]")

                    If x = "DELETE" Then

                        For Each f As String In Directory.GetFiles(FO)

                            File.Delete(f)

                        Next

                        FileBrowser.Items.Clear()

                    Else
                        Exit Sub
                    End If

            End Select

        End If

    End Sub


End Class