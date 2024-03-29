﻿using PayrollManagement.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PayrollManagement.Forms
{
    public partial class AddEmployeePanel : Form
    {
        #region Initializers
        private string Username { get; set; }
        private string Password { get; set; }
        public AddEmployeePanel(string username, string password)
        {
            InitializeComponent();
            this.Username = username;
            this.Password = password;
        }
        private void AddEmployeePanel_Load(object sender, EventArgs e)
        {
            SalariedHourlyComboBox.SelectedIndex = 0;
        }
        #endregion
        #region Buttons
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //check to see if all data is valid
                if (!this.ValidateChildren()) return;
                //Convert FedTaxRateStr to decimal
                decimal FedTaxRate = Decimal.Parse(FedRateTextBox.Text);                    

                //convert Check Box info into "Admin" or "Employee"
                string Permissions = "";
                Permissions = AdminUserCheckBox.Checked ? "Admin" : "Employee";

                //Create new objects
                BankAccount newEmployeeBankInfo = new BankAccount(BankRNTextBox.Text, BankANTextBox.Text, BankNameTextBox.Text);
                DateTime.TryParseExact(DoBTextBox.Text, InputValidation.dateStringPatterns, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime DoB);
                DateTime.TryParseExact(HireDateTextBox.Text, InputValidation.dateStringPatterns, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime HireDate);
                int empID = 0; //database makes this
                decimal stateTaxRate = 0; //database looks this up
                string trueEmpID = "";

                List<Deduction> dummyDeductionList = new List<Deduction>();
                    
                //create an employee object based on if they are hourly or salaried & send it to database
                if (SalariedHourlyComboBox.Text == "Salary")
                {
                    decimal salary = Decimal.Parse(SalariedPayPerDayTextBox.Text);
                    SalaryEmployee newSalaryEmployee = new SalaryEmployee(FirstNameTextBox.Text, LastNameTextBox.Text, AddressTextBox.Text, 
                        CityTextBox.Text, ZipCodeTextBox.Text, StateComboBox.Text, newEmployeeBankInfo, empID, FedTaxRate, Permissions, 
                        SSNTextBox.Text, DoB, HireDate, PhoneTextBox.Text, DepartmentTextBox.Text, dummyDeductionList, stateTaxRate, salary);
                    trueEmpID = Database.AddEmployee(Username, Password, newSalaryEmployee);
                }
                else
                {
                    decimal payPerHour = Decimal.Parse(HourlyPayTextbox.Text);
                    HourlyEmployee newHourlyEmployee = new HourlyEmployee(FirstNameTextBox.Text, LastNameTextBox.Text, AddressTextBox.Text, 
                        CityTextBox.Text, ZipCodeTextBox.Text, StateComboBox.Text, newEmployeeBankInfo, empID, FedTaxRate, Permissions, 
                        SSNTextBox.Text, DoB, HireDate, PhoneTextBox.Text, DepartmentTextBox.Text, dummyDeductionList, stateTaxRate, payPerHour);
                    trueEmpID = Database.AddEmployee(Username, Password, newHourlyEmployee);
                }
                MessageBox.Show($"New employee ID {trueEmpID} was added to the database.");
                this.ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void CancelAddButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Clear Form
        private void ClearForm()
        {
            FormMethods.ClearAllTextBoxes(this, AddErrorProvider);
            SalariedHourlyComboBox.SelectedIndex = 0;
            StateComboBox.SelectedIndex = -1;
            AdminUserCheckBox.Checked = false;
        }
        #endregion
        #region Validate Events
        private void FirstNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(InputValidation.IsNormalStringValid(FirstNameTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(FirstNameTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(FirstNameTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }
        private void LastNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(LastNameTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(LastNameTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(LastNameTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }
        private void AddressTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(AddressTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(AddressTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(AddressTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void CityTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(CityTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(CityTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(CityTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void ZipCodeTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(ZipCodeTextBox.Text, 5, 5))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(ZipCodeTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(ZipCodeTextBox, FormMethods.ReturnGeneralStringFormat(5, 5));
            }
        }

        private void StateComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsStateValid(StateComboBox.Text))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(StateComboBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(StateComboBox, "Must select a state.");
            }
        }

        private void PhoneTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(PhoneTextBox.Text, 10, 10))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(PhoneTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(PhoneTextBox, FormMethods.ReturnSetLengthStringNumberFormat(10));
            }
        }

        private void DoBTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsDateStringValid(DoBTextBox.Text))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(DoBTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(DoBTextBox, FormMethods.ReturnDateStringFormat());
            }
        }

        private void SSNTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(SSNTextBox.Text, 9, 9))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(SSNTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(SSNTextBox, FormMethods.ReturnSetLengthStringNumberFormat(9));
            }
        }

        private void BankNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(BankNameTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(BankNameTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(BankNameTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void BankRNTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(BankRNTextBox.Text, 9, 9))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(BankRNTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(BankRNTextBox, FormMethods.ReturnSetLengthStringNumberFormat(9));
            }
        }

        private void BankANTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(BankANTextBox.Text, 5, 17))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(BankANTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(BankANTextBox, FormMethods.ReturnGeneralStringFormat(5, 17));
            }
        }

        private void DepartmentTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(DepartmentTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(DepartmentTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(DepartmentTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void HireDateTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsDateStringValid(HireDateTextBox.Text))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(HireDateTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(HireDateTextBox, FormMethods.ReturnDateStringFormat());
            }
        }

        private void SalariedHourlyComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(SalariedHourlyComboBox.Text, 1, 49))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(SalariedHourlyComboBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(SalariedHourlyComboBox, "Must select a value.");
            }
        }

        private void FedRateTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsRateValid(FedRateTextBox.Text))
            {
                e.Cancel = false;
                AddErrorProvider.SetError(FedRateTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(FedRateTextBox, FormMethods.ReturnRateStringFormat());
            }
        }

        private void SalariedPayPerDayTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsPayStringValid(SalariedPayPerDayTextBox.Text) || SalariedHourlyComboBox.Text == "Hourly")
            {
                e.Cancel = false;
                AddErrorProvider.SetError(SalariedPayPerDayTextBox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(SalariedPayPerDayTextBox, FormMethods.ReturnPayStringFormat());
            }
        }

        private void HourlyPayTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsPayStringValid(HourlyPayTextbox.Text) || SalariedHourlyComboBox.Text == "Salary")
            {
                e.Cancel = false;
                AddErrorProvider.SetError(HourlyPayTextbox, "");
            }
            else
            {
                e.Cancel = true;
                AddErrorProvider.SetError(HourlyPayTextbox, FormMethods.ReturnPayStringFormat());
            }
        }
        #endregion
        #region Blur Functionality
        private void SalariedHourlyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSalaryHourlyTextBoxes();
        }
        private void UpdateSalaryHourlyTextBoxes()
        {
            switch (SalariedHourlyComboBox.Text)
            {
                case "Salary":
                    SalariedPayPerDayTextBox.Enabled = true;
                    HourlyPayTextbox.Enabled = false;
                    HourlyPayTextbox.Text = "";
                    AddErrorProvider.SetError(HourlyPayTextbox, "");
                    break;
                case "Hourly":
                    HourlyPayTextbox.Enabled = true;
                    SalariedPayPerDayTextBox.Enabled = false;
                    SalariedPayPerDayTextBox.Text = "";
                    AddErrorProvider.SetError(SalariedPayPerDayTextBox, "");
                    break;
            }
        }
        #endregion
    }
}
