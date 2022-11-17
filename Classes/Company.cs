using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Classes
{
    public class Company
    {
        #region Varialbes
        BankAccount bank;
        string federalID;
        string address;
        string city;
        string state;
        string postalCode;
        string phoneNumber;
        string _name;
        #endregion
        #region Getters/Setters
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
        public BankAccount Bank { get => bank; set => bank = value; }
        public string FederalID { get => federalID; set => federalID = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Name { get => _name; set => _name = value; }
        #endregion
    }
}
