using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PayrollManagement.Classes
{
    public class HourlyEmployee : Employee
    {
        #region Variables

        #endregion
        #region Get / Set
        public decimal HoursWorked { get; set; }

        public decimal PayPerHour { get; set; }

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
            if (HoursWorked > 0 && HoursWorked < 200 && PayPerHour > 0)
            {
                decimal grossPay = PayPerHour * HoursWorked;
                return grossPay;
            }

            throw new ArgumentException("Invalid Hour or Pay Per Hour data for "+ this.FirstName + " " + this.LastName + "!");
        }

        public void GetPayrollHours()
        {
            bool boolTryAgain;
            do
            {
                boolTryAgain = false;
                string sTextFromUser = PopUpBox.GetUserInput("Enter " + this.FirstName + " " + this.LastName + "'s hours worked.", "Employee Hours");
                if (sTextFromUser == "" || sTextFromUser == "cancel")
                {
                    DialogResult dialogResult = MessageBox.Show(@"You cancelled or did not enter anything. Try again?", @"Error", MessageBoxButtons.YesNo);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            boolTryAgain = true; //will reopen the dialog for user to input text again
                            break;
                        case DialogResult.No:
                            //exit/cancel
                            //MessageBox.Show("Operation Cancelled!");
                            throw new ArgumentException("Hours not provided!");
                    }
                }
                else if (!InputValidation.IsHourStringValid(sTextFromUser) || !Decimal.TryParse(sTextFromUser, out decimal hours))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Format Required: 99.99 - Try Again?", @"Error", MessageBoxButtons.YesNo);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            boolTryAgain = true; //will reopen the dialog for user to input text again
                            break;
                        case DialogResult.No:
                            //exit/cancel
                            //MessageBox.Show("Operation Cancelled!");
                            throw new ArgumentException("Hours not provided!");
                    }
                }
                else
                {
                    if (sTextFromUser == "cancel")
                    {
                        //MessageBox.Show("Operation Cancelled!");
                        throw new ArgumentException("Hours not provided!");
                    }

                    //MessageBox.Show("Here is the text you entered: " + hours);
                    HoursWorked = hours;
                }
            } while (boolTryAgain);
        }
        #endregion
    }
}
