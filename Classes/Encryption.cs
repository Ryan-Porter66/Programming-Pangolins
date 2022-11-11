using System;
using System.IO;
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
        public static string SHA256Encryption(string stringToEncrypt)
        {
            if(stringToEncrypt == null || stringToEncrypt.Length < 1)
            {
                throw new ArgumentNullException("stringToEncrypt");
            }

            using (SHA256 mySHA256Return = SHA256.Create())
            {
                //this gets the byte array using UTF8 encoding
                byte[] byteArray = mySHA256Return.ComputeHash(Encoding.UTF8.GetBytes(stringToEncrypt));
                StringBuilder hash = new StringBuilder();
                foreach(byte theByte in byteArray)
                {
                    hash.Append(theByte.ToString("x2"));
                }
                return hash.ToString();
            }
        }


        //https://www.codeproject.com/Articles/1278566/Simple-AES-Encryption-using-Csharp
        //https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0
        //https://www.c-sharpcorner.com/article/aes-encryption-in-c-sharp/
        //https://stackoverflow.com/questions/9031537/really-simple-encryption-with-c-sharp-and-symmetricalgorithm
        //https://stackoverflow.com/questions/472906/how-do-i-get-a-consistent-byte-representation-of-strings-in-c-sharp-without-manu
        //https://stackoverflow.com/questions/951487/how-to-convert-a-byte-array-to-a-string
        //This is horrible practice to store keys in the code, but this will work (will change later if have more time)
        private static readonly byte[] initializeVector = { 66, 3, 1, 2, 66, 7, 10, 13, 77, 11, 76, 8, 5, 1, 2, 5  };
        private static readonly byte[] key = { 66, 3, 1, 2, 66, 7, 10, 13, 77, 11, 76, 8, 5, 1, 2, 5, 66, 3, 1, 2, 66, 7, 10, 13, 77, 11, 76, 8, 5, 1, 2, 5 };

        //this function will encrypt information that needs to be decrypted
        public static string AESEncryption(string stringToEncrypt)
        {
            if (stringToEncrypt == null || stringToEncrypt.Length < 1)
            {
                throw new ArgumentNullException("stringToEncrypt.");
            }

            byte[] encryptedArray;
            using (Aes myAES = Aes.Create())
            {
                myAES.Key = key;
                myAES.IV = initializeVector;
                ICryptoTransform encryptionAlgorithm = myAES.CreateEncryptor(myAES.Key, myAES.IV);

                using(MemoryStream memoryStream = new MemoryStream())
                {
                    using(CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptionAlgorithm, CryptoStreamMode.Write))
                    {
                        using(StreamWriter streamReader = new StreamWriter(cryptoStream))
                        {
                            streamReader.Write(stringToEncrypt);
                        }
                        encryptedArray = memoryStream.ToArray();
                    }
                }
            }
            //char[] chars = new char[encryptedArray.Length / sizeof(char)];
            //Buffer.BlockCopy(encryptedArray, 0, chars, 0, encryptedArray.Length);
            // return new string(chars);
            string returnString = Convert.ToBase64String(encryptedArray);

            return returnString;
        }

        //this function will decrypt any AES encryption strings that were generated before
        public static string AESDecryption(string stringToDecrypt)
        {
            if (stringToDecrypt == null || stringToDecrypt.Length < 1)
            {
                throw new ArgumentNullException("stringToDecrypt");
            }

            string decryptedString = null;

            //byte[] bytes = new byte[stringToDecrypt.Length * sizeof(char)];
            //Buffer.BlockCopy(stringToDecrypt.ToCharArray(), 0, bytes, 0, bytes.Length);
            byte[] bytes = Convert.FromBase64String(stringToDecrypt);

            using (Aes myAES = Aes.Create())
            {
                myAES.Key = key;
                myAES.IV = initializeVector;
                ICryptoTransform decryptionAlgorithm = myAES.CreateDecryptor(myAES.Key, myAES.IV);
                using(MemoryStream memoryStream = new MemoryStream(bytes))
                {
                    using(CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptionAlgorithm, CryptoStreamMode.Read))
                    {
                        using(StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            decryptedString = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return decryptedString;
        }
    }
}
