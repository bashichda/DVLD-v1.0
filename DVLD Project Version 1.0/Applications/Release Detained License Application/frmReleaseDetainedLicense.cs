using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Global_Classes;
using DVLD_Project_Version_1._0.Licenses;
using DVLD_Project_Version_1._0.Licenses.Local_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Applications.Release_Detained_License_Application
{
    public partial class frmReleaseDetainedLicense : Form
    {
        private int _SelectedLicenseID = -1;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void frmReleaseDetainedLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtFilterValueFocus();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            lblLicenseID.Text = _SelectedLicenseID.ToString();
            LLShowLicensesHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                return;
            }

            // Check if License Is Detained:
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License Is Not Detained, Choose Another One!", "Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationTypeFees.ToString();
            lblCreatedBy.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;

            lblDetainID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblDetainDate.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToShortDateString();
            lblFineFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = ((Convert.ToDecimal(lblApplicationFees.Text) + (Convert.ToDecimal(lblFineFees.Text)))).ToString();

            btnRelease.Enabled = true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure you want to Release This Detained License ? ","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question
                ) == DialogResult.No)
            {
                return;
            }

            int ApplicatinID = -1;

            bool IsReleased = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicatinID);

            lblApplicationID.Text = ApplicatinID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to Release The Detained License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License Released Successfully.", "Released License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ctrlDriverLicenseInfoWithFilter1.RefreshLicenseInfo();

            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            LLShowLicensesInfo.Enabled = true;

        }

        private void LLShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void LLShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }
    }
}
