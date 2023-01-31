Imports System.Linq.Expressions
Imports System.IO
Imports IniParser
Imports IniParser.Model

Public Class Form1

    Dim dmodfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\.minecraft\mods"
    Dim dresfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\.minecraft\resourcepacks"
    Dim dshadefolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\.minecraft\shaderpacks"
    Dim dmc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\.minecraft"
    Dim ezmodp = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\EZmod"
    Dim settingsfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\ezmod\settings\settings.ini"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\ezmod\settings\settings.ini") Then
            DropPanel1.Size = DropPanel1.MinimumSize()
            Guna2Panel1.Size = Guna2Panel1.MinimumSize()
            My.Settings.MCpath = File.ReadAllLines(settingsfile).ElementAt(0).Replace("MCpath: ", "")
            My.Settings.ModFolder = File.ReadAllLines(settingsfile).ElementAt(1).Replace("Modsfolder: ", "")
            My.Settings.ResFolder = File.ReadAllLines(settingsfile).ElementAt(2).Replace("ResourceFolder: ", "")
            My.Settings.ShadeFolder = File.ReadAllLines(settingsfile).ElementAt(3).Replace("ShaderFolder: ", "")
            change_menu("home")
        Else
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\ezmod\settings\settings.ini", "MCpath: " & dmc & Environment.NewLine & "Modsfolder: " & dmodfolder & Environment.NewLine & "ResourceFolder: " & dresfolder & Environment.NewLine & "ShaderFolder: " & dshadefolder)

            My.Settings.MCpath = dmc
            My.Settings.ModFolder = dmodfolder
            My.Settings.ResFolder = dresfolder
            My.Settings.ShadeFolder = dshadefolder

        End If

        change_menu("home")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DropPanel1.Size = DropPanel1.MinimumSize Then
            DropPanel1.Size = DropPanel1.MaximumSize
        ElseIf DropPanel1.Size = DropPanel1.MaximumSize Then
            DropPanel1.Size = DropPanel1.MinimumSize
        End If
    End Sub

    Private Sub changeForm(frm As Form)
        PanelContainer.Controls.Clear()
        frm.TopLevel = False
        frm.TopMost = True
        frm.Dock = DockStyle.Fill
        PanelContainer.Controls.Add(frm)
        frm.Show()
    End Sub

    Private Sub change_menu(menu As String)

        Select Case menu
            Case "quickadd"
                QuickAdd.ShowDialog()
            Case "home"
                changeForm(HomeForm)
            Case "modmanager"
                changeForm(ModManager)
            Case "files"
                changeForm(Files)
            Case "Bmodmanager"
                changeForm(Form2)
        End Select

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        change_menu("quickadd")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        change_menu("home")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim a As Integer
        For a = 100 To 10 Step -7
            Me.Opacity = a / 100
            Me.Refresh()
            Threading.Thread.Sleep(15)
        Next

        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        change_menu("modmanager")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        change_menu("files")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Guna2Panel1.Size = Guna2Panel1.MinimumSize Then
            Guna2Panel1.Size = Guna2Panel1.MaximumSize
        ElseIf Guna2Panel1.Size = Guna2Panel1.MaximumSize Then
            Guna2Panel1.Size = Guna2Panel1.MinimumSize
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        change_menu("Bmodmanager")
    End Sub
End Class
