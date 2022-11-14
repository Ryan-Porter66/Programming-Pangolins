using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PayrollManagement.Classes;
using Payroll.ClassDiagram;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UnitTestsForPayrollManagement
{
    [TestClass]
    public class ReportsTest
    {
        [TestMethod]
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
                "6053803739", "Accounting", tempDeduct, 9546.78m, .05m);


            //create company
            BankAccount tempComBank = new BankAccount("654651", "941985", "Great Western");
            tempEmList.Company = new Company("Automaxx", tempComBank, "151515151", "515 Jones Ave", "Ipswitch", "SD", "57252", "6007256299");

            //add employees to list
            List<Employee> tempEmployees = new List<Employee>
            {
                tempEm
            };
            tempEmList.Employees = tempEmployees;

            Reports.createPayStubsPDF(tempEmList);
        }

        [TestMethod]
        public void TestCreateNachaFile()
        {
            Reports.createNachaFile();
        }
    }
}
