using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PayrollManagement.Classes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PayrollManagementUnitTests
{
    [TestClass]
    public class ReportsTest
    {
        //old test methods
        /*       [TestMethod]
               public void TestCreatePayStubsPDF()
               {
                   EmployeeList tempEmList = new EmployeeList();

                   //create employee 1
                   DateTime tempEmpDob = new DateTime(1995, 4, 11);
                   DateTime tempEmpHire = new DateTime(2011, 8, 25);
                   BankAccount tempEmpBank = new BankAccount("789456123", "123456789", "American Bank and Loans");
                   List<Deduction> tempDeduct = new List<Deduction>
                   {
                       new FlatDeduction(),
                       new FlatDeduction()
                   };
                   SalaryEmployee tempEm = new SalaryEmployee("Ryan", "Porter", "515 Jones Street", "Aberdeen", "57401", "SD", tempEmpBank, 75, 0.01m, " ", "888888888", tempEmpDob, tempEmpHire, 
                       "6053803739", "Accounting", tempDeduct, .05m, 549.86m);




                   //create employee 2
                   tempEmpDob = new DateTime(1991, 8, 21);
                   tempEmpHire = new DateTime(2020, 8, 25);
                   tempEmpBank = new BankAccount("75273275", "883275374", "Great Plains bank");
                   tempDeduct = new List<Deduction>
                   {
                       new FlatDeduction(),
                       new FlatDeduction()
                   };
                   HourlyEmployee tempEm2 = new HourlyEmployee("First", "Last", "Address", "City", "ZIP", "HW", tempEmpBank, 99, 0.02m, "ALL", "123456789", tempEmpDob, tempEmpHire,
                       "6053803739", "Payroll", tempDeduct, .065m, 13.75m);
                   tempEm2.getPayrollHours();



                   //add employees to list
                   List<Employee> tempEmployees = new List<Employee>
                   {
                       tempEm,
                       tempEm2
                   };
                   tempEmList.Employees = tempEmployees;

                   //create company
                   BankAccount tempComBank = new BankAccount("654651", "941985", "Great Western");
                   tempEmList.Company = new Company("Automaxx", tempComBank, "151515151", "515 Jones Ave", "Ipswitch", "SD", "57252", "6007256299");

                   Reports.createPayStubsPDF(tempEmList);
               }

               [TestMethod]
               public void TestCreateNachaFile()
               {
                   //Reports.createNachaFile();
               }*/
        [TestMethod]
        public void CompilePayrollInformationAndPrint()
        {
            EmployeeList tempEmList = new EmployeeList();

            //create employee 1
            DateTime tempEmpDob = new DateTime(1965, 5, 11);
            DateTime tempEmpHire = new DateTime(2000, 9, 8);
            BankAccount tempEmpBank = new BankAccount("856947569", "8756321966", "Bank of America");
            List<Deduction> tempDeduct = new List<Deduction>
            {
                new PercentageDeduction("401K", .1m),
                new FlatDeduction("Early Pay", 150m)
            };
            HourlyEmployee tempEm = new HourlyEmployee("Ryan", "Porter", "515 Jones Street", "Aberdeen", "57401", "SD", tempEmpBank, 55, 0.012m, "Payroll", "894562011", tempEmpDob, tempEmpHire,
                "6052905555", "Payroll", tempDeduct, .0m, 20.5m);

            //create employee 2
            tempEmpDob = new DateTime(2000, 7, 25);
            tempEmpHire = new DateTime(2020, 9, 25);
            tempEmpBank = new BankAccount("586923185", "78641231", "Great Plains Bank");
            tempDeduct = new List<Deduction>
            {
                
            };
            HourlyEmployee tempEm2 = new HourlyEmployee("Becky", "Fueller", "654 Alphabet Drive", "Webster", "57274", "SD", tempEmpBank, 89, 0.0m, "None", "123456789", tempEmpDob, tempEmpHire,
                "6058593655", "Parts", tempDeduct, .0m, 12m);

            //create employee 3
            tempEmpDob = new DateTime(2000, 1, 20);
            tempEmpHire = new DateTime(2000, 9, 1);
            tempEmpBank = new BankAccount("091000019", "123456", "Wells Fargo");
            tempDeduct = new List<Deduction>
            {
                new PercentageDeduction("401K", .05m),
                new PercentageDeduction("Health Care", .05m),
                new PercentageDeduction("Dental", .01m)
            };
            SalaryEmployee tempEm3 = new SalaryEmployee("Albert", "Kline", "89 Central Street", "Saint Paul", "55101", "MN", tempEmpBank, 2, 0.06m, "Payroll", "456123789", tempEmpDob, tempEmpHire,
                "6058905674", "Payroll", tempDeduct, .06875m, 2500m);

            //create employee 4
            tempEmpDob = new DateTime(1985, 4, 25);
            tempEmpHire = new DateTime(2005, 7, 8);
            tempEmpBank = new BankAccount("85915084", "1111111111", "First Interstate Bank");
            tempDeduct = new List<Deduction>
            {
                new FlatDeduction("Parts", 100m)
            };
            HourlyEmployee tempEm4 = new HourlyEmployee("Paul", "Prop", "456 Grove NE", "Nebraska City", "68410", "NE", tempEmpBank, 56, 0.1m, "None", "759630148", tempEmpDob, tempEmpHire,
                "9875464444", "Delivery", tempDeduct, .055m, 20m);

            //add employees to list
            List<Employee> tempEmployees = new List<Employee>
            {
                tempEm,
                tempEm2,
                tempEm3,
                tempEm4
            };
            tempEmList.Employees = tempEmployees;

            //create company
            BankAccount tempComBank = new BankAccount("091000019", "5876446", "Wells Fargo");
            tempEmList.Company = new Company("The Auto Parts Store", tempComBank, "859885555", "123 Summer Lane", "Webster", "SD", "57274", "6057258888");

            Reports.CompilePayrollData(tempEmList);
        }
    }
}
