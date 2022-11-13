using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ClassDiagram
{
    public class BankAccount
    {
        string bankRoutingNumber;
        string bankAccountNumber;
        string bankName;

        public BankAccount(string bankRoutingNumber, string bankAccountNumber, string bankName)
        {
            BankRoutingNumber = bankRoutingNumber;
            BankAccountNumber = bankAccountNumber;
            BankName = bankName;
        }

        public string BankRoutingNumber { get => bankRoutingNumber; set => bankRoutingNumber = value; }
        public string BankAccountNumber { get => bankAccountNumber; set => bankAccountNumber = value; }
        public string BankName { get => bankName; set => bankName = value; }

        public string returnFirstEightOfRoute()
        {
            //pull the first 8 digits starting @ position 0 in the routing number string
            string firstEight = BankRoutingNumber.Substring(0, 8);
            return firstEight;
        }
    }
}
