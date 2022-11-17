using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollManagement.Classes;
using System;
using System.Diagnostics;
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
                string username = "1";
                string password = "thisaintit";

                string privilege = Database.login(username, password);

                Assert.AreEqual("Denied", privilege);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
        }
    }
}
