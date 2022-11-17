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
            Assert.IsTrue(InputValidation.isNormalStringValid("Ryan", 99));
            Assert.IsFalse(InputValidation.isNormalStringValid("   ", 99));
            Assert.IsFalse(InputValidation.isNormalStringValid("d   ", 3));
        }

        [TestMethod]
        public void TestIsStateValid()
        {
            Assert.IsTrue(InputValidation.isStateValid("SD"));
            Assert.IsTrue(InputValidation.isStateValid("Sd"));
            Assert.IsFalse(InputValidation.isStateValid("  "));
            Assert.IsFalse(InputValidation.isStateValid("Sdd"));
        }

        [TestMethod]
        public void TestIsRateValid()
        {
            Assert.IsTrue(InputValidation.isRateValid("0"));
            Assert.IsTrue(InputValidation.isRateValid("0.11"));
            Assert.IsTrue(InputValidation.isRateValid(".1645"));
            Assert.IsFalse(InputValidation.isRateValid("1"));
            Assert.IsFalse(InputValidation.isRateValid(".67866"));
        }

        [TestMethod]
        public void TestIsNumberStringValid()
        {
            Assert.IsTrue(InputValidation.isNumberStringValid("123456789", 9, 9));   //SSN
            Assert.IsTrue(InputValidation.isNumberStringValid("4561237895", 9, 17));   //bank account number
            Assert.IsFalse(InputValidation.isNumberStringValid("3534df4534534", 1, 100));
            Assert.IsFalse(InputValidation.isNumberStringValid("3534df4534534", 1, 5));
            Assert.IsFalse(InputValidation.isNumberStringValid(" ", -1, 1));
        }

        [TestMethod]
        public void TestIsDateStringValid()
        {
            Assert.IsTrue(InputValidation.isDateStringValid("04221999")); 
            Assert.IsTrue(InputValidation.isDateStringValid("12202005"));   
            Assert.IsFalse(InputValidation.isDateStringValid("1221999"));
            Assert.IsFalse(InputValidation.isDateStringValid("01321999"));
            Assert.IsFalse(InputValidation.isDateStringValid("04221899"));
            Assert.IsFalse(InputValidation.isDateStringValid("04222100"));
            Assert.IsFalse(InputValidation.isDateStringValid(" "));
        }

        [TestMethod]
        public void TestIsHourStringValid()
        {
            Assert.IsTrue(InputValidation.isHourStringValid("40.00"));
            Assert.IsTrue(InputValidation.isHourStringValid("40"));
            Assert.IsTrue(InputValidation.isHourStringValid("40.00"));
            Assert.IsTrue(InputValidation.isHourStringValid(".20"));
            Assert.IsFalse(InputValidation.isHourStringValid("999"));
            Assert.IsFalse(InputValidation.isHourStringValid("99.999"));
            Assert.IsFalse(InputValidation.isHourStringValid("0"));
            Assert.IsFalse(InputValidation.isHourStringValid("00.00"));
            Assert.IsFalse(InputValidation.isHourStringValid("999.00"));
        }

        [TestMethod]
        public void TestIsPayStringValid()
        {
            Assert.IsTrue(InputValidation.isPayStringValid("1399.99"));
            Assert.IsTrue(InputValidation.isPayStringValid("17"));
            Assert.IsTrue(InputValidation.isPayStringValid("19.99"));
            Assert.IsTrue(InputValidation.isPayStringValid("999"));
            Assert.IsFalse(InputValidation.isPayStringValid(".99"));
            Assert.IsFalse(InputValidation.isPayStringValid("99.999"));
            Assert.IsFalse(InputValidation.isPayStringValid("0"));
            Assert.IsFalse(InputValidation.isPayStringValid("00.00"));
        }
    }
}
