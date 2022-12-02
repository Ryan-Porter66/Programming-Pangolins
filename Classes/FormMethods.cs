using System.Windows.Forms;

namespace PayrollManagement.Classes
{
    public static class FormMethods
    {
        #region String Format Methods
        public static string ReturnGeneralStringFormat(int min, int max)
        {
            return "Must be between " + min + " and " + max + " characters.";
        }
        public static string ReturnDateStringFormat()
        {
            return "Must be in MMddyyyy format and a valid date (not too far in the past nor future).";
        }
        public static string ReturnRateStringFormat()
        {
            return "Must have no numbers to left of the decimal and at most 4 to the right of the decimal.";
        }
        public static string ReturnPayStringFormat()
        {
            return "Must have between 1 and 6 numbers to the left of the decimal and/or max 2 numbers to the right of it.";
        }
        public static string ReturnSetLengthStringNumberFormat(int length)
        {
            return $"Must be {length} digits with no characters between the numbers.";
        }
        #endregion
        #region Methods
        //this clears all text and errors for all textboxes
        public static void ClearAllTextBoxes(Form formToEmpty, ErrorProvider epToClear)
        {
            foreach (var control in formToEmpty.Controls)
            {
                if (!(control is TextBox tb)) continue;
                tb.Clear();
                epToClear.SetError(tb, "");
            }
        }
        #endregion
    }
}
