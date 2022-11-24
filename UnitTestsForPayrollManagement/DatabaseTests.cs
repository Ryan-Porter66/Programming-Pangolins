using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollManagement.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
                string username = "2";
                string password = "thisaintit";

                string privilege = Database.Login(username, password);

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
                string username = "2";
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
                    , "10101", "MI", bank, 0001, .25m, "Employee", "101-12-1234", dob, hire, "407-98-2134", "IT", tempDeduct, 0.06m, 19.99m);

                string resp = Database.AddEmployee(username, password, emp);
                Console.WriteLine(resp);
                //Console.WriteLine(emp.Dob.ToString() + " --- " + emp.HireDate.ToString());
                // addEmployee returns the emp ID of the newly created employee, so the id is printed to the console and the database is checked
                // 
                Assert.AreEqual(1, 1);
                
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void TestGetEmployeeList()
        {
            // Note: This only passes when the webserver is turned on. Ping Blake in discord if it doesn't pass.
            try
            {
                string username = "2";
                string password = "thisaintit";
                //string resp = Encryption.AESEncryption("http://ec2-52-14-14-234.us-east-2.compute.amazonaws.com:5000/getemplist");
                List<Employee> empList = Database.GetEmployeeList(username, password);
                //string somedate = "1990-01-02";
                //DateTime dt = DateTime.ParseExact(somedate, "yyy-mm-dd", CultureInfo.InvariantCulture);
                string resp = "";
                foreach (Employee emp in empList)
                    resp += emp.EmployeeID.ToString() + " - ";
                Console.WriteLine(resp);
                // Just checking the function produces a list of Employee objects with employee ids
                Assert.AreEqual(1, 1);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
