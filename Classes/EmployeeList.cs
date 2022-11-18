﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void generateEmployeeList(int compFedID)
        {
            throw new NotImplementedException();
        }

        public void displaySelectableEmployeeList()
        {
            throw new NotImplementedException();
        }

        public decimal getNetPayAllEmployeesInList()
        {
            if (this._employeesCompany == null || this.getSizeOfList() < 1)
            {
                throw new ArgumentNullException("Employee List is Empty");
            }

            decimal totalNetPay = 0m;
            foreach (Employee emp in _employeeList)
            {
                totalNetPay += emp.calculateNetPay(emp.calculateGrossPay());
            }
            return totalNetPay;
        }

        public int getSizeOfList()
        {
            return this._employeeList.Count();
        }

        public string getSumOfFirst8DigitsRoute()
        {
            if(this._employeesCompany == null || this.getSizeOfList() < 1)
            {
                throw new ArgumentNullException("Employee List is Empty");
            }

            long totalOfDigits = 0;
            foreach(Employee emp in _employeeList)
            {
                totalOfDigits += long.Parse(emp.bank.returnFirstEightOfRoute());
            }
            return totalOfDigits.ToString();
        }
        #endregion
    }
}

