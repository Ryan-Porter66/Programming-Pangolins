using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PayrollManagement.Classes;

namespace UnitTestsForPayrollManagement
{
    [TestClass]
    public class ReportsTest
    {
        [TestMethod]
        public void TestCreatePayStubsPDF()
        {
            Reports.createPayStubsPDF();
        }
    }
}
