namespace PayrollManagement.Classes
{
    public abstract class Deduction
    {
        #region Variables
        private string _name;
        #endregion
        #region Getters/Setters
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
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
