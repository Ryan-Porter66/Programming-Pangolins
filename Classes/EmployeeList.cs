using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public class EmployeeList
    {
        List<Employee> _employeeList;
        Company _employeesCompany;

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

        public void generateEmployeeList(int compFedID)
        {
            throw new NotImplementedException();
        }

        public void displaySelectableEmployeeList()
        {
            throw new NotImplementedException();
        }

        public void calculateGrossPayAllEmployeesInList()
        {
            throw new NotImplementedException();
        }

        public decimal getGrossPayCombined()
        {
            throw new NotImplementedException();
        }

        public int getSizeOfList()
        {
            return this._employeeList.Count();
        }

        public int getSumOfFirst8DigitsRoute()
        {
            throw new NotImplementedException();
        }
    }
}

