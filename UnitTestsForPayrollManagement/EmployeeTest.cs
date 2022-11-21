using iText.Layout.Element;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.BouncyCastle.Crypto.Tls;
using PayrollManagement.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PayrollManagementUnitTests
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void EmployeeTest1()
        {

            DateTime dob = new DateTime(1990, 1, 2);
            DateTime hire = new DateTime(2019, 3, 14);
            BankAccount bank = new BankAccount("213985701", "7132894023", "Bank of America");
            List<Deduction> tempDeduct = new List<Deduction>
            {
                new FlatDeduction("flat", 20.00m),
                new PercentageDeduction("Percentage", 0.03m)
            };
            HourlyEmployee emp = new HourlyEmployee("John", "Doe", "101 N 57th St", "Springfield", "10101", "MI", bank, 0001, .25m, "all", "101-12-1234", dob, hire, "407-98-2134", "IT", tempDeduct, 0.06m, 19.99m);
            //emp.PayPerHour = 24.00m;
            emp.GetPayrollHours();
            Debug.WriteLine(emp.CalculateGrossPay());
        }
    }
}
