using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public class PercentageDeduction : Deduction
    {
        decimal percentage;

        public override decimal calculateDeductionAmount(decimal grossPay)
        {
            return percentage * grossPay;
        }
    }
}
