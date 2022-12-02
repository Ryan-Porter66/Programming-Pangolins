using PayrollManagement.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollManagement.Classes
{
    public class EmployeeList
    {
        #region Getter/Setter
        public List<Employee> Employees { get; set; }
        public Company Company { get; set; }
        #endregion
        #region Methods
        public void GenerateEmployeeList(string username, string password)
        {
            this.Employees = Database.GetEmployeeList(username, password);
            this.Company = Database.GetCompany(username, password);
        }
        //allow user to select employees for the list
        public void DisplaySelectableEmployeeList(bool singleSelect)
        {
            EmployeeListBoxForm employeeListForm = new EmployeeListBoxForm();

            employeeListForm.employeeListBox.DisplayMember = "EmployeeID";
            employeeListForm.employeeListBox.DataSource = this.Employees;
            if(singleSelect)
            {
                employeeListForm.employeeListBox.SelectionMode = System.Windows.Forms.SelectionMode.One;
                employeeListForm.SelectAllButton.Visible = false;
                employeeListForm.SelectAllButton.Enabled = false;
            }
            employeeListForm.employeeListBox.ClearSelected();
            employeeListForm.ShowDialog();

            List<Employee> newEmpList = employeeListForm.employeeListBox.SelectedItems.Cast<Employee>().ToList();
            this.Employees = newEmpList;

            employeeListForm.Dispose(); //need to dispose manually since ShowDialog was used
        }
        public decimal GetNetPayAllEmployeesInList()
        {
            if (this.Company == null || this.GetSizeOfList() < 1)
            {
                throw new ArgumentNullException($"Employee List is Empty");
            }
            return Employees.Sum(emp => emp.CalculateNetPay(emp.CalculateGrossPay()));
        }
        public int GetSizeOfList()
        {
            return this.Employees.Count();
        }
        public string GetSumOfFirst8DigitsRoute()
        {
            if(this.Company == null || this.GetSizeOfList() < 1)
            {
                throw new ArgumentNullException($"Employee List is Empty");
            }

            long totalOfDigits = Employees.Sum(emp => long.Parse(emp.Bank.ReturnFirstEightOfRoute()));
            return totalOfDigits.ToString();
        }
        #endregion
    }
}

