using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Test
{
    public partial class frmScheduleTest : Form
    {

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.Visiontest;
        private int _TestAppointmentID = -1;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID,int TestAppointment = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointment;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestAppointmentID);
        }
    }
}
