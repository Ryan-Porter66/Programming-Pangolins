using System;
using System.Security.Cryptography;
using System.Text;

namespace PayrollManagement.Classes
{
    public class Encryption
    {
        //this function will take in a string and return the SHA256 hash of it
        //https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha256?view=net-6.0
        //https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
        //https://stackoverflow.com/questions/12416249/hashing-a-string-with-sha256
        public static string SHA256Encryption(string stringtoEncrypt)
        {
            using (SHA256 mySHA256Return = SHA256.Create())
            {
                //this gets the byte array using UTF8 encoding
                byte[] byteArray = mySHA256Return.ComputeHash(Encoding.UTF8.GetBytes(stringtoEncrypt));
                StringBuilder hash = new StringBuilder();
                foreach(byte theByte in byteArray)
                {
                    hash.Append(theByte.ToString("x2"));
                }
                return hash.ToString();
            }
        }
    }
}
