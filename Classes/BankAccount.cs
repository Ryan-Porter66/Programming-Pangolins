using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public class BankAccount
    {
        #region Variables
        private string _bankRoutingNumber;
        private string _bankAccountNumber;
        private string _bankName;
        #endregion
        #region Getters/Setters
        public string bankRoutingNumber
        {
            get { return _bankRoutingNumber; }
            private set { _bankRoutingNumber = value; }
        }
        
        public string bankAccountNumber
        {
            get { return _bankAccountNumber; }
            private set { _bankAccountNumber = value; }
        }
        
        public string bankName
        {
            get { return _bankName; }
            private set { _bankName = value; }
        }
        #endregion
        #region Constructors
        public BankAccount(string bankRoutingNumber, string bankAccountNumber, string bankName)
        {
            this.bankRoutingNumber = bankRoutingNumber;
            this.bankAccountNumber = bankAccountNumber;
            this.bankName = bankName;
        }
        #endregion
        #region Methods
        public string returnFirstEightOfRoute()
        {
            if(InputValidation.isNumberStringValid(bankRoutingNumber, 8, 17)) //verify that the bankAccount # is at least 8 digits
            {
                string firstEight = bankRoutingNumber.Substring(0, 8);//pull the first 8 digits starting @ position 0 in the routing number string
                return firstEight;
            }  
            else
            {
                throw new ArgumentException("Bank account must be 8 or more digits");
            }
        }
        #endregion
    }
}
