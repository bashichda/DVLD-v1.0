using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Global_Classes;
using DVLD_Project_Version_1._0.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Applications
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int _ApplicationID = -1;
        private clsApplications _Application;
        
        public int ApplicationID
        {
            get
            {
                return _ApplicationID;
            }
        }
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplications.FindBaseApplication(ApplicationID);

            if (_Application == null)
            {
                ResetApplicactionInfo();

                MessageBox.Show("No Application With ID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillApplicationInfo();
            }
            
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblApplicationStatus.Text = _Application.StatusText;
            lblApplicationType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblApplicationFees.Text = _Application.PaidFees.ToString();
            lblApplicantPerson.Text = _Application.ApplicantFullName;
            lblAplicationDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblLastStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
            lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;
        }

        public void ResetApplicactionInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[???]";
            lblApplicationStatus.Text = "[???]";
            lblApplicationFees.Text = "[$$$]";
            lblApplicationType.Text = "[???]";
            lblApplicantPerson.Text = "[???]";
            lblAplicationDate.Text = "[??/??/????]";
            lblLastStatusDate.Text = "[??/??/????]";
            lblCreatedByUser.Text = "[???]";
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();

            LoadApplicationInfo(_ApplicationID);
        }
    }
}
