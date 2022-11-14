using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ClassDiagram
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
        private decimal _netPay;
        private decimal _stateTaxRate;
        #endregion
        #region Get/Set
        public string firstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }
        public string lastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }
        public string address
        {
            get { return _address; }
            private set { _address = value; }
        }
        public string city
        {
            get { return _city; }
            private set { _city = value; }
        }
        public string postalCode
        {
            get { return _postalCode; }
            private set { _postalCode = value; }
        }
        public string state
        {
            get { return _state; }
            private set { _state = value; }
        }
        public BankAccount bank
        {
            get { return _bank; }
            private set { _bank = value; }
        }
        public int employeeID
        {
            get { return _employeeID; }
            private set { _employeeID = value; }
        }
        public decimal federalTaxRate
        {
            get { return _federalTaxRate; }
            private set { _federalTaxRate = value; }
        }
        public string permissions
        {
            get { return _permissions; }
            private set { _permissions = value; }
        }
        public string ssn
        {
            get { return _ssn; }
            private set { _ssn = value; }
        }
        public DateTime dob
        {
            get { return _dob; }
            private set { _dob = value; }
        }
        public DateTime hireDate
        {
            get { return _hireDate; }
            private set { _hireDate = value; }
        }
        public string phoneNumber
        {
            get { return _phoneNumber; }
            private set { _phoneNumber = value; }
        }
        public string department
        {
            get { return _department; }
            private set { _department = value; }
        }
        public List<Deduction> deductionList
        {
            get { return _deductionList; }
            private set { _deductionList = value; }
        }
        public decimal netPay
        {
            get { return _netPay; }
            private set { _netPay = value; }
        }
        public decimal stateTaxRate
        {
            get { return _stateTaxRate; }
            private set { _stateTaxRate = value; }
        }
        #endregion
        #region Constructor
        public Employee(string firstName, string lastName, string address, string city, string postalCode, string state, BankAccount bank, int employeeID, decimal federalTaxRate, string permissions, string ssn, DateTime dob, DateTime hireDate, string phoneNumber, string department, List<Deduction> deductionList, decimal netPay, decimal stateTaxRate)
        {
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.address = address ?? throw new ArgumentNullException(nameof(address));
            this.city = city ?? throw new ArgumentNullException(nameof(city));
            this.postalCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
            this.state = state ?? throw new ArgumentNullException(nameof(state));
            this.bank = bank ?? throw new ArgumentNullException(nameof(bank));
            this.employeeID = employeeID;
            this.federalTaxRate = federalTaxRate;
            this.permissions = permissions ?? throw new ArgumentNullException(nameof(permissions));
            this.ssn = ssn;
            this.dob = dob;
            this.hireDate = hireDate;
            this.phoneNumber = phoneNumber;
            this.department = department ?? throw new ArgumentNullException(nameof(department));
            this.deductionList = deductionList ?? throw new ArgumentNullException(nameof(deductionList));
            this.netPay = netPay;
            this.stateTaxRate = stateTaxRate;
        }


        #endregion
        #region Methods
        public abstract decimal calculateGrossPay();


        public decimal calculateFederalTax()
        {
            throw new NotImplementedException();
        }

        public decimal calculateStateTax()
        {
            throw new NotImplementedException();
        }

        public decimal calculateFICATax()
        {
            throw new NotImplementedException();
        }

        public decimal calculateMedTax()
        {
            throw new NotImplementedException();
        }

        public decimal calculateTotalNonTaxDeductionAmount()
        {
            throw new NotImplementedException();
        }

        public void calculateNetPay(int grossPay)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
