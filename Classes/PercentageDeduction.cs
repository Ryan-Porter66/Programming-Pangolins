using System;

namespace PayrollManagement.Classes
{
    public class PercentageDeduction : Deduction
    {
        #region Variables
        private decimal _percentage;
        #endregion
        #region Getters/Setters
        public decimal Percentage
        {
            get { return _percentage; }
            private set { _percentage = value; }
        }
        #endregion
        #region Constructor
        public PercentageDeduction(string name, decimal percentage) : base(name)
        {
            this.Percentage = percentage;
        }
        #endregion
        #region Methods
        public override decimal CalculateDeductionAmount(decimal grossPay)
        {
            if (Percentage > 0 && Percentage < 1)
            {
                return Percentage * grossPay;
            }
            else
            {
                throw new ArgumentException(this.Name + "'s value must be between 0 and 1!");
            }
        }
        #endregion
    }
}
