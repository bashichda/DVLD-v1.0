using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseClassData
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dtAllLicenseClasses = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Select * From LicenseClasses;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtAllLicenseClasses.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dtAllLicenseClasses;
        }

        public static bool GetLicenseInfoByLicenseID(int LicenseClassID,ref string ClassName,ref string ClassDescription,ref short MinimumAllowedAge,
            ref short MaximumAllowedAge,ref decimal ClassFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Select * From LicenseClasses Where LicenseClassID = @LicenseClassID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    MaximumAllowedAge = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetLicenseInfoByClassName(string ClassName,ref int LicenseClassID, ref string ClassDescription, ref short MinimumAllowedAge,
            ref short MaximumAllowedAge, ref decimal ClassFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Select * From LicenseClasses Where ClassName = @ClassName;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    MaximumAllowedAge = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
