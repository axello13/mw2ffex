Public Class CompSize

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            MessageBox.Show(Ionic.Zlib.ZlibStream.CompressBuffer(System.IO.File.ReadAllBytes("tempFile")).Length)
        Catch ex As Exception

        End Try

    End Sub
End Class