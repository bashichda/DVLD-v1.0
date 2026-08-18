using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Licenses.Local_Licenses
{
    public partial class frmShowDriverLicenseInfo : Form
    {
        private int _LicenseID = -1;


        public frmShowDriverLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadInfo(_LicenseID);
        }
    }
}
