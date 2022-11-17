using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public class SalaryEmployee : Employee
    {
        decimal _salaryPerPayPeriod;

        public decimal SalaryPerPayPeriod
        {
            get { return _salaryPerPayPeriod; }
            set { _salaryPerPayPeriod = value; }
        }

        public SalaryEmployee(string firstName, string lastName, string address, string city, string postalCode, string state, BankAccount bank, int employeeID, decimal federalTaxRate, string permissions, string ssn, DateTime dob, DateTime hireDate, string phoneNumber, string department, List<Deduction> deductionList, decimal netPay, decimal stateTaxRate) : base(firstName, lastName, address, city, postalCode, state, bank, employeeID, federalTaxRate, permissions, ssn, dob, hireDate, phoneNumber, department, deductionList, netPay, stateTaxRate)
        {
        }

        public override decimal calculateGrossPay()
        {
            //add check for hours > 0
            return SalaryPerPayPeriod;
        }
    }
}
