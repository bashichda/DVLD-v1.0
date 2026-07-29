using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicense
    {
        public static bool isLicenseExistByPersonID(int PersonID,int LicenseClassID)
        {
            return (GetActiveLicenseByPersonID(PersonID, LicenseClassID) != -1);
        }

        public static int GetActiveLicenseByPersonID(int PersonID,int LicenseClassID)
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }
    }
}
