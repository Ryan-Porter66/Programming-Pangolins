using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PayrollManagement.Classes;

namespace PayrollManagementUnitTests
{
    [TestClass]
    public class InputValidationTests
    {
        [TestMethod]
        public void TestIsNormalStringValid()
        {
            Assert.IsTrue(InputValidation.IsNormalStringValid("Ryan", 99));
            Assert.IsFalse(InputValidation.IsNormalStringValid("   ", 99));
            Assert.IsFalse(InputValidation.IsNormalStringValid("d   ", 3));
        }

        [TestMethod]
        public void TestIsStateValid()
        {
            Assert.IsTrue(InputValidation.IsStateValid("SD"));
            Assert.IsTrue(InputValidation.IsStateValid("Sd"));
            Assert.IsFalse(InputValidation.IsStateValid("  "));
            Assert.IsFalse(InputValidation.IsStateValid("Sdd"));
        }

        [TestMethod]
        public void TestIsRateValid()
        {
            Assert.IsTrue(InputValidation.IsRateValid("0"));
            Assert.IsTrue(InputValidation.IsRateValid("0.11"));
            Assert.IsTrue(InputValidation.IsRateValid(".1645"));
            Assert.IsFalse(InputValidation.IsRateValid("1"));
            Assert.IsFalse(InputValidation.IsRateValid(".67866"));
        }

        [TestMethod]
        public void TestIsNumberStringValid()
        {
            Assert.IsTrue(InputValidation.IsNumberStringValid("123456789", 9, 9));   //SSN
            Assert.IsTrue(InputValidation.IsNumberStringValid("4561237895", 9, 17));   //bank account number
            Assert.IsFalse(InputValidation.IsNumberStringValid("3534df4534534", 1, 100));
            Assert.IsFalse(InputValidation.IsNumberStringValid("3534df4534534", 1, 5));
            Assert.IsFalse(InputValidation.IsNumberStringValid(" ", -1, 1));
        }

        [TestMethod]
        public void TestIsDateStringValid()
        {
            Assert.IsTrue(InputValidation.IsDateStringValid("04221999")); 
            Assert.IsTrue(InputValidation.IsDateStringValid("12202005"));   
            Assert.IsFalse(InputValidation.IsDateStringValid("1221999"));
            Assert.IsFalse(InputValidation.IsDateStringValid("01321999"));
            Assert.IsFalse(InputValidation.IsDateStringValid("04221899"));
            Assert.IsFalse(InputValidation.IsDateStringValid("04222100"));
            Assert.IsFalse(InputValidation.IsDateStringValid(" "));
        }

        [TestMethod]
        public void TestIsHourStringValid()
        {
            Assert.IsTrue(InputValidation.IsHourStringValid("40.00"));
            Assert.IsTrue(InputValidation.IsHourStringValid("40"));
            Assert.IsTrue(InputValidation.IsHourStringValid("40.2"));
            Assert.IsTrue(InputValidation.IsHourStringValid(".20"));
            Assert.IsFalse(InputValidation.IsHourStringValid("999"));
            Assert.IsFalse(InputValidation.IsHourStringValid("99.999"));
            Assert.IsFalse(InputValidation.IsHourStringValid("0"));
            Assert.IsFalse(InputValidation.IsHourStringValid("00.00"));
            Assert.IsFalse(InputValidation.IsHourStringValid("999.00"));
        }

        [TestMethod]
        public void TestIsPayStringValid()
        {
            Assert.IsTrue(InputValidation.IsPayStringValid("1399.99"));
            Assert.IsTrue(InputValidation.IsPayStringValid("17"));
            Assert.IsTrue(InputValidation.IsPayStringValid("19.99"));
            Assert.IsTrue(InputValidation.IsPayStringValid("999"));
            Assert.IsFalse(InputValidation.IsPayStringValid(".99"));
            Assert.IsFalse(InputValidation.IsPayStringValid("99.999"));
            Assert.IsFalse(InputValidation.IsPayStringValid("0"));
            Assert.IsFalse(InputValidation.IsPayStringValid("00.00"));
        }
    }
}
