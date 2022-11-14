using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ClassDiagram
{
    public class HourlyEmployee : Employee
    {
        decimal _payPerHour;
        decimal _hoursWorked;

        public decimal HoursWorked
        {
            get { return _hoursWorked; }
            set { _hoursWorked = value; }
        }

        public decimal PayPerHour
        {
            get { return _payPerHour; }
            set { _payPerHour = value; }
        }

        public HourlyEmployee(string firstName, string lastName, string address, string city, string postalCode, string state, BankAccount bank, int employeeID, decimal federalTaxRate, string permissions, string ssn, DateTime dob, DateTime hireDate, string phoneNumber, string department, List<Deduction> deductionList, decimal netPay, decimal stateTaxRate) : base(firstName, lastName, address, city, postalCode, state, bank, employeeID, federalTaxRate, permissions, ssn, dob, hireDate, phoneNumber, department, deductionList, netPay, stateTaxRate)
        {
        }

        public override decimal calculateGrossPay()
        {
            decimal grossPay = PayPerHour * HoursWorked;
            throw new NotImplementedException();
        }

        public decimal getPayrollHours()
        {
            return HoursWorked;
        }
    }
}
