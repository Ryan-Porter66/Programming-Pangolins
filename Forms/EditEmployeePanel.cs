using PayrollManagement.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PayrollManagement.Forms
{
    public partial class EditEmployeePanel : Form
    {
        #region Initializers
        private string Username { get; set; }
        private string Password { get; set; }
        private string UserID { get; set; }
        public EditEmployeePanel(string username, string password)
        {
            InitializeComponent();
            this.Username = username;
            this.Password = password;
        }
        private void AddEmployeePanel_Load(object sender, EventArgs e)
        {
            EnableAllBoxes(false);
        }
        #endregion
        #region Buttons
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //need more here
            if(this.ValidateChildren())
            {
                ClearForm();
            }
        }
        private void EmployeeListButton_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeList employees = new EmployeeList();
                employees.GenerateEmployeeList(Username, Password);
                employees.DisplaySelectableEmployeeList(true);
                Employee employeeToEdit = employees.Employees.First();
                UserID = employeeToEdit.EmployeeID.ToString();
                EnableAllBoxes(true);
                FillTextBoxes(employeeToEdit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DeductionsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (DeductionsForm deductionsForm = new DeductionsForm(Username, Password, UserID))
            {
                deductionsForm.ShowDialog();
                deductionsForm.Dispose();
            }
            this.Show();
        }
        #endregion
        #region Clear Form
        private void ClearForm()
        {
            FormMethods.ClearAllTextBoxes(this, EditErrorProvider);
            EnableAllBoxes(false);
        }
        #endregion
        #region Validate Events
        private void FirstNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(InputValidation.IsNormalStringValid(FirstNameTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(FirstNameTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(FirstNameTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }
        private void LastNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(LastNameTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(LastNameTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(LastNameTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }
        private void AddressTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(AddressTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(AddressTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(AddressTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void CityTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(CityTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(CityTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(CityTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void ZipCodeTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(ZipCodeTextBox.Text, 5, 5))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(ZipCodeTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(ZipCodeTextBox, FormMethods.ReturnGeneralStringFormat(5, 5));
            }
        }

        private void StateComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsStateValid(StateComboBox.Text))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(StateComboBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(StateComboBox, "Must select a state.");
            }
        }

        private void PhoneTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(PhoneTextBox.Text, 10, 10))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(PhoneTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(PhoneTextBox, FormMethods.ReturnSetLengthStringNumberFormat(10));
            }
        }

        private void DoBTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsDateStringValid(DoBTextBox.Text))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(DoBTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(DoBTextBox, FormMethods.ReturnDateStringFormat());
            }
        }

        private void SSNTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(SSNTextBox.Text, 9, 9))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(SSNTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(SSNTextBox, FormMethods.ReturnSetLengthStringNumberFormat(9));
            }
        }

        private void BankNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(BankNameTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(BankNameTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(BankNameTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void BankRNTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(BankRNTextBox.Text, 9, 9))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(BankRNTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(BankRNTextBox, FormMethods.ReturnSetLengthStringNumberFormat(9));
            }
        }

        private void BankANTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(BankANTextBox.Text, 5, 17))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(BankANTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(BankANTextBox, FormMethods.ReturnGeneralStringFormat(5, 17));
            }
        }

        private void DepartmentTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(DepartmentTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(DepartmentTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(DepartmentTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void HireDateTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsDateStringValid(HireDateTextBox.Text))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(HireDateTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(HireDateTextBox, FormMethods.ReturnDateStringFormat());
            }
        }

        private void SalariedHourlyComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(SalariedHourlyComboBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(SalariedHourlyComboBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(SalariedHourlyComboBox, "Must select a value.");
            }
        }

        private void FedRateTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsRateValid(FedRateTextBox.Text))
            {
                e.Cancel = false;
                EditErrorProvider.SetError(FedRateTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(FedRateTextBox, FormMethods.ReturnRateStringFormat());
            }
        }

        private void SalariedPayPerDayTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsPayStringValid(SalariedPayPerDayTextBox.Text) || SalariedHourlyComboBox.Text == "Hourly")
            {
                e.Cancel = false;
                EditErrorProvider.SetError(SalariedPayPerDayTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(SalariedPayPerDayTextBox, FormMethods.ReturnPayStringFormat());
            }
        }

        private void HourlyPayTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsPayStringValid(HourlyPayTextbox.Text) || SalariedHourlyComboBox.Text == "Salary")
            {
                e.Cancel = false;
                EditErrorProvider.SetError(HourlyPayTextbox, "");
            }
            else
            {
                e.Cancel = true;
                EditErrorProvider.SetError(HourlyPayTextbox, FormMethods.ReturnPayStringFormat());
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
            if (SalariedHourlyComboBox.Text == "Salary")
            {
                SalariedPayPerDayTextBox.Enabled = true;
                HourlyPayTextbox.Enabled = false;
                HourlyPayTextbox.Text = "";
                EditErrorProvider.SetError(HourlyPayTextbox, "");
            }
            else if (SalariedHourlyComboBox.Text == "Hourly")
            {
                HourlyPayTextbox.Enabled = true;
                SalariedPayPerDayTextBox.Enabled = false;
                SalariedPayPerDayTextBox.Text = "";
                EditErrorProvider.SetError(SalariedPayPerDayTextBox, "");
            }
        }
        #endregion
        #region Misc Functions
        private void EnableAllBoxes(bool enabled)
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox tb)
                {
                    tb.Enabled = enabled;
                }
            }
            StateComboBox.Enabled = enabled;
            SalariedHourlyComboBox.Enabled = enabled;
            SaveButton.Enabled = enabled;
            DeductionsButton.Enabled = enabled;
            AdminUserCheckBox.Enabled = enabled;
        }
        private void FillTextBoxes(Employee emp)
        {
            FirstNameTextBox.Text = emp.FirstName;
            LastNameTextBox.Text = emp.LastName;
            AddressTextBox.Text = emp.Address;
            CityTextBox.Text = emp.City;
            StateComboBox.Text = emp.State;
            ZipCodeTextBox.Text = emp.PostalCode;
            PhoneTextBox.Text = emp.PhoneNumber;
            DoBTextBox.Text = emp.Dob.ToString(InputValidation.dateStringPatterns);
            SSNTextBox.Text = emp.Ssn;
            BankNameTextBox.Text = emp.Bank.BankName;
            BankRNTextBox.Text = emp.Bank.BankRoutingNumber;
            BankANTextBox.Text = emp.Bank.BankAccountNumber;
            DepartmentTextBox.Text = emp.Department;
            HireDateTextBox.Text = emp.HireDate.ToString(InputValidation.dateStringPatterns);
            if(emp is SalaryEmployee se)
            {
                SalariedHourlyComboBox.Text = "Salary";
                SalariedPayPerDayTextBox.Text = se.SalaryPerPayPeriod.ToString("0.00");
            } 
            else if(emp is HourlyEmployee he)
            {
                SalariedHourlyComboBox.Text = "Hourly";
                HourlyPayTextbox.Text = he.PayPerHour.ToString("0.00");
            }
            FedRateTextBox.Text = emp.FederalTaxRate.ToString("0.00");
            if(emp.Permissions == "Admin")
            {
                AdminUserCheckBox.Checked = true;
            }
            if(UserID == Username) //ensure user cannot change own privileges
            {
                AdminUserCheckBox.Enabled = false;
            }
        }
        #endregion
    }
}
