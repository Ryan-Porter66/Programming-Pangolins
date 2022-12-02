using PayrollManagement.Classes;
using System;
using System.Windows.Forms;

namespace PayrollManagement.Forms
{
    public partial class EditBusinessInfoPanel : Form
    {
        #region Initializers
        private string Username { get; set; }
        private string Password { get; set; }
        public EditBusinessInfoPanel(string username, string password)
        {
            InitializeComponent();
            this.Username = username;
            this.Password = password;
        }
        private void EditBusinessInfoPanel_Load(object sender, EventArgs e)
        {
            LoadInformationToScreen();
        }
        private void LoadInformationToScreen()
        {
            Company company = Database.GetCompany(Username, Password);
            NameTextBox.Text = company.Name;
            AddressTextBox.Text = company.Address;
            CityTextBox.Text = company.City;
            StateComboBox.Text = company.State;
            ZipCodeTextBox.Text = company.PostalCode;
            PhoneTextBox.Text = company.PhoneNumber;
            FedIDTextBox.Text = company.FederalID;
            BankNameTextBox.Text = company.Bank.BankName;
            BankRNTextBox.Text = company.Bank.BankRoutingNumber;
            BankANTextBox.Text = company.Bank.BankAccountNumber;
        }
        #endregion
        #region Buttons
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateChildren()) return;
                string name = NameTextBox.Text;
                string address = AddressTextBox.Text;
                string city = CityTextBox.Text;
                string state = StateComboBox.Text;
                string zipCode = ZipCodeTextBox.Text;
                string phoneNumb = PhoneTextBox.Text;
                string fedID = FedIDTextBox.Text;
                string bankName = BankNameTextBox.Text;
                string bankRN = BankRNTextBox.Text;
                string bankAN = BankANTextBox.Text;
                BankAccount bankToAdd = new BankAccount(bankRN, bankAN, bankName);
                Company compToAdd = new Company(name, bankToAdd, fedID, address, city, state, zipCode, phoneNumb);
                Database.UpdateComany(Username, Password, compToAdd);
                MessageBox.Show(@"Company information successfully updated.");
                this.LoadInformationToScreen();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Validating
        private void NameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(NameTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditCompErrorProvider.SetError(NameTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditCompErrorProvider.SetError(NameTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }
        private void AddressTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(AddressTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditCompErrorProvider.SetError(AddressTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditCompErrorProvider.SetError(AddressTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void CityTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(CityTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditCompErrorProvider.SetError(CityTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditCompErrorProvider.SetError(CityTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void ZipCodeTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(ZipCodeTextBox.Text, 5, 5))
            {
                e.Cancel = false;
                EditCompErrorProvider.SetError(ZipCodeTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditCompErrorProvider.SetError(ZipCodeTextBox, FormMethods.ReturnGeneralStringFormat(5, 5));
            }
        }

        private void StateComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsStateValid(StateComboBox.Text))
            {
                e.Cancel = false;
                EditCompErrorProvider.SetError(StateComboBox, "");
            }
            else
            {
                e.Cancel = true;
                EditCompErrorProvider.SetError(StateComboBox, "Must select a state.");
            }
        }
        private void PhoneTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(PhoneTextBox.Text, 10, 10))
            {
                e.Cancel = false;
                EditCompErrorProvider.SetError(PhoneTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditCompErrorProvider.SetError(PhoneTextBox, FormMethods.ReturnSetLengthStringNumberFormat(10));
            }
        }
        private void FedIDTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(FedIDTextBox.Text, 9, 9))
            {
                e.Cancel = false;
                EditCompErrorProvider.SetError(FedIDTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditCompErrorProvider.SetError(FedIDTextBox, FormMethods.ReturnSetLengthStringNumberFormat(9));
            }
        }
        private void BankNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(BankNameTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                EditCompErrorProvider.SetError(BankNameTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditCompErrorProvider.SetError(BankNameTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void BankRNTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(BankRNTextBox.Text, 9, 9))
            {
                e.Cancel = false;
                EditCompErrorProvider.SetError(BankRNTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditCompErrorProvider.SetError(BankRNTextBox, FormMethods.ReturnSetLengthStringNumberFormat(9));
            }
        }

        private void BankANTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNumberStringValid(BankANTextBox.Text, 5, 17))
            {
                e.Cancel = false;
                EditCompErrorProvider.SetError(BankANTextBox, "");
            }
            else
            {
                e.Cancel = true;
                EditCompErrorProvider.SetError(BankANTextBox, FormMethods.ReturnGeneralStringFormat(5, 17));
            }
        }
        #endregion
    }
}
