namespace PayrollManagement.Classes
{
    public abstract class Deduction
    {
        #region Getters/Setters
        public string Name { get; set; }
        #endregion
        #region Constructor
        public Deduction(string name)
        {
            this.Name = name;
        }
        #endregion
        #region Methods
        public abstract decimal CalculateDeductionAmount(decimal grossPay);
        #endregion
    }
}
