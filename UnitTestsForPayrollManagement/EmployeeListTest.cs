using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollManagement.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UnitTestsForPayrollManagement
{
    [TestClass]
    public class EmployeeListTest
    {
        [TestMethod]
        public void SelectEmployeeTest()
        {
            EmployeeList tempEmList = new EmployeeList();


            DateTime dob = new DateTime(1990, 1, 2);
            DateTime hire = new DateTime(2019, 3, 14);
            BankAccount bank = new BankAccount("213985701", "7132894023", "Bank of America");
            List<Deduction> tempDeduct = new List<Deduction>
            {
                new FlatDeduction("flat", 20.00m),
                new PercentageDeduction("Percentage", 0.03m)
            };
            HourlyEmployee emp = new HourlyEmployee("Ted", "Johnson", "101 N 57th St", "Springfield", "10101", "MI", bank, 0001, .25m, "all", "101-12-1234", dob, hire, "407-98-2134", "IT", tempDeduct, 0.06m, 19.99m);

            DateTime dob1 = new DateTime(1992, 4, 2);
            DateTime hire1 = new DateTime(2012, 8, 14);
            BankAccount bank1 = new BankAccount("213987281", "7132892046", "Bank of America");
            List<Deduction> tempDeduct1 = new List<Deduction>
            {
                new FlatDeduction("flat", 20.00m),
                new PercentageDeduction("Percentage", 0.03m)
            };
            HourlyEmployee emp1 = new HourlyEmployee("Jane", "Doe", "108 N 7th St", "Springfield", "10101", "MI", bank1, 0002, .25m, "all", "101-12-1234", dob1, hire1, "407-98-2134", "IT", tempDeduct1, 0.06m, 19.99m);


            List<Employee> tempEmployees = new List<Employee>
            {
                emp,
                emp1
            };
            tempEmList.Employees = tempEmployees;

            tempEmList.DisplaySelectableEmployeeList(false);
            MessageBox.Show(tempEmList.GetSizeOfList().ToString());
        }

        [TestMethod]
        public void GenerateEmployeeListTest()
        {
            try
            {
                string username = "1";
                string password = Encryption.SHA256Encryption("1234");

                EmployeeList tempEmpList = new EmployeeList();
                tempEmpList.GenerateEmployeeList(username, password);

                foreach (Employee emp in tempEmpList.Employees)
                {
                    Console.WriteLine(emp.EmployeeID.ToString() + " " + emp.FirstName + " " + emp.LastName);
                    Console.WriteLine(emp.Address + " " + emp.City + " " + emp.State + " " + emp.PostalCode);
                    Console.WriteLine(emp.Bank.BankName + " " + emp.Bank.BankRoutingNumber + " " + emp.Bank.BankAccountNumber);
                    Console.WriteLine(emp.FederalTaxRate.ToString() + " " + emp.StateTaxRate.ToString());
                    Console.WriteLine(emp.Ssn + " " + emp.Permissions + " " + emp.Dob.ToString("yyyyMMdd") + " " + emp.HireDate.ToString("yyyyMMdd"));
                    Console.WriteLine(emp.PhoneNumber + " " + emp.Department);
                    foreach(Deduction ded in emp.DeductionList)
                    {
                        if(ded is PercentageDeduction pd)
                        {
                            Console.WriteLine(pd.Name + " " + pd.Percentage.ToString());
                        }
                        else if(ded is FlatDeduction fd)
                        {
                            Console.WriteLine(fd.Name + " " + fd.Flat.ToString());
                        }
                    }
                    if(emp is SalaryEmployee se)
                    {
                        Console.WriteLine("Salary: " + se.SalaryPerPayPeriod.ToString());
                    }
                    else if(emp is HourlyEmployee he)
                    {
                        Console.WriteLine("Hourly: " + he.PayPerHour.ToString());
                    }
                    Console.WriteLine();
                }
                // Just checking the function produces a list of Employee objects with employee ids
                tempEmpList.DisplaySelectableEmployeeList(false);

                Console.WriteLine(tempEmpList.Company.Name + " " + tempEmpList.Company.FederalID + " " + tempEmpList.Company.PhoneNumber);
                Console.WriteLine(tempEmpList.Company.Address + " " + tempEmpList.Company.City + ", " + tempEmpList.Company.State + " " + tempEmpList.Company.PostalCode);
                Console.WriteLine(tempEmpList.Company.Bank.BankName + " " + tempEmpList.Company.Bank.BankRoutingNumber + " " + tempEmpList.Company.Bank.BankAccountNumber);

                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
