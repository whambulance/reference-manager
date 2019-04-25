Option Explicit On

Imports System.IO
Imports EPDM.Interop.epdm
Imports SolidWorks.Interop.swdocumentmgr
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports SolidWorks.Interop
Imports EPDM.Interop

Partial Public Class MainForm

    Dim SoftVer As String = "Version 4.4.190425"

    Private vault1 As IEdmVault5 = Nothing
    Dim fileName As String
    Dim rawRefs As IEdmRawReferenceMgr
    Dim refs() As EdmRawReference = Nothing
    Dim referenceupdate As IEdmReference11
    Dim GlobalErrorSupress As Boolean = True
    Dim ProgressPoint As Integer
    Dim Clearlist As Integer = Nothing
    Dim AddToSelect As Boolean = False
    Dim swDmApp As SwDMApplication4
    Dim resultTotal As Integer
    Dim resultCounter As Integer
    Dim resultList() As String
    Dim LicenseKey As String

    Private Sub MainForm_Load(
        ByVal sender As System.Object,
          ByVal e As System.EventArgs) _
        Handles MyBase.Load

        If Not File.Exists("Key.txt") Then
            MsgBox("You are missing the PDM License key file. Create a .txt named 'Key.txt' inside the executable folder, and paste your key in there.")
            End
        Else
            LicenseKey = My.Computer.FileSystem.ReadAllText("Key.txt")
        End If

        ErrorSupress.Checked = True

        Try
            Dim vault As IEdmVault8 = New EdmVault5
            Dim Views() As EdmViewInfo = Nothing

            vault.GetVaultViews(Views, False)
            VaultsComboBox.Items.Clear()
            For Each View As EdmViewInfo In Views
                VaultsComboBox.Items.Add(View.mbsVaultName)
            Next
            If VaultsComboBox.Items.Count > 0 Then
                VaultsComboBox.Text = VaultsComboBox.Items(0).ToString
            End If

            toolStripStatusLabel1.Text = "No references shown"
            toolStripStatusLabel2.Text = ""
            toolStripStatusLabel3.Text = ""
            toolStripStatusLabel4.Text = ""
            toolStripStatusLabel5.Text = ""
            toolStripStatusLabel6.Text = ""

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Catch ex As Runtime.InteropServices.COMException
            MessageBox.Show("HRESULT = 0x" +
              ex.ErrorCode.ToString("X") + vbCrLf +
              ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub OpenButton_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenButton.Click
        Try
            If vault1 Is Nothing Then
                vault1 = New EdmVault5()
            End If

            If Not vault1.IsLoggedIn Then
                vault1.LoginAuto(VaultsComboBox.Text, Me.Handle.ToInt32())
            End If

            If Not FileRefListBox.Items.Count = 0 And AddToSelect = False Then
                Clearlist = MessageBox.Show("Warning: Doing this will clear the File & Reference lists, are you sure you want to continue?", "Open Files", MessageBoxButtons.YesNo)
                If Clearlist = 6 Then
                    FileRefListBox.Items.Clear()
                    dataGridView1.Rows.Clear()
                    toolStripStatusLabel1.Text = "No references shown"
                    toolStripStatusLabel2.Text = ""
                    toolStripStatusLabel3.Text = ""
                    toolStripStatusLabel4.Text = ""
                    toolStripStatusLabel5.Text = ""
                    toolStripStatusLabel6.Text = ""
                ElseIf Clearlist = 7 Then
                    Exit Sub
                End If
            End If

            AddToSelect = False

            openFileDialog1.InitialDirectory = vault1.RootFolderPath                                                                                'Set initial directory of design component OpenFileDialog1 to root folder path of vault1 var
            '			openFileDialog1.InitialDirectory = "C:\ENG-CAD\Projects\AA16-295\01 - MC Assy"
            Dim DialogResult As System.Windows.Forms.DialogResult = Nothing                                                                         'dim new var "dialogresult" as a windows form, set it to nothing
            DialogResult = openFileDialog1.ShowDialog()                                                                                             'set var "dialogresult", by opening OpenFileDialog1 dialog

            If Not (DialogResult = System.Windows.Forms.DialogResult.OK) Then
            Else
                rawRefs = CType(vault1.CreateUtility(EdmUtility.EdmUtil_RawReferenceMgr), IEdmRawReferenceMgr)
                Dim fileRefsSupported As Boolean                                                                                                    'simple yes/no VAR for checking if file references are supported by file
                Dim File As String
                For Each File In openFileDialog1.FileNames
                    fileRefsSupported = rawRefs.Open(File)                                                                                          'bool filerefsupp. set to yes/no for current file by trying to open refs
                    If Not fileRefsSupported Then                                                                                                   'check if bool filerefsupp. is yes or no (check if it is not in this case)
                        If GlobalErrorSupress = False Then MessageBox.Show("File's format for " & File & " does not support file references.")      'msgbox to show it is unsupported
                    Else
                        FileRefListBox.Items.Add(File)
                        listBoxCons.Items.Add(File & " added")
                    End If
                    rawRefs.Close()                                                                                                                 'close current open rawRefs
                Next
                listBoxCons.Items.Add(FileRefListBox.Items.Count & " files selected for search")
            End If

        Catch ex As System.Runtime.InteropServices.COMException
            MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub GetButton2_Click(sender As Object, e As EventArgs) Handles GetButton2.Click

        Dim LocationBlacklist As New List(Of String)
        LocationBlacklist.Add("johnguest.com")
        LocationBlacklist.Add("cifs")
        LocationBlacklist.Add("chadwick")

        Try

#Region "Startup_checks"
            If FileRefListBox.Items.Count = 0 Then
                MessageBox.Show("Load files using 'Open Files' before attempting to get references")
                Exit Sub
            End If

            If vault1 Is Nothing Then
                vault1 = New EdmVault5
            End If

            If Not vault1.IsLoggedIn Then
                vault1.LoginAuto(VaultsComboBox.Text, Me.Handle.ToInt32)
            End If

            dataGridView1.Rows.Clear()
            listBoxCons.Items.Add("Vault recognised & ready for search")
#End Region

#Region "Startup_dims"
            Dim RefArraySize As Integer = 0
            Dim FileArraySize As Integer = 0
            Dim ExistingHighlight As Color = ColorTranslator.FromHtml("#e0feff")
            Dim ReplacedHighlight As Color = ColorTranslator.FromHtml("#e1ffe0")
            Dim ChooseNewHighlight As Color = ColorTranslator.FromHtml("#feffe2")
            Dim MissingHighlight As Color = ColorTranslator.FromHtml("#ffe2e2")
            Dim ReplacePath As String = Nothing

            Dim FileRefList As New Dictionary(Of String, List(Of String))
            listBoxCons.Items.Add("Beginning Dictionary Search")
#End Region

#Region "Generate_Dictionary"

            Dim refscount As Integer = 0
            For Each Entry In openFileDialog1.FileNames
                Console.WriteLine("Getting references for " & Entry)
                rawRefs.Close()
                rawRefs.Open(Entry)
                rawRefs.GetReferences(refs)
                RefArraySize = refs.Length
                Console.WriteLine("Got references for " & Entry)
                If RefArraySize = 0 Then
                    If GlobalErrorSupress = False Then
                        MessageBox.Show("File " & Entry & " contains no references, and was skipped")
                    End If
                Else
                    refscount = refscount + refs.Length
                    For Each reference In refs
                        Try
                            FileRefList.Add(Path.GetFileName(Entry.ToString) & "-" & Path.GetFileName(reference.mbsIncludePath.ToString), New List(Of String))
                            FileRefList(Path.GetFileName(Entry.ToString) & "-" & Path.GetFileName(reference.mbsIncludePath.ToString)).Add(Path.GetFileName(Entry.ToString))
                            FileRefList(Path.GetFileName(Entry.ToString) & "-" & Path.GetFileName(reference.mbsIncludePath.ToString)).Add(Path.GetFileName(reference.mbsIncludePath.ToString))
                            FileRefList(Path.GetFileName(Entry.ToString) & "-" & Path.GetFileName(reference.mbsIncludePath.ToString)).Add("na")
                            FileRefList(Path.GetFileName(Entry.ToString) & "-" & Path.GetFileName(reference.mbsIncludePath.ToString)).Add(reference.mbsIncludePath.ToString)
                            FileRefList(Path.GetFileName(Entry.ToString) & "-" & Path.GetFileName(reference.mbsIncludePath.ToString)).Add("-")
                            FileRefList(Path.GetFileName(Entry.ToString) & "-" & Path.GetFileName(reference.mbsIncludePath.ToString)).Add(Entry.ToString)
                            Console.WriteLine("Ref array consolidated for " & Entry)
                        Catch ex As System.Runtime.InteropServices.COMException
                            Console.WriteLine("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message)
                        Catch ex As Exception
                        End Try

                        'FileRefList.Item(key.Key)(0) = Parent FileName
                        'FileRefList.Item(key.Key)(1) = Referenced FileName
                        'FileRefList.Item(key.Key)(2) = Replaced FilePath
                        'FileRefList.Item(key.Key)(3) = Old FilePath
                        'FileRefList.Item(key.Key)(4) = Dropdown Selection
                        'FileRefList.Item(key.Key)(5) = Parent FilePath

                    Next
                End If
            Next
            progressBar1.Maximum = refscount
            ProgressPoint = 0
#End Region

#Region "Search_Script"

            Dim keycount As Integer = 1
            For Each key In FileRefList
                listBoxCons.Items.Add("Opening reference " & keycount & " for " & FileRefList.Item(key.Key)(0))
                Console.WriteLine("1: Opening reference " & keycount & " for " & FileRefList.Item(key.Key)(0))
                keycount += 1
                Dim SearchResults As New List(Of IEdmSearchResult5)
                Dim SortResult As String = Nothing

#Region "Consolidate_Search_to_List"
                Dim search As IEdmSearch5 = vault1.CreateSearch
                Dim result As IEdmSearchResult5 = Nothing
                Dim Blacklisted As Boolean = False
                search.Clear()
                search.FindFiles = True
                search.FindFolders = False
                search.Recursive = True
                For Each Value In LocationBlacklist
                    If FileRefList.Item(key.Key)(3).ToString.ToLower.Contains(Value) = True Then
                        Blacklisted = True
                        Exit For
                    End If
                Next
                If Blacklisted = True Then
                ElseIf System.IO.File.Exists(FileRefList.Item(key.Key)(3)) = True And FileRefList.Item(key.Key)(3).ToLower.Contains("c:\eng-cad\") = True Then
                    SortResult = "Existing Reference OK"
                End If
                If FileRefList.Item(key.Key)(1).Contains("[") = False And FileRefList.Item(key.Key)(1).Contains("]") = False And SortResult Is Nothing Then
                    search.FileName = "%" & FileRefList.Item(key.Key)(1).Substring(0, FileRefList.Item(key.Key)(1).IndexOf(".")) & "%"
                ElseIf SortResult Is Nothing Then
                    search.FileName = "%" & FileRefList.Item(key.Key)(1).Substring(0, FileRefList.Item(key.Key)(1).IndexOf("[")) & "%"
                End If
                If SortResult = Nothing Then
                    Console.WriteLine("2: Beginning search for " & FileRefList.Item(key.Key)(1).ToString)
                    result = search.GetFirstResult()
                    Console.WriteLine("3: Search complete for " & FileRefList.Item(key.Key)(1).ToString)
                    While result IsNot Nothing And search.FileName.Length > 2
                        SearchResults.Add(result)
                        result = search.GetNextResult
                    End While
                End If
                Console.WriteLine("4: Consolidation done for " & FileRefList.Item(key.Key)(1).ToString)
#End Region

#Region "Select_Ideal_From_List"
                If SearchResults.Count > 0 And SortResult Is Nothing And FileRefList.Item(key.Key)(1).ToString.Contains("[") = True And FileRefList.Item(key.Key)(1).ToString.Contains("]") = True Then
                    Dim KeyIssue As Integer = Convert.ToInt32(FileRefList.Item(key.Key)(1).Substring(FileRefList.Item(key.Key)(1).IndexOf("[") + 1, FileRefList.Item(key.Key)(1).IndexOf("]") - FileRefList.Item(key.Key)(1).IndexOf("[") - 1))
                    Dim SearchResultIssue As Integer = 0
                    Dim SortResultIssue As Integer = 0
                    For Each result In SearchResults
                        If result.Name = FileRefList.Item(key.Key)(1) Or result.Name = FileRefList.Item(key.Key)(1).Substring(0, FileRefList.Item(key.Key)(1).IndexOf("[")) & FileRefList.Item(key.Key)(1).Substring(FileRefList.Item(key.Key)(1).LastIndexOf("."), FileRefList.Item(key.Key)(1).Length - FileRefList.Item(key.Key)(1).LastIndexOf(".")) Then
                            SortResult = result.Path
                        ElseIf result.Name.Contains("[") And result.Name.Contains("]") Then
                            Dim testint = 0
                            Dim testbool As Boolean = Int32.TryParse(result.Name.Substring(result.Name.IndexOf("[") + 1, result.Name.IndexOf("]") - result.Name.IndexOf("[") - 1), testint)
                            If testbool Then
                                SearchResultIssue = Convert.ToInt32(result.Name.Substring(result.Name.IndexOf("[") + 1, result.Name.IndexOf("]") - result.Name.IndexOf("[") - 1))
                            Else
                                SearchResultIssue = 0
                            End If
                            Dim testbooltwo As Integer
                            If SortResult Is Nothing Then
                            ElseIf SortResult.Contains("]") And SortResult.Contains("[") And Int32.TryParse(SortResult.Substring(SortResult.IndexOf("[") + 1, SortResult.IndexOf("]") - SortResult.IndexOf("[") - 1), testbooltwo) Then
                                SortResultIssue = Convert.ToInt32(SortResult.Substring(SortResult.IndexOf("[") + 1, SortResult.IndexOf("]") - SortResult.IndexOf("[") - 1))
                            End If
                            If SearchResultIssue >= KeyIssue And SearchResultIssue > SortResultIssue Then
                                SortResult = result.Path
                            End If
                        End If
                        If SortResult Is Nothing Then
                        ElseIf SortResult.Contains("]") = False And SortResult.Contains("[") = False Then
                            Exit For
                        End If
                    Next
                    If SortResult = Nothing Then
                        SortResult = "Choose From Selection"
                    End If
                ElseIf SearchResults.Count > 0 And SortResult Is Nothing Then
                    For Each result In SearchResults
                        If result.Name = FileRefList.Item(key.Key)(1) Then
                            SortResult = result.Path
                            Exit For
                        End If
                    Next
                    If SortResult = Nothing Then
                        SortResult = "Choose From Selection"
                    End If
                ElseIf SearchResults.Count = 0 And SortResult Is Nothing Then
                    SortResult = "No matches found"
                    Console.WriteLine("5: Selection done for " & FileRefList.Item(key.Key)(1).ToString)
                End If
#End Region

#Region "Last_Resort"
                If SortResult = "No matches found" Then
                    search.Clear()
                    Dim SplitArray() As String
                    SplitArray = Split(FileRefList.Item(key.Key)(1))
                    For Each ArrayValue In SplitArray
                        If ArrayValue.Contains(".") = False Then
                            search.FileName = "%" & ArrayValue & "%"
                            result = search.GetFirstResult()
                            While result IsNot Nothing
                                If SearchResults.Contains(result) = False Then SearchResults.Add(result)
                                result = search.GetNextResult
                            End While
                        End If
                    Next
                    If SearchResults.Count > 0 Then
                        SortResult = "Choose From Selection [Last Resort Search]"
                    End If
                    'DEBUG AREA
                    For Each value In SearchResults
                        Console.WriteLine(value.Path)
                    Next
                    Console.WriteLine("6: Last resort for " & FileRefList.Item(key.Key)(1).ToString)
                End If
#End Region

#Region "Add_List_Item_to_Table"
                Me.dataGridView1.Rows.Add({FileRefList.Item(key.Key)(0), FileRefList.Item(key.Key)(1), FileRefList.Item(key.Key)(2), FileRefList.Item(key.Key)(3), "", FileRefList.Item(key.Key)(5)})
                Me.dataGridView1.Rows(dataGridView1.Rows.Count - 1).Cells(2).Value = SortResult
                Console.WriteLine("7: Returned: " & SortResult)
                If SortResult = "No matches found" Then
                    dataGridView1.Rows(dataGridView1.Rows.Count - 1).DefaultCellStyle.BackColor = MissingHighlight
                    Me.dataGridView1.Rows(dataGridView1.Rows.Count - 1).Cells(4).Dispose()
                    Me.dataGridView1.Rows(dataGridView1.Rows.Count - 1).Cells(4) = New DataGridViewTextBoxCell With {.Value = "-"}
                ElseIf SortResult = "Existing Reference OK" Then
                    dataGridView1.Rows(dataGridView1.Rows.Count - 1).DefaultCellStyle.BackColor = ExistingHighlight
                    Me.dataGridView1.Rows(dataGridView1.Rows.Count - 1).Cells(4).Dispose()
                    Me.dataGridView1.Rows(dataGridView1.Rows.Count - 1).Cells(4) = New DataGridViewTextBoxCell With {.Value = "-"}
                ElseIf SortResult = "Choose From Selection" Or SortResult = "Choose From Selection [Last Resort Search]" Then
                    dataGridView1.Rows(dataGridView1.Rows.Count - 1).DefaultCellStyle.BackColor = ChooseNewHighlight
                    Dim cell As DataGridViewComboBoxCell
                    cell = dataGridView1.Rows(dataGridView1.Rows.Count - 1).Cells(4)
                    If SearchResults.Count < 2 Then
                        cell.Items.Add(SearchResults(0).Path)
                        cell.Value = SearchResults(0)
                    Else
                        For Each result In SearchResults
                            cell.Items.Add(result.Path)
                        Next
                    End If
                Else
                    dataGridView1.Rows(dataGridView1.Rows.Count - 1).DefaultCellStyle.BackColor = ReplacedHighlight
                    Me.dataGridView1.Rows(dataGridView1.Rows.Count - 1).Cells(4).Dispose()
                    Me.dataGridView1.Rows(dataGridView1.Rows.Count - 1).Cells(4) = New DataGridViewTextBoxCell With {.Value = "-"}
                End If
                Console.WriteLine("8: Table row added for " & FileRefList.Item(key.Key)(1).ToString)
#End Region

                ProgressPoint += 1
            Next

#End Region

#Region "Final_Script"
            Dim Existingcount As Integer
            Dim ReplacedCount As Integer
            Dim MissingCount As Integer
            Dim AttentionCount As Integer
            Dim ManuallyCount As Integer
            For Each row As DataGridViewRow In dataGridView1.Rows
                If row.DefaultCellStyle.BackColor = ExistingHighlight Then
                    Existingcount = Existingcount + 1
                ElseIf row.DefaultCellStyle.BackColor = ReplacedHighlight Then
                    ReplacedCount = ReplacedCount + 1
                ElseIf row.DefaultCellStyle.BackColor = MissingHighlight Then
                    MissingCount = MissingCount + 1
                ElseIf row.DefaultCellStyle.BackColor = ChooseNewHighlight Then
                    AttentionCount = AttentionCount + 1
                End If
            Next
            toolStripStatusLabel2.Text = Existingcount & " Existing references"
            toolStripStatusLabel3.Text = ReplacedCount & " Replaced References"
            toolStripStatusLabel4.Text = AttentionCount & " Attention References"
            toolStripStatusLabel5.Text = MissingCount & " Missing References"
            toolStripStatusLabel6.Text = ManuallyCount & " Manually replaced References"
            dataGridView1.Sort(dataGridView1.Columns(2), System.ComponentModel.ListSortDirection.Descending)
            listBoxCons.Items.Add("Search completed - statistics shown in ProgressBar")
            listBoxCons.Items.Add("Select References tab to view & edit references")
#End Region

        Catch ex As System.Runtime.InteropServices.COMException
            MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

        Console.WriteLine("Function complete")
        progressBar1.Value = 0

    End Sub

    Public Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click

        If dataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Use 'Get File References' before attempting to update references")
            Exit Sub
        End If

        Dim OrigFile As String
        Dim OrigFileDir As IEdmFolder5 = Nothing
        Dim OrigRef As String
        Dim ReplRef As String
        Dim brokenRefVar As System.Object = Nothing
        Dim isVirtual As System.Object = Nothing
        Dim timeStamp As System.Object = Nothing

        Dim dmClassFact As swdocumentmgr.SwDMClassFactory
        Dim dmDoc As swdocumentmgr.ISwDMDocument
        Dim dmapp As swdocumentmgr.ISwDMApplication
        Dim errVal As SwDmDocumentOpenError
        Dim docType As SwDmDocumentType
        Dim swSearchOpt As SwDMSearchOption
        Dim swFile As IEdmFile5

        listBoxCons.Items.Add("Updating values in files")

        Try

            If vault1 Is Nothing Then
                vault1 = New EdmVault5
            End If

            If Not vault1.IsLoggedIn Then
                vault1.LoginAuto(VaultsComboBox.Text, Me.Handle.ToInt32)
            End If

            rawRefs.Close()
            dmDoc = Nothing

            For Each Row As DataGridViewRow In dataGridView1.Rows

                Try

                    listBoxCons.Items.Add("Updating " & Row.Cells(1).Value.ToString)

                    If Not Row.Cells(2).Value Is Nothing Then

                        OrigFile = Row.Cells(5).Value.ToString
                        OrigRef = Row.Cells(3).Value.ToString
                        ReplRef = Row.Cells(2).Value.ToString


                        If ReplRef = "Choose From Selection" Or ReplRef = "Choose From Selection [Last Resort Search]" Then
                            If CStr(dataGridView1.Rows(Row.Index).Cells(4).Value).Length > 6 Then
                                ReplRef = CStr(dataGridView1.Rows(Row.Index).Cells(4).Value)
                            Else
                                ReplRef = "No matches found"
                            End If
                        End If


                        Console.WriteLine("9: Updating Reference for - " + ReplRef)

                        If ReplRef = "No matches found" Or ReplRef = "Existing Reference OK" Then
                            Console.WriteLine("10: No update required")
                        Else

                            Console.WriteLine("11: Update required")
                            swFile = vault1.GetFileFromPath(OrigFile, OrigFileDir)
                            If Not swFile.IsLocked Then
                                swFile.LockFile(OrigFileDir.ID, Me.Handle.ToInt32(), CInt(EdmLockFlag.EdmLock_Simple))
                            End If

                            Dim ext As String
                            ext = LCase(OrigFile.Substring(OrigFile.Length - 6, 6))
                            Select Case ext
                                Case "sldprt"
                                    docType = SwDmDocumentType.swDmDocumentPart
                                Case "sldasm"
                                    docType = SwDmDocumentType.swDmDocumentAssembly
                                Case "slddrw"
                                    docType = SwDmDocumentType.swDmDocumentDrawing
                            End Select

                            dmClassFact = CreateObject("SwDocumentMgr.SwDMClassFactory")
                            dmapp = Nothing
                            dmapp = dmClassFact.GetApplication(LicenseKey)
                            If dmapp Is Nothing Then
                                MsgBox("Invalid license Key")
                                Exit Sub
                            End If
                            swSearchOpt = dmapp.GetSearchOptionObject
                            dmDoc = dmapp.GetDocument(OrigFile, docType, False, errVal)

                            dmDoc.GetAllExternalReferences(swSearchOpt)

                            dmDoc.ReplaceReference(OrigRef, ReplRef)

                            dmDoc.Save()
                            dmDoc.CloseDoc()

                            Console.WriteLine("11: Update successful for - " + ReplRef)

                        End If

                    Else

                        If GlobalErrorSupress = False Then
                            MessageBox.Show("Reference row " & Row.ToString & " is invalid")
                        End If

                    End If

                Catch ex As Exception
                    MessageBox.Show("Part " & OrigFile & " Cannot be updated" & vbNewLine & ex.Message)
                End Try

            Next

            listBoxCons.Items.Add("Values updated")

        Catch ex As System.Runtime.InteropServices.COMException
            MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Function OpenDocument(FilePath As System.String) As SwDMDocument22

        Dim Err As SwDmDocumentOpenError
        Dim docType As SwDmDocumentType

        Dim ext As String
        ext = LCase(FilePath.Substring(FilePath.Length - 6, 6))

        Select Case ext
            Case "sldprt"
                docType = SwDmDocumentType.swDmDocumentPart
            Case "sldasm"
                docType = SwDmDocumentType.swDmDocumentAssembly
            Case "slddrw"
                docType = SwDmDocumentType.swDmDocumentDrawing
        End Select

        Dim allowreadonly As System.Boolean
        Dim swDmDoc1 As SwDMDocument18

        swDmDoc1 = swDmApp.GetDocument(FilePath, docType, False, Err)

        OpenDocument = swDmDoc1

    End Function

    Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles exitToolStripMenuItem.Click
        Close()
    End Sub

    Sub OpenToolStripMenuItemClick(sender As Object, e As EventArgs) Handles openToolStripMenuItem.Click
        Call OpenButton_click(sender, e)
    End Sub

    Sub HelpToolStripMenuItemClick(sender As Object, e As EventArgs) Handles helpToolStripMenuItem.Click
        Dim hForm = New HelpForm
        hForm.ShowDialog()
    End Sub

    Sub AboutReReferencingToolToolStripMenuItemClick(sender As Object, e As EventArgs) Handles aboutReReferencingToolToolStripMenuItem.Click

        MessageBox.Show("Solidworks PDM Re-Referencing Tool" & vbNewLine &
            "Local Version: " & SoftVer & vbNewLine &
            "See Jack for bugs or improvements - EXT 209")

    End Sub

    Sub AddToSelectionToolStripMenuItemClick(sender As Object, e As EventArgs) Handles addToSelectionToolStripMenuItem.Click
        AddToSelect = True
        Call OpenButton_click(sender, e)
    End Sub

    Sub ManuallyReplaceReferenceToolStripMenuItemClick(sender As Object, e As EventArgs) Handles manuallyReplaceReferenceToolStripMenuItem.Click

        Try

            If (dataGridView1.SelectedRows.Count <> 1) Then
                MessageBox.Show("Please select a single row to edit")
            Else
                OpenFileDialog2.InitialDirectory = "C:\ENG-CAD\Projects\TEST\test folder to prove shit"
                Dim DialogResult As System.Windows.Forms.DialogResult = Nothing
                DialogResult = OpenFileDialog2.ShowDialog()

                If Not (DialogResult = System.Windows.Forms.DialogResult.OK) Then
                ElseIf Not System.IO.File.Exists(OpenFileDialog2.FileName) = True Then
                    If GlobalErrorSupress = False Then MessageBox.Show("Fileformat for " & OpenFileDialog2.SafeFileName & " means it cannot be referenced.")
                Else
                    Me.dataGridView1.CurrentRow.Cells(2).Value = OpenFileDialog2.FileName
                End If
            End If

        Catch ex As System.Runtime.InteropServices.COMException
            MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Sub UpdateFilesToolStripMenuItemClick(sender As Object, e As EventArgs) Handles UpdateButton.Click
        Call UpdateButton_Click(sender, e)
    End Sub

    Private Sub getFileReferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles getFileReferencesToolStripMenuItem.Click
        Call GetButton2_Click(sender, e)
    End Sub

    Private Sub updateFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles updateFilesToolStripMenuItem.Click
        Call UpdateButton_Click(sender, e)
    End Sub

End Class