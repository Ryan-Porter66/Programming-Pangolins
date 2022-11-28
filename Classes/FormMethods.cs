using System.Windows.Forms;

namespace PayrollManagement.Classes
{
    public static class FormMethods
    {
        #region Strings Format Methods
        public static string ReturnGeneralStringFormat(int min, int max)
        {
            return "Must be between " + min.ToString() + " and " + max.ToString() + " characters.";
        }
        public static string ReturnDateStringFormat()
        {
            return "Must be in MMddyyyy format.";
        }
        public static string ReturnRateStringFormat()
        {
            return "Must have no numbers to left of the decimal and at most 4 to the right of the decimal.";
        }
        public static string ReturnHourStringFormat()
        {
            return "Must have at max 2 numbers to the left of the decimal and/or max 2 numbers to the right of it.";
        }
        public static string ReturnPayStringFormat()
        {
            return "Must have between 1 and 6 numbers to the left of the decimal and/or max 2 numbers to the right of it.";
        }
        #endregion
        #region Methods
        //this clears all text and errors for all textboxes
        public static void ClearAllTextBoxes(Form formToEmpty, ErrorProvider epToClear)
        {
            foreach (var control in formToEmpty.Controls)
            {
                if (control is TextBox tb)
                {
                    tb.Clear();
                    epToClear.SetError(tb, "");
                }
            }
        }
        //https://stackoverflow.com/questions/12323044/c-sharp-errorprovider-want-to-know-if-any-are-active
        //this checks to see if any errors are still set
        public static bool IsFormValid(Form formToCheck, ErrorProvider epToCheck)
        {
            foreach (Control control in formToCheck.Controls)
            {
                if(!string.IsNullOrEmpty(epToCheck.GetError(control)))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
