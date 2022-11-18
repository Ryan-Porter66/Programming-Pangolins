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
            DateTime tempEmpDob = new DateTime(1995, 4, 11);
            DateTime tempEmpHire = new DateTime(2011, 8, 25);
            BankAccount tempEmpBank = new BankAccount("789456123", "123456789", "American Bank and Loans");
            List<Deduction> tempDeduct = new List<Deduction>
            {
                new FlatDeduction("flat1", 10.00m),
                new FlatDeduction("flat2", 5.00m)
            };
            SalaryEmployee tempEm = new SalaryEmployee("Ryan", "Porter", "515 Jones Street", "Aberdeen", "57401", "SD", tempEmpBank, 75, 0.01m, " ", "888888888", tempEmpDob, tempEmpHire,
                "6053803739", "Accounting", tempDeduct, .05m, 549.86m);




            //create employee 2
            tempEmpDob = new DateTime(1991, 8, 21);
            tempEmpHire = new DateTime(2020, 8, 25);
            tempEmpBank = new BankAccount("75273275", "883275374", "Great Plains bank");
            tempDeduct = new List<Deduction>
            {
                new FlatDeduction("flat1", 10.00m),
                new FlatDeduction("flat2", 5.00m)
            };
            HourlyEmployee tempEm2 = new HourlyEmployee("First", "Last", "Address", "City", "ZIP", "HW", tempEmpBank, 99, 0.02m, "ALL", "123456789", tempEmpDob, tempEmpHire,
                "6053803739", "Payroll", tempDeduct, .065m, 13.75m);



            //add employees to list
            List<Employee> tempEmployees = new List<Employee>
            {
                tempEm,
                tempEm2
            };
            tempEmList.Employees = tempEmployees;

            //create company
            BankAccount tempComBank = new BankAccount("65454354651", "941753985", "Great Western");
            tempEmList.Company = new Company("Automaxx", tempComBank, "151515151", "515 Jones Ave", "Ipswitch", "SD", "57252", "6007256299");

            Reports.compilePayrollData(tempEmList);
        }
    }
}
