Public Class EmployeeLogin

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim NumberOfRows As Integer
        Dim RowData As Object
        Dim Password As String = String.Empty

        'exception handler for login attempt with empty fields
        If txtEmail.Text = String.Empty Or txtPassword.Text = String.Empty Then
            MessageBox.Show("please enter your email and password")
        Else

            'how many records contain the email provided by the user?
            NumberOfRows = LibraryEmployeesTableAdapter.FillByEmail(ELibrary_DatabaseDataSet.LibraryEmployees, txtEmail.Text)
            'if there is one existing record with the email then get the user's record with the getdataby method
            'and put the record (really point to the record) in the object "RowData" then get the email from the object. 
            'The dataset's index names will match the names of the columns in the table.  
            'Thus RowData.Password points to the user's password
            If NumberOfRows = 1 Then

                RowData = LibraryEmployeesTableAdapter.GetDataByEmail(txtEmail.Text)(0)
                Password = RowData.Password

                'if everything matches up, the user is shown a success message and the next screen is opened
                'the search form is opened, and form1 is hidden
                'the fields are cleared out

                'if everything does not match up, they are shown a failure message and the fields are cleared
                If Password = txtPassword.Text Then
                    Search.Show()
                    Me.Hide()
                    txtEmail.Clear()
                    txtPassword.Clear()
                Else
                    MessageBox.Show("Login unsuccessful")
                    txtPassword.Clear()
                End If
            Else
                MessageBox.Show("No user has registered with this email, please try a different email or register as a new user")
                txtEmail.Clear()
                txtPassword.Clear()
            End If
        End If

    End Sub

    Private Sub LibraryEmployeesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LibraryEmployeesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ELibrary_DatabaseDataSet)

    End Sub

    Private Sub EmployeeLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ELibrary_DatabaseDataSet.LibraryEmployees' table. You can move, or remove it, as needed.
        Me.LibraryEmployeesTableAdapter.Fill(Me.ELibrary_DatabaseDataSet.LibraryEmployees)

    End Sub
End Class