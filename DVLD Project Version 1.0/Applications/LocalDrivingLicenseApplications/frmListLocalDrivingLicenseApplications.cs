using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Test;
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
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        DataTable _dtAllLocalDrivingLicenseApplications;

        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllApplications();
            dgvListLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivingLicenseApplications;

            lblRecordsNumber.Text = dgvListLocalDrivingLicenseApplications.Rows.Count.ToString();

            if (dgvListLocalDrivingLicenseApplications.Rows.Count > 0)
            {
                dgvListLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvListLocalDrivingLicenseApplications.Columns[0].Width = 120;

                dgvListLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvListLocalDrivingLicenseApplications.Columns[1].Width = 350;

                dgvListLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvListLocalDrivingLicenseApplications.Columns[2].Width = 150;

                dgvListLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvListLocalDrivingLicenseApplications.Columns[3].Width = 400;

                dgvListLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvListLocalDrivingLicenseApplications.Columns[4].Width = 170;

                dgvListLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvListLocalDrivingLicenseApplications.Columns[5].Width = 150;

                dgvListLocalDrivingLicenseApplications.Columns[6].HeaderText = "Status";
                dgvListLocalDrivingLicenseApplications.Columns[6].Width = 110;
            }

            cbFilterValue.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();

            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvListLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication((int)dgvListLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterValue.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvListLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format($"{FilterColumn} = {txtFilterValue.Text.Trim()}");
            }
            else
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format($"{FilterColumn} Like '{txtFilterValue.Text.Trim()}%'");
            }

            lblRecordsNumber.Text = dgvListLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void cbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterValue.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase L.D.L.AppID id is selected.
            if (cbFilterValue.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not Implement yet", "Feature", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not Implement yet", "Feature", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not Implement yet", "Feature", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna Cancel This Application?","Confrimation",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                int LocalDrivingLicneseApplicationID = (int)dgvListLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

                clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicneseApplicationID);

                if (LocalDrivingLicenseApplication != null)
                {
                    if (LocalDrivingLicenseApplication.Cancel())
                    {
                        MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmListLocalDrivingLicenseApplications_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Cannot Canncel Applicaiton", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID((int)dgvListLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if (MessageBox.Show($"Are you sure you wanna Delete This Application With ID = {localDrivingLicenseApplication.ApplicationID.ToString()} ?","Confirmation",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (localDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Succesfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cannot Delete Application Because It Linked To Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgvListLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;

            bool LicenseExists = localDrivingLicenseApplication.IsLicneseIssued();

            //Enable Only if Person Passed all Tests and Does Not have Licnese:
            issueDrivingLicenseToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;
            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            editApplicationToolStripMenuItem.Enabled = !LicenseExists && (localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);

            //Enable Disable Cancel Menue Item
            // We Only Cancel The application With status = new.
            cancelApplicationToolStripMenuItem.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);

            //Enable Disabel Delete Menue Item
            // We only allow delete incase the application status is new not complete or cancelled
            deleteApplicationToolStripMenuItem.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);

            bool PassedVisionTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.Visiontest);
            bool PassedWrittenTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.StreetTest);

            ScheduleTestsMenue.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) &&
                (localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);

            if (ScheduleTestsMenue.Enabled)
            {
                // Vision Test:
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //Written Test:
                scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                // Street Test:
                scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointment frm = new frmListTestAppointment((int)dgvListLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.Visiontest);
            frm.ShowDialog();

            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointment frm = new frmListTestAppointment((int)dgvListLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.WrittenTest);
            frm.ShowDialog();

            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointment frm = new frmListTestAppointment((int)dgvListLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.StreetTest);
            frm.ShowDialog();

            frmListLocalDrivingLicenseApplications_Load(null, null);
        }
    }
}
