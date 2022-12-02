using PayrollManagement.Classes;
using System;
using System.Windows.Forms;

namespace PayrollManagement.Forms
{
    public partial class EmployeePanel : Form
    {
        #region Initializers
        private string Username { get; set; }
        private string Password { get; set; }
        private string UserID { get; set; }
        public EmployeePanel(string username, string password, string userID)
        {
            InitializeComponent();
            this.Username = username;
            this.Password = password;
            UserID = userID;
        }
        private void AddEmployeePanel_Load(object sender, EventArgs e)
        {
            Employee employee = Database.GetEmployee(Username, Password, UserID);
            FillTextBoxes(employee);
            DeductionsListBox.DisplayMember = "Name";
            DeductionsListBox.DataSource = employee.DeductionList;
            DeductionsListBox.ClearSelected();
        }
        #endregion
        #region Misc Functions
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
            switch (emp)
            {
                case SalaryEmployee se:
                    SalariedHourlyComboBox.Text = "Salary";
                    SalariedPayPerDayTextBox.Text = se.SalaryPerPayPeriod.ToString("0.00");
                    break;
                case HourlyEmployee he:
                    SalariedHourlyComboBox.Text = "Hourly";
                    HourlyPayTextbox.Text = he.PayPerHour.ToString("0.00");
                    break;
            }
            FedRateTextBox.Text = emp.FederalTaxRate.ToString("0.00");
        }
        private void DeductionsListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            string name = ((Deduction)e.ListItem).Name;
            string amount = "bad data";
            switch ((Deduction)e.ListItem)
            {
                case FlatDeduction fd:
                    amount = fd.Flat.ToString("0.00");
                    break;
                case PercentageDeduction pd:
                    amount = pd.Percentage.ToString("0.00");
                    break;
            }
            string stringToDisplay = $"{amount.PadRight(10)} {name}";
            e.Value = stringToDisplay;
        }
        #endregion
    }
}
