using DVLD_BusinessLayer;
using DVLD_Common;
using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Global_Classes
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;

        private static string _Key = "1234567890123456";

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            

            try
            {
                Registry.SetValue(keyPath, "Username", Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", Encrypt(Password,_Key), RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";



            try
            {

                Username = Registry.GetValue(keyPath, "UserName", null) as string;
                Password = Decrypt(Registry.GetValue(keyPath, "Password", null) as string, _Key);


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

            public static string Encrypt(string plainText, string key)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    // Set the key and IV for AES encryption
                    aesAlg.Key = Encoding.UTF8.GetBytes(key);
                    aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                    // Create an encryptor
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                    // Encrypt the data
                    using (var msEncrypt = new System.IO.MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }


                        // Return the encrypted data as a Base64-encoded string
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }

            public static string Decrypt(string cipherText, string key)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    // Set the key and IV for AES decryption
                    aesAlg.Key = Encoding.UTF8.GetBytes(key);
                    aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                    // Create a decryptor
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                    // Decrypt the data
                    using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                    {
                        // Read the decrypted data from the StreamReader
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
    }
}
