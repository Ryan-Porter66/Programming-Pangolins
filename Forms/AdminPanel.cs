using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            //call next addEmployee Form
            this.Hide();
            AddEmployeePanel addEmployeeForm = new AddEmployeePanel();
            addEmployeeForm.ShowDialog();
            this.Show();
        }

        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {

        }

        private void EnterEditEmployPayInfoButton_Click(object sender, EventArgs e)
        {

        }

        private void EditBusButton_Click(object sender, EventArgs e)
        {

        }

        private void CompleGeneratePayButton_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
