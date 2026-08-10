using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0,Update = 1};
        public enMode Mode;

        public int TestAppointmentID { get; set; }
        public clsTestTypes.enTestType TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public clsApplications RetakeTestApplicationInfo { get; set; }
        public int TestID
        {
            get
            {
                return _GetTestID();
            }
        }

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestTypes.enTestType.Visiontest;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
            Mode = enMode.AddNew;
        }

        private clsTestAppointment(int TestAppointmentID,clsTestTypes.enTestType TestTypeID,int LocalDrivingLicenseApplicationID,DateTime AppointmentDate,
            decimal PaidFees,bool IsLocked,int CreatedByUserID,int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
            this.CreatedByUserID = CreatedByUserID;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestApplicationInfo = clsApplications.FindBaseApplication(RetakeTestApplicationID);
            Mode = enMode.Update;
        }

        public static clsTestAppointment FindTestAppointmentByTestAppointmentID(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsLocked = false;

            bool isFound = clsTestAppointmentData.GetTestAppointmentInfoByTestAppointmentID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID);

            if (isFound)
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestTypes.enTestType)TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                    PaidFees, IsLocked, CreatedByUserID,RetakeTestApplicationID);
            }
            else
            {
                return null;
            }
        }

        public static clsTestAppointment GetLastTestAppointment(int TestTypeID,int LocalDrivingLicenseApplicationID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsLocked = false;

            bool isFound = clsTestAppointmentData.GetLastTestAppointment(TestTypeID, LocalDrivingLicenseApplicationID, ref TestAppointmentID, ref AppointmentDate,
                ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID);

            if (isFound)
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestTypes.enTestType)TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                    PaidFees, IsLocked, CreatedByUserID, RetakeTestApplicationID);
            }
            else
                return null;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateTestAppointment();
            }
            return false;
        }

        private int _GetTestID()
        {
            return clsTestAppointmentData.GetTestID(this.TestAppointmentID);
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplictionTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
    }
}
