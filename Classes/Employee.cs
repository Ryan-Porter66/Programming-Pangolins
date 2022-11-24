using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollManagement.Classes
{
    
    public abstract class Employee
    {
        #region Variables

        private const decimal FICA_TAX = 0.062m;
        private const decimal MED_TAX = 0.0145m;
        #endregion
        #region Get/Set
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public BankAccount Bank { get; set; }

        public int EmployeeID { get; set; }

        public decimal FederalTaxRate { get; set; }

        public string Permissions { get; set; }

        public string Ssn { get; set; }

        public DateTime Dob { get; set; }

        public DateTime HireDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Department { get; set; }

        public List<Deduction> DeductionList { get; set; }

        public decimal StateTaxRate { get; set; }

        #endregion
        #region Constructor
        public Employee(string firstName, string lastName, string address, string city, string postalCode, string state, BankAccount bank, int employeeID, decimal federalTaxRate, string permissions, string ssn, DateTime dob, DateTime hireDate, string phoneNumber, string department, List<Deduction> deductionList, decimal stateTaxRate)
        {
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.Address = address ?? throw new ArgumentNullException(nameof(address));
            this.City = city ?? throw new ArgumentNullException(nameof(city));
            this.PostalCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
            this.State = state ?? throw new ArgumentNullException(nameof(state));
            this.Bank = bank ?? throw new ArgumentNullException(nameof(bank));
            this.EmployeeID = employeeID;
            this.FederalTaxRate = federalTaxRate;
            this.Permissions = permissions ?? throw new ArgumentNullException(nameof(permissions));
            this.Ssn = ssn;
            this.Dob = dob;
            this.HireDate = hireDate;
            this.PhoneNumber = phoneNumber;
            this.Department = department ?? throw new ArgumentNullException(nameof(department));
            this.DeductionList = deductionList ?? throw new ArgumentNullException(nameof(deductionList));
            this.StateTaxRate = stateTaxRate;
        }
        #endregion
        #region Methods
        public abstract decimal CalculateGrossPay();
  
        public decimal CalculateFederalTax()
        {
            decimal fedTax = FederalTaxRate * CalculateGrossPay();
            return fedTax;
        }

        public decimal CalculateStateTax()
        {
            decimal stateTax = StateTaxRate * CalculateGrossPay();
            return stateTax;
        }

        public decimal CalculateFICATax()
        {
            decimal ficaTax = FICA_TAX * CalculateGrossPay();
            return ficaTax;
        }

        public decimal CalculateMedTax()
        {
            decimal medTax = MED_TAX * CalculateGrossPay();
            return medTax;
        }

        public decimal CalculateTotalNonTaxDeductionAmount()
        {
            decimal gross = this.CalculateGrossPay();
            return DeductionList.Sum(ded => ded.CalculateDeductionAmount(gross));
        }

        public decimal CalculateNetPay(decimal grossPay)
        {
            decimal netPay = grossPay - CalculateFederalTax() - CalculateFICATax() - CalculateMedTax() - CalculateStateTax() - CalculateTotalNonTaxDeductionAmount();
            if(netPay < 0)
            {
                throw new ArgumentException("Net pay cannot be negative for " + this.FirstName + " " + this.LastName + ". Check your deductions.");
            }
            return Math.Round(netPay, 2);
        }
        #endregion
    }
}
