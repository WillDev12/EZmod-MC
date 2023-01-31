Imports System.IO
Imports System.IO.Compression
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form2

    Dim bedrockfolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod\Backup\Bedrock"
    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click

        Dim x = MsgBox("Are you sure that you would like to clear your backups? [This action cannot be undone]", vbYesNo, "EZmod MC")

        If x = vbYes Then

            For Each f As String In Directory.GetFiles(bedrockfolder)

                File.Delete(f)

            Next

            ListBox1.Items.Clear()

        Else



        End If

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each f As String In Directory.GetFiles(bedrockfolder)

            Dim r = My.Computer.FileSystem.GetFileInfo(f).Name
            ListBox1.Items.Add(r)

        Next

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If ListBox1.SelectedIndex >= 0 Then

            Process.Start(bedrockfolder & "\" & ListBox1.SelectedItem.ToString())

        Else

            MsgBox("Error: You must select an item to continue", 16, "EZmod")

        End If
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then

            File.Copy(OpenFileDialog1.FileName, bedrockfolder & "\" & My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileName).Name)

        End If

        ListBox1.Items.Add(My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileName).Name)

    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click

        ZipFile.CreateFromDirectory(bedrockfolder, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\extraction.zip")

        MsgBox("Backups saved to: " & Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\extraction.zip", 64, "EZmod")

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click

        Dim x = MsgBox("Are you sure that you would like to import backups?  All current backups will be deleted forever.", vbYesNo, "EZmod")

        If x = vbYes Then

            Using o As New OpenFileDialog With {.Filter = "(Zip Files)|*.zip", .Multiselect = False, .Title = "Select your file"}

                If o.ShowDialog = 1 Then

                    ListBox1.Items.Clear()

                    For Each f As String In Directory.GetFiles(bedrockfolder)

                        File.Delete(f)

                    Next

                    ZipFile.ExtractToDirectory(o.FileName, bedrockfolder)

                    For Each f As String In Directory.GetFiles(bedrockfolder)

                        Dim n = My.Computer.FileSystem.GetFileInfo(f).Name
                        ListBox1.Items.Add(n)

                    Next

                End If

            End Using

        End If

    End Sub

End Class