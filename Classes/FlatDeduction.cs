using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public class FlatDeduction : Deduction
    {
        #region Variables
        private decimal _flat;


        #endregion
        #region Getters/Setters
        public decimal flat
        {
            get { return _flat; }
            private set { _flat = value; }
        }
        #endregion
        #region Constructor
        public FlatDeduction(string name, decimal flat) : base(name)
        {
            this.flat = flat;
        }
        #endregion
        #region Methods
        public override decimal calculateDeductionAmount(decimal grossPay)
        {
            return flat;
        }
        #endregion
    }
}
