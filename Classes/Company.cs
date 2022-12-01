using System;

namespace PayrollManagement.Classes
{
    public class Company
    {
        #region Getters/Setters
        public BankAccount Bank { get; set; }
        public string FederalID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
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
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        #endregion
    }
}
