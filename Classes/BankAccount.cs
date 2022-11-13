using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ClassDiagram
{
    public class BankAccount
    {
        #region Variables
        private string _bankRoutingNumber;
        public string bankRoutingNumber
        {
            get { return _bankRoutingNumber; }
            private set { _bankRoutingNumber = value; }
        }
        private string _bankAccountNumber;
        public string bankAccountNumber
        {
            get { return _bankAccountNumber; }
            private set { _bankAccountNumber = value; }
        }
        private string _bankName;
        public string bankName
        {
            get { return _bankName; }
            private set { _bankName = value; }
        }
        #endregion

        public BankAccount(string bankRoutingNumber, string bankAccountNumber, string bankName)
        {
            this.bankRoutingNumber = bankRoutingNumber;
            this.bankAccountNumber = bankAccountNumber;
            this.bankName = bankName;
        }

        public string returnFirstEightOfRoute()
        {
            //pull the first 8 digits starting @ position 0 in the routing number string
            string firstEight = bankRoutingNumber.Substring(0, 8);
            return firstEight;
        }
    }
}
