using PayrollManagement.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollManagement.Classes
{
    public class EmployeeList
    {
        #region Variables
        List<Employee> _employeeList;
        Company _employeesCompany;
        #endregion
        #region Getter/Setter
        public List<Employee> Employees
        {
            get { return this._employeeList; }
            set { this._employeeList = value; }
        }
        public Company Company
        {
            get { return this._employeesCompany; }
            set { this._employeesCompany = value; }
        }
        #endregion
        #region Constructor
        #endregion
        #region Methods
        public void GenerateEmployeeList(string compFedID)
        {
            throw new NotImplementedException();
        }
        //allow user to select employees for the list
        public void DisplaySelectableEmployeeList()
        {
            EmployeeListBoxForm employeeListForm = new EmployeeListBoxForm();

            employeeListForm.employeeListBox.DisplayMember = "EmployeeID";
            employeeListForm.employeeListBox.DataSource = this.Employees;
            employeeListForm.employeeListBox.ClearSelected();
            employeeListForm.ShowDialog();

            List<Employee> newEmpList = new List<Employee>();
            foreach (object selectedItem in employeeListForm.employeeListBox.SelectedItems)
            {
                Employee item = (Employee)selectedItem;
                newEmpList.Add(item);
            }
            this.Employees = newEmpList;

            employeeListForm.Dispose(); //need to dispose manually since ShowDialog was used
        }

        public decimal GetNetPayAllEmployeesInList()
        {
            if (this._employeesCompany == null || this.GetSizeOfList() < 1)
            {
                throw new ArgumentNullException("Employee List is Empty");
            }

            decimal totalNetPay = 0m;
            foreach (Employee emp in _employeeList)
            {
                totalNetPay += emp.CalculateNetPay(emp.CalculateGrossPay());
            }
            return totalNetPay;
        }

        public int GetSizeOfList()
        {
            return this._employeeList.Count();
        }

        public string GetSumOfFirst8DigitsRoute()
        {
            if(this._employeesCompany == null || this.GetSizeOfList() < 1)
            {
                throw new ArgumentNullException("Employee List is Empty");
            }

            long totalOfDigits = 0;
            foreach(Employee emp in _employeeList)
            {
                totalOfDigits += long.Parse(emp.Bank.ReturnFirstEightOfRoute());
            }
            return totalOfDigits.ToString();
        }
        #endregion
    }
}

