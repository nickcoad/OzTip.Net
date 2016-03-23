using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Common
{
    public class Utilities
    {
        private static readonly RNGCryptoServiceProvider CryptoServiceProvider = new RNGCryptoServiceProvider();
        private static readonly SHA256Managed SHA256 = new SHA256Managed();

        public static byte[] GenerateSalt()
        {
            var newSalt = new byte[8];
            CryptoServiceProvider.GetBytes(newSalt);

            return newSalt;
        }

        public static byte[] GeneratePasswordHash(string password, byte[] salt)
        {
            salt = salt ?? GenerateSalt();

            var saltedPassword = salt.Concat(Encoding.UTF8.GetBytes(password)).ToArray();
            var saltedHash = SHA256.ComputeHash(saltedPassword);

            return saltedHash;
        }

        public static bool ComparePassword(string password, byte[] hash, byte[] salt)
        {
            var hashedPassword = GeneratePasswordHash(password, salt);

            return hashedPassword.SequenceEqual(hash);
        }
    }
}
