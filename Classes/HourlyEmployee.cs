using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PayrollManagement.Classes
{
    public class HourlyEmployee : Employee
    {
        #region Variables
        decimal _payPerHour;
        decimal _hoursWorked;
        #endregion
        #region Get / Set
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
        #endregion
        #region Constructor
        public HourlyEmployee(string firstName, string lastName, string address, string city, string postalCode, string state, BankAccount bank, int employeeID, decimal federalTaxRate, string permissions, string ssn, DateTime dob, DateTime hireDate, string phoneNumber, string department, List<Deduction> deductionList, decimal stateTaxRate, decimal payHours) : base(firstName, lastName, address, city, postalCode, state, bank, employeeID, federalTaxRate, permissions, ssn, dob, hireDate, phoneNumber, department, deductionList, stateTaxRate)
        {
            PayPerHour = payHours;
        }
        #endregion
        #region Methods
        public override decimal CalculateGrossPay()
        {
            decimal grossPay;
            if (HoursWorked > 0 && HoursWorked < 200 && PayPerHour > 0)
            {
                grossPay = PayPerHour * HoursWorked;
                return grossPay;
            }
            else
            {
                throw new ArgumentException("Invalid Hour or Pay Per Hour data");
            }
        }

        public decimal GetPayrollHours()
        {
            bool boolTryAgain = false;
            double hours;
            //should have text for specific employee
            do
            {
                boolTryAgain = false;
                string sTextFromUser = PopUpBox.GetUserInput("Enter " +this.FirstName + " " +this.LastName +"'s hours worked.",  "Employee Hours");
                hours = Convert.ToDouble(sTextFromUser);
                if (sTextFromUser == "")
                {
                    DialogResult dialogResult = MessageBox.Show("You did not enter anything. Try again?", "Error", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        boolTryAgain = true; //will reopen the dialog for user to input text again
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //exit/cancel
                        MessageBox.Show("Operation Cancelled");
                        throw new ArgumentException("No data provided");
                        
                    }
                }
                if (double.IsNaN(hours))
                {
                    DialogResult dialogResult = MessageBox.Show("Entered value is not a number", "Error", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        boolTryAgain = true; //will reopen the dialog for user to input text again
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //exit/cancel
                        MessageBox.Show("Operation Cancelled");
                        throw new ArgumentException("No data provided");

                    }
                }
                else
                {
                    if (sTextFromUser == "cancel")
                    {
                        MessageBox.Show("Operation Cancelled!");
                        throw new ArgumentException("No data provided");
                    }
                    else
                    {
                        //MessageBox.Show("Here is the text you entered: '" + sTextFromUser + "'");
                        //do something here with the user input
                        //error check from string to decimal
                        HoursWorked = decimal.Parse(sTextFromUser);
                    }
                }
            } while (boolTryAgain == true);

            return HoursWorked;
        }
        #endregion
    }
}
