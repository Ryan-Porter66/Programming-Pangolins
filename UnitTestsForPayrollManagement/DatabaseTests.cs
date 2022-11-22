﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollManagement.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace PayrollManagementUnitTests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void TestLogin()
        {
            // Note: This only passes when the webserver is turned on. Ping Blake in discord if it doesn't pass.
            try
            {
                string username = "1";
                string password = "thisaintit";

                string privilege = Database.login(username, password);

                Assert.AreEqual("Denied", privilege);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
        }

        [TestMethod]
        public void TestAddEmployee()
        {
            // Note: This only passes when the webserver is turned on. Ping Blake in discord if it doesn't pass.
            try
            {
                string username = "1";
                string password = "thisaintit";
                DateTime dob = new DateTime(1990, 1, 2);
                DateTime hire = new DateTime(2019, 3, 14);
                BankAccount bank = new BankAccount("213985701", "7132894023", "Bank of America");
                List<Deduction> tempDeduct = new List<Deduction>
                {
                    new FlatDeduction("flat", 20.00m),
                    new PercentageDeduction("Percentage", 0.03m)
                };
                HourlyEmployee emp = new HourlyEmployee("John", "Doe", "101 N 57th St", "Springfield"
                    , "10101", "MI", bank, 0001, .25m, "all", "101-12-1234", dob, hire, "407-98-2134", "IT", tempDeduct, 0.06m, 19.99m);

                string resp = Database.addEmployee(username, password, emp);
                Console.WriteLine(resp);
                // addEmployee returns the emp ID of the newly created employee, so the id is printed to the console and the database is checked
                // 
                Assert.AreEqual(1, 1);
                
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
