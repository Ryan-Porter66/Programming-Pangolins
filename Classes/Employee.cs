using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ClassDiagram
{
    public abstract class Employee
    {
        string firstName;
        string lastName;
        string address;
        string city;
        string postalCode;
        string state;
        BankAccount bank;
        int employeeID;
        decimal federalTaxRate;
        string permissions;
        int SSN;
        DateTime DOB;
        DateTime hireDate;
        int phoneNumber;
        string department;
        List<Deduction> deductionList;
        decimal netPay;
        decimal stateTaxRate;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string State { get => state; set => state = value; }
        public BankAccount Bank { get => bank; set => bank = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public decimal FederalTaxRate { get => federalTaxRate; set => federalTaxRate = value; }
        public string Permissions { get => permissions; set => permissions = value; }
        public int SSN1 { get => SSN; set => SSN = value; }
        public DateTime DOB1 { get => DOB; set => DOB = value; }
        public DateTime HireDate { get => hireDate; set => hireDate = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Department { get => department; set => department = value; }
        public List<Deduction> DeductionList { get => deductionList; set => deductionList = value; }
        public decimal NetPay { get => netPay; set => netPay = value; }
        public decimal StateTaxRate { get => stateTaxRate; set => stateTaxRate = value; }

        protected Employee(string firstName, string lastName, string address, string city, string postalCode, string state, BankAccount bank, int employeeID, decimal federalTaxRate, string permissions, int ssn, DateTime dob, DateTime hireDate, int phoneNumber, string department, List<Deduction> deductionList, decimal netPay, decimal stateTaxRate)
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
            SSN1 = ssn;
            DOB1 = dob;
            this.HireDate = hireDate;
            this.PhoneNumber = phoneNumber;
            this.Department = department ?? throw new ArgumentNullException(nameof(department));
            this.DeductionList = deductionList ?? throw new ArgumentNullException(nameof(deductionList));
            this.NetPay = netPay;
            this.StateTaxRate = stateTaxRate;
        }

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
