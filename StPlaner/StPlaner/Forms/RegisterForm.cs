using System;
using System.Windows.Forms;
using StPlaner.Models;
using StPlaner.Services;

namespace StPlaner.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthenticationService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterForm"/> class.
        /// </summary>
        public RegisterForm()
        {
            InitializeComponent();
            _authService = new AuthenticationService();
        }

        /// <summary>
        /// Handles the register button click event to register a new user.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string name = txtName.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (_authService.IsUsernameTaken(username))
            {
                MessageBox.Show("Username is already taken. Please choose another one.");
                return;
            }

            var student = new Student
            {
                ID = _authService.GetNextStudentID(),
                Name = name,
                Username = username,
                Password = password
            };

            _authService.RegisterStudent(student);
            MessageBox.Show("Registration successful.");
            this.Close();
        }
    }
}
