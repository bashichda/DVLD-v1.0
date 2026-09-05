using DVLD_BusinessLayer;
using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DVLD_Project_Version_1._0.Global_Classes
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            try
            {
                Registry.SetValue(keyPath, "Username", Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", Password, RegistryValueKind.String);

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
                Password = Registry.GetValue(keyPath, "Password", null) as string;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }
    }
}