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

namespace DVLD_Project_Version_1._0.Applications.Detained_License
{
    public partial class frmDetainLicense : Form
    {

        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();
            LLShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                return;
            }

            // Check if Licnese Already Detained:
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License Already Detained, Choose Another One.", "not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            // Check If License Is Not Active:
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License Is Not Active, Please Choose An Acive License!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtFilterValueFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Detain This License? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == DialogResult.No)
            {
                return;
            }

            _DetainID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToDecimal(txtFineFees.Text.Trim()), clsGlobal.CurrentUser.UserID);

            if (_DetainID == -1)
            {
                MessageBox.Show("Faild To Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully With ID = " + _DetainID.ToString(), "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ctrlDriverLicenseInfoWithFilter1.RefreshLicenseInfo();

            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            btnDetain.Enabled = false;
            txtFineFees.Enabled = false;
            LLShowLicenseseInfo.Enabled = true;
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "This Field Is Required!");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
            }

            if (!clsValidation.IsNumber(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number!");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
            }
        }

        private void LLShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void LLShowLicenseseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }
    }
}
