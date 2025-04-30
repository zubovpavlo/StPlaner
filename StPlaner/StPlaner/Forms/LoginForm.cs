using System;
using System.Windows.Forms;
using StPlaner.Services;
using StPlaner.Models;

namespace StPlaner.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthenticationService();
        }

        /// <summary>
        /// Handles the login button click event to authenticate the user.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (_authService.Authenticate(username, password))
            {
                var student = _authService.GetCurrentUser();
                this.Hide();
                ShowMainForm(student);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        /// <summary>
        /// Handles the register button click event to open the register form.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            ShowRegisterForm();
        }

        /// <summary>
        /// Handles the close program button click event to exit the application.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void btnCloseProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Shows the main form for the authenticated student.
        /// </summary>
        /// <param name="student">The authenticated student.</param>
        private void ShowMainForm(Student student)
        {
            using (var mainForm = new MainForm(student))
            {
                mainForm.ShowDialog();
            }
        }

        /// <summary>
        /// Shows the register form.
        /// </summary>
        private void ShowRegisterForm()
        {
            using (var registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }
        }
    }
}
