using System;
using System.Windows.Forms;

namespace PayrollManagement.Forms
{
    public partial class AdminPanel : Form
    {
        #region Initializers
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Buttons
        //calls addEmployee Form
        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddEmployeePanel addEmployeeForm = new AddEmployeePanel();
            addEmployeeForm.ShowDialog();
            addEmployeeForm.Dispose();
            this.Show();
        }
        //call delete employee form
        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {

        }
        //call edit employee form
        private void EditEmployPayInfoButton_Click(object sender, EventArgs e)
        {

        }
        //call business button
        private void EditBusButton_Click(object sender, EventArgs e)
        {

        }
        //call compile form
        private void CompileGeneratePayButton_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
