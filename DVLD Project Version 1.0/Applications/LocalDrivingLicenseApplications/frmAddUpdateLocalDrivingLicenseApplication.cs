using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Applications.LocalDrivingLicenseApplications
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1};
        private enMode _Mode;

        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _Mode = enMode.Update;
        }

        private void _FillLicenseClasssInComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach(DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private void __ReseteDefaultValues()
        {
            _FillLicenseClasssInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonCardWithFilter1.FilterFocus();
                tbApplicationInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewDrivingLicense).ApplicationTypeFees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tbApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            __ReseteDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _LoadData()
        {
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID,"Not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInf(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
            lblLoclaDrivingApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseID;

            int ActiveApplicationID = clsApplications.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplications.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Chooese Another License Class, the selected Person Already Has an Active Application for the selected class with ID = " + ActiveApplicationID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLicenseClass.Focus();
                return;
            }

            if (clsLicense.isLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            {
                MessageBox.Show("Person Already Have a license with the same applied class, choose deffrent driving Class", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToDecimal(lblFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

            if (_LocalDrivingLicenseApplication.Save())
            {
                lblLoclaDrivingApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                lblTitle.Text = "Update Local Driving License Application";
                _Mode = enMode.Update;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error : Data is not saved Succesfully.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBackEvent(object sender,int PersonID)
        {
            _SelectedPersonID = PersonID;
            ctrlPersonCardWithFilter1.LoadPersonInf(PersonID);
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tbApplicationInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tbApplicationInfo"];
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tbApplicationInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tbApplicationInfo"];
            }
            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.Focus();
        }
    }
}
