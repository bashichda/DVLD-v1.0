using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Properties;
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
    public partial class frmListTestAppointment : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.Visiontest;

        DataTable _dtAllTestAppointments;

        public frmListTestAppointment(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestTypes.enTestType.Visiontest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = "Vision Test Appointments";
                        pbTestAppintmentImage.Image = Resources.Vision_512;
                        break;
                    }
                case clsTestTypes.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = "Written Test Appointments";
                        pbTestAppintmentImage.Image = Resources.Written_512;
                        break;
                    }
                case clsTestTypes.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = "Street Test Appointments";
                        pbTestAppintmentImage.Image = Resources.Street_512;
                        break;
                    }
            }
        }

        private void frmListTestAppointment_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();

            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);

            _dtAllTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID,_TestTypeID);
            dgvListTestAppointemts.DataSource = _dtAllTestAppointments;
            lblRecordsNumbers.Text = dgvListTestAppointemts.Rows.Count.ToString();

            if (dgvListTestAppointemts.Rows.Count > 0)
            {
                dgvListTestAppointemts.Columns[0].HeaderText = "Appointment ID";
                dgvListTestAppointemts.Columns[0].Width = 150;

                dgvListTestAppointemts.Columns[1].HeaderText = "Appointment Date";
                dgvListTestAppointemts.Columns[1].Width = 200;

                dgvListTestAppointemts.Columns[2].HeaderText = "Paid Fees";
                dgvListTestAppointemts.Columns[2].Width = 150;

                dgvListTestAppointemts.Columns[3].HeaderText = "Is Locked";
                dgvListTestAppointemts.Columns[3].Width = 100;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewTestAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalDrivingLicesnseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicesnseApplication == null)
            {
                return;
            }

            if (LocalDrivingLicesnseApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person Already Have an Active appointment for this Test, You cannot Add New Appointment.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LocalDrivingLicesnseApplication.DoesPassTestType(_TestTypeID))
            {
                MessageBox.Show("This Person Already Passed this test before,you can only retake failed test.", "Not Allowed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);
            frm.ShowDialog();

            frmListTestAppointment_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvListTestAppointemts.CurrentRow.Cells[0].Value;

            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID, TestAppointmentID);
            frm.ShowDialog();

            frmListTestAppointment_Load(null, null);
        }
    }
}
