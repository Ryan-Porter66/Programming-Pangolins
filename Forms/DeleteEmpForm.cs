using System;
using System.Windows.Forms;
using PayrollManagement.Classes;

namespace PayrollManagement.Forms
{
    public partial class DeleteEmpForm : Form
    {
        #region Initializors
        private string Username { get; set; }
        private string Password { get; set; }
        public DeleteEmpForm(string username, string password)
        {
            InitializeComponent();
            this.Username = username;
            this.Password = password;
        }
        #endregion
        #region Methods
        private void CancelDeleteButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteEmpButton_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeList employees = new EmployeeList();
                employees.GenerateEmployeeList(Username, Password);
                employees.DisplaySelectableEmployeeList(false);
                int count = 0;
                foreach(Employee employee in employees.Employees)
                {
                    if(employee.EmployeeID.ToString() == Username)
                    {
                        MessageBox.Show(@"Cannot delete yourself!");
                    } 
                    else
                    {
                        Database.DeleteEmployee(Username, Password, employee.EmployeeID.ToString());
                        count++;
                    }
                }
                MessageBox.Show($@"Successfully deleted {count} employees.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


    }
}
