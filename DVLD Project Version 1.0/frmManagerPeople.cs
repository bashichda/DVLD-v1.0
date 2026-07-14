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
using DVLD_Project_Version_1._0.People;

namespace DVLD_Project_Version_1._0
{
    public partial class frmManagePeople : Form
    {
        private DataView _dvPeople;

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewPeople_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            _RefreshPeopleData();
        }

        private void _RefreshPeopleData()
        {
            DataTable dt = clsPerson.GetAllPeople();
            _dvPeople = new DataView(dt);

            dgvPeopleList.DataSource = _dvPeople;

            cbFilterByManagePeople.Items.Clear();
            cbFilterByManagePeople.Items.Add("None");
            cbFilterByManagePeople.Items.Add("PersonID");
            cbFilterByManagePeople.Items.Add("National No");
            cbFilterByManagePeople.Items.Add("First Name");
            cbFilterByManagePeople.Items.Add("Second Name");
            cbFilterByManagePeople.Items.Add("Third Name");
            cbFilterByManagePeople.Items.Add("Last Name");
            cbFilterByManagePeople.Items.Add("Email");
            cbFilterByManagePeople.Items.Add("Phone");
            cbFilterByManagePeople.Items.Add("Nationality");
            cbFilterByManagePeople.SelectedIndex = 0;
            txtFilter.Visible = false;

            lblRecordNumbers.Text = dt.Rows.Count.ToString();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleData();
            
        }

        private void cbFilterByManagePeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterByManagePeople.SelectedIndex == 0)
            {
                txtFilter.Visible = false;
                txtFilter.Clear();
                _dvPeople.RowFilter = "";
            }
            else
            {
                txtFilter.Visible = true;
                txtFilter.Focus();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (_dvPeople == null) return;

            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _dvPeople.RowFilter = "";
                lblRecordNumbers.Text = dgvPeopleList.Rows.Count.ToString();
                return;
            }

            string filterColumn = "";
            bool isNumber = false;

            switch (cbFilterByManagePeople.Text)
            {
                case "PersonID":    filterColumn = "PersonID"; isNumber = true; break;
                case "National No": filterColumn = "NationalNo";break;
                case "First Name":  filterColumn = "FirstName"; break;
                case "Second Name": filterColumn = "SecondName"; break;
                case "Third Name":  filterColumn = "ThirdName"; break;
                case "Last Name":   filterColumn = "LastName";break;
                case "Email":       filterColumn = "Email"; break;
                case "Phone":       filterColumn = "Phone"; break;
                case "Nationality": filterColumn = "Nationality"; break;
            }

            try
            {
                if (isNumber)
                {
                    if (int.TryParse(txtFilter.Text, out int id))
                    {
                        _dvPeople.RowFilter = $"{filterColumn} = {id}";
                        lblRecordNumbers.Text = dgvPeopleList.Rows.Count.ToString();
                    }
                    else
                    {
                        _dvPeople.RowFilter = $"{filterColumn} = -1";
                    }
                }
                else
                {
                    _dvPeople.RowFilter = $"{filterColumn} LIKE '{txtFilter.Text}%'";
                    lblRecordNumbers.Text = dgvPeopleList.Rows.Count.ToString();
                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Filter Error : " + ex.Message);
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            _RefreshPeopleData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshPeopleData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPerson Person = clsPerson.Find((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            int PersonID = Person.PersonID;
            string ImgaePath = Person.ImagePath;

            if (MessageBox.Show($"Are You Sure You wanna Delete this Person [{PersonID}]?","Alert",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show($"Person With ID [{PersonID} Deleted Successfully.]", "Successfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Delete(Person.ImagePath);
                }
                else
                {
                    MessageBox.Show("Person was not delete because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Operation Canceld", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _RefreshPeopleData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshPeopleData();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
