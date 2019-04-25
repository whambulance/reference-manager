'
' Created by SharpDevelop.
' User: jackbrooker
' Date: 23/08/2018
' Time: 14:26
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Partial Class HelpForm
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		label5.Text = "Pressing the 'Open Files' Button will bring up a selection dialog, allowing you to select multiple files within the Vault" & _
			vbNewLine & vbNewLine & "The selected parts will be loaded into the Left hand panel of the 'Open Files and Console' tab. Currently, it will not recursively" & _
			" add new files to the dialog, so ensure that all your required files are added. Ensure that you have checked out the selected files as well, as" & _
			" the program cannot currently check out files for you."
		
		label6.Text = "The 'Get File References' Button is the most complicated and time consuming procedure" & vbNewLine & "Upon clicking the button, the" & _
			" program will iterate through the List box to the left hand side of the 'Open Files and Console' tab, getting references for each file in there." & _
			" Each reference will be checked to see if it is valid, if not, a search will be initiated. The search will do multiple things:" & vbNewLine & vbNewLine & _
			"Search for a result to the base filename as is" & vbNewLine & _
			"Search for a result to the base filename without its Issue date (If it has one)" & vbNewLine & _
			"Search for the base filename with or without its Issue, and return a list of results for the user to select from" & vbNewLine & vbNewLine & _
			"Once it has completed its search, a row will be added With the aquired data, To the table In the 'References' tab)"
		
		label7.Text = "The 'Update Files' Button checks the references that have been added to the table inside the 'References' tab. It updates values" & _
			" directly in the files" & vbNewLine & vbNewLine & "Be warned - the system can not check if each file is exactly the same as what the assembly" & _
			" or drawing was looking For - it only checks For filenames. Take some time To iterate through the table In the 'References' tab To ensure you're happy" & _
			" before just updating everything"
		
		label8.Text = "File > Add to Selection" & vbNewLine & "This adds files to the Open Files dialog to the left of the 'Open Files and Console' tab, without clearing the entries" & _
			vbNewLine & vbNewLine & "File > Manually Replace Reference" & vbNewLine & "Once you have used the 'Get References' function, you can select a row and click this button to" & _
			" open up a file selection dialog, allowing you to manually replace the reference specified. Be warned: there is no way to get back the old reference without doing another" & _
			" 'Get References' function." & vbNewLine & vbNewLine & "Settings > Supress Error Popups" & vbNewLine & "Supresses error popups which may occur during runtime. Any errors" & _
			" which get supressed by this will not affect the runtime in anyway, and are instead supposed to aid in troubleshooting any issues"
	End Sub
	
	Private Sub Helpform_Keydowm(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    	If e.KeyCode = Keys.Escape Then Me.Close()
	End Sub
	
End Class
