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
        #region Dynamic Methods
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

                if(response == "Admin" || response == "Employee")
                {
                    TextBoxUsername.Text = "";
                    TextBoxPassword.Text = "";
                    //call next form
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
        #region Static Methods
        #endregion
    }
}
