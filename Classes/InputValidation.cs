using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace PayrollManagement.Classes
{
    public static class InputValidation
    {
        #region Regex
        const string normalStringPattern = @"^[\w][\w\-\s]+$";
        const string stateStringPattern = @"^[A-Za-z]{2}$";
        const string rateStringPattern = @"^0?(\.\d{1,4})?$";
        const string numberStringPattern = @"^\d+$";
        const string hourStringPattern = @"^\d{0,2}(\.\d{0,2})?$";
        const string payStringPattern = @"^\d{1,6}(\.\d{0,2})?$";
        const string dateStringPatterns = "MMddyyyy";
        #endregion
        #region Methods
        //this method will see if the string contains only alphanumeric and spaces with at least 1 character
        public static bool IsNormalStringValid(string stringToValidate, int minLength, int maxLength)
        {
            return Regex.Match(stringToValidate, normalStringPattern).Success && stringToValidate.Length <= maxLength && stringToValidate.Length >= minLength;
        }

        //this will check to see if a State string is valid (2 letters)
        public static bool IsStateValid(string stringToValidate)
        {
            return Regex.Match(stringToValidate, stateStringPattern).Success;
        }

        //this check decimal number to make sure it is between 0 and 1 (not including 1), and at most 4 digits right of the period
        public static bool IsRateValid(string stringToValidate)
        {
            if (!Regex.Match(stringToValidate, rateStringPattern).Success) return false;
            //Debug.WriteLine(stringToValidate);
            if (decimal.TryParse(stringToValidate, out decimal decimalToValidate))
            {
                return decimalToValidate >= 0 && decimalToValidate < 1;
            }
            return false;
        }

        //check if string that should be all numbers meets the requirements
        public static bool IsNumberStringValid(string stringToValidate, int minLength, int maxLength)
        {
            return Regex.Match(stringToValidate, numberStringPattern).Success && stringToValidate.Length >= minLength && stringToValidate.Length <= maxLength;
        }

        //checks dates passed in MMddYYYY format and ensures that the date is not too in the past or in the future
        public static bool IsDateStringValid(string stringToValidate)
        {
            if (!DateTime.TryParseExact(stringToValidate, dateStringPatterns,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime tempTime)) return false;
            Debug.WriteLine(tempTime.Year);
            return DateTime.Now.Year - tempTime.Year < 100 && tempTime < DateTime.Now; //ensure the year is not too far back and in the past
        }

        //this checks the input hours for hourly employees (99.99)
        public static bool IsHourStringValid(string stringToValidate)
        {
            if (!Regex.Match(stringToValidate, hourStringPattern).Success) return false;
            if (!decimal.TryParse(stringToValidate, out decimal stringDecimal)) return false;
            return stringDecimal > 0;
        }

        //this check input pay (hourly or salary) and has the form of 999999.99
        public static bool IsPayStringValid(string stringToValidate)
        {
            if (!Regex.Match(stringToValidate, payStringPattern).Success) return false;
            if (!decimal.TryParse(stringToValidate, out decimal stringDecimal)) return false;
            return stringDecimal > 0;
        }
        public static bool IsSalariedOrHourlyValid(string stringToValidate)
        {
            if (stringToValidate == "") return false;
            return true;

        }
        #endregion
    }
}
