using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0
{
    public partial class Person_Details : Form
    {
        private int _PersonID;
        clsPeople _People;

        public Person_Details(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;

            ctrlPersonDetails.PersonUpdated += CtrlPersonDetails_PersonUpdated;
        }

        private void CtrlPersonDetails_PersonUpdated(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            _People = clsPeople.Find(_PersonID);

            if (_People == null)
            {
                MessageBox.Show($"This Windows will close because there no Person With this ID {_PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPersonDetails.PersonID = _People.PersonID.ToString();
            ctrlPersonDetails.FullName = _People.FirstName + " " + _People.SecondName + " " + _People.ThirdName + " " + _People.LastName;
            ctrlPersonDetails.NationalNo = _People.NationalNo;
            ctrlPersonDetails.Gender = _People.Gender == 0 ? "Male" : "Female";
            ctrlPersonDetails.Email = _People.Email;
            ctrlPersonDetails.Address = _People.Address;
            ctrlPersonDetails.DateOfBirth = _People.DateOfBirth.ToShortDateString();
            ctrlPersonDetails.Phone = _People.Phone;
            ctrlPersonDetails.Country = clsCountries.FindCountryNameByID(_People.NationalCountryID);
            ctrlPersonDetails.ImagePath = _People.ImagePath;
            ctrlPersonDetails.RefreshData();
        }

        private void Person_Details_Load(object sender, EventArgs e)
        {

            _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
