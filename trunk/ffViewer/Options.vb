Public Class Options

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            XboxIp.Text = Form1.GetPreferenceValue("xboxip")
            UName.Text = Form1.GetPreferenceValue("uname")
            Pass.Text = Form1.GetPreferenceValue("pass")
            PathTo.Text = Form1.GetPreferenceValue("path")

            RLF.Checked = Boolean.Parse(Form1.GetPreferenceValue("rememberLF", "False"))
            'RLWP.Checked = Boolean.Parse(Form1.GetPreferenceValue("rememberLWP", "False"))
            'OneClickSaving.Checked = Boolean.Parse(Form1.GetPreferenceValue("oneclicksave", "False"))
            'ShowWarning.Checked = Boolean.Parse(Form1.GetPreferenceValue("showwarning", "False"))
            DeleteTemp.Checked = Boolean.Parse(Form1.GetPreferenceValue("deletetemp", "False"))
            'ReduceRAM.Checked = Boolean.Parse(Form1.GetPreferenceValue("reduceram", "True"))
        Catch ex As Exception
            MessageBox.Show("Error loading preferences: " + ex.Message, "Failed", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If (PathTo.Text.ElementAt(0) <> Char.Parse("/")) Then
                Throw New Exception("The path doesn't start with a forward slash!")
            End If
            If (PathTo.Text.ElementAt(PathTo.Text.Length - 1) = Char.Parse("/")) Then
                Throw New Exception("The path cannot have a forward slash at the end!")
            End If
            Form1.SetPreferenceValue("xboxip", XboxIp.Text)
            Form1.SetPreferenceValue("uname", UName.Text)
            Form1.SetPreferenceValue("pass", Pass.Text)
            Form1.SetPreferenceValue("path", PathTo.Text)

            Form1.SetPreferenceValue("rememberLF", RLF.Checked.ToString())
            'Form1.SetPreferenceValue("rememberLWP", RLWP.Checked.ToString())
            'Form1.SetPreferenceValue("oneclicksave", OneClickSaving.Checked.ToString())
            'Form1.SetPreferenceValue("showwarning", ShowWarning.Checked.ToString())

            Form1.SetPreferenceValue("deletetemp", DeleteTemp.Checked.ToString())
            'Form1.SetPreferenceValue("reduceram", ReduceRAM.Checked.ToString())

            System.IO.File.Delete("prefs\prefs.ini")

            System.IO.File.WriteAllLines("prefs\prefs.ini", Form1.optionsData.ToArray(GetType(String)))

            MessageBox.Show("Preferences saved successfully!", "Saved", MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show("Error saving preferences: " + ex.Message, "Failed", MessageBoxButtons.OK)
        End Try

    End Sub
End Class