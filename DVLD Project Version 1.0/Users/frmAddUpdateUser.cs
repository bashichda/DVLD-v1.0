using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0.Users
{
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1};

        private enMode _Mode = enMode.AddNew;

        private int _UserID = -1;

        clsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                this.Text = "Add New User";

                _User = new clsUser();

                tpLoginInfo.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblMode.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            txtUserName.Text= "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = false;

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];

                
                return;
            }

            
            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                if (clsUser.isUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];

                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();

            }


        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

            if (clsUser.isUserExist(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This User Name is already used choose another one!");
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password Cannot be blank!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void _LoadData()
        {
            _User = clsUser.FindUserByUserID(_UserID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("There is no User with ID [" + _UserID + "]", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblMode.Text = "Update User";
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            ctrlPersonCardWithFilter1.LoadPersonInf(_User.PersonID);
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Field are not valide!, put the mouse over the red Icon(s).", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();

                _Mode = enMode.Update;

                lblMode.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("User Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("User is not saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
