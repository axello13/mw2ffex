Public Class Find

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Dim selectionStart As Integer = Form1.CodeBox.Text.IndexOf(SearchBox.Text)
        If (selectionStart > 0) Then
            Form1.CodeBox.Select(selectionStart, SearchBox.Text.Length)
            Form1.CodeBox.ScrollToCaret()
        End If
    End Sub
End Class