using System;
using System.Collections.Generic;

namespace PayrollManagement.Classes
{
    
    public abstract class Employee
    {
        #region Variables
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _city;        
        private string _postalCode;        
        private string _state;        
        private BankAccount _bank;        
        private int _employeeID;        
        private decimal _federalTaxRate;
        private string _permissions;        
        private string _ssn;
        private DateTime _dob;
        private DateTime _hireDate;
        private string _phoneNumber;
        private string _department;
        private List<Deduction> _deductionList;
        private decimal _stateTaxRate;
        private const decimal FICA_TAX = 0.062m;
        private const decimal MED_TAX = 0.0145m;
        #endregion
        #region Get/Set
        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }
        public string Address
        {
            get { return _address; }
            private set { _address = value; }
        }
        public string City
        {
            get { return _city; }
            private set { _city = value; }
        }
        public string PostalCode
        {
            get { return _postalCode; }
            private set { _postalCode = value; }
        }
        public string State
        {
            get { return _state; }
            private set { _state = value; }
        }
        public BankAccount Bank
        {
            get { return _bank; }
            private set { _bank = value; }
        }
        public int EmployeeID
        {
            get { return _employeeID; }
            private set { _employeeID = value; }
        }
        public decimal FederalTaxRate
        {
            get { return _federalTaxRate; }
            private set { _federalTaxRate = value; }
        }
        public string Permissions
        {
            get { return _permissions; }
            private set { _permissions = value; }
        }
        public string Ssn
        {
            get { return _ssn; }
            private set { _ssn = value; }
        }
        public DateTime Dob
        {
            get { return _dob; }
            private set { _dob = value; }
        }
        public DateTime HireDate
        {
            get { return _hireDate; }
            private set { _hireDate = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            private set { _phoneNumber = value; }
        }
        public string Department
        {
            get { return _department; }
            private set { _department = value; }
        }
        public List<Deduction> DeductionList
        {
            get { return _deductionList; }
            private set { _deductionList = value; }
        }
        public decimal StateTaxRate
        {
            get { return _stateTaxRate; }
            private set { _stateTaxRate = value; }
        }
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
            decimal dedAmt = 0;
            foreach(Deduction ded in DeductionList)
            {
                dedAmt += ded.CalculateDeductionAmount(gross);
            }
            return dedAmt;
        }

        public decimal CalculateNetPay(decimal grossPay)
        {
            decimal netPay = grossPay - CalculateFederalTax() - CalculateFICATax() - CalculateMedTax() - CalculateStateTax() - CalculateTotalNonTaxDeductionAmount();
            if(netPay < 0)
            {
                throw new ArgumentException("Netpay cannot be negative for " + this.FirstName + " " + this.LastName + ". Check your deductions.");
            }
            return Math.Round(netPay, 2);
        }
        #endregion
    }
}
