using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Licenses.International_License
{
    public partial class frmDriverShowInternationalLicenseInfo : Form
    {
        private int _InteranaionalLicenseID = -1;

        public frmDriverShowInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InteranaionalLicenseID = InternationalLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverInternationalLicenseInfo1.LoadInfo(_InteranaionalLicenseID);
        }
    }
}
