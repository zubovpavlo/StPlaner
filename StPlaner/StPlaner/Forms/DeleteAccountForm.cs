using System;
using System.Windows.Forms;
using StPlaner.Models;
using StPlaner.Services;

namespace StPlaner.Forms
{
    public partial class DeleteAccountForm : Form
    {
        private readonly AuthenticationService _authService;
        private readonly Student _currentStudent;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAccountForm"/> class.
        /// </summary>
        /// <param name="student">The current student whose account is to be deleted.</param>
        public DeleteAccountForm(Student student)
        {
            InitializeComponent();
            _authService = new AuthenticationService();
            _currentStudent = student;
        }

        /// <summary>
        /// Handles the delete button click event to delete the student's account.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsValidCredentials(txtUsername.Text, txtPassword.Text))
            {
                _authService.DeleteStudent(_currentStudent);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        /// <summary>
        /// Validates the input credentials.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <returns><c>true</c> if the credentials are valid; otherwise, <c>false</c>.</returns>
        private bool IsValidCredentials(string username, string password)
        {
            return username == _currentStudent.Username && password == _currentStudent.Password;
        }
    }
}
