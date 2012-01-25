Imports System
Imports System.IO
Imports Ionic.Zlib
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Net

' ----------------------------------------

' COPYRIGHT 2010 JAMES BLANDFORD (PRASOC). THIS SOURCE CODE IS LICENSED UNDER THE
' CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-SHAREALIKE 3.0 UNPORTED
' http://creativecommons.org/licenses/by-nc-sa/3.0/

' -------------------------------------

Public Class Form1
    Public Shared versionNum As String = "2.52"
    Public Shared currentOpenFFextracted As String = ""
    Public Shared openedMW2 As Boolean = True

    Public Shared changedGSC As Boolean = False

    Public Shared ffBytes As Byte()

    Public Shared openFileCompressed As Boolean = False
    Public Shared openFileStart As Integer = 0
    Public Shared openFileEnd As Integer = 0

    Public Shared cancelCurrentOp As Boolean = False
    Public Shared dragDropFFname As String = ""

    Public Shared optionsData As ArrayList
    Public Shared fileInfo As New FileData()

    Public Shared clickNodeRawFiles As TreeNode

    Public Shared MW2Version As Integer = 269
    Public Shared MW2VersionPC As Integer = 276
    Public Shared COD4Version As Integer = 256
    Public Shared WaWVersion As Integer = 387

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try

            If (Boolean.Parse(GetPreferenceValue("deletetemp", "False")) And fileInfo.FileName.Length > 4) Then
                File.Delete(currentOpenFFextracted)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Shortcuts(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.O AndAlso e.Control Then
            ' OPEN
            OpenFF()
        End If
        If e.KeyCode = Keys.S AndAlso e.Control Then
            ' SAVE
            SaveFFToolStripMenuItem_Click("", New System.EventArgs())
        End If
        If e.KeyCode = Keys.S AndAlso e.Control AndAlso e.Shift Then
            ' SAVE coolios
            DoItToolStripMenuItem_Click("", New System.EventArgs())
        End If
        If e.KeyCode = Keys.Q AndAlso e.Control Then
            ' CLOSE FF
            CloseFFToolStripMenuItem_Click("", New System.EventArgs())
        End If

        If e.KeyCode = Keys.F AndAlso e.Control Then
            ' FIND
            Find.Show()
        End If
        If e.KeyCode = Keys.F3 Then
            ' FIND NEXT
            Dim selectionStart As Integer = CodeBox.Text.IndexOf(Find.SearchBox.Text, CodeBox.SelectionStart + CodeBox.SelectionLength)
            If (selectionStart > 0) Then
                CodeBox.Select(selectionStart, Find.SearchBox.Text.Length)
                CodeBox.ScrollToCaret()
            End If
        End If
        If e.KeyCode = Keys.G AndAlso e.Control Then
            ' GOTO line
            GotoLine.Show()
        End If
        If e.KeyCode = Keys.A AndAlso e.Control Then
            CodeBox.SelectAll()
        End If
        If e.KeyCode = Keys.C AndAlso e.Control Then
            If (CodeBox.SelectedText.Length > 0) Then
                Clipboard.SetText(CodeBox.SelectedText)
            End If
        End If
        If e.KeyCode = Keys.X AndAlso e.Control Then
            CodeBox.Cut()
        End If
        If e.KeyCode = Keys.V AndAlso e.Control Then
            'CodeBox.Paste()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "FF Viewer v" + versionNum

        FileGridView.SelectedObject = fileInfo

        Try

            Dim arg As String()

            ReDim arg(Environment.GetCommandLineArgs().Length)
            arg = Environment.GetCommandLineArgs()
            Dim currentDir As String = arg(0).Substring(0, arg(0).LastIndexOf("\"))
            Directory.SetCurrentDirectory(currentDir)

            If (Not Directory.Exists(Directory.GetCurrentDirectory() + "\prefs")) Then
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\prefs")
            End If

            ReDim ffBytes(1)

            If (Not File.Exists(Directory.GetCurrentDirectory() + "\prefs\prefs.ini")) Then
                Dim webC As New System.Net.WebClient
                webC.DownloadFile("http://dev-il.com/xbox/prefs.ini", Directory.GetCurrentDirectory() + "\prefs\prefs.ini")
                optionsData = New ArrayList(File.ReadAllLines(Directory.GetCurrentDirectory() + "\prefs\prefs.ini"))
            Else
                optionsData = New ArrayList(File.ReadAllLines(Directory.GetCurrentDirectory() + "\prefs\prefs.ini"))
            End If

            If (arg.Length > 1) Then
                If (arg(1) <> "") Then
                    ' Cmd line argument: run from actual file OR run using cmd.exe
                    If (File.Exists(arg(1))) Then
                        dragDropFFname = arg(1)
                        OpenFF()
                    Else
                        MessageBox.Show("Command line file doesn't exist!")
                    End If
                End If
            End If

            If (My.Computer.Network.IsAvailable) Then
                Dim webC As New System.Net.WebClient
                webC.DownloadFile("http://dev-il.com/xbox/currentVer.txt", Directory.GetCurrentDirectory() + "\currentVer.txt")
                Dim newestVer As String = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "\currentVer.txt")
                If (newestVer <> versionNum And newestVer.Length < 10) Then
                    Changelog.Show()
                    Changelog.Text = "Changelog - New to v" + newestVer
                    'Me.Enabled = False
                End If
            Else
                MessageBox.Show("No active network connection found. Updating is disabled.")
            End If

            If (File.Exists(Directory.GetCurrentDirectory() + "\updater.exe")) Then
                File.Delete(Directory.GetCurrentDirectory() + "\updater.exe")
            End If
            If (File.Exists(Directory.GetCurrentDirectory() + "\currentVer.txt")) Then
                File.Delete(Directory.GetCurrentDirectory() + "\currentVer.txt")
            End If
            If (File.Exists(Directory.GetCurrentDirectory() + "\changeLog.rtf")) Then
                File.Delete(Directory.GetCurrentDirectory() + "\changeLog.rtf")
            End If
            If (Directory.Exists("prefs") <> True) Then
                Directory.CreateDirectory("prefs")
            End If
            If (Directory.Exists(Directory.GetCurrentDirectory() + "\snippets") <> True) Then
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\snippets")
            End If

            ' Download FFbackend.exe if not exist
            If (Not File.Exists(Directory.GetCurrentDirectory() + "\FFbackend.exe")) Then
                Dim webC As New System.Net.WebClient
                webC.DownloadFile("http://dev-il.com/xbox/ffBackend.exe", Directory.GetCurrentDirectory() + "\FFbackend.exe")
            End If

            UpdateSnippetsToolStripMenuItem_Click_1("form1_load", New System.EventArgs())

        Catch ex As Exception
            MessageBox.Show("Cannot connect to update server... continuing anyway... Error is: " + ex.InnerException.Message)

        End Try
    End Sub

    Public Function GetPreferenceValue(ByVal prefName As String, Optional ByVal returnIfNotFound As String = "")
        Dim returnStr As String = ""
        For i As Integer = 0 To optionsData.Count - 1
            If (optionsData(i).ToString().Contains(prefName)) Then
                returnStr = optionsData(i).ToString().Substring(optionsData(i).ToString().IndexOf("=") + 1, optionsData(i).ToString().Length - optionsData(i).ToString().IndexOf("=") - 1)
                Return returnStr
                Exit Function
            End If
        Next
        Return returnIfNotFound
    End Function

    Public Sub SetPreferenceValue(ByVal prefName As String, ByVal value As String)
        For i As Integer = 0 To optionsData.Count - 1
            If (optionsData(i).ToString().Contains(prefName)) Then
                ' return from for loop 
                Dim beforeEquals As String = optionsData(i).ToString().Substring(0, optionsData(i).ToString().IndexOf("="))
                optionsData(i) = beforeEquals + "=" + value
                Exit Sub
            End If
        Next
        optionsData.Add(prefName + "=" + value) ' if it gets to here, just add the string :D because it doesnt exist
    End Sub

    Private Sub OpenFFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFFToolStripMenuItem.Click
        OpenFF()
    End Sub



    Private Sub OpenFF()
        Try
            If (dragDropFFname = "") Then
                OpenDialog.Title = "Open a .FF file"
                OpenDialog.Filter = ".FF files(*.ff)|*.ff"
                OpenDialog.FileName = ""
                OpenDialog.FilterIndex = 1
                If (Boolean.Parse(GetPreferenceValue("rememberLF"))) Then
                    OpenDialog.InitialDirectory = GetPreferenceValue("lastlocation")
                Else
                    OpenDialog.InitialDirectory = Directory.GetCurrentDirectory()
                End If
                OpenDialog.RestoreDirectory = True
                If (OpenDialog.ShowDialog() = Windows.Forms.DialogResult.OK And OpenDialog.CheckFileExists) Then
                    dragDropFFname = OpenDialog.FileName
                Else
                    Exit Sub
                End If
            End If

            ' Load the .FF file

            Array.Clear(ffBytes, 0, ffBytes.Length)

            RawFiles.Nodes.Clear()
            fileInfo.RawFiles.Clear()

            CodeBox.Text = ""

            Wait.Show()

            'If (Boolean.Parse(GetPreferenceValue("reduceram", "True"))) Then

            ' run backend in 'open' mode

            Dim backEnd As Process = System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\FFbackend.exe", "-o """ + dragDropFFname + """")

            backEnd.WaitForExit()

            fileInfo.DataOffset = Integer.Parse(File.ReadAllLines(Directory.GetCurrentDirectory() + "\prefs\ff.config")(0)) ' read the file the backend makes
            fileInfo.IsMultiplayer = Boolean.Parse(File.ReadAllLines(Directory.GetCurrentDirectory() + "\prefs\ff.config")(1))
            fileInfo.OrigFileName = File.ReadAllLines(Directory.GetCurrentDirectory() + "\prefs\ff.config")(2)

            File.Delete(Directory.GetCurrentDirectory() + "\prefs\ff.config") ' delete it

            Me.Cursor = Cursors.Default

            currentOpenFFextracted = dragDropFFname.Substring(0, dragDropFFname.LastIndexOf(".")) + "-extract.dat" ' The backend makes this file
            fileInfo.FileName = dragDropFFname
            dragDropFFname = ""

            SetPreferenceValue("lastlocation", fileInfo.FileName.Substring(0, fileInfo.FileName.LastIndexOf("\")))
            System.IO.File.Delete("prefs\prefs.ini")
            System.IO.File.WriteAllLines("prefs\prefs.ini", Form1.optionsData.ToArray(GetType(System.String)))

            ffBytes = File.ReadAllBytes(currentOpenFFextracted)

            Me.Text = "FF Viewer v" + versionNum + " [" + fileInfo.FileName + "]"

            Dim numOfNulls As Integer = 0

            Dim notExtractedFF As Byte()
            notExtractedFF = File.ReadAllBytes(fileInfo.FileName)

            If (Integer.Parse(notExtractedFF(8).ToString()) <> 0) Then
                ' the file is little endian (usually pc)
                fileInfo.Version = ByteHandling.GetDWORD(notExtractedFF, 8, True)
                fileInfo.BigEndian = False
            Else
                ' the file is big endian
                fileInfo.Version = ByteHandling.GetDWORD(notExtractedFF, 8, False)
                fileInfo.BigEndian = True
            End If

            If (ffBytes(47) <> 255) Then ' if byte 47 is not FF, the current file is COD4/5!
                numOfNulls = ByteHandling.GetDWORD(ffBytes, 44, Not fileInfo.BigEndian) 'and the amount of nulls starts 12 later! (12 more header bytes!)
                openedMW2 = False
            Else
                numOfNulls = ByteHandling.GetDWORD(ffBytes, 32, Not fileInfo.BigEndian)
                openedMW2 = True
            End If

            ' Find out where the PreAssetStrings at the top of the FF starts
            Dim currentSpacer As Integer = 52
            If (Not openedMW2) Then
                currentSpacer += 4
            End If
            While (ffBytes(currentSpacer) = Byte.Parse(255))
                currentSpacer += 1
            End While


            ' Now, add all of the PreAssetStrings to fileInfo
            If (openedMW2) Then
                fileInfo.PreAssetStringCount = ByteHandling.GetDWORD(ffBytes, 40, Not fileInfo.BigEndian) - 1
                Dim preAssetStringOffset As Integer = currentSpacer
                For i As Integer = 0 To fileInfo.PreAssetStringCount - 1
                    Dim newOffset As Integer = ByteHandling.FindBytes(ffBytes, New Byte() {0}, preAssetStringOffset)
                    Dim stringName As String = ByteHandling.GetString(ffBytes, preAssetStringOffset, newOffset)
                    fileInfo.PreAssetStrings.Add(New PreAssetStringData(stringName, stringName.Length))
                    preAssetStringOffset = newOffset + 1
                Next
            Else
                fileInfo.PreAssetStringCount = ByteHandling.GetDWORD(ffBytes, 36, Not fileInfo.BigEndian) - 1
                Dim preAssetStringOffset As Integer = currentSpacer
                For i As Integer = 0 To fileInfo.PreAssetStringCount - 1
                    Dim newOffset As Integer = ByteHandling.FindBytes(ffBytes, New Byte() {0}, preAssetStringOffset)
                    Dim stringName As String = ByteHandling.GetString(ffBytes, preAssetStringOffset, newOffset)
                    fileInfo.PreAssetStrings.Add(New PreAssetStringData(stringName, stringName.Length))
                    preAssetStringOffset = newOffset + 1
                Next
            End If

            numOfNulls = fileInfo.PreAssetStringCount

            ' Now find out where the string table ends and the assets start!
            Dim startAssets As Integer = currentSpacer
            While (numOfNulls > 0)
                startAssets = ByteHandling.FindBytes(ffBytes, New Byte() {0}, startAssets + 1)
                numOfNulls -= 1
            End While

            If (openedMW2) Then
                fileInfo.AssetCount = ByteHandling.GetDWORD(ffBytes, 48, Not fileInfo.BigEndian)
                Dim currentOffset As Integer = startAssets + 3

                For i As Integer = 0 To fileInfo.AssetCount - 1
                    If (fileInfo.BigEndian) Then
                        fileInfo.Assets.Add(New AssetData(ffBytes(currentOffset + 1)))
                    Else
                        fileInfo.Assets.Add(New AssetData(ffBytes(currentOffset)))
                    End If
                    currentOffset += 8
                Next
            Else
                fileInfo.AssetCount = ByteHandling.GetDWORD(ffBytes, 44, Not fileInfo.BigEndian)
                Dim currentOffset As Integer = startAssets + 3

                For i As Integer = 0 To fileInfo.AssetCount - 1
                    If (fileInfo.BigEndian) Then
                        fileInfo.Assets.Add(New AssetData(ffBytes(currentOffset + 1)))
                    Else
                        fileInfo.Assets.Add(New AssetData(ffBytes(currentOffset)))
                    End If

                    currentOffset += 8
                Next
            End If

            Dim csvCount As Integer = ByteHandling.CountBytes(ffBytes, New Byte() {Asc("."), Asc("c"), Asc("s"), Asc("v"), 0})
            Dim offset As Integer = 0
            For i As Integer = 0 To csvCount - 1
                offset = ByteHandling.FindBytes(ffBytes, New Byte() {Asc("."), Asc("c"), Asc("s"), Asc("v"), 0}, offset + 1, True) + 1
                Dim startofNameoffset As Integer
                startofNameoffset = ByteHandling.FindByteBackward(ffBytes, Byte.Parse(255), offset) + 1
                Dim columns As Integer = ByteHandling.GetDWORD(ffBytes, startofNameoffset - 12, Not fileInfo.BigEndian)
                Dim rows As Integer = ByteHandling.GetDWORD(ffBytes, startofNameoffset - 8, Not fileInfo.BigEndian)

                If (rows <> -1 And columns <> -1 And offset - startofNameoffset < 25) Then
                    StringTables.Nodes.Add(ByteHandling.GetString(ffBytes, startofNameoffset, offset + 4))
                    StringTables.Nodes(StringTables.Nodes.Count - 1).Nodes.Add("Columns: " + columns.ToString())
                    StringTables.Nodes(StringTables.Nodes.Count - 1).Nodes.Add("Rows: " + rows.ToString())
                    fileInfo.StringTables.Add(New StringTableData(ByteHandling.GetString(ffBytes, startofNameoffset, offset + 4), columns, rows, startofNameoffset))
                End If
                Application.DoEvents()
            Next

            AddRawFileExtension(New Byte() {Asc("."), Asc("g"), Asc("s"), Asc("c"), 0})
            AddRawFileExtension(New Byte() {Asc("."), Asc("r"), Asc("m"), Asc("b"), 0})
            AddRawFileExtension(New Byte() {Asc("."), Asc("d"), Asc("e"), Asc("f"), 0, 78})
            AddRawFileExtension(New Byte() {Asc("."), Asc("c"), Asc("f"), Asc("g"), 0})
            AddRawFileExtension(New Byte() {Asc("."), Asc("i"), Asc("n"), Asc("f"), Asc("o"), 0}, 5)

            Dim imageOffset As Integer = 0
            Dim imageCount As Integer = ByteHandling.CountBytes(ffBytes, New Byte() {0, 160, 171, 16}, 0)
            For i As Integer = 0 To imageCount - 1

                imageOffset = ByteHandling.FindBytes(ffBytes, New Byte() {0, 160, 171, 16}, imageOffset + 1)
                Dim nameOffsetEnd As Integer = imageOffset ' start of Image name
                Dim nameOffset As Integer = 0
                If (openedMW2) Then ' for some reason, cod4 uses a FF byte to indicate the start of an image :S?
                    nameOffset = ByteHandling.FindByteBackward(ffBytes, Byte.Parse(0), nameOffsetEnd - 1) + 1
                Else
                    nameOffset = ByteHandling.FindByteBackward(ffBytes, Byte.Parse(255), nameOffsetEnd - 1) + 1
                End If
                MiscData.Nodes(0).Nodes.Add(ByteHandling.GetString(ffBytes, nameOffset, nameOffsetEnd))
                Application.DoEvents()
            Next

            Dim menuOffset As Integer = 0
            Dim menuCount As Integer = ByteHandling.CountBytes(ffBytes, New Byte() {Asc("."), Asc("m"), Asc("e"), Asc("n"), Asc("u"), 0}, 0)
            For i As Integer = 0 To menuCount - 1
                menuOffset = ByteHandling.FindBytes(ffBytes, New Byte() {Asc("."), Asc("m"), Asc("e"), Asc("n"), Asc("u"), 0}, menuOffset + 1)
                Dim nameOffsetEnd As Integer = menuOffset ' start of menu name
                Dim nameOffset As Integer = 0
                nameOffset = ByteHandling.FindByteBackward(ffBytes, Byte.Parse(255), nameOffsetEnd - 1) + 1
                Dim node As TreeNode = MiscData.Nodes(1).Nodes.Add(ByteHandling.GetString(ffBytes, nameOffset, nameOffsetEnd + 5))
                node.Nodes.Add("Name Offset: " + nameOffset.ToString())
                node.Nodes.Add("File offset: " + nameOffsetEnd.ToString())
                node.Nodes.Add("# of menuDef's: " + ByteHandling.GetDWORD(ffBytes, nameOffset - 8, Not openedMW2).ToString())
                Application.DoEvents()
            Next

            Dim weapCount As Integer = ByteHandling.CountBytes(ffBytes, New Byte() {0, Asc("W"), Asc("E"), Asc("A"), Asc("P")})
            offset = 0
            For i As Integer = 0 To weapCount - 1
                offset = ByteHandling.FindBytes(ffBytes, New Byte() {0, Asc("W"), Asc("E"), Asc("A"), Asc("P")}, offset + 1, True) + 1
                Dim startofNameoffset As Integer = ByteHandling.FindByteBackward(ffBytes, Byte.Parse(0), offset) + 1
                Dim endofNameoffset As Integer = ByteHandling.FindBytes(ffBytes, New Byte() {255}, offset) + 1
                Dim node As TreeNode = MiscData.Nodes(2).Nodes.Add(ByteHandling.GetString(ffBytes, startofNameoffset, endofNameoffset))
                Dim endOffset As Integer = ByteHandling.FindBytes(ffBytes, New Byte() {255, 255, 255, 255}, offset + 4).ToString()
                node.Nodes.Add("Name Offset: " + startofNameoffset.ToString())
                node = Nothing
            Next

            'Catch ex As Exception
            '    MessageBox.Show("Could not open .FF file: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try

            fileInfo.Size = ByteHandling.GetDWORD(ffBytes, 0, Not fileInfo.BigEndian)

            If (fileInfo.Version = MW2Version Or fileInfo.Version = MW2VersionPC) Then
                fileInfo.SecondSize = ByteHandling.GetDWORD(ffBytes, 20, Not fileInfo.BigEndian)
            Else
                fileInfo.SecondSize = ByteHandling.GetDWORD(ffBytes, 24, Not fileInfo.BigEndian)
            End If

            FileGridView.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error opening: " + ex.Message)
        End Try

    End Sub

    Private Sub AddRawFileExtension(ByVal extension As Byte(), Optional ByVal OffsetPlus As Integer = 4)
        Wait.Hide()
        Dim gscCount As Integer = ByteHandling.CountBytes(ffBytes, extension)
        Dim offset As Integer = 0
        For i As Integer = 0 To gscCount - 1
            offset = ByteHandling.FindBytes(ffBytes, extension, offset + 1, True) + 1
            Dim startofNameoffset As Integer = ByteHandling.FindByteBackward(ffBytes, Byte.Parse(255), offset) + 1
            Dim compressedSize As Integer = ByteHandling.GetDWORD(ffBytes, startofNameoffset - 12, Not fileInfo.BigEndian)
            Dim node As TreeNode = RawFiles.Nodes.Add(ByteHandling.GetString(ffBytes, startofNameoffset, offset + 4))
            Dim endOffset As Integer = ByteHandling.FindBytes(ffBytes, New Byte() {255, 255, 255, 255}, offset + OffsetPlus).ToString()
            If (compressedSize = 0 Or compressedSize = -1) Then
                endOffset -= 1
            End If
            Dim gscBytes As Byte()
            ReDim gscBytes(endOffset - (offset + 4))
            Array.ConstrainedCopy(ffBytes, offset + 4, gscBytes, 0, endOffset - (offset + 4))
            node = Nothing
            Application.DoEvents()
            If (compressedSize = -1 Or compressedSize = 0) Then
                fileInfo.RawFiles.Add(New RawFileData(ByteHandling.GetString(ffBytes, startofNameoffset, offset + 4), endOffset - (offset + 4), offset + 4, False, ByteHandling.CountBytes(gscBytes, New Byte() {255})))
            Else
                fileInfo.RawFiles.Add(New RawFileData(ByteHandling.GetString(ffBytes, startofNameoffset, offset + 4), endOffset - (offset + 4), offset + 4, True, ByteHandling.CountBytes(gscBytes, New Byte() {255})))
            End If
        Next
    End Sub

    Private Sub DONATEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DONATEToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=6HSWAEP7DRLJE")
    End Sub

    Private Sub SaveFFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveFFToolStripMenuItem.Click
        Try

            If (CodeBox.Text.Length < 1) Then
                MessageBox.Show("You didn't edit anything! There is no need to save!", "What are you on?!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Else
                ' First of all, write the opened .GSC to the data file ("currentOpenFFextraced")
                Dim compressedFile As Byte()
                Dim newNumberOfFFs As Integer = 0
                changedGSC = False
                Dim saveRawFile As RawFileData = fileInfo.RawFiles(clickNodeRawFiles.Index)
                If (saveRawFile.Compressed) Then
                    compressedFile = ZlibStream.CompressString(CodeBox.Text)

                    ' the below line is commented out because i haven't worked out how to make the file smaller or larger yet :(
                    'ffBytes = ByteHandling.SetDWORD(ffBytes, saveRawFile.Offset - saveRawFile.Filename.Length - 11, compressedFile.Length, Not fileInfo.BigEndian) ' compressed size

                    ffBytes = ByteHandling.SetDWORD(ffBytes, saveRawFile.Offset - saveRawFile.Filename.Length - 7, CodeBox.Text.Length, Not fileInfo.BigEndian) ' uncompressed size
                Else
                    compressedFile = System.Text.ASCIIEncoding.ASCII.GetBytes(CodeBox.Text)
                End If



                ' delete the previous data
                ffBytes = ByteHandling.RemoveBytes(ffBytes, saveRawFile.Offset - 1, (saveRawFile.Offset) + saveRawFile.Size)

                ' now, add the new data!

                ffBytes = ByteHandling.AddBytes(ffBytes, compressedFile, saveRawFile.Offset)

                ' pad the new data to the same size as the old data
                Dim nulls As Byte()
                ReDim nulls(saveRawFile.Size - compressedFile.Length - 1)
                ffBytes = ByteHandling.AddBytes(ffBytes, nulls, saveRawFile.Offset + compressedFile.Length)

                ' set the new file size
                If (fileInfo.Version = MW2Version) Then
                    ffBytes = ByteHandling.SetDWORD(ffBytes, 0, ffBytes.Length - 32, Not fileInfo.BigEndian)
                    fileInfo.Size = ffBytes.Length - 32
                Else
                    ffBytes = ByteHandling.SetDWORD(ffBytes, 0, ffBytes.Length - 36, Not fileInfo.BigEndian)
                    fileInfo.Size = ffBytes.Length - 36
                End If


                ' overwrite the current open -extract.dat
                File.Delete(currentOpenFFextracted)
                File.WriteAllBytes(currentOpenFFextracted, ffBytes)

                ' use the backend to save the -extract.dat to the fastfile and compress it
                If (File.ReadAllBytes(fileInfo.FileName).Length < 2097152) Then
                    Dim backEnd As Process = System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\FFbackend.exe", "-s "" " + fileInfo.FileName + " "" "" " + currentOpenFFextracted + " "" " + fileInfo.DataOffset.ToString() + " false " + fileInfo.Version.ToString() + " " + fileInfo.BigEndian.ToString())
                    Wait.Show()
                    backEnd.WaitForExit()
                    ReloadOffsets("0")
                    Wait.Hide()
                Else
                    Dim backEnd As Process = System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\FFbackend.exe", "-s "" " + fileInfo.FileName + " "" "" " + currentOpenFFextracted + " "" " + fileInfo.DataOffset.ToString() + " " + fileInfo.IsMultiplayer.ToString() + " " + fileInfo.Version.ToString() + " " + fileInfo.BigEndian.ToString())
                    Wait.Show()
                    backEnd.WaitForExit()
                    ReloadOffsets("0")
                    Wait.Hide()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Error saving .FF: " + ex.Message, "Error saving")
        End Try
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        CodeBox.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        If (CodeBox.SelectedText.Length > 0) Then
            Clipboard.SetText(CodeBox.SelectedText)
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        CodeBox.Paste()
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        Find.Show()
    End Sub

    Public Function CharCount(ByVal OrigString As String, _
  ByVal Chars As String, Optional ByVal CaseSensitive As Boolean = False) _
  As Long

        Dim lAns As Long
        Dim sChar As String
        Dim lCtr As Long
        Dim lEndOfLoop As Long
        Dim bytCompareType As Byte

        If OrigString = "" Then Exit Function
        lEndOfLoop = (Len(OrigString) - Len(Chars)) + 1
        bytCompareType = IIf(CaseSensitive, vbBinaryCompare, _
           vbTextCompare)

        For lCtr = 1 To lEndOfLoop
            sChar = Mid(OrigString, lCtr, Len(Chars))
            If StrComp(sChar, Chars, bytCompareType) = 0 Then _
                lAns = lAns + 1
        Next

        CharCount = lAns

    End Function

    Private Sub DoItToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (fileInfo.FileName.Length > 5) Then
            Wait.Show()
            'If (Boolean.Parse(GetPreferenceValue("reduceram", "True"))) Then
            Dim backEnd As Process = System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\FFbackend.exe", "-s "" " + fileInfo.FileName + " "" "" " + currentOpenFFextracted + " "" " + fileInfo.DataOffset.ToString() + " " + fileInfo.IsMultiplayer.ToString())
            backEnd.WaitForExit()
            ffBytes = File.ReadAllBytes(currentOpenFFextracted)
            'Else
            '    SaveFFBackEnd(fileInfo.FileName, currentOpenFFextracted, fileInfo.HeaderOffset, fileInfo.IsMultiplayer)
            '    ffBytes = File.ReadAllBytes(currentOpenFFextracted)
            'End If
            Wait.Hide()

        End If
    End Sub

    Private Sub CloseFFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseFFToolStripMenuItem.Click
        Try

            If (MessageBox.Show("Are you sure? Any unsaved changes will be lost", "Close .FF?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                If (Boolean.Parse(GetPreferenceValue("deletetemp", "False"))) Then
                    File.Delete(currentOpenFFextracted)
                End If
                Array.Clear(ffBytes, 0, ffBytes.Length)
                fileInfo.DataOffset = 0

                fileInfo.FileName = ""
                fileInfo.IsMultiplayer = False
                fileInfo.DataOffset = 0
                fileInfo.PreAssetStrings.Clear()
                fileInfo.Size = 0
                fileInfo.Version = 0
                fileInfo.Assets.Clear()
                fileInfo.AssetCount = 0
                fileInfo.BigEndian = False
                fileInfo.OrigFileName = ""
                fileInfo.PreAssetStringCount = 0
                fileInfo.SecondSize = 0

                LnLbl.Text = "Ln:"
                ColLbl.Text = "Col:"
                OpenRawFile.Text = "Open Raw File:"
                OpenStringTable.Text = "Open String Table:"
                OldSizeLbl.Text = "Old size:"
                NewSizeLbl.Text = "New size:"

                FileGridView.Refresh()

                currentOpenFFextracted = ""

                RawFiles.Nodes.Clear()
                fileInfo.RawFiles.Clear()

                MiscData.Nodes(0).Nodes.Clear()
                MiscData.Nodes(1).Nodes.Clear()
                MiscData.Nodes(2).Nodes.Clear()

                CodeBox.Text = ""
                openFileCompressed = False
                openFileStart = 0
                openFileEnd = 0
                openedMW2 = False
                fileInfo.IsMultiplayer = False
                Me.Text = "FF Viewer v" + versionNum
            End If

        Catch ex As Exception
            MessageBox.Show("Error: cannot close (??). Recommended steps: close the program :\", "Error closing")
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub SyntaxCheckerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyntaxCheckerToolStripMenuItem.Click
        Dim i As Integer = 1

        Dim openStasheCount As Integer = 0
        Dim closeStasheCount As Integer = 0

        Dim startLineSearchBracket As Integer = -1
        Dim currentSearchBracket As Integer = -1

        Dim totalLines As String() = CodeBox.Text.Split(vbCrLf)
        Dim functions(450) As String
        Dim includes(25) As String ' it actually stores the included files :O

        Dim functionCount As Integer = 0
        Dim includeCount As Integer = 0

        ' Go line by line, counting up the amounts of things like curly braces
        For Each line As String In totalLines
            Dim commentChar As Integer = line.Length
            If (line.LastIndexOf("//") <> -1) Then
                commentChar = line.IndexOf("//")
            End If
            Dim beforeComment As String = line.Substring(0, commentChar)

            openStasheCount += CharCount(beforeComment, "{")
            closeStasheCount += CharCount(beforeComment, "}")

            If (openStasheCount = closeStasheCount And line.IndexOf("}") And line.IndexOf("#include") = -1) Then ' if the line isn't in a function....
                If (line.IndexOf("(") = -1) Then
                    'functions(functionCount) = line.Substring(0, line.Length)
                    ' tbh, it should not even do this :S
                Else
                    functions(functionCount) = line.Substring(0, line.IndexOf("("))
                    functionCount += 1
                End If


            End If
            If (line.IndexOf("#include") <> -1) Then
                includes(includeCount) = line.Substring(line.IndexOf("#include") + 8)
                includeCount += 1
            End If
            i += 1
        Next
        ' So, we have all of the functions. Now see if anything is called that ins't a function!
        Dim allFunctions As String = "" ' a CSV function table
        Dim allIncludes As String = "" ' a CSV includes table
        For k As Integer = 0 To functions.Length - 1
            allFunctions += functions(k) + ","
        Next
        ReDim functions(1) ' delete to save some ram
        For k As Integer = 0 To includes.Length - 1
            allIncludes += includes(k) + ","
        Next
        ReDim functions(1) ' delete to save some ram
        i = 1
        For Each line As String In totalLines
            If (line.IndexOf("self thread ") <> -1) Then
                ' here is a function called...
                Dim endOffset As Integer = line.IndexOfAny(New Char() {"(", " "}, line.IndexOf(" thread ") + 8) - line.IndexOf(" thread ") - 8
                Dim called As String = line.Substring(line.IndexOf(" thread ") + 8, endOffset)

                If (allFunctions.IndexOf(called + ",") = -1) Then
                    ' the function was NOT found! Check the includes...
                    If (called.IndexOf("\") = -1) Then
                        ' there was also no file reference, so it is an unknown function.
                        MessageBox.Show("Script compile error: Unknown function """ + called + """ on line " + i.ToString())
                    End If

                End If
            End If
            i += 1
        Next

        If (openStasheCount < closeStasheCount) Then
            MessageBox.Show("Syntax error: Too many close braces }")
        End If
        If (openStasheCount > closeStasheCount) Then
            MessageBox.Show("Syntax error: Too many open braces {")
        End If

        MessageBox.Show("Finished checking syntax.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0, False)

    End Sub

    Private Sub CodeBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeBox.TextChanged
        Try
            If (fileInfo.FileName <> "") Then
                If (fileInfo.RawFiles.ElementAt(RawFiles.SelectedNode.Index).Compressed) Then
                    NewSizeLbl.Text = "New size: " + ZlibStream.CompressString(CodeBox.Text).Length.ToString()
                Else
                    NewSizeLbl.Text = "New size: " + CodeBox.Text.Length.ToString()
                End If
            Else
                OldSizeLbl.Text = "Old size:"
                NewSizeLbl.Text = "New size:"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub moved() Handles CodeBox.Click, CodeBox.KeyUp
        LnLbl.Text = "Ln: " + (CodeBox.GetLineFromCharIndex(CodeBox.SelectionStart) + 1).ToString()
        ColLbl.Text = "Col: " + (CodeBox.SelectionStart - CodeBox.GetFirstCharIndexOfCurrentLine() + 1).ToString()
    End Sub

    Public Sub Form1_OnDragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Public Sub Form1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Dim dataFullStrings As String() = e.Data.GetData("FileDrop")

        dragDropFFname = dataFullStrings(0)

        If (File.GetAttributes(dataFullStrings(0)) = FileAttributes.ReadOnly) Then
            MessageBox.Show("Error: File could not be opened. The file is read only", "Error opening")
            dragDropFFname = ""
            Exit Sub
        End If

        If (File.GetAttributes(dataFullStrings(0)) = FileAttributes.Directory) Then
            MessageBox.Show("Error: File could not be opened. The file is a directory", "Error opening")
            dragDropFFname = ""
            Exit Sub
        End If

        If (dragDropFFname.Substring(dragDropFFname.LastIndexOf("."), 3).ToLower() <> ".ff") Then
            MessageBox.Show("Error: File could not be opened. The file is not a Fast File. The extension is: " + dragDropFFname.Substring(dragDropFFname.LastIndexOf(".") + 1, 2), "Error opening")
            dragDropFFname = ""
            Exit Sub
        End If

        OpenFF()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Options.Show()
    End Sub

    Private Sub SaveOverFTPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveOverFTPToolStripMenuItem.Click
        ' save ovar ftp lolzzz

        Try

            Dim clsRequest As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://" + GetPreferenceValue("xboxip") + GetPreferenceValue("path") + "/" + fileInfo.FileName.Substring(fileInfo.FileName.LastIndexOf("\"), fileInfo.FileName.Length - fileInfo.FileName.LastIndexOf("\"))), System.Net.FtpWebRequest)
            clsRequest.UsePassive = False
            clsRequest.Credentials = New System.Net.NetworkCredential(GetPreferenceValue("uname"), GetPreferenceValue("pass"))
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
            clsRequest.UseBinary = True
            'read in file...

            Dim bFile() As Byte = System.IO.File.ReadAllBytes(fileInfo.FileName)

            'upload the file
            Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()

            Wait.Hide()
        Catch ex As Exception
            MessageBox.Show("Error saving over FTP: " + ex.Message, "Error saving")
        End Try


    End Sub

    Private Sub ExportFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ExportFileToolStripMenuItem.Click
        SaveDialog.Title = "Save file"
        SaveDialog.Filter = "All files(*.*)|*.*"
        If (RawFiles.SelectedNode.Text.Contains("/")) Then
            SaveDialog.FileName = RawFiles.SelectedNode.Text.Substring(RawFiles.SelectedNode.Text.LastIndexOf("/") + 1, RawFiles.SelectedNode.Text.Length - RawFiles.SelectedNode.Text.LastIndexOf("/") - 1)
        Else
            SaveDialog.FileName = RawFiles.SelectedNode.Text
        End If

        SaveDialog.FilterIndex = 1
        If (Boolean.Parse(GetPreferenceValue("rememberLF"))) Then
            SaveDialog.InitialDirectory = GetPreferenceValue("lastlocation")
        Else
            SaveDialog.InitialDirectory = Directory.GetCurrentDirectory()
        End If
        SaveDialog.RestoreDirectory = True
        If (SaveDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            If (SaveDialog.CheckFileExists) Then
                File.Delete(SaveDialog.FileName)
            End If
            Dim fileText As Byte()
            Dim selectedRaw As RawFileData = fileInfo.RawFiles.ElementAt(clickNodeRawFiles.Index)
            ReDim fileText(selectedRaw.Size)
            Array.ConstrainedCopy(ffBytes, selectedRaw.Offset, fileText, 0, selectedRaw.Size)

            If (selectedRaw.Compressed) Then
                File.WriteAllText(SaveDialog.FileName, System.Text.ASCIIEncoding.ASCII.GetString(ZlibStream.UncompressBuffer(fileText)))
            Else
                File.WriteAllText(SaveDialog.FileName, System.Text.ASCIIEncoding.ASCII.GetString(fileText))
            End If
        End If
    End Sub

    Private Sub RemoveCommentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveCommentsToolStripMenuItem.Click
        Dim firstCommentChar As Integer = -1 ' The first time an occurance of "//" exists to seperate comments from code!
        Dim endCommentChar As Integer = -1
        Dim numComments As Integer = 0 ' number of comments removed
        'DeletingComments.Show()
        For i As Integer = 0 To CodeBox.Text.Length - 2
            Dim newCodeBoxText As String = ""
            If (CodeBox.Text.Length - 1 > i) Then ' added bcoz removing the comments makes the code box length smaller
                If firstCommentChar = -1 Then
                    If (CodeBox.Text(i) = "/" And CodeBox.Text(i + 1) = "/") Then
                        ' Here is a comment!
                        firstCommentChar = i
                    End If

                End If

                If (endCommentChar = -1 And firstCommentChar <> -1) Then
                    If (CodeBox.Text(i) = vbCr And CodeBox.Text(i + 1) = vbLf) Then
                        endCommentChar = i
                        ' before the comment:
                        newCodeBoxText = CodeBox.Text.Substring(0, firstCommentChar)
                        ' after the comment:
                        newCodeBoxText += CodeBox.Text.Substring(endCommentChar, CodeBox.Text.Length - endCommentChar)

                        CodeBox.Text = newCodeBoxText

                        i -= (endCommentChar - firstCommentChar)

                        endCommentChar = -1
                        firstCommentChar = -1

                        numComments += 1

                        newCodeBoxText = ""

                    End If

                End If
            End If

        Next

        ' DELETE /* */ S
        For i As Integer = 0 To CodeBox.Text.Length - 2
            Dim newCodeBoxText As String = ""
            If (CodeBox.Text.Length - 1 > i) Then ' added bcoz removing the comments makes the code box length smaller
                If firstCommentChar = -1 Then
                    If (CodeBox.Text(i) = "/" And CodeBox.Text(i + 1) = "*") Then
                        ' Here is a comment!
                        firstCommentChar = i
                    End If

                End If

                If (endCommentChar = -1 And firstCommentChar <> -1) Then
                    If (CodeBox.Text(i) = "*" And CodeBox.Text(i + 1) = "/") Then
                        endCommentChar = i
                        ' before the comment:
                        newCodeBoxText = CodeBox.Text.Substring(0, firstCommentChar)
                        ' after the comment:
                        newCodeBoxText += CodeBox.Text.Substring(endCommentChar + 2, CodeBox.Text.Length - endCommentChar - 2)

                        CodeBox.Text = newCodeBoxText

                        i -= (endCommentChar - firstCommentChar)

                        endCommentChar = -1
                        firstCommentChar = -1

                        numComments += 1

                        newCodeBoxText = ""

                    End If

                End If
            End If

        Next
        ' DELETE /# #/ S
        For i As Integer = 0 To CodeBox.Text.Length - 2
            Dim newCodeBoxText As String = ""
            If (CodeBox.Text.Length - 1 > i) Then ' added bcoz removing the comments makes the code box length smaller
                If firstCommentChar = -1 Then
                    If (CodeBox.Text(i) = "/" And CodeBox.Text(i + 1) = "#") Then
                        ' Here is a comment!
                        firstCommentChar = i
                    End If

                End If

                If (endCommentChar = -1 And firstCommentChar <> -1) Then
                    If (CodeBox.Text(i) = "#" And CodeBox.Text(i + 1) = "/") Then
                        endCommentChar = i
                        ' before the comment:
                        newCodeBoxText = CodeBox.Text.Substring(0, firstCommentChar)
                        ' after the comment:
                        newCodeBoxText += CodeBox.Text.Substring(endCommentChar + 2, CodeBox.Text.Length - endCommentChar - 2)

                        CodeBox.Text = newCodeBoxText

                        i -= (endCommentChar - firstCommentChar)

                        endCommentChar = -1
                        firstCommentChar = -1

                        numComments += 1

                        newCodeBoxText = ""

                    End If

                End If
            End If
        Next
    End Sub

    Private Sub GetPatchmpffTU6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetPatchmpffTU6ToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://dev-il.com/xbox/patch_mp-tu6.ff")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub PadFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PadFileToolStripMenuItem.Click
        If (OpenRawFile.Text.Length > 16) Then
            CodeBox.Text += "//"
            For i As Integer = Integer.Parse(NewSizeLbl.Text.Substring(10, NewSizeLbl.Text.Length - 10)) To fileInfo.RawFiles.ElementAt(RawFiles.SelectedNode.Index).Size
                CodeBox.Text += "/"
            Next
        End If
    End Sub

    Private Sub ExtractAllGSCsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtractAllGSCsToolStripMenuItem.Click
        SaveDialog.Title = "Locate the root directory that the files should go"
        SaveDialog.Filter = "GSC files(*.gsc)|*.gsc"

        SaveDialog.FileName = "save here.gsc"

        SaveDialog.FilterIndex = 1
        If (Boolean.Parse(GetPreferenceValue("rememberLF"))) Then
            SaveDialog.InitialDirectory = GetPreferenceValue("lastlocation")
        Else
            SaveDialog.InitialDirectory = Directory.GetCurrentDirectory()
        End If
        SaveDialog.RestoreDirectory = True
        If (SaveDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            For i As Integer = 0 To RawFiles.Nodes(0).Nodes.Count - 1
                ' get all directories
                Dim nodeText As String = RawFiles.Nodes(0).Nodes(i).Text
                nodeText = Replace(nodeText, "/", "\")
                nodeText = nodeText.Substring(0, nodeText.LastIndexOf("\"))
                Dim currDir As String = SaveDialog.FileName.Substring(0, SaveDialog.FileName.LastIndexOf("\"))
                If (Not Directory.Exists(currDir + "\" + nodeText)) Then
                    Directory.CreateDirectory(currDir + "\" + nodeText)
                End If
            Next
            For i As Integer = 0 To RawFiles.Nodes(0).Nodes.Count

                Dim currDir As String = SaveDialog.FileName.Substring(0, SaveDialog.FileName.LastIndexOf("\")) + "\" + Replace(RawFiles.Nodes(0).Nodes(i).Text, "/", "\")

                Dim extract As Byte()

                Dim startCompSizeOffset As Integer = Val(RawFiles.Nodes(0).Nodes(i).Nodes(0).Text.Substring(13)) - 12
                Dim startingOffset As Integer = Val(RawFiles.Nodes(0).Nodes(i).Nodes(1).Text.Substring(19))
                Dim endingOffset As Integer = Val(RawFiles.Nodes(0).Nodes(i).Nodes(2).Text.Substring(17))

                ReDim extract(endingOffset - startingOffset)

                Array.ConstrainedCopy(ffBytes, startingOffset, extract, 0, endingOffset - startingOffset)

                If (File.Exists(currDir)) Then
                    File.Delete(currDir)
                End If

                If (openedMW2) Then
                    Dim compress As String = System.Text.ASCIIEncoding.ASCII.GetString(ZlibStream.UncompressBuffer(extract))
                    File.WriteAllText(currDir, compress)
                Else
                    File.WriteAllText(currDir, BitConverter.ToString(extract))
                End If


            Next
        End If
    End Sub

    Private Sub InsertNewFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertNewFileToolStripMenuItem.Click

    End Sub

    Private Sub DeleteSelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelectedToolStripMenuItem.Click
        'If (MessageBox.Show("Are you sure you want to remove this raw file?", "Remove?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
        '    Dim removeRaw As RawFileData = fileInfo.RawFiles(clickNodeRawFiles.Index)

        '    ffBytes = ByteHandling.RemoveBytes(ffBytes, removeRaw.Offset - removeRaw.Filename.Length - 16, removeRaw.Offset + removeRaw.Size)

        '    fileInfo.Size = ffBytes.Length
        '    RawFiles.Nodes.RemoveAt(clickNodeRawFiles.Index)
        '    fileInfo.RawFiles.RemoveAt(clickNodeRawFiles.Index)

        '    ReloadOffsets("19") ' 19 = a raw file
        'End If
    End Sub

    Private Sub ReloadOffsets(Optional ByVal removeHexAsset As String = "0", Optional ByVal addHexAsset As String = "0")
        
        RawFiles.Nodes.Clear()
        fileInfo.RawFiles.Clear()

        AddRawFileExtension(New Byte() {Asc("."), Asc("g"), Asc("s"), Asc("c"), 0})
        AddRawFileExtension(New Byte() {Asc("."), Asc("r"), Asc("m"), Asc("b"), 0})
        AddRawFileExtension(New Byte() {Asc("."), Asc("d"), Asc("e"), Asc("f"), 0, 78})
        AddRawFileExtension(New Byte() {Asc("."), Asc("c"), Asc("f"), Asc("g"), 0})
        AddRawFileExtension(New Byte() {Asc("."), Asc("i"), Asc("n"), Asc("f"), Asc("o"), 0}, 5)

    End Sub

    Private Sub RawFilesRightClick(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles RawFiles.MouseDown
        'If e.Button = MouseButtons.Right Then
        clickNodeRawFiles = RawFiles.GetNodeAt(e.X, e.Y)
        'End If
    End Sub

    Private Sub RawFiles_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles RawFiles.AfterSelect
        Try
            If (changedGSC) Then
                If (MessageBox.Show("You have edited the current file. Want to discard changes?", "Discard changes?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                    changedGSC = False
                Else
                    Exit Sub
                End If
            End If

            Dim file As Byte()

            Dim selectedRaw As RawFileData = fileInfo.RawFiles.ElementAt(RawFiles.SelectedNode.Index)

            OpenRawFile.Text = "Open Raw File: " + selectedRaw.Filename

            ReDim Preserve file(selectedRaw.Size)

            Array.ConstrainedCopy(ffBytes, selectedRaw.Offset, file, 0, selectedRaw.Size)

            If (selectedRaw.Compressed) Then
                CodeBox.Text = System.Text.ASCIIEncoding.ASCII.GetString(ZlibStream.UncompressBuffer(file))
            Else
                CodeBox.Text = System.Text.ASCIIEncoding.ASCII.GetString(file)
            End If

            OldSizeLbl.Text = "Old size: " + selectedRaw.Size.ToString()
            If (selectedRaw.Compressed) Then
                NewSizeLbl.Text = "New size: " + ZlibStream.CompressString(CodeBox.Text).Length.ToString()
            Else
                NewSizeLbl.Text = "New size: " + CodeBox.Text.Length.ToString()
            End If

        Catch ex As Exception
            CodeBox.Text = ""
        End Try
    End Sub

    Private Sub StringTables_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles StringTables.AfterSelect
        Dim showRealValue As Boolean = False

        Dim startOfCSV As Integer = ByteHandling.FindBytes(ffBytes, New Byte() {0}, fileInfo.StringTables(e.Node.Index).Offset)
        Dim rows As Integer = fileInfo.StringTables(e.Node.Index).Rows
        Dim columns As Integer = fileInfo.StringTables(e.Node.Index).Columns

        OpenStringTable.Text = "Open String Table: " + e.Node.Text

        Dim currentOffset As Integer = 1
        Dim numFFoffset As Integer = startOfCSV + 1 ' start of string table RELATIVE TO START
        If (fileInfo.Version <> MW2Version And fileInfo.Version <> MW2VersionPC) Then
            numFFoffset += rows * columns * 4
        Else
            numFFoffset += rows * columns * 8
        End If

        Dim cells As Integer = rows * columns

        Dim csvBytes As Byte()

        ReDim csvBytes(cells * 8)

        If (openedMW2) Then
            Array.ConstrainedCopy(ffBytes, startOfCSV, csvBytes, 0, cells * 8)
        Else
            Array.ConstrainedCopy(ffBytes, startOfCSV, csvBytes, 0, cells * 4)
        End If


        For i As Integer = 0 To columns - 1
            StringTableDataView.Columns.Add("#" + (i + 1).ToString(), 100, HorizontalAlignment.Left)
        Next

        Dim currentRow As Integer = 0
        Dim currentColumn As Integer = 0

        Dim currentRowItem As ListViewItem

        Dim reversBytes As Boolean = False

        For i As Integer = 1 To cells
            If (cancelCurrentOp) Then
                cancelCurrentOp = False
                Wait.Close()
                Exit For
            End If
            If (csvBytes(currentOffset) = 255) Then
                ' This value for the CSV is located in the second section
                Dim tempOffset As Integer = ByteHandling.FindBytes(ffBytes, New Byte() {0}, numFFoffset + 1)
                'CodeBox.Text += ByteHandling.GetString(ffBytes, numFFoffset, tempOffset)

                If (currentColumn = 0) Then
                    currentRowItem = StringTableDataView.Items.Add(ByteHandling.GetString(ffBytes, numFFoffset, tempOffset))
                Else
                    currentRowItem.SubItems.Add(ByteHandling.GetString(ffBytes, numFFoffset, tempOffset))
                End If

                numFFoffset = tempOffset + 1 ' need to go 2 ahead

            Else
                ' nned to work out the actual byte layout for the values :O
                If (showRealValue) Then
                    ' sloooooooooooooooooooooooooooooooooooooooooooooooooooooow
                    Dim realValueOffset As Int32 = ByteHandling.GetDWORD3(csvBytes, currentOffset + 1, True)

                    Dim tableIndexBytes As Byte()
                    ReDim tableIndexBytes(3)

                    For j As Integer = 1 To 3
                        tableIndexBytes(j) = csvBytes(currentOffset + j)
                    Next
                    Array.Reverse(tableIndexBytes)


                    realValueOffset = BitConverter.ToUInt32(tableIndexBytes, 0)


                    Dim startValueOffset As Int32 = 188622

                    Dim realOffset As Int32 = 193562

                    Dim text As String = ""

                    If (reversBytes) Then
                        text = ByteHandling.GetString(ffBytes, 193562 + (realValueOffset - startValueOffset), ByteHandling.FindBytes(ffBytes, New Byte() {0}, 193562 + (realValueOffset - startValueOffset), True))
                    Else
                        text = ByteHandling.GetString(ffBytes, 193562 + (realValueOffset - startValueOffset), ByteHandling.FindBytes(ffBytes, New Byte() {0}, 193562 + (realValueOffset - startValueOffset), False))
                    End If

                    If (currentColumn = 0) Then
                        currentRowItem = StringTableDataView.Items.Add(text)
                    Else
                        currentRowItem.SubItems.Add(text)
                    End If

                Else
                    Dim dqword As Byte()
                    ReDim dqword(8)
                    Array.ConstrainedCopy(csvBytes, currentOffset, dqword, 0, 8)

                    If (currentColumn = 0) Then
                        currentRowItem = StringTableDataView.Items.Add("")
                    Else
                        currentRowItem.SubItems.Add("")
                    End If

                    If (ByteHandling.FindBytes(dqword, New Byte() {0, 0, 0, 0}, 4, True) = -1 Or Not openedMW2) Then
                        For j As Integer = 0 To 3
                            currentRowItem.SubItems(currentRowItem.SubItems.Count - 1).Text += Hex(dqword(j))
                            If (j <> 3) Then
                                currentRowItem.SubItems(currentRowItem.SubItems.Count - 1).Text += "-"
                            End If
                        Next
                    End If
                End If

            End If

            If (i Mod columns = 0) Then
                'CodeBox.Text += vbCrLf
                currentRow += 1
                currentColumn = 0
            Else
                Application.DoEvents()
                currentColumn += 1
                ' CodeBox.Text += ","
            End If

            If (fileInfo.Version <> MW2Version And fileInfo.Version <> MW2VersionPC) Then
                currentOffset += 4 ' Go to the next value
            Else
                currentOffset += 8
            End If
        Next
    End Sub

    Private Sub ExportToCSVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToCSVToolStripMenuItem.Click
        SaveDialog.Title = "Save as a .CSV file"
        SaveDialog.Filter = ".CSV files(*.csv)|*.csv"
        'Form1.SaveDialog.FileName = Form1.OpenFileLbl.Text.Substring(Form1.OpenFileLbl.Text.LastIndexOf("/") + 1, Form1.OpenFileLbl.Text.Length - Form1.OpenFileLbl.Text.LastIndexOf("/") - 1)
        SaveDialog.FilterIndex = 1
        SaveDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory()
        SaveDialog.RestoreDirectory = True
        If (SaveDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            If (SaveDialog.CheckFileExists) Then
                System.IO.File.Delete(SaveDialog.FileName)
            End If
            Dim file As New System.IO.FileStream(SaveDialog.FileName, IO.FileMode.Create)
            Dim s As New System.IO.StreamWriter(file)
            For j As Integer = 0 To StringTableDataView.Items.Count - 1
                'rows
                Dim tempStr As String = ""
                For i As Integer = 0 To StringTableDataView.Columns.Count - 1
                    ' columns
                    tempStr += StringTableDataView.Items(j).SubItems(i).Text
                    If (i <> StringTableDataView.Columns.Count - 1) Then
                        tempStr += ","
                    End If
                Next
                s.WriteLine(tempStr)
            Next
            s.Close()
            s.Dispose()
            file.Dispose()
        End If
    End Sub

    Private Sub GetCompressedSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CompSize.Show()
    End Sub

    Private Sub ADVSaveToFFOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADVSaveToFFOnlyToolStripMenuItem.Click
        If (ZlibStream.CompressBuffer(ffBytes).Length < 2097152) Then
            Dim backEnd As Process = System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\FFbackend.exe", "-s "" " + fileInfo.FileName + " "" "" " + currentOpenFFextracted + " "" " + fileInfo.DataOffset.ToString() + " false")
            Wait.Show()
            backEnd.WaitForExit()
            ReloadOffsets("0")
            Wait.Hide()
        Else
            Dim backEnd As Process = System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\FFbackend.exe", "-s "" " + fileInfo.FileName + " "" "" " + currentOpenFFextracted + " "" " + fileInfo.DataOffset.ToString() + " " + fileInfo.IsMultiplayer.ToString())
            Wait.Show()
            backEnd.WaitForExit()
            ReloadOffsets("0")
            Wait.Hide()
        End If
    End Sub

    Private Sub ChromeGunsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CodeBox.Paste("self setClientDvar( ""r_specularmap"", ""2"" );")
    End Sub

    Private Sub GetSourceCodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetSourceCodeToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://dev-il.com/xbox/ffViewer-source.zip")
    End Sub

    Private Sub onClickCustomSnippets(ByVal sender As Object, ByVal e As EventArgs)
        Dim filename As String = sender.ToString()
        If (File.Exists(Directory.GetCurrentDirectory() + "\snippets\" + filename)) Then
            CodeBox.Paste(File.ReadAllText(Directory.GetCurrentDirectory() + "\snippets\" + filename))
        End If
    End Sub

    Private Sub InstructionsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstructionsToolStripMenuItem.Click
        MessageBox.Show("Put the snippets as a text file inside a folder called ""snippets"".", "Custom snippets", MessageBoxButtons.OK)
    End Sub

    Private Sub UpdateSnippetsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateSnippetsToolStripMenuItem.Click
        Dim allFiles As New DirectoryInfo(Directory.GetCurrentDirectory() + "\snippets")
        For Each txt As FileInfo In allFiles.GetFiles("*.txt")
            Snippets.DropDownItems.Add(txt.Name, Nothing, AddressOf onClickCustomSnippets)
        Next
    End Sub
End Class

