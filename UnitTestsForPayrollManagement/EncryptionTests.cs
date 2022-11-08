using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollManagement.Classes;
using System;

namespace PayrollManagementUnitTests
{
    [TestClass]
    public class EncryptionTests
    {
        [TestMethod]
        public void TestSHA256Encprytion()
        {
            //https://emn178.github.io/online-tools/sha256.html to get hashed values
            string hashedValue = Encryption.SHA256Encryption("1234");
            Assert.AreEqual(hashedValue, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4");

            hashedValue = Encryption.SHA256Encryption("password");
            Assert.AreEqual(hashedValue, "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8");

            hashedValue = Encryption.SHA256Encryption("TrustMe");
            Assert.AreEqual(hashedValue, "878d44b06d7a098308c77ba3d3fed5cfa2f057bdac34506883008076229400e0");
        }
    }
}
