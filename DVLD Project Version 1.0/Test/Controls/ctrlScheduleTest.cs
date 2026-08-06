using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Test.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        public enum enMode { AddNew = 0,Update = 1};
        private enMode _Mode = enMode.AddNew;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1};
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.Visiontest;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _LocalDrivingLicenseApplicationID = -1;

        private clsTestAppointment _TestAppointment;

        private int _TestAppointmentID = -1;

        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.Visiontest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision_512;
                            break;
                        }
                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written_512;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.Street_512;
                            break;
                        }
                }
            }
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID,int AppointmentID = -1)
        {
            if (AppointmentID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Local Driving License Application With = " + _LocalDrivingLicenseApplicationID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnSave.Enabled = false;
                return;
            }

            //Decide if the creattion mode is  retake test or not based if the person attended thir test before:

            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
            {
                _CreationMode = enCreationMode.RetakeTestSchedule;
            }
            else
            {
                _CreationMode = enCreationMode.FirstTimeSchedule;
            }

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRetakeAppFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).ApplicationTypeFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";

                //==> see you soon;
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
    }
}
