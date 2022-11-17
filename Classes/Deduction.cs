using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public abstract class Deduction
    {
        string name;

        public abstract decimal calculateDeductionAmount(decimal grossPay);
    }
}
