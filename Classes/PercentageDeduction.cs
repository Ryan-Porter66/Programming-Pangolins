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

        public decimal calculateDeductionAmount(decimal grossPay)
        {
            throw new NotImplementedException();
        }
    }
}
