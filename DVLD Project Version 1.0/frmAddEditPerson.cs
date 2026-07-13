using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_Project_Version_1._0
{
    public partial class frmAddEditPerson : Form
    {
        public enum enMode { AddNew = 0, Update = 1};
        private enMode _Mode = enMode.AddNew;

        int _PersonID;
        clsPerson _People;

        public frmAddEditPerson(int ID)
        {
            InitializeComponent();
            _PersonID = ID;

            if (_PersonID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }
        private void _FillCountries()
        {
            DataTable dt = clsCountry.GetAllCountries();

            cbCountries.DataSource = dt;
            cbCountries.DisplayMember = "CountryName";
            cbCountries.ValueMember = "CountryID";
            cbCountries.Text = "Morocco";
        }

        private void _LoadData()
        {
            _FillCountries();

            dtPicker.MaxDate = DateTime.Today.AddYears(-18);

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _People = new clsPerson();
                llRemoveImage.Visible = false;
                rdMale.Checked = true;
                return;
            }

            _People = clsPerson.Find(_PersonID);

            if (_People == null)
            {
                MessageBox.Show($"This Firm will close Because There no Person with ID [{_PersonID}]");
                this.Close();
                return;
            }

            lblMode.Text = @"Update Person";
            lblPersonID.Text = _People.PersonID.ToString();
            txtFirstName.Text = _People.FirstName;
            txtSecondName.Text = _People.SecondName;
            txtThirdName.Text = _People.ThirdName;
            txtLastName.Text = _People.LastName;
            txtNationalNo.Text = _People.NationalNo;
            dtPicker.Value = _People.DateOfBirth;
            if (_People.Gender == 0)
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }
           txtPhone.Text = _People.Phone;
           txtEmail.Text = _People.Email;
           txtAddress.Text = _People.Address;
           cbCountries.SelectedValue = _People.NationalCountryID;

            if (_People.ImagePath != null)
            {
                pictureBox1.ImageLocation = _People.ImagePath;
                llRemoveImage.Visible = true;
            }
            else
            {
                pictureBox1.ImageLocation = null;
                llRemoveImage.Visible = false;
            }
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadData();



        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _People.NationalNo = txtNationalNo.Text;
            _People.FirstName = txtFirstName.Text;
            _People.SecondName = txtSecondName.Text;
            _People.ThirdName = txtThirdName.Text;
            _People.LastName = txtLastName.Text;
            if (rdMale.Checked == true)
            {
                _People.Gender = 0;
            }
            else
            {
                _People.Gender = 1;
            }

            _People.DateOfBirth = dtPicker.Value;
            _People.NationalCountryID = (int)cbCountries.SelectedValue;
            _People.Phone = txtPhone.Text;
            _People.Email = txtEmail.Text;
            _People.Address = txtAddress.Text;

            if (pictureBox1.ImageLocation != null)
            {
                _People.ImagePath = pictureBox1.ImageLocation;
            }
            else
            {
                _People.ImagePath = "";
            }

            if (_People.Save())
            {
                MessageBox.Show("Person Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                lblMode.Text = "Update Person";
                lblPersonID.Text = _People.PersonID.ToString();
            }
            else
            {
                MessageBox.Show("Failed To Save Persson Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

            if (rdMale.Checked == true)
            {
                pictureBox1.Image = Properties.Resources.Man;
            }
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFemale.Checked == true)
            {
                pictureBox1.Image = Properties.Resources.woman;
            }
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string systemFolder = @"C:\DVLD_People_Images\";

                    string oldImagePath = pictureBox1.ImageLocation;

                    if (!Directory.Exists(systemFolder))
                    {
                        Directory.CreateDirectory(systemFolder);
                    }

                    string extension = Path.GetExtension(openFileDialog1.FileName);

                    string newFileName = Guid.NewGuid().ToString() + extension;

                    string destinationPath = Path.Combine(systemFolder, newFileName);

                    File.Copy(openFileDialog1.FileName, destinationPath, true);

                    pictureBox1.ImageLocation = destinationPath;

                    if (!string.IsNullOrEmpty(oldImagePath) && File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(pictureBox1.ImageLocation) && File.Exists(pictureBox1.ImageLocation))
            {
                File.Delete(pictureBox1.ImageLocation);
            }

            pictureBox1.ImageLocation = null;
            llRemoveImage.Visible = false;
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtLastName, "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (clsPerson.isPersonExist(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "National Number is used for another Person!");
            }
            else if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, "");
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtPhone, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!txtEmail.Text.Contains("@"))
            {
                errorProvider1.SetError(txtEmail, "Invalid Email Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtAddress, "");
            }
        }
    }
}
