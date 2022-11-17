using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public class FlatDeduction : Deduction
    {
        #region Variables
        decimal flat;
        #endregion
        #region Getters/Setters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        public override decimal calculateDeductionAmount(decimal grossPay)
        {
            return flat;
        }
        #endregion
    }
}
