using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OzTip.Common.Tests
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void TestGeneratePasswordHash()
        {
            var sha256 = new SHA256Managed();
            const string password = "TeStPaSsWoRd";
            var generatedSalt = Utilities.GenerateSalt();
            var hashedPassword = Utilities.GeneratePasswordHash(password, generatedSalt);

            // Manually go through the same process and make sure we get the same result.
            var saltedPassword = generatedSalt.Concat(Encoding.UTF8.GetBytes(password)).ToArray();
            var saltedHash = sha256.ComputeHash(saltedPassword);

            CollectionAssert.AreEqual(hashedPassword, saltedHash);
        }

        [TestMethod]
        public void TestComparePassword()
        {
            var sha256 = new SHA256Managed();
            const string password = "TeStPaSsWoRd";
            const string incorrectPassword = "InCoRrEcT";
            var generatedSalt = Utilities.GenerateSalt();
            var hashedPassword = Utilities.GeneratePasswordHash(password, generatedSalt);

            var correctPasswordResult = Utilities.ComparePassword(password, hashedPassword, generatedSalt);
            var incorrectPasswordResult = Utilities.ComparePassword(incorrectPassword, hashedPassword, generatedSalt);

            Assert.IsTrue(correctPasswordResult);
            Assert.IsFalse(incorrectPasswordResult);
        }
    }
}
