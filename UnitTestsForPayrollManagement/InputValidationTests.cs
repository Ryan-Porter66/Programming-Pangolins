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
            Assert.IsTrue(InputValidation.isRateValid(0m));
            Assert.IsTrue(InputValidation.isRateValid(.11m));
            Assert.IsTrue(InputValidation.isRateValid(.1645m));
            Assert.IsFalse(InputValidation.isRateValid(1m));
            Assert.IsFalse(InputValidation.isRateValid(.67866m));
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
    }
}
