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
        private void LoginButton1(object sender, EventArgs e)
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
                    FormMethods.ClearAllTextBoxes(this, ErrorInvalidLogin);

                    //call next form
                    this.Hide();
                    AdminPanel adminForm = new AdminPanel();
                    adminForm.ShowDialog();
                    adminForm.Dispose();
                    this.Show();
                }
                else if(response == "Employee")
                {
                    FormMethods.ClearAllTextBoxes(this, ErrorInvalidLogin);

                    //call next form
                    this.Hide();
                    EmployeePanel employeeForm = new EmployeePanel();
                    employeeForm.ShowDialog();
                    employeeForm.Dispose();
                    this.Show();
                }
                else if(response == "Denied" || response == "Error: Incorrect Login")
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
