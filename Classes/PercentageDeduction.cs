using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ClassDiagram
{
    public class PercentageDeduction : Deduction
    {
        decimal percentage;

        public override decimal calculateDeductionAmount(decimal grossPay)
        {
            return (1 - percentage) * grossPay;
        }
    }
}
