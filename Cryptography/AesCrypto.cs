using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    internal class AesCrypto()
    {
        public static void StartEncrypt(string input)
        {
            string original = input;
            using Aes myAes = Aes.Create();

            byte[] key = myAes.Key;

            byte[] encrypted = EncryptStringToBytes_Aes(original, key, myAes.IV);

            Console.WriteLine($"Encrypted string: {BitConverter.ToString(encrypted)}");
            Console.WriteLine($"key: {BitConverter.ToString(key)} IV: {Convert.ToBase64String(myAes.IV)}");
        }

        public static void StartDecrypt(string input, string key)
        {
            string original = input;

            using Aes myAes = Aes.Create();

            string decrypted = DecryptStringFromBytes_Aes(Encoding.UTF8.GetBytes(original), Encoding.UTF8.GetBytes(key), myAes.IV);
            Console.WriteLine(decrypted);
        }

        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException(nameof(Key));
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException(nameof(IV));

            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msEncrypt = new();

                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);

                using (StreamWriter swEncrypt = new(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }
                encrypted = msEncrypt.ToArray();
            }

            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(cipherText));
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException(nameof(Key));
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException(nameof(IV));

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msDecrypt = new(cipherText);

                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);

                using StreamReader srDecrypt = new(csDecrypt);
                
                    plaintext = srDecrypt.ReadToEnd();
            }

            return plaintext;
        }
    }
}
