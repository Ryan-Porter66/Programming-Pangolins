﻿using System;

namespace PayrollManagement.Classes
{
    public class PercentageDeduction : Deduction
    {
        #region Getters/Setters
        public decimal Percentage { get; set; }
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

            throw new ArgumentException(this.Name + "'s value must be between 0 and 1!");
        }
        #endregion
    }
}
