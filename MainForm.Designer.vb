'
' Created by SharpDevelop.
' User: jackbrooker
' Date: 13/08/2018
' Time: 11:38
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.VaultsComboBox = New System.Windows.Forms.ComboBox()
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.UpdateButton = New System.Windows.Forms.Button()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FileRefListBox = New System.Windows.Forms.ListBox()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ParentFile1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filename1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewPath1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OldPath1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewPathList1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ParentPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.addToSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.getFileReferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.manuallyReplaceReferenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.updateFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorSupress = New System.Windows.Forms.ToolStripMenuItem()
        Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.aboutReReferencingToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.listBoxCons = New System.Windows.Forms.ListBox()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.GetButton2 = New System.Windows.Forms.Button()
        Me.progressBar1 = New System.Windows.Forms.ProgressBar()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip1.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'VaultsComboBox
        '
        Me.VaultsComboBox.FormattingEnabled = True
        Me.VaultsComboBox.Location = New System.Drawing.Point(12, 33)
        Me.VaultsComboBox.Name = "VaultsComboBox"
        Me.VaultsComboBox.Size = New System.Drawing.Size(153, 21)
        Me.VaultsComboBox.TabIndex = 0
        '
        'OpenButton
        '
        Me.OpenButton.Location = New System.Drawing.Point(171, 28)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(153, 31)
        Me.OpenButton.TabIndex = 1
        Me.OpenButton.Text = "Open Files"
        Me.OpenButton.UseVisualStyleBackColor = True
        '
        'UpdateButton
        '
        Me.UpdateButton.Location = New System.Drawing.Point(489, 28)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(153, 31)
        Me.UpdateButton.TabIndex = 3
        Me.UpdateButton.Text = "Update Files"
        Me.UpdateButton.UseVisualStyleBackColor = True
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        Me.openFileDialog1.InitialDirectory = "C:\ENG-CAD"
        Me.openFileDialog1.Multiselect = True
        '
        'FileRefListBox
        '
        Me.FileRefListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FileRefListBox.FormattingEnabled = True
        Me.FileRefListBox.HorizontalScrollbar = True
        Me.FileRefListBox.IntegralHeight = False
        Me.FileRefListBox.Location = New System.Drawing.Point(6, 6)
        Me.FileRefListBox.Name = "FileRefListBox"
        Me.FileRefListBox.Size = New System.Drawing.Size(455, 679)
        Me.FileRefListBox.TabIndex = 4
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.AllowUserToOrderColumns = True
        Me.dataGridView1.AllowUserToResizeRows = False
        Me.dataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ParentFile1, Me.Filename1, Me.NewPath1, Me.OldPath1, Me.NewPathList1, Me.ParentPath})
        Me.dataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.Size = New System.Drawing.Size(1377, 679)
        Me.dataGridView1.TabIndex = 6
        '
        'ParentFile1
        '
        Me.ParentFile1.HeaderText = "Parent Filename"
        Me.ParentFile1.Name = "ParentFile1"
        Me.ParentFile1.ReadOnly = True
        Me.ParentFile1.Width = 200
        '
        'Filename1
        '
        Me.Filename1.HeaderText = "Referenced File Filename"
        Me.Filename1.Name = "Filename1"
        Me.Filename1.ReadOnly = True
        Me.Filename1.Width = 200
        '
        'NewPath1
        '
        Me.NewPath1.HeaderText = "Updated Part Path"
        Me.NewPath1.Name = "NewPath1"
        Me.NewPath1.Width = 400
        '
        'OldPath1
        '
        Me.OldPath1.HeaderText = "Old Path"
        Me.OldPath1.Name = "OldPath1"
        Me.OldPath1.ReadOnly = True
        Me.OldPath1.Width = 400
        '
        'NewPathList1
        '
        Me.NewPathList1.DataPropertyName = "ComboBoxSelect1"
        Me.NewPathList1.HeaderText = "Choose New File"
        Me.NewPathList1.Items.AddRange(New Object() {"-"})
        Me.NewPathList1.Name = "NewPathList1"
        Me.NewPathList1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NewPathList1.Sorted = True
        Me.NewPathList1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.NewPathList1.Width = 500
        '
        'ParentPath
        '
        Me.ParentPath.HeaderText = "Parent Full Path"
        Me.ParentPath.Name = "ParentPath"
        Me.ParentPath.ReadOnly = True
        Me.ParentPath.Width = 500
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.toolStripMenuItem1, Me.aboutToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1421, 24)
        Me.menuStrip1.TabIndex = 8
        Me.menuStrip1.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openToolStripMenuItem, Me.addToSelectionToolStripMenuItem, Me.toolStripSeparator2, Me.getFileReferencesToolStripMenuItem, Me.manuallyReplaceReferenceToolStripMenuItem, Me.toolStripSeparator1, Me.updateFilesToolStripMenuItem, Me.toolStripSeparator3, Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileToolStripMenuItem.Text = "File"
        '
        'openToolStripMenuItem
        '
        Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
        Me.openToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.openToolStripMenuItem.Text = "Open Files"
        '
        'addToSelectionToolStripMenuItem
        '
        Me.addToSelectionToolStripMenuItem.Name = "addToSelectionToolStripMenuItem"
        Me.addToSelectionToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.addToSelectionToolStripMenuItem.Text = "Add to Selection"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(219, 6)
        '
        'getFileReferencesToolStripMenuItem
        '
        Me.getFileReferencesToolStripMenuItem.Name = "getFileReferencesToolStripMenuItem"
        Me.getFileReferencesToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.getFileReferencesToolStripMenuItem.Text = "Get File References"
        '
        'manuallyReplaceReferenceToolStripMenuItem
        '
        Me.manuallyReplaceReferenceToolStripMenuItem.Name = "manuallyReplaceReferenceToolStripMenuItem"
        Me.manuallyReplaceReferenceToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.manuallyReplaceReferenceToolStripMenuItem.Text = "Manually Replace Reference"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(219, 6)
        '
        'updateFilesToolStripMenuItem
        '
        Me.updateFilesToolStripMenuItem.Name = "updateFilesToolStripMenuItem"
        Me.updateFilesToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.updateFilesToolStripMenuItem.Text = "Update Files"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(219, 6)
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.exitToolStripMenuItem.Text = "Exit"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ErrorSupress})
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(61, 20)
        Me.toolStripMenuItem1.Text = "Settings"
        '
        'ErrorSupress
        '
        Me.ErrorSupress.CheckOnClick = True
        Me.ErrorSupress.Name = "ErrorSupress"
        Me.ErrorSupress.Size = New System.Drawing.Size(185, 22)
        Me.ErrorSupress.Text = "Supress Error Popups"
        '
        'aboutToolStripMenuItem
        '
        Me.aboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.helpToolStripMenuItem, Me.aboutReReferencingToolToolStripMenuItem})
        Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
        Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.aboutToolStripMenuItem.Text = "About"
        '
        'helpToolStripMenuItem
        '
        Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
        Me.helpToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.helpToolStripMenuItem.Text = "Help"
        '
        'aboutReReferencingToolToolStripMenuItem
        '
        Me.aboutReReferencingToolToolStripMenuItem.Name = "aboutReReferencingToolToolStripMenuItem"
        Me.aboutReReferencingToolToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.aboutReReferencingToolToolStripMenuItem.Text = "About Re-Referencing Tool"
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel1, Me.toolStripStatusLabel2, Me.toolStripStatusLabel3, Me.toolStripStatusLabel4, Me.toolStripStatusLabel5, Me.toolStripStatusLabel6})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 785)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(1421, 22)
        Me.statusStrip1.TabIndex = 10
        Me.statusStrip1.Text = "statusStrip1"
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(118, 17)
        Me.toolStripStatusLabel1.Text = "toolStripStatusLabel1"
        '
        'toolStripStatusLabel2
        '
        Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
        Me.toolStripStatusLabel2.Size = New System.Drawing.Size(118, 17)
        Me.toolStripStatusLabel2.Text = "toolStripStatusLabel2"
        '
        'toolStripStatusLabel3
        '
        Me.toolStripStatusLabel3.Name = "toolStripStatusLabel3"
        Me.toolStripStatusLabel3.Size = New System.Drawing.Size(118, 17)
        Me.toolStripStatusLabel3.Text = "toolStripStatusLabel3"
        '
        'toolStripStatusLabel4
        '
        Me.toolStripStatusLabel4.Name = "toolStripStatusLabel4"
        Me.toolStripStatusLabel4.Size = New System.Drawing.Size(118, 17)
        Me.toolStripStatusLabel4.Text = "toolStripStatusLabel4"
        '
        'toolStripStatusLabel5
        '
        Me.toolStripStatusLabel5.Name = "toolStripStatusLabel5"
        Me.toolStripStatusLabel5.Size = New System.Drawing.Size(118, 17)
        Me.toolStripStatusLabel5.Text = "toolStripStatusLabel5"
        '
        'toolStripStatusLabel6
        '
        Me.toolStripStatusLabel6.Name = "toolStripStatusLabel6"
        Me.toolStripStatusLabel6.Size = New System.Drawing.Size(118, 17)
        Me.toolStripStatusLabel6.Text = "toolStripStatusLabel6"
        '
        'listBoxCons
        '
        Me.listBoxCons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listBoxCons.BackColor = System.Drawing.SystemColors.MenuText
        Me.listBoxCons.ForeColor = System.Drawing.Color.Lime
        Me.listBoxCons.FormattingEnabled = True
        Me.listBoxCons.IntegralHeight = False
        Me.listBoxCons.Location = New System.Drawing.Point(3, 6)
        Me.listBoxCons.Name = "listBoxCons"
        Me.listBoxCons.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.listBoxCons.Size = New System.Drawing.Size(912, 679)
        Me.listBoxCons.TabIndex = 11
        '
        'tabControl1
        '
        Me.tabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.HotTrack = True
        Me.tabControl1.Location = New System.Drawing.Point(12, 65)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(1397, 717)
        Me.tabControl1.TabIndex = 14
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.splitContainer1)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(1389, 691)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Opened Files & Console"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'splitContainer1
        '
        Me.splitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.FileRefListBox)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.listBoxCons)
        Me.splitContainer1.Size = New System.Drawing.Size(1393, 695)
        Me.splitContainer1.SplitterDistance = 464
        Me.splitContainer1.TabIndex = 12
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.dataGridView1)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(1389, 691)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "References"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'GetButton2
        '
        Me.GetButton2.Location = New System.Drawing.Point(330, 28)
        Me.GetButton2.Name = "GetButton2"
        Me.GetButton2.Size = New System.Drawing.Size(153, 31)
        Me.GetButton2.TabIndex = 15
        Me.GetButton2.Text = "Get File References"
        Me.GetButton2.UseVisualStyleBackColor = True
        '
        'progressBar1
        '
        Me.progressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressBar1.Location = New System.Drawing.Point(648, 28)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(761, 30)
        Me.progressBar1.TabIndex = 16
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1421, 807)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.GetButton2)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.UpdateButton)
        Me.Controls.Add(Me.OpenButton)
        Me.Controls.Add(Me.VaultsComboBox)
        Me.Controls.Add(Me.menuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip1
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reference Manager 4.3"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.tabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private splitContainer1 As System.Windows.Forms.SplitContainer
    Private tabPage2 As System.Windows.Forms.TabPage
    Private tabPage1 As System.Windows.Forms.TabPage
    Private tabControl1 As System.Windows.Forms.TabControl
    Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents updateFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents getFileReferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private listBoxCons As System.Windows.Forms.ListBox
    Private toolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents manuallyReplaceReferenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private ParentPath As System.Windows.Forms.DataGridViewTextBoxColumn
    Private toolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Private toolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Private toolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Private toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents addToSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Private ParentFile1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents aboutReReferencingToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ErrorSupress As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private menuStrip1 As System.Windows.Forms.MenuStrip

    Private NewPathList1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Private OldPath1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private NewPath1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private Filename1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private dataGridView1 As System.Windows.Forms.DataGridView
    Private FileRefListBox As System.Windows.Forms.ListBox
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog

    Private WithEvents UpdateButton As System.Windows.Forms.Button
    Private WithEvents OpenButton As System.Windows.Forms.Button
    Private WithEvents VaultsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents GetButton2 As Button
    Private WithEvents progressBar1 As ProgressBar
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
End Class
