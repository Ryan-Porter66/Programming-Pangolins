using PayrollManagement.Classes;
using System;
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
            SalariedHourlyComboBox.Items.Add("");
            SalariedHourlyComboBox.Items.Add("Salaried");
            SalariedHourlyComboBox.Items.Add("Hourly");
        }
        #endregion

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //verify the data is sound
                //Personal Information
                if (!InputValidation.IsNormalStringValid(FirstNameTextBox.Text, 1, 49))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a First Name with a Length of 1-49.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsNormalStringValid(LastNameTextBox.Text, 1, 49))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a Last Name with a Length of 1-49.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsNormalStringValid(AddressTextBox.Text, 1, 49))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter an Address with a Length of 1-49.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsNormalStringValid(CityTextBox.Text, 1, 49))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a City with a Length of 1-49.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsNumberStringValid(ZipCodeTextBox.Text, 5, 5))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a Zip Code with a Length of 5.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsStateValid(StateTextBox.Text))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a State with its short hand form. Example: Nebraska = NE", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsNumberStringValid(PhoneTextBox.Text, 10, 10))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a Phone Number that is 10 digits long with no dashes.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsDateStringValid(DoBTextBox.Text))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a DoB in the format MMddYYYY . ", @"Please correct:", MessageBoxButtons.OK);
                }
                //Bank Information
                else if (!InputValidation.IsNormalStringValid(BankNameTextBox.Text, 1, 49))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a Bank Name with a Length of 1-49.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsNumberStringValid(BankANTextBox.Text, 5, 17))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a Bank Account Number with a Length of 5-17.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsNumberStringValid(BankRNTextBox.Text, 1, 49))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a Bank Routing Number that is 9 digits.", @"Please correct:", MessageBoxButtons.OK);
                }
                //Payroll Information
                else if (!InputValidation.IsNormalStringValid(DepartmentTextBox.Text, 1, 49))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a Department Name with a Length of 1-49.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsDateStringValid(HireDateTextBox.Text))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a Hire Date in the format MMddYYYY.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsSalariedOrHourlyValid(SalariedHourlyComboBox.Text))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must choose Hourly or Salaried", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsNumberStringValid(SSNTextBox.Text, 9, 9))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a Social Security Number with the length of 9 and no dashes.", @"Please correct:", MessageBoxButtons.OK);
                }
                else if (!InputValidation.IsRateValid(FedRateTextBox.Text))
                {
                    DialogResult dialogResult = MessageBox.Show(@"Must enter a Federal Tax rate between .0 and 1.", @"Please correct:", MessageBoxButtons.OK);
                }
                //add new employees based on the data
                else
                {
                      

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
