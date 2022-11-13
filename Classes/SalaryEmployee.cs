﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ClassDiagram
{
    public class SalaryEmployee : Employee
    {
        decimal salaryPerPayPeriod;

        public SalaryEmployee(string firstName, string lastName, string address, string city, string postalCode, string state, BankAccount bank, int employeeID, decimal federalTaxRate, string permissions, int ssn, DateTime dob, DateTime hireDate, int phoneNumber, string department, List<Deduction> deductionList, decimal netPay, decimal stateTaxRate) : base(firstName, lastName, address, city, postalCode, state, bank, employeeID, federalTaxRate, permissions, ssn, dob, hireDate, phoneNumber, department, deductionList, netPay, stateTaxRate)
        {
        }

        public override decimal calculateGrossPay()
        {
            return salaryPerPayPeriod;
        }
    }
}
