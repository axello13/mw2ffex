Public Class Wait

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.cancelCurrentOp = True
        Me.Hide()
    End Sub
End Class