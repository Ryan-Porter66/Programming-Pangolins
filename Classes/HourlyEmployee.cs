using PayrollManagement.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public override decimal calculateGrossPay()
        {
            decimal grossPay;
            if (HoursWorked > 0 && HoursWorked < 200 && PayPerHour > 0)
            {
                grossPay = PayPerHour * HoursWorked;
                return grossPay;
            }
            else
            {
                grossPay = 0.00m;
                return grossPay;
            }
        }

        public decimal getPayrollHours()
        {
            bool boolTryAgain = false;
            //should have text for specific employee
            do
            {
                string sTextFromUser = PopUpBox.GetUserInput("Enter employee hours", "Employee Hours");
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
                        MessageBox.Show("operation cancelled");
                        boolTryAgain = false;
                    }//end if
                }
                else
                {
                    if (sTextFromUser == "cancel")
                    {
                        MessageBox.Show("Operation Cancelled!");
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
