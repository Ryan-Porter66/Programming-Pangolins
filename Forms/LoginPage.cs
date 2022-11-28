using System.Windows.Forms;

namespace PayrollManagement.Forms
{
    public partial class LoginPage : Form
    {
        #region Auto-Built 
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
            string username;
            string password;

            username = TextBoxUsername.Text;
            password = TextBoxPassword.Text;
            var combo = username + ":" + password;

            MessageBox.Show(combo, "Test");

        }
        private void UsernameTextBox(object sender, System.EventArgs e)
        {

        }
        private void PasswordTextbox(object sender, System.EventArgs e)
        {

        }
        #endregion
        #region Static Methods
        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, System.EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, System.EventArgs e)
        {

        }
        #endregion
    }
}
