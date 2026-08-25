using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicense : clsApplications
    {
        public enum enMode { AddNew = 0, Update = 1};
        public enMode Mode = enMode.AddNew;

        public clsDriver DriverInfo { get; set; }

        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }


        public clsInternationalLicense()
        {
            this.ApplicationTypeID = (int)clsApplications.enApplicationType.NewInternationalDrivingLicense;

            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;

            Mode = enMode.AddNew;
        }

        public clsInternationalLicense(int ApplicationID,int ApplicantPersonID,DateTime ApplicationDate,enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate,decimal PaidFees,int CreatedByUser,int InternationalLicenseID,int DriverID,int IssuedUsingLocalLicenseID,
            DateTime IssueDate,DateTime ExpirationDate,bool IsActive)
        {
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplications.enApplicationType.NewInternationalDrivingLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUser;

            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;

            DriverInfo = clsDriver.FindByDriverID(this.DriverID);

            Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicensesData.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicensesData.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID,
                this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }

        public bool Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsApplications.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateInternationalLicense();
            }

            return false;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = true;

            bool IsFound = clsInternationalLicensesData.GetInternationalInfoByID(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID);

            if (IsFound)
            {
                // now we find the base Applcition
                clsApplications Application = clsApplications.FindBaseApplication(ApplicationID);

                return new clsInternationalLicense(Application.ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate,
                    Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, InternationalLicenseID,
                    DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesData.GetAllInternationalLicenses();
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicensesData.GetDriverInternationalLicenses(DriverID);
        }

        public static int GetActiveInternationalLicneseIDByDriverID(int DriverID)
        {
            return clsInternationalLicensesData.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }

        
    }
}
