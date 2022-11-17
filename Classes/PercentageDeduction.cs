using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public class PercentageDeduction : Deduction
    {
        #region Variables
        decimal percentage;
        #endregion
        #region Getters/Setters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        public override decimal calculateDeductionAmount(decimal grossPay)
        {
            return percentage * grossPay;
        }
        #endregion
    }
}
