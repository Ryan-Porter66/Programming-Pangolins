﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollManagement.Classes;
using System;
using System.Collections.Generic;

namespace UnitTestsForPayrollManagement
{
    [TestClass]
    public class EmployeeListTest
    {
        [TestMethod]
        public void EmployeeTest()
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
            HourlyEmployee emp1 = new HourlyEmployee("Jane", "Doe", "108 N 7th St", "Springfield", "10101", "MI", bank1, 0001, .25m, "all", "101-12-1234", dob1, hire1, "407-98-2134", "IT", tempDeduct1, 0.06m, 19.99m);


            List<Employee> tempEmployees = new List<Employee>
            {
                emp,
                emp1
            };
            tempEmList.Employees = tempEmployees;

            tempEmList.DisplaySelectableEmployeeList();


        }
    }
}