Imports System.IO

Public Class Changelog

    Private Sub Changelog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim webC As New System.Net.WebClient
        webC.DownloadFile("http://dev-il.com/xbox/Changelog.rtf", Directory.GetCurrentDirectory() + "\changeLog.rtf")
        ChangelogBox.Rtf = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "\changeLog.rtf")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim webC As New System.Net.WebClient
        If (File.Exists("updater.exe")) Then
            File.Delete("updater.exe")
        End If
        webC.DownloadFile("http://dev-il.com/xbox/ffUpdater.exe", Directory.GetCurrentDirectory() + "\updater.exe")
        System.Diagnostics.Process.Start("updater.exe")
        End
    End Sub
End Class