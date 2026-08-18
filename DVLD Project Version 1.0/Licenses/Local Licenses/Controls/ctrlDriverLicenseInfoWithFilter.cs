using DVLD_BusinessLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        // Define a custom evnet handler delegate with parameters:
        public event Action<int> OnLicenseSelected;

        //Create a Protected method to raise the event with a parameter:
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with parameter;
            }
        }

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseID = -1;

        public int LicenseID
        {
            get
            {
                return ctrlDriverLicenseInfo1.LicenseID;
            }
        }

        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return ctrlDriverLicenseInfo1.SelectedLicenseInfo;
            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtFilterValue.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoadInfo(LicenseID);
            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;
            if (OnLicenseSelected != null && FilterEnabled)
            {
                // Raise The event with a parameter:
                OnLicenseSelected(_LicenseID);
            }
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields are not valide!, put the mouse over red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtFilterValue.Focus();
                return;
            }

            _LicenseID = int.Parse(txtFilterValue.Text);
            LoadLicenseInfo(_LicenseID);
        }

        private void BtnFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                BtnFind.PerformClick();
            }
        }

        public void txtFilterValueFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This Field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }
    }
}
