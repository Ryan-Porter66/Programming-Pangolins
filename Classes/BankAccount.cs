using System;

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
        public string BankRoutingNumber
        {
            get { return _bankRoutingNumber; }
            private set { _bankRoutingNumber = value; }
        }
        
        public string BankAccountNumber
        {
            get { return _bankAccountNumber; }
            private set { _bankAccountNumber = value; }
        }
        
        public string BankName
        {
            get { return _bankName; }
            private set { _bankName = value; }
        }
        #endregion
        #region Constructors
        public BankAccount(string bankRoutingNumber, string bankAccountNumber, string bankName)
        {
            this.BankRoutingNumber = bankRoutingNumber;
            this.BankAccountNumber = bankAccountNumber;
            this.BankName = bankName;
        }
        #endregion
        #region Methods
        public string ReturnFirstEightOfRoute()
        {
            if(InputValidation.IsNumberStringValid(BankRoutingNumber, 8, 17)) //verify that the bankAccount # is at least 8 digits
            {
                string firstEight = BankRoutingNumber.Substring(0, 8);//pull the first 8 digits starting @ position 0 in the routing number string
                return firstEight;
            }  
            else
            {
                throw new ArgumentException("Bank routing number must be 8 or more digits");
            }
        }
        #endregion
    }
}
