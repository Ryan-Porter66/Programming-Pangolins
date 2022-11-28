using System;
using System.Windows.Forms;
using PayrollManagement.Classes;

namespace PayrollManagement.Forms
{
    public partial class LoginPage : Form
    {
        #region Initializers 
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, System.EventArgs e)
        {

        }
        #endregion
        #region Buttons
        private void LoginButton1(object sender, System.EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(TextBoxUsername.Text) || string.IsNullOrEmpty(TextBoxPassword.Text))
                {
                    this.ErrorInvalidLogin.SetError(TextBoxPassword, "Please enter username and password!");
                    return;
                }
                string username = TextBoxUsername.Text;
                string password = Encryption.SHA256Encryption(TextBoxPassword.Text);

                string response = Database.Login(username, password);

                if(response == "Admin")
                {
                    TextBoxUsername.Text = "";
                    TextBoxPassword.Text = "";

                    //call next form
                    this.Hide();
                    AdminPanel adminForm = new AdminPanel();
                    adminForm.ShowDialog();
                }
                else if(response == "Employee")
                {
                    TextBoxUsername.Text = "";
                    TextBoxPassword.Text = "";

                    //call next form
                    this.Hide();
                    EmployeePanel employeeForm = new EmployeePanel();
                    employeeForm.ShowDialog();
                }
                else if(response == "Denied")
                {
                    this.ErrorInvalidLogin.SetError(TextBoxPassword, "Username or password is incorrect!");
                    return;
                }
                else
                {
                    throw new Exception("Error when connecting. Contact developer.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        #endregion
    }
}
