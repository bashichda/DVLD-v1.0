using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using DVLD_DataAccessLayer;


namespace DVLD_BusinessLayer
{
    public class clsApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFees { get; set; }

        public clsApplicationTypes()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationTypeFees = 0;
        }

        private clsApplicationTypes(int ApplicationTypeID,string ApplicationTypeTitle,decimal ApplicationTypeFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationTypes(this.ApplicationTypeID,this.ApplicationTypeTitle,this.ApplicationTypeFees);
        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }

        public static clsApplicationTypes Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationTypeFees = 0;

            bool isFound = clsApplicationTypesData.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationTypeFees);

            if (isFound)
            {
                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);
            }
            else
            {
                return null;
            }
        }
    }
}
