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

                switch (response)
                {
                    case "Admin":
                    {
                        FormMethods.ClearAllTextBoxes(this, ErrorInvalidLogin);

                        //call next form
                        this.Hide();
                        AdminPanel adminForm = new AdminPanel(username, password);
                        adminForm.ShowDialog();
                        adminForm.Dispose();
                        this.Show();
                        break;
                    }
                    case "Employee":
                    {
                        FormMethods.ClearAllTextBoxes(this, ErrorInvalidLogin);

                        //call next form
                        this.Hide();
                        EmployeePanel employeeForm = new EmployeePanel(username, password, username);
                        employeeForm.ShowDialog();
                        employeeForm.Dispose();
                        this.Show();
                        break;
                    }
                    case "Denied":
                    case "Error: Incorrect Login":
                        this.ErrorInvalidLogin.SetError(TextBoxPassword, "Username or password is incorrect!");
                        return;
                    default:
                        throw new Exception("Error when connecting. Contact developer.");
                }
                TextBoxUsername.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }

        }
        #endregion
    }
}
