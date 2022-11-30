using System;
using System.Windows.Forms;
using PayrollManagement.Classes;

namespace PayrollManagement.Forms
{
    public partial class PayrollForm : Form
    {
        #region Initializors
        private string Username { get; set; }
        private string Password { get; set; }
        public PayrollForm(string username, string password)
        {
            InitializeComponent();
            this.Username = username;
            this.Password = password;
        }
        #endregion
        #region Methods
        private void StartPayrollButton_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeList employees = new EmployeeList();
                employees.GenerateEmployeeList(Username, Password);
                employees.DisplaySelectableEmployeeList(false);
                Reports.CompilePayrollData(employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CancelPayrollButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
