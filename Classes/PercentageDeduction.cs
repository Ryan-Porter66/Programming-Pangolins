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
        private decimal _percentage;

        #endregion
        #region Getters/Setters
        public decimal percentage
        {
            get { return _percentage; }
            private set { _percentage = value; }
        }
        #endregion
        #region Constructor
        public PercentageDeduction(string name, decimal percentage) : base(name)
        {
            this.percentage = percentage;
        }
        #endregion
        #region Methods
        public override decimal calculateDeductionAmount(decimal grossPay)
        {
            if (percentage > 0 && percentage < 1)
            {
                return percentage * grossPay;
            }
            else
            {
                throw new ArgumentException("Percentage value must be between 0 and 1");
            }
        }
        #endregion
    }
}
