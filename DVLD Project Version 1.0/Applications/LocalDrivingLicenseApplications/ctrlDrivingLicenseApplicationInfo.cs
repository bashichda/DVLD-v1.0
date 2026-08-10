using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Applications.LocalDrivingLicenseApplications
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        
        private int _LocalDrivingLicenseApplicationID = -1;

        private int _LicenseID;

        public int LocalDrivingLicenseApplicationID
        {
            get
            {
                return _LocalDrivingLicenseApplicationID;
            }
        }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplictioninfo();

                MessageBox.Show("No Application With Application ID = " + _LocalDrivingLicenseApplicationID, "Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            llShowLienseInfo.Enabled = (_LicenseID != -1);

            lblDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName.ToString();
            lblPassedTests.Text = "0/3";
            //lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().To.String() + "/3";
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
        }

        private void _ResetLocalDrivingLicenseApplictioninfo()
        {
            _LocalDrivingLicenseApplicationID = -1;

            lblDrivingLicenseApplicationID.Text = "[???]";
            lblAppliedForLicense.Text = "[???]";
            lblPassedTests.Text = "???";

            ctrlApplicationBasicInfo1.ResetApplicactionInfo();
        }

        
    }
}
