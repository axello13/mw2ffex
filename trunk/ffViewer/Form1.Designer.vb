<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Images")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Menus")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Weapons")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveOverFTPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ADVSaveToFFOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SyntaxCheckerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveCommentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PadFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator
        Me.GetPatchmpffTU6ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Snippets = New System.Windows.Forms.ToolStripMenuItem
        Me.DONATEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GetSourceCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileListRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InsertNewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExtractAllGSCsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.DeleteSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InsertExistingFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CodeBoxRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FindNextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GotoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveRawFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenDialog = New System.Windows.Forms.OpenFileDialog
        Me.SaveDialog = New System.Windows.Forms.SaveFileDialog
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.StringTables = New System.Windows.Forms.TreeView
        Me.StringTableDataView = New System.Windows.Forms.ListView
        Me.StringTableRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.RawFiles = New System.Windows.Forms.TreeView
        Me.CodeBox = New System.Windows.Forms.TextBox
        Me.Tabs = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.FileGridView = New System.Windows.Forms.PropertyGrid
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TreeView2 = New System.Windows.Forms.TreeView
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TreeView3 = New System.Windows.Forms.TreeView
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.OldSizeLbl = New System.Windows.Forms.ToolStripStatusLabel
        Me.NewSizeLbl = New System.Windows.Forms.ToolStripStatusLabel
        Me.InstructionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdateSnippetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator
        Me.OpenRawFile = New System.Windows.Forms.ToolStripStatusLabel
        Me.OpenStringTable = New System.Windows.Forms.ToolStripStatusLabel
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TreeView4 = New System.Windows.Forms.TreeView
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.MiscData = New System.Windows.Forms.TreeView
        Me.LnLbl = New System.Windows.Forms.ToolStripStatusLabel
        Me.ColLbl = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1.SuspendLayout()
        Me.FileListRightClick.SuspendLayout()
        Me.CodeBoxRightClick.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.StringTableRightClick.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Tabs.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.AboutToolStripMenuItem, Me.Snippets, Me.DONATEToolStripMenuItem, Me.GetSourceCodeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1096, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFFToolStripMenuItem, Me.SaveFFToolStripMenuItem, Me.SaveOverFTPToolStripMenuItem, Me.ADVSaveToFFOnlyToolStripMenuItem, Me.CloseFFToolStripMenuItem, Me.ToolStripMenuItem1, Me.OptionsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenFFToolStripMenuItem
        '
        Me.OpenFFToolStripMenuItem.Name = "OpenFFToolStripMenuItem"
        Me.OpenFFToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O"
        Me.OpenFFToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.OpenFFToolStripMenuItem.Text = "Open Fastfile"
        '
        'SaveFFToolStripMenuItem
        '
        Me.SaveFFToolStripMenuItem.Name = "SaveFFToolStripMenuItem"
        Me.SaveFFToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S"
        Me.SaveFFToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.SaveFFToolStripMenuItem.Text = "Save Fastfile"
        '
        'SaveOverFTPToolStripMenuItem
        '
        Me.SaveOverFTPToolStripMenuItem.Name = "SaveOverFTPToolStripMenuItem"
        Me.SaveOverFTPToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.SaveOverFTPToolStripMenuItem.Text = "Copy to FTP"
        '
        'ADVSaveToFFOnlyToolStripMenuItem
        '
        Me.ADVSaveToFFOnlyToolStripMenuItem.Name = "ADVSaveToFFOnlyToolStripMenuItem"
        Me.ADVSaveToFFOnlyToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ADVSaveToFFOnlyToolStripMenuItem.Text = "(ADV) External file save"
        '
        'CloseFFToolStripMenuItem
        '
        Me.CloseFFToolStripMenuItem.Name = "CloseFFToolStripMenuItem"
        Me.CloseFFToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Q"
        Me.CloseFFToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.CloseFFToolStripMenuItem.Text = "Close Fastfile"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(191, 6)
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+T"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SyntaxCheckerToolStripMenuItem, Me.RemoveCommentsToolStripMenuItem, Me.PadFileToolStripMenuItem, Me.ToolStripMenuItem5, Me.GetPatchmpffTU6ToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'SyntaxCheckerToolStripMenuItem
        '
        Me.SyntaxCheckerToolStripMenuItem.Name = "SyntaxCheckerToolStripMenuItem"
        Me.SyntaxCheckerToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SyntaxCheckerToolStripMenuItem.Text = "Syntax checker"
        '
        'RemoveCommentsToolStripMenuItem
        '
        Me.RemoveCommentsToolStripMenuItem.Name = "RemoveCommentsToolStripMenuItem"
        Me.RemoveCommentsToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.RemoveCommentsToolStripMenuItem.Text = "Remove comments"
        '
        'PadFileToolStripMenuItem
        '
        Me.PadFileToolStripMenuItem.Name = "PadFileToolStripMenuItem"
        Me.PadFileToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.PadFileToolStripMenuItem.Text = "Pad file (Wii only)"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(180, 6)
        '
        'GetPatchmpffTU6ToolStripMenuItem
        '
        Me.GetPatchmpffTU6ToolStripMenuItem.Name = "GetPatchmpffTU6ToolStripMenuItem"
        Me.GetPatchmpffTU6ToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.GetPatchmpffTU6ToolStripMenuItem.Text = "Get patch_mp.ff TU6"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'Snippets
        '
        Me.Snippets.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstructionsToolStripMenuItem, Me.UpdateSnippetsToolStripMenuItem, Me.ToolStripMenuItem6})
        Me.Snippets.Name = "Snippets"
        Me.Snippets.Size = New System.Drawing.Size(64, 20)
        Me.Snippets.Text = "&Snippets"
        '
        'DONATEToolStripMenuItem
        '
        Me.DONATEToolStripMenuItem.Name = "DONATEToolStripMenuItem"
        Me.DONATEToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.DONATEToolStripMenuItem.Text = "&DONATE :D"
        '
        'GetSourceCodeToolStripMenuItem
        '
        Me.GetSourceCodeToolStripMenuItem.Name = "GetSourceCodeToolStripMenuItem"
        Me.GetSourceCodeToolStripMenuItem.Size = New System.Drawing.Size(107, 20)
        Me.GetSourceCodeToolStripMenuItem.Text = "Get source code!"
        '
        'FileListRightClick
        '
        Me.FileListRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertNewFileToolStripMenuItem, Me.ExportFileToolStripMenuItem, Me.ExtractAllGSCsToolStripMenuItem, Me.EditSelectionToolStripMenuItem, Me.ToolStripMenuItem2, Me.DeleteSelectedToolStripMenuItem, Me.InsertExistingFileToolStripMenuItem})
        Me.FileListRightClick.Name = "FileListRightClick"
        Me.FileListRightClick.Size = New System.Drawing.Size(168, 142)
        '
        'InsertNewFileToolStripMenuItem
        '
        Me.InsertNewFileToolStripMenuItem.Name = "InsertNewFileToolStripMenuItem"
        Me.InsertNewFileToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.InsertNewFileToolStripMenuItem.Text = "Insert new file"
        '
        'ExportFileToolStripMenuItem
        '
        Me.ExportFileToolStripMenuItem.Name = "ExportFileToolStripMenuItem"
        Me.ExportFileToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ExportFileToolStripMenuItem.Text = "Export file"
        '
        'ExtractAllGSCsToolStripMenuItem
        '
        Me.ExtractAllGSCsToolStripMenuItem.Name = "ExtractAllGSCsToolStripMenuItem"
        Me.ExtractAllGSCsToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ExtractAllGSCsToolStripMenuItem.Text = "Extract all"
        '
        'EditSelectionToolStripMenuItem
        '
        Me.EditSelectionToolStripMenuItem.Name = "EditSelectionToolStripMenuItem"
        Me.EditSelectionToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.EditSelectionToolStripMenuItem.Text = "Rename selection"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(164, 6)
        '
        'DeleteSelectedToolStripMenuItem
        '
        Me.DeleteSelectedToolStripMenuItem.Name = "DeleteSelectedToolStripMenuItem"
        Me.DeleteSelectedToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DeleteSelectedToolStripMenuItem.Text = "Delete selected"
        '
        'InsertExistingFileToolStripMenuItem
        '
        Me.InsertExistingFileToolStripMenuItem.Name = "InsertExistingFileToolStripMenuItem"
        Me.InsertExistingFileToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.InsertExistingFileToolStripMenuItem.Text = "Insert existing file"
        '
        'CodeBoxRightClick
        '
        Me.CodeBoxRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripMenuItem3, Me.FindToolStripMenuItem, Me.FindNextToolStripMenuItem, Me.GotoToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.ToolStripMenuItem4, Me.SaveRawFileToolStripMenuItem})
        Me.CodeBoxRightClick.Name = "CodeBoxRightClick"
        Me.CodeBoxRightClick.Size = New System.Drawing.Size(163, 192)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(159, 6)
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F"
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'FindNextToolStripMenuItem
        '
        Me.FindNextToolStripMenuItem.Name = "FindNextToolStripMenuItem"
        Me.FindNextToolStripMenuItem.ShortcutKeyDisplayString = "F3"
        Me.FindNextToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.FindNextToolStripMenuItem.Text = "Find next"
        '
        'GotoToolStripMenuItem
        '
        Me.GotoToolStripMenuItem.Name = "GotoToolStripMenuItem"
        Me.GotoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+G"
        Me.GotoToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.GotoToolStripMenuItem.Text = "Goto"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select all"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(159, 6)
        '
        'SaveRawFileToolStripMenuItem
        '
        Me.SaveRawFileToolStripMenuItem.Name = "SaveRawFileToolStripMenuItem"
        Me.SaveRawFileToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SaveRawFileToolStripMenuItem.Text = "Save raw file"
        '
        'OpenDialog
        '
        Me.OpenDialog.FileName = "OpenDialog"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1088, 511)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "String tables"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.StringTables)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.StringTableDataView)
        Me.SplitContainer2.Size = New System.Drawing.Size(1088, 537)
        Me.SplitContainer2.SplitterDistance = 265
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 1
        '
        'StringTables
        '
        Me.StringTables.ContextMenuStrip = Me.FileListRightClick
        Me.StringTables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StringTables.FullRowSelect = True
        Me.StringTables.Location = New System.Drawing.Point(0, 0)
        Me.StringTables.Name = "StringTables"
        Me.StringTables.Size = New System.Drawing.Size(265, 537)
        Me.StringTables.TabIndex = 1
        '
        'StringTableDataView
        '
        Me.StringTableDataView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StringTableDataView.ContextMenuStrip = Me.StringTableRightClick
        Me.StringTableDataView.Cursor = System.Windows.Forms.Cursors.Default
        Me.StringTableDataView.FullRowSelect = True
        Me.StringTableDataView.GridLines = True
        Me.StringTableDataView.Location = New System.Drawing.Point(3, 0)
        Me.StringTableDataView.MultiSelect = False
        Me.StringTableDataView.Name = "StringTableDataView"
        Me.StringTableDataView.ShowGroups = False
        Me.StringTableDataView.Size = New System.Drawing.Size(819, 537)
        Me.StringTableDataView.TabIndex = 1
        Me.StringTableDataView.UseCompatibleStateImageBehavior = False
        Me.StringTableDataView.View = System.Windows.Forms.View.Details
        '
        'StringTableRightClick
        '
        Me.StringTableRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToCSVToolStripMenuItem})
        Me.StringTableRightClick.Name = "StringTableRightClick"
        Me.StringTableRightClick.Size = New System.Drawing.Size(149, 26)
        '
        'ExportToCSVToolStripMenuItem
        '
        Me.ExportToCSVToolStripMenuItem.Name = "ExportToCSVToolStripMenuItem"
        Me.ExportToCSVToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.ExportToCSVToolStripMenuItem.Text = "Export to .CSV"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1088, 511)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Raw files"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.RawFiles)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CodeBox)
        Me.SplitContainer1.Size = New System.Drawing.Size(1088, 511)
        Me.SplitContainer1.SplitterDistance = 265
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'RawFiles
        '
        Me.RawFiles.ContextMenuStrip = Me.FileListRightClick
        Me.RawFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RawFiles.FullRowSelect = True
        Me.RawFiles.HideSelection = False
        Me.RawFiles.Location = New System.Drawing.Point(0, 0)
        Me.RawFiles.Name = "RawFiles"
        Me.RawFiles.Size = New System.Drawing.Size(265, 511)
        Me.RawFiles.TabIndex = 1
        '
        'CodeBox
        '
        Me.CodeBox.AcceptsTab = True
        Me.CodeBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodeBox.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodeBox.Location = New System.Drawing.Point(2, 0)
        Me.CodeBox.MaxLength = 2147483647
        Me.CodeBox.Multiline = True
        Me.CodeBox.Name = "CodeBox"
        Me.CodeBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.CodeBox.Size = New System.Drawing.Size(820, 515)
        Me.CodeBox.TabIndex = 0
        Me.CodeBox.WordWrap = False
        '
        'Tabs
        '
        Me.Tabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tabs.Controls.Add(Me.TabPage1)
        Me.Tabs.Controls.Add(Me.TabPage2)
        Me.Tabs.Controls.Add(Me.TabPage3)
        Me.Tabs.Controls.Add(Me.TabPage4)
        Me.Tabs.Location = New System.Drawing.Point(0, 27)
        Me.Tabs.Margin = New System.Windows.Forms.Padding(0)
        Me.Tabs.Multiline = True
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(1096, 537)
        Me.Tabs.TabIndex = 3
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.FileGridView)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1088, 511)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Fastfile data"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'FileGridView
        '
        Me.FileGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FileGridView.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileGridView.Location = New System.Drawing.Point(0, 0)
        Me.FileGridView.Name = "FileGridView"
        Me.FileGridView.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.FileGridView.Size = New System.Drawing.Size(1088, 511)
        Me.FileGridView.TabIndex = 0
        Me.FileGridView.ToolbarVisible = False
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.ContextMenuStrip = Me.FileListRightClick
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.Location = New System.Drawing.Point(-4, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(269, 537)
        Me.TreeView1.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.AcceptsTab = True
        Me.TextBox1.AllowDrop = True
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(2, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(820, 541)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.WordWrap = False
        '
        'TreeView2
        '
        Me.TreeView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView2.ContextMenuStrip = Me.FileListRightClick
        Me.TreeView2.FullRowSelect = True
        Me.TreeView2.Location = New System.Drawing.Point(-4, 0)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(269, 537)
        Me.TreeView2.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.AcceptsReturn = True
        Me.TextBox2.AcceptsTab = True
        Me.TextBox2.AllowDrop = True
        Me.TextBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(2, 0)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox2.Size = New System.Drawing.Size(820, 541)
        Me.TextBox2.TabIndex = 0
        Me.TextBox2.WordWrap = False
        '
        'TreeView3
        '
        Me.TreeView3.ContextMenuStrip = Me.FileListRightClick
        Me.TreeView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView3.FullRowSelect = True
        Me.TreeView3.Location = New System.Drawing.Point(0, 0)
        Me.TreeView3.Name = "TreeView3"
        Me.TreeView3.Size = New System.Drawing.Size(265, 537)
        Me.TreeView3.TabIndex = 1
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.ContextMenuStrip = Me.StringTableRightClick
        Me.ListView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(3, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowGroups = False
        Me.ListView1.Size = New System.Drawing.Size(819, 537)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OldSizeLbl, Me.NewSizeLbl, Me.OpenRawFile, Me.OpenStringTable, Me.ToolStripStatusLabel5, Me.LnLbl, Me.ColLbl})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 568)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1096, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'OldSizeLbl
        '
        Me.OldSizeLbl.Name = "OldSizeLbl"
        Me.OldSizeLbl.Size = New System.Drawing.Size(51, 17)
        Me.OldSizeLbl.Text = "Old size:"
        '
        'NewSizeLbl
        '
        Me.NewSizeLbl.Name = "NewSizeLbl"
        Me.NewSizeLbl.Size = New System.Drawing.Size(56, 17)
        Me.NewSizeLbl.Text = "New size:"
        '
        'InstructionsToolStripMenuItem
        '
        Me.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem"
        Me.InstructionsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.InstructionsToolStripMenuItem.Text = "Instructions"
        '
        'UpdateSnippetsToolStripMenuItem
        '
        Me.UpdateSnippetsToolStripMenuItem.Name = "UpdateSnippetsToolStripMenuItem"
        Me.UpdateSnippetsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.UpdateSnippetsToolStripMenuItem.Text = "Update snippets"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(156, 6)
        '
        'OpenRawFile
        '
        Me.OpenRawFile.Name = "OpenRawFile"
        Me.OpenRawFile.Size = New System.Drawing.Size(85, 17)
        Me.OpenRawFile.Text = "Open Raw File:"
        '
        'OpenStringTable
        '
        Me.OpenStringTable.Name = "OpenStringTable"
        Me.OpenStringTable.Size = New System.Drawing.Size(105, 17)
        Me.OpenStringTable.Text = "Open String Table:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1088, 511)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "Misc. data"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TreeView4
        '
        Me.TreeView4.ContextMenuStrip = Me.FileListRightClick
        Me.TreeView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView4.FullRowSelect = True
        Me.TreeView4.HideSelection = False
        Me.TreeView4.Location = New System.Drawing.Point(0, 0)
        Me.TreeView4.Name = "TreeView4"
        Me.TreeView4.Size = New System.Drawing.Size(265, 511)
        Me.TreeView4.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.AcceptsTab = True
        Me.TextBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(2, 0)
        Me.TextBox3.MaxLength = 2147483647
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox3.Size = New System.Drawing.Size(820, 515)
        Me.TextBox3.TabIndex = 0
        Me.TextBox3.WordWrap = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.MiscData)
        Me.SplitContainer3.Size = New System.Drawing.Size(1088, 511)
        Me.SplitContainer3.SplitterDistance = 265
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 1
        '
        'MiscData
        '
        Me.MiscData.ContextMenuStrip = Me.FileListRightClick
        Me.MiscData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MiscData.FullRowSelect = True
        Me.MiscData.HideSelection = False
        Me.MiscData.Location = New System.Drawing.Point(0, 0)
        Me.MiscData.Name = "MiscData"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "Images"
        TreeNode2.Name = "Node1"
        TreeNode2.Text = "Menus"
        TreeNode3.Name = "Node2"
        TreeNode3.Text = "Weapons"
        Me.MiscData.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Me.MiscData.Size = New System.Drawing.Size(265, 511)
        Me.MiscData.TabIndex = 1
        '
        'LnLbl
        '
        Me.LnLbl.Name = "LnLbl"
        Me.LnLbl.Size = New System.Drawing.Size(23, 17)
        Me.LnLbl.Text = "Ln:"
        '
        'ColLbl
        '
        Me.ColLbl.Name = "ColLbl"
        Me.ColLbl.Size = New System.Drawing.Size(28, 17)
        Me.ColLbl.Text = "Col:"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(733, 17)
        Me.ToolStripStatusLabel5.Spring = True
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 590)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Tabs)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FFViewerV2"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.FileListRightClick.ResumeLayout(False)
        Me.CodeBoxRightClick.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.StringTableRightClick.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Tabs.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SyntaxCheckerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DONATEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FileListRightClick As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents InsertNewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodeBoxRightClick As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindNextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GotoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ADVSaveToFFOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseFFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveOverFTPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveCommentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GetPatchmpffTU6ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PadFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtractAllGSCsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents CodeBox As System.Windows.Forms.TextBox
    Friend WithEvents RawFiles As System.Windows.Forms.TreeView
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents FileGridView As System.Windows.Forms.PropertyGrid
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents StringTables As System.Windows.Forms.TreeView
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents StringTableDataView As System.Windows.Forms.ListView
    Friend WithEvents InsertExistingFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StringTableRightClick As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveRawFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Snippets As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TreeView3 As System.Windows.Forms.TreeView
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents OldSizeLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NewSizeLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GetSourceCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstructionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateSnippetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenRawFile As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OpenStringTable As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents MiscData As System.Windows.Forms.TreeView
    Friend WithEvents TreeView4 As System.Windows.Forms.TreeView
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LnLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ColLbl As System.Windows.Forms.ToolStripStatusLabel

End Class
