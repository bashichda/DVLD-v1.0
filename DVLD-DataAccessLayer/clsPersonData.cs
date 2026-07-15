using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.CodeDom;
using System.Security.Policy;

namespace DVLD_DataAccessLayer
{
    public class clsPersonData
    {

        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
    ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isfound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Select * From People where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = reader["SecondName"] != DBNull.Value ? (string)reader["SecondName"] : "";
                    ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Phone = (string)reader["Phone"];
                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";
                    Address = (string)reader["Address"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Erorr (Find) : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isfound;
        }

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isfound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Select * From People where NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = reader["SecondName"] != DBNull.Value ? (string)reader["SecondName"] : "";
                    ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Phone = (string)reader["Phone"];
                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";
                    Address = (string)reader["Address"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Erorr (Find) : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isfound;
        }


        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Insert Into People(NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,
                            NationalityCountryID,ImagePath)
                            Values(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,
                            @NationalityCountryID,@ImagePath);
                            Select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath == null)
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            if (Email == null)
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);
            if (SecondName == null)
                command.Parameters.AddWithValue("@SecondName", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName == null)
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    PersonID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine( "Error (Add New Person) : "+ ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

        public static bool UpdatePerson(int PersonID,string NationalNo,string FirstName,string SecondName,string ThirdName,string LastName,
            DateTime DateOfBirth,int Gendor,string Address,string Phone,string Email,int NationalityCountryID,string ImagePath)
        {
            int rowsEffectedt = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Update People
                            Set NationalNo = @NationalNo,
                                FirstName = @FirstName,
                                SecondName = @SecondName,
                                ThirdName = @ThirdName,
                                LastName = @LastName,
                                DateOfBirth = @DateOfBirth,
                                Gendor = @Gendor,
                                Address = @Address,
                                Phone = @Phone,
                                Email = @Email,
                                NationalityCountryID = @NationalityCountryID,
                                ImagePath = @ImagePath
                                Where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            if (SecondName == null)
                command.Parameters.AddWithValue("@SecondName", System.DBNull.Value);
            else 
                command.Parameters.AddWithValue("@SecondName", SecondName);

            if(ThirdName == null)
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            else 
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email == null)
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath == null)
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);


            try
            {
                connection.Open();

                rowsEffectedt = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsEffectedt > 0);
        }
    
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Select 
                            People.PersonID,
                            People.NationalNo,
                            People.FirstName,
                            People.SecondName,
                            People.ThirdName,
                            People.LastName,
                                Case 
                                When People.Gendor = 0 then 'Male'
                                Else 'Female'
                                End As Gendor,
                            People.DateOfBirth,
                            Countries.CountryName As Nationality,
                            People.Phone,
                            People.Email From People
                            Inner Join Countries on People.NationalityCountryID = Countries.CountryID
                            Order By People.FirstName;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool DeletePerson(int PersonID)
        {
            int rowsEffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Delete From People Where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                rowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsEffected > 0);
        }

        public static bool isPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Select Found = 1 From People
                            where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool isPersonExist(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Select Found = 1 From People
                            where NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }




    }
}
