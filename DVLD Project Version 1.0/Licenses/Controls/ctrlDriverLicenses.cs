using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Licenses.Local_Licenses;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID = -1;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicenseHistory;
        private DataTable _dtDriverInternationalLicenseHistory;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenseInfo()
        {
            _dtDriverLocalLicenseHistory = clsDriver.GetDriverLicenses(_DriverID);

            dgvLocalLicensesHistory.DataSource = _dtDriverLocalLicenseHistory;
            lblLocalRecordsCount.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 270;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 170;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 170;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 110;
            }
        }

        private void _LoadInternationalLicenseInfo()
        {
            //_dtDriverInternationalLicenseHistory = clsDriver.GetInternationalLicense(_DriverID);

            dgvInternationalLicensesHitory.DataSource = _dtDriverInternationalLicenseHistory;
            lblInternationalRecordsCount.Text = dgvInternationalLicensesHitory.Rows.Count.ToString();

            if (dgvInternationalLicensesHitory.Rows.Count > 0)
            {
                dgvInternationalLicensesHitory.Columns[0].HeaderText = "Int.Licenses.ID";
                dgvInternationalLicensesHitory.Columns[0].Width = 160;

                dgvInternationalLicensesHitory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHitory.Columns[1].Width = 130;

                dgvInternationalLicensesHitory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHitory.Columns[2].Width = 130;

                dgvInternationalLicensesHitory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHitory.Columns[3].Width = 180;

                dgvInternationalLicensesHitory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHitory.Columns[4].Width = 180;

                dgvInternationalLicensesHitory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicensesHitory.Columns[5].Width = 120;
            }
        }

        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.FindByDriverID(_DriverID);

            if (_Driver == null)
            {
                MessageBox.Show("There is no Driver With ID = " + _DriverID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);

            if (_Driver != null)
            {
                _DriverID = _Driver.DriverID;
            }
            else
            {
                MessageBox.Show("There is no Driver Person With ID = " + PersonID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;

            frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        public void Clear()
        {
            _dtDriverInternationalLicenseHistory.Clear();
            _dtDriverLocalLicenseHistory.Clear();
        }
    }
}
