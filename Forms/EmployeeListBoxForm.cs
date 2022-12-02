using System;
using System.Windows.Forms;
using PayrollManagement.Classes;

namespace PayrollManagement.Forms
{
    public partial class EmployeeListBoxForm : Form
    {
        public EmployeeListBoxForm()
        {
            InitializeComponent();
        }
        //https://stackoverflow.com/questions/3098198/bind-listbox-with-multiple-fields
        private void EmployeeListBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string empID = ((Employee)e.ListItem).EmployeeID.ToString();
            string EmpFirst = ((Employee)e.ListItem).FirstName;
            string empLast = ((Employee)e.ListItem).LastName;
            string stringToDisplay = $"{empID.PadRight(4)} {EmpFirst} {empLast}";
            e.Value = stringToDisplay;
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.employeeListBox.ClearSelected();
            this.Hide();
        }

        //https://stackoverflow.com/questions/45036028/select-all-in-listbox-by-clicking-a-button
        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.employeeListBox.Items.Count; i++)
            {
                this.employeeListBox.SetSelected(i, true);
            }
        }
    }
}
