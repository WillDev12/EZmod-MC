Imports System.IO
Public Class QuickAdd

    Dim MCfolder = My.Settings.MCpath
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then

            For Each file In OpenFileDialog1.FileNames
                ListBox1.Items.Add(file)
            Next

        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        If RadioButton1.Checked Then

            RadioButton3.Show()
            RadioButton4.Show()
            RadioButton5.Show()

        Else

            RadioButton3.Hide()
            RadioButton4.Hide()
            RadioButton5.Hide()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RadioButton1.Checked Then

            If RadioButton3.Checked Then

                For Each filep As String In ListBox1.Items

                    If File.Exists(MCfolder & "\mods\" & My.Computer.FileSystem.GetFileInfo(filep).Name) Then


                    Else

                        File.Copy(filep, MCfolder & "\mods\" & My.Computer.FileSystem.GetFileInfo(filep).Name)

                    End If

                Next

            ElseIf RadioButton5.Checked Then

                For Each filep As String In ListBox1.Items

                    If File.Exists(MCfolder & "\shaderpacks\" & My.Computer.FileSystem.GetFileInfo(filep).Name) Then


                    Else

                        File.Copy(filep, MCfolder & "\shaderpacks\" & My.Computer.FileSystem.GetFileInfo(filep).Name)

                    End If

                Next

            ElseIf RadioButton4.Checked Then

                For Each filep As String In ListBox1.Items

                    If File.Exists(MCfolder & "\resourcepacks\" & My.Computer.FileSystem.GetFileInfo(filep).Name) Then


                    Else

                        File.Copy(filep, MCfolder & "\resourcepacks\" & My.Computer.FileSystem.GetFileInfo(filep).Name)

                    End If

                Next

            End If

        ElseIf RadioButton2.Checked Then

            For Each file As String In ListBox1.Items

                Process.Start(file)

            Next

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub QuickAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
    End Sub

End Class