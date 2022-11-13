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
        public string firstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }
        private string _lastName;
        public string lastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }
        private string _address;
        public string address
        {
            get { return _address; }
            private set { _address = value; }
        }
        private string _city;
        public string city
        {
            get { return _city; }
            private set { _city = value; }
        }
        private string _postalCode;
        public string postalCode
        {
            get { return _postalCode; }
            private set { _postalCode = value; }
        }
        private string _state;
        public string state
        {
            get { return _state; }
            private set { _state = value; }
        }
        private BankAccount _bank;
        public BankAccount bank
        {
            get { return _bank; }
            private set { _bank = value; }
        }
        private int _employeeID;
        public int employeeID
        {
            get { return _employeeID; }
            private set { _employeeID = value; }
        }
        private decimal _federalTaxRate;
        public decimal federalTaxRate
        {
            get { return _federalTaxRate; }
            private set { _federalTaxRate = value; }
        }
        private string _permissions;
        public string permissions
        {
            get { return _permissions; }
            private set { _permissions = value; }
        }
        private int _ssn;
        public int ssn
        {
            get { return _ssn; }
            private set { _ssn = value; }
        }
        private DateTime _dob;
        public DateTime dob
        {
            get { return _dob; }
            private set { _dob = value; }
        }
        private DateTime _hireDate;
        public DateTime hireDate
        {
            get { return _hireDate; }
            private set { _hireDate = value; }
        }
        private int _phoneNumber;
        public int phoneNumber
        {
            get { return _phoneNumber; }
            private set { _phoneNumber = value; }
        }
        private string _department;
        public string department
        {
            get { return _department; }
            private set { _department = value; }
        }
        private List<Deduction> _deductionList;
        public List<Deduction> deductionList
        {
            get { return _deductionList; }
            private set { _deductionList = value; }
        }
        private decimal _netPay;
        public decimal netPay
        {
            get { return _netPay; }
            private set { _netPay = value; }
        }
        private decimal _stateTaxRate;
        public decimal stateTaxRate
        {
            get { return _stateTaxRate; }
            private set { _stateTaxRate = value; }
        }
        public Employee(string firstName, string lastName, string address, string city, string postalCode, string state, BankAccount bank, int employeeID, decimal federalTaxRate, string permissions, int ssn, DateTime dob, DateTime hireDate, int phoneNumber, string department, List<Deduction> deductionList, decimal netPay, decimal stateTaxRate)
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
    }
}
