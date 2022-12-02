using System;

namespace PayrollManagement.Classes
{
    public class FlatDeduction : Deduction
    {
        #region Getters/Setters
        public decimal Flat { get; set; }
        #endregion
        #region Constructor
        public FlatDeduction(string name, decimal flat) : base(name)
        {
            this.Flat = flat;
        }
        #endregion
        #region Methods
        public override decimal CalculateDeductionAmount(decimal grossPay)
        {
            if (Flat > 0)
            {
                return Flat;
            }

            throw new ArgumentException(this.Name + "'s value must be greater than 0!");
        }
        #endregion
    }
}
