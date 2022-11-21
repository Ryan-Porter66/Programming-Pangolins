using System;

namespace PayrollManagement.Classes
{
    public class Company
    {
        #region Variables
        BankAccount _bank;
        private string _federalID;
        private string _address;
        private string _city;
        private string _state;
        private string _postalCode;
        private string _phoneNumber;
        private string _name;
        #endregion
        #region Getters/Setters
        public BankAccount Bank { get => _bank; set => _bank = value; }
        public string FederalID { get => _federalID; set => _federalID = value; }
        public string Address { get => _address; set => _address = value; }
        public string City { get => _city; set => _city = value; }
        public string State { get => _state; set => _state = value; }
        public string PostalCode { get => _postalCode; set => _postalCode = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Name { get => _name; set => _name = value; }
        #endregion
        #region Constructors
        public Company(string name, BankAccount bank, string federalID, string address, string city, string state, string postalCode, string phoneNumber)
        {
            Bank = bank ?? throw new ArgumentNullException(nameof(bank));
            FederalID = federalID;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            City = city ?? throw new ArgumentNullException(nameof(city));
            State = state ?? throw new ArgumentNullException(nameof(state));
            PostalCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
            PhoneNumber = phoneNumber;
            Name = name ?? throw new ArgumentNullException(nameof(postalCode));
        }
        #endregion
        #region Methods
        #endregion
    }
}
