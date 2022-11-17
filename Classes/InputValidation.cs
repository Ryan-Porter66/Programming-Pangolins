using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace PayrollManagement.Classes
{
    public class InputValidation
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
        //this method will see if the string contains only alphanumiric and spaces with at least 1 character
        public static bool isNormalStringValid(string stringToValidate, int maxLength)
        {
            if(Regex.Match(stringToValidate, normalStringPattern).Success && stringToValidate.Length <= maxLength)
            {
                return true;
            }
            return false;
        }

        //this will check to see if a State string is valid (2 letters)
        public static bool isStateValid(string stringToValidate)
        { 
            if (Regex.Match(stringToValidate, stateStringPattern).Success)
            {
                return true;
            }
            return false;
        }

        //this check decimal number to make sure it is between 0 and 1 (not including 1), and at most 4 digits right of the period
        public static bool isRateValid(string stringToValidate)
        {
            
            if (Regex.Match(stringToValidate, rateStringPattern).Success)
            {
                //Debug.WriteLine(stringToValidate);
                decimal decimalToValidate;
                if(Decimal.TryParse(stringToValidate, out decimalToValidate))
                {
                    if(decimalToValidate < 0 || decimalToValidate >= 1)
                    {
                        return false;
                    }
                    return true;
                }
                
            }
            
            return false;
        }

        //check if string that should be all numbers meets the requirements
        public static bool isNumberStringValid(string stringToValidate, int minLength, int maxLength)
        {
            if(Regex.Match(stringToValidate, numberStringPattern).Success && stringToValidate.Length >= minLength && stringToValidate.Length <= maxLength)
            {
                return true;
            }
            return false;
        }

        //checks dates passed in MMddYYYY format and ensures that the date is not too in the past or in the future
        public static bool isDateStringValid(string stringToValidate)
        {
            DateTime tempTime;
            if(DateTime.TryParseExact(stringToValidate, dateStringPatterns, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out tempTime))
            {
                Debug.WriteLine(tempTime.Year);
                if( DateTime.Now.Year - tempTime.Year < 100 && tempTime < DateTime.Now)    //ensure the year is not too far back and in the past
                {
                    return true;
                }
 
            }

            return false;
        }

        //this checks the input hours for hourly employees (99.99)
        public static bool isHourStringValid(string stringToValidate)
        {
            if(Regex.Match(stringToValidate, hourStringPattern).Success)
            {
                decimal stringDecimal;

                if(Decimal.TryParse(stringToValidate, out stringDecimal))
                {
                    if(stringDecimal > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //this check input pay (hourly or salary) and has the form of 999999.99
        public static bool isPayStringValid(string stringToValidate)
        {
            if (Regex.Match(stringToValidate, payStringPattern).Success)
            {
                decimal stringDecimal;

                if (Decimal.TryParse(stringToValidate, out stringDecimal))
                {
                    if (stringDecimal > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion
    }
}
