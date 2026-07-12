using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0
{
    public partial class PersonDetails : UserControl
    {

        public event EventHandler PersonUpdated;

        public string PersonID { get; set; }
        public string FullName { get; set; }
        public string NationalNo { get; set;}
        public string Gender { get; set;}
        public string Email { get; set; }
        public string Phone { get; set;}
        public string Country { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string ImagePath { get; set; }
     


        public PersonDetails()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            lblPersonID.Text = PersonID;
            lblName.Text = FullName;
            lblNationalNo.Text = NationalNo;
            lblGendor.Text = Gender;
            lblEmail.Text = Email;
            lblPhone.Text = Phone;
            lblCountry.Text = Country;
            lblAddress.Text = Address;
            lblDate.Text = DateOfBirth;
            if (ImagePath == "")
            {
                if (lblGendor.Text == "Male")
                {
                    pictureBox1.Image = Properties.Resources.Man;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.woman;
                }
            }
            else
            {
                pictureBox1.ImageLocation = ImagePath;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson((int)Convert.ToInt32(lblPersonID.Text));
            frm.ShowDialog();

            PersonUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
