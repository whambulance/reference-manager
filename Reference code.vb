'
' Created by SharpDevelop.
' User: jackbrooker
' Date: 14/08/2018
' Time: 07:27
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

'Get IEdmRawReferences interface 
rawRefs = vault1.CreateUtility(EdmUtility.EdmUtil_RawReferenceMgr)		'Sets VAR "rawRefs" to utility RawReferenceMgr - important first step
Dim fileRefsSupported As Boolean 										'simple yes/no VAR for checking if file references are supported by file
fileRefsSupported = rawRefs.Open(fileName)								'bool filerefsupp. set to yes/no for current file by trying to open refs
If Not fileRefsSupported Then											'check if bool filerefsupp. is yes or no (check if it is not in this case)
	MessageBox.Show("File's format does not support file references.")	'msgbox to show it is unsupported
    Exit Sub															'exit subscript
End If

Dim arrSize As Integer													'dim a VAR to count number of references (to check if there are any) & to loop
Dim i As Integer = 0													'dim i so that a (while i < arrSize) loop can be created
Dim message As String													'in this case message is used for the messagebox command to show references
rawRefs.GetReferences(refs)												'"rawRefs" VAR is called with GetReferences - put to new VAR "refs"
arrSize = refs.Length													'new var "refs" called, getting array size, setting to VAR "arrSize"
If arrSize = 0 Then														'determine if there are any refs
    MessageBox.Show("No file references for opened file.")				'msgbox to show there are no refs
    Exit Sub															'exit subscript
End If


'Get IEdmRawReferences rawrefs array info
refs(i).mbsRefID														'Internal ID
refs(i).mbsIncludePath													'Referenced How (Path)
refs(i).mbsRefName														'Referenced Name (Filename)
refs(i).mlCount.ToString												'Number of times referenced
refs(i).mlFlags															'Determine certain properties (Ghost, InternalComponent, Normal file reference)