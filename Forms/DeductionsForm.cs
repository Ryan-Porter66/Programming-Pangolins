using PayrollManagement.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PayrollManagement.Forms
{
    public partial class DeductionsForm : Form
    {
        #region Initializors/Misc
        private string Username { get; set; }
        private string Password { get; set; }
        private string EmpID { get; set; }
        private List<Deduction> Deductions { get; set; }
        public DeductionsForm(string username, string password, string empID)
        {
            InitializeComponent();
            Username = username;
            Password = password;
            EmpID = empID;
            Deductions = Database.GetDeductions(Username, Password, EmpID);
        }
        private void DeductionsForm_Load(object sender, System.EventArgs e)
        {
            DeductionsListBox.DisplayMember = "Name";
            DeductionsListBox.DataSource = Deductions;
            DeductionsListBox.ClearSelected();
        }
        #endregion
        #region Clear Form
        private void ClearForm()
        {
            FormMethods.ClearAllTextBoxes(this, DedErrorProvider);
            DedTypeComboBox.SelectedIndex = -1;
        }
        #endregion
        #region ListBox Methods
        private void DeductionsListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            string name = ((Deduction)e.ListItem).Name.ToString();
            string amount = "bad data";
            if ((Deduction)e.ListItem is FlatDeduction fd) {
                amount = fd.Flat.ToString("0.00");
            }
            else if ((Deduction)e.ListItem is PercentageDeduction pd)
            {
                amount = pd.Percentage.ToString("0.00");
            }
            string stringToDisplay = string.Format("{0} {1}", amount.PadRight(10), name);
            e.Value = stringToDisplay;
        }
        private void RefreshDeductionListBox()
        {
            Deductions = Database.GetDeductions(Username, Password, EmpID);
            DeductionsListBox.DataSource = null;
            DeductionsListBox.DataSource = Deductions;
        }
        #endregion
        #region Button Methods
        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                List<Deduction> deductionsToDelete = DeductionsListBox.SelectedItems.Cast<Deduction>().ToList();
                int count = 0;
                foreach(Deduction deduction in deductionsToDelete)
                {
                    count++;
                    Database.DeleteDeduction(Username, Password, EmpID, deduction);
                }
                MessageBox.Show($"Successfully deleted {count} deductions.");
                RefreshDeductionListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DedAddButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                if(this.ValidateChildren())
                {
                    string dedName = DedNameTextBox.Text;
                    string dedAmount = DedAmountTextBox.Text;
                    decimal dedAmountDecimal = Convert.ToDecimal(dedAmount);
                    string dedType = DedTypeComboBox.Text;
                
                    if(dedType == "Flat")
                    {
                        FlatDeduction deductionToAdd = new FlatDeduction(dedName, dedAmountDecimal);
                        List<Deduction> deductionsToAdd = new List<Deduction> { deductionToAdd };
                        Database.AddDeductions(Username, Password, EmpID, deductionsToAdd);
                    }
                    else
                    {
                        PercentageDeduction deductionToAdd = new PercentageDeduction(dedName, dedAmountDecimal);
                        List<Deduction> deductionsToAdd = new List<Deduction> { deductionToAdd };
                        Database.AddDeductions(Username, Password, EmpID, deductionsToAdd);
                    }
                    MessageBox.Show("Successfully added deduction.");
                    RefreshDeductionListBox();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Validating
        private void DedNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(DedNameTextBox.Text, 1, 49))
            {
                e.Cancel = false;
                DedErrorProvider.SetError(DedNameTextBox, "");
            }
            else
            {
                e.Cancel = true;
                DedErrorProvider.SetError(DedNameTextBox, FormMethods.ReturnGeneralStringFormat(1, 49));
            }
        }

        private void DedTypeComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (InputValidation.IsNormalStringValid(DedTypeComboBox.Text, 1, 49))
            {
                e.Cancel = false;
                DedErrorProvider.SetError(DedTypeComboBox, "");
            }
            else
            {
                e.Cancel = true;
                DedErrorProvider.SetError(DedTypeComboBox, "Must select a type.");
            }
        }

        private void DedAmountTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!InputValidation.IsNormalStringValid(DedTypeComboBox.Text, 1, 49))
            {
                e.Cancel = true;
                DedErrorProvider.SetError(DedAmountTextBox, "Must select a type first.");
            }
            else if (DedTypeComboBox.Text == "Flat")
            {
                if(InputValidation.IsPayStringValid(DedAmountTextBox.Text))
                {
                    e.Cancel = false;
                    DedErrorProvider.SetError(DedAmountTextBox, "");
                }
                else
                {
                    e.Cancel = true;
                    DedErrorProvider.SetError(DedAmountTextBox, FormMethods.ReturnPayStringFormat());
                }
            }
            else
            {
                if (InputValidation.IsRateValid(DedAmountTextBox.Text))
                {
                    e.Cancel = false;
                    DedErrorProvider.SetError(DedAmountTextBox, "");
                }
                else
                {
                    e.Cancel = true;
                    DedErrorProvider.SetError(DedAmountTextBox, FormMethods.ReturnRateStringFormat());
                }
            }
        }
        #endregion
    }
}
