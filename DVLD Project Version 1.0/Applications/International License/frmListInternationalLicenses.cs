using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Licenses.International_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Applications.International_License
{
    public partial class frmListInternationalLicenses : Form
    {
        DataTable _dtInternationalLicenses;

        public frmListInternationalLicenses()
        {
            InitializeComponent();
        }

        private void frmListInternationalLicenses_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _dtInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicenses.DataSource = _dtInternationalLicenses;
            lblRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 150;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 150;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 150;

                dgvInternationalLicenses.Columns[3].HeaderText = "License ID";
                dgvInternationalLicenses.Columns[3].Width = 150;

                dgvInternationalLicenses.Columns[4].HeaderText = "Isse Date";
                dgvInternationalLicenses.Columns[4].Width = 200;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 200;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 150;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmInternationalLicense frm = new frmInternationalLicense();
            frm.ShowDialog();

            frmListInternationalLicenses_Load(null, null);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilter.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilter.Text != "None");
                cbIsActive.Visible = false;
                if (cbFilter.Text == "None")
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

            switch (cbFilter.Text)
            {
                case "International License ID":
                    ColumnFilter = "InternationalLicenseID";
                    break;
                case "Application ID":
                    ColumnFilter = "ApplicationID";
                    break;
                case "Driver ID":
                    ColumnFilter = "DriverID";
                    break;
                case "Local License ID":
                    ColumnFilter = "IssuedUsingLocalLicenseID";
                    break;
                case "Is Actvie":
                    ColumnFilter = "IsActive";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || ColumnFilter == "None")
            {
                _dtInternationalLicenses.DefaultView.RowFilter = "";
                lblRecords.Text = _dtInternationalLicenses.Rows.Count.ToString();
                return;
            }


            _dtInternationalLicenses.DefaultView.RowFilter = string.Format($"[{ColumnFilter}] = {txtFilterValue.Text.Trim()}");
            lblRecords.Text = _dtInternationalLicenses.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ColumnFilter = "IsActive";
            string FilterValue = cbIsActive.Text;

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
            {
                _dtInternationalLicenses.DefaultView.RowFilter = "";
            }
            else
            {
                _dtInternationalLicenses.DefaultView.RowFilter = string.Format($"[{ColumnFilter}] = {FilterValue}");
            }

            lblRecords.Text = _dtInternationalLicenses.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
