using System; using DVLD_Common;
using System.Configuration;

namespace DVLD_DataAccessLayer
{
    internal class clsDataAccessSettings
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DVLD_DBConnection"].ConnectionString;
    }
}
