using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public class SalaryEmployee : Employee
    {
        #region Variables
        decimal _salaryPerPayPeriod;
        #endregion
        #region Getters/Setters
        public decimal SalaryPerPayPeriod
        {
            get { return _salaryPerPayPeriod; }
            set { _salaryPerPayPeriod = value; }
        }
        #endregion
        #region Constructor
        public SalaryEmployee(string firstName, string lastName, string address, string city, string postalCode, string state, BankAccount bank, int employeeID, decimal federalTaxRate, string permissions, string ssn, DateTime dob, DateTime hireDate, string phoneNumber, string department, List<Deduction> deductionList, decimal stateTaxRate, decimal salary) : base(firstName, lastName, address, city, postalCode, state, bank, employeeID, federalTaxRate, permissions, ssn, dob, hireDate, phoneNumber, department, deductionList, stateTaxRate)
        {
            this.SalaryPerPayPeriod = salary;
        }
        #endregion
        #region Methods
        public override decimal calculateGrossPay()
        {
            if (SalaryPerPayPeriod > 0)
            {
                return SalaryPerPayPeriod;
            }
            else
            {
                throw new ArgumentException("Salary must be more than 0");
            }
        }
        #endregion
    }
}
