using PayrollManagement.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


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

        public void DisplaySelectableEmployeeList()
        {
            Form2 form = new Form2();
            form.listBox1.Items.Add(String.Format("{0,-20} {1,15}", "Name", "Employee ID"));
            foreach (Employee emp in _employeeList)
            {
                form.listBox1.Items.Add(String.Format("{0,-20} {1,15}", emp.FirstName +" "+ emp.LastName, emp.EmployeeID));
                
            }
            form.listBox1.EndUpdate();
            form.ShowDialog();
            //throw new NotImplementedException();
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

