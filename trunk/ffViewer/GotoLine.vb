Public Class GotoLine

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (Val(SearchBox.Text) > 0 And Val(SearchBox.Text) < Form1.CharCount(Form1.CodeBox.Text, vbCrLf, False)) Then

            For i As Integer = 0 To Val(SearchBox.Text) - 2
                Form1.CodeBox.SelectionStart = Form1.CodeBox.Text.IndexOf(vbCrLf, Form1.CodeBox.SelectionStart) + 2
            Next

            Form1.CodeBox.ScrollToCaret()
        End If
    End Sub
End Class