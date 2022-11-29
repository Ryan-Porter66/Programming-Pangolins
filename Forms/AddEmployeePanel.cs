using PayrollManagement.Classes;
using System;
using System.Windows.Forms;

namespace PayrollManagement.Forms
{
    public partial class AddEmployeePanel : Form
    {
        #region Initializers
        private string Username { get; set; }
        private string Password { get; set; }
        public AddEmployeePanel(string username, string password)
        {
            InitializeComponent();
            this.Username = username;
            this.Password = password;
        }
        private void AddEmployeePanel_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //verify the data is sound

                //add new employees based on the data
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
