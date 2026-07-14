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
        clsPerson _Person;

        public Person_Details(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void CtrlPersonDetails_PersonUpdated(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"This Windows will close because there no Person With this ID {_PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPersonDetails.LoadPersonInfo(_PersonID);
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
