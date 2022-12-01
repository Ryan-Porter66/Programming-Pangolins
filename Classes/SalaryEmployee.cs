using System;
using System.Collections.Generic;

namespace PayrollManagement.Classes
{
    public class SalaryEmployee : Employee
    {
        #region Getters/Setters
        public decimal SalaryPerPayPeriod { get; set; }
        #endregion
        #region Constructor
        public SalaryEmployee(string firstName, string lastName, string address, string city, string postalCode, string state, BankAccount bank, int employeeID, decimal federalTaxRate, string permissions, string ssn, DateTime dob, DateTime hireDate, string phoneNumber, string department, List<Deduction> deductionList, decimal stateTaxRate, decimal salary) : base(firstName, lastName, address, city, postalCode, state, bank, employeeID, federalTaxRate, permissions, ssn, dob, hireDate, phoneNumber, department, deductionList, stateTaxRate)
        {
            this.SalaryPerPayPeriod = salary;
        }
        #endregion
        #region Methods
        public override decimal CalculateGrossPay()
        {
            if (SalaryPerPayPeriod > 0)
            {
                return SalaryPerPayPeriod;
            }

            throw new ArgumentException(this.FirstName + " " + this.LastName + "'s salary must be greater than 0!");
        }
        #endregion
    }
}
