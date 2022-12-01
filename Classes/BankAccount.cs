using System;

namespace PayrollManagement.Classes
{
    public class BankAccount
    {
        #region Getters/Setters
        public string BankRoutingNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        #endregion
        #region Constructors
        public BankAccount(string bankRoutingNumber, string bankAccountNumber, string bankName)
        {
            BankRoutingNumber = bankRoutingNumber;
            BankAccountNumber = bankAccountNumber;
            BankName = bankName;
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

            throw new ArgumentException("Bank routing number must be 8 or more digits");
        }
        #endregion
    }
}
