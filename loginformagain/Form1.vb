
Public Class Form1

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        MessageBox.Show("Coming soon")
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged




    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ELibrary_DatabaseDataSet.LibraryMembers' table. You can move, or remove it, as needed.
        Me.LibraryMembersTableAdapter.Fill(Me.ELibrary_DatabaseDataSet.LibraryMembers)
        'this sets the text in the textboxes when the form loads
        txtEmail.Text = "Email"
        txtPassword.Text = "Password"
    End Sub



    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click


        Dim NumberOfRows As Integer
        Dim RowData As Object
        Dim Password As String = String.Empty

        'exception handling for login attempt with empty fields
        If txtEmail.Text = String.Empty Or txtPassword.Text = String.Empty Then
            MessageBox.Show("please enter your email and password")
        Else

            'how many records contain the email provided by the user?
            NumberOfRows = LibraryMembersTableAdapter.FillByEmail(ELibrary_DatabaseDataSet.LibraryMembers, txtEmail.Text)
            If NumberOfRows = 1 Then
                RowData = LibraryMembersTableAdapter.GetDataByEmail(txtEmail.Text)(0)
                Password = RowData.Password
            Else
                NumberOfRows = LibraryEmployeesTableAdapter.FillByEmail(ELibrary_DatabaseDataSet.LibraryEmployees, txtEmail.Text)
                If NumberOfRows = 1 Then
                    RowData = LibraryEmployeesTableAdapter.GetDataByEmail(txtEmail.Text)(0)
                    Password = RowData.Password
                End If
            End If
            'if there is one existing record with the email then get the user's record with the getdataby method
            'and put the record (really point to the record) in the object "RowData" then get the email from the object. 
            'The dataset's index names will match the names of the columns in the table.  
            'Thus RowData.Password points to the user's password


            If NumberOfRows = 1 Then
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

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged


    End Sub

    Private Sub LibraryMembersBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LibraryMembersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ELibrary_DatabaseDataSet)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'hides form 1 and opens the employee login form
        Me.Hide()
        EmployeeLogin.Show()
        'clears out the fields
        txtEmail.Clear()
        txtPassword.Clear()

    End Sub

    Private Sub btnLogin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnLogin.KeyPress

    End Sub
End Class
