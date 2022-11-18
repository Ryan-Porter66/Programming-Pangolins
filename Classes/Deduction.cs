using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public abstract class Deduction
    {
        #region Variables
        private string _name;
        #endregion
        #region Getters/Setters
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region Constructor
        public Deduction(string name)
        {
            this.name = name;
        }
        #endregion
        #region Methods
        public abstract decimal calculateDeductionAmount(decimal grossPay);
        #endregion
    }
}
