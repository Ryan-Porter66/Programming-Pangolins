using System;
using System.Windows.Forms;

namespace PayrollManagement.Forms
{
    public partial class AdminPanel : Form
    {
        #region Initializers
        private string Username { get; set; }
        private string Password { get; set; }
        public AdminPanel(string username, string password)
        {
            InitializeComponent();
            this.Username = username;
            this.Password = password;
        }
        #endregion

        #region Buttons
        //calls addEmployee Form
        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (AddEmployeePanel addEmployeeForm = new AddEmployeePanel(Username, Password))
            {
                addEmployeeForm.ShowDialog();
                addEmployeeForm.Dispose();
            }
            this.Show();
        }
        //call delete employee form
        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (DeleteEmpForm deleteEmployeeForm = new DeleteEmpForm(Username, Password))
            {
                deleteEmployeeForm.ShowDialog();
                deleteEmployeeForm.Dispose();
            }
            this.Show();
        }
        //call edit employee form
        private void EditEmployPayInfoButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (editEmployeePanel editEmployeeForm = new editEmployeePanel(Username, Password))
            {
                editEmployeeForm.ShowDialog();
                editEmployeeForm.Dispose();
            }
            this.Show();
        }
        //call business button
        private void EditBusButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (editBusinessInfoPanel editBusinessInfoForm = new editBusinessInfoPanel(Username, Password))
            {
                editBusinessInfoForm.ShowDialog();
                editBusinessInfoForm.Dispose();
            }
            this.Show();
        }
        //call compile form
        private void CompileGeneratePayButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (PayrollForm addEmployeeForm = new PayrollForm(Username, Password))
            {
                addEmployeeForm.ShowDialog();
                addEmployeeForm.Dispose();
            }
            this.Show();
        }
        #endregion
    }
}
