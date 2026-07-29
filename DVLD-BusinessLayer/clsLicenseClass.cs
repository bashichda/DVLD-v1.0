using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClass
    {
        public enum enMode { AddNew = 0,Update = 1 };
        public enMode Mode;

        public int LicenseID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public short MinimumAllowedAge { get; set; }
        public short MaximumAllowedAge { get; set; }
        public decimal ClassFees { get; set; }

        public clsLicenseClass()
        {
            this.LicenseID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.MaximumAllowedAge = 0;
            this.ClassFees = 0;
            Mode = enMode.AddNew;
        }

        private clsLicenseClass(int LicenseID,string ClassName,string ClassDescription,short MinimumAllowedAge,short MaximumAllowedAge,decimal ClassFees)
        {
            this.LicenseID = LicenseID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.MaximumAllowedAge = MaximumAllowedAge;
            this.ClassFees = ClassFees;
            Mode = enMode.Update;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }
    
        public static clsLicenseClass Find(int LicenseID)
        {
            string ClassName = "", ClassDescription = "";
            short MinimumAllowedAge = 0, MaximumAllowedAge = 0;
            decimal ClassFees = 0;

            bool isFound = clsLicenseClassData.GetLicenseInfoByLicenseID(LicenseID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge,
                ref MaximumAllowedAge, ref ClassFees);

            if (isFound)
            {
                return new clsLicenseClass(LicenseID, ClassName, ClassDescription, MinimumAllowedAge, MaximumAllowedAge, ClassFees);
            }
            else
            {
                return null;
            }
        }

        public static clsLicenseClass Find(string ClassName)
        {
            int LicenseID = -1;
            string ClassDescription = "";
            short MinimumAllowedAge = 0, MaximumAllowedAge = 0;
            decimal ClassFees = 0;

            bool isFound = clsLicenseClassData.GetLicenseInfoByClassName(ClassName, ref LicenseID, ref ClassDescription, ref MinimumAllowedAge,
                ref MaximumAllowedAge, ref ClassFees);

            if (isFound)
            {
                return new clsLicenseClass(LicenseID, ClassName, ClassDescription, MinimumAllowedAge, MaximumAllowedAge, ClassFees);
            }
            else
            {
                return null;
            }
        }
    
    }

    
}
