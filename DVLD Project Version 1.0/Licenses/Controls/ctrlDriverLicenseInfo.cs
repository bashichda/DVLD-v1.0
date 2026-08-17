using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Properties;
using System.IO;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Licenses.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID = -1;
        private clsLicense _License;

        public int LicenseID
        {
            get
            {
                return _LicenseID;
            }
        }


        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return _License;
            }
        }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;

            _License = clsLicense.Find(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show("No License With ID = " + _LicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = _License.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            // TODO : Change to (_License.IsDetained? "Yes" : "No";) after implementing clsDetainedLicense
            lblIsDetained.Text = "No";
            _LoadPersonImage();
            
        }

        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gender == 0)
            {
                pbPersonImage.Image = Resources.Man;
                pbGender.Image = Resources.male;
            }
            else
            {
                pbPersonImage.Image = Resources.woman;
                pbGender.Image = Resources.female;
            }

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pbPersonImage.Load(ImagePath);
                }
                else
                {
                    MessageBox.Show("Could Not Find this image : " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}
