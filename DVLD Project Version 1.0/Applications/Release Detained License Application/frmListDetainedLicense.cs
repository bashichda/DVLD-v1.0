using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Applications.Detained_License;
using DVLD_Project_Version_1._0.Licenses;
using DVLD_Project_Version_1._0.Licenses.Local_Licenses;
using DVLD_Project_Version_1._0.People;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Applications.Release_Detained_License_Application
{
    public partial class frmListDetainedLicense : Form
    {
        DataTable _dtListDeatinedLicenses;

        public frmListDetainedLicense()
        {
            InitializeComponent();
        }

        private void frmListDetainedLicense_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _dtListDeatinedLicenses = clsDetainLicense.GetAllDetainedLicenses();
            dgvListDetainedLicenses.DataSource = _dtListDeatinedLicenses;
            lblRecordsCount.Text = dgvListDetainedLicenses.Rows.Count.ToString();

            if (dgvListDetainedLicenses.Rows.Count > 0)
            {
                dgvListDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvListDetainedLicenses.Columns[0].Width = 110;

                dgvListDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvListDetainedLicenses.Columns[1].Width = 110;

                dgvListDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvListDetainedLicenses.Columns[2].Width = 150;

                dgvListDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvListDetainedLicenses.Columns[3].Width = 120;

                dgvListDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvListDetainedLicenses.Columns[4].Width = 150;

                dgvListDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvListDetainedLicenses.Columns[5].Width = 150;

                dgvListDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvListDetainedLicenses.Columns[6].Width = 120;

                dgvListDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvListDetainedLicenses.Columns[7].Width = 270;

                dgvListDetainedLicenses.Columns[8].HeaderText = "Release App ID";
                dgvListDetainedLicenses.Columns[8].Width = 150;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            frmListDetainedLicense_Load(null, null);
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
            frmListDetainedLicense_Load(null, null);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = true;
                cbIsReleased.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                {
                    txtFilterValue.Enabled = true;
                }

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    ColumnFilter = "DetainID";
                    break;
                case "Is Released":
                    ColumnFilter = "IsReleased";
                    break;
                case "National No.":
                    ColumnFilter = "NationalNo";
                    break;
                case "Full Name":
                    ColumnFilter = "FullName";
                    break;
                case "Release Application ID":
                    ColumnFilter = "ReleaseApplicationID";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || ColumnFilter == "None")
            {
                _dtListDeatinedLicenses.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtListDeatinedLicenses.Rows.Count.ToString();
                return;
            }

            if (ColumnFilter == "DetainID" || ColumnFilter == "ReleaseApplicationID")
            {
                _dtListDeatinedLicenses.DefaultView.RowFilter = string.Format($"[{ColumnFilter}] = {txtFilterValue.Text.Trim()}");
            }
            else
            {
                _dtListDeatinedLicenses.DefaultView.RowFilter = string.Format($"[{ColumnFilter}] Like '{txtFilterValue.Text.Trim()}%'");
            }
            lblRecordsCount.Text = _dtListDeatinedLicenses.Rows.Count.ToString();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtListDeatinedLicenses.DefaultView.RowFilter = "";
            else
                _dtListDeatinedLicenses.DefaultView.RowFilter = string.Format($"[{FilterColumn}] = {FilterValue}");

            lblRecordsCount.Text = _dtListDeatinedLicenses.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);

            frm.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;
            frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(LicenseID);
            frm.ShowDialog();
            frmListDetainedLicense_Load(null, null);
        }

        private void cmsDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvListDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
