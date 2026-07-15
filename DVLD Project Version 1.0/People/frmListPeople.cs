using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.People;

namespace DVLD_Project_Version_1._0
{
    public partial class frmListPeople : Form
    {
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName",
            "Gendor", "DateOfBirth", "Nationality", "Phone", "Email");

        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();

            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName",
            "Gendor", "DateOfBirth", "Nationality", "Phone", "Email");

            dgvPeopleList.DataSource = _dtPeople;
            lblRecordNumbers.Text = dgvPeopleList.Rows.Count.ToString();
        }

        public frmListPeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            dgvPeopleList.DataSource = _dtPeople;
            cbFilterBy.SelectedIndex = 0;

            lblRecordNumbers.Text = dgvPeopleList.Rows.Count.ToString();

            if (dgvPeopleList.Rows.Count > 0)
            {
                dgvPeopleList.Columns[0].HeaderText = "Person ID";
                dgvPeopleList.Columns[0].Width = 110;

                dgvPeopleList.Columns[1].HeaderText = "National No.";
                dgvPeopleList.Columns[1].Width = 120;

                dgvPeopleList.Columns[2].HeaderText = "First Name";
                dgvPeopleList.Columns[2].Width = 120;

                dgvPeopleList.Columns[3].HeaderText = "Second Name";
                dgvPeopleList.Columns[3].Width = 140;

                dgvPeopleList.Columns[4].HeaderText = "Third Name";
                dgvPeopleList.Columns[4].Width = 120;

                dgvPeopleList.Columns[5].HeaderText = "Last Name";
                dgvPeopleList.Columns[5].Width = 120;

                dgvPeopleList.Columns[6].HeaderText = "Gendor";
                dgvPeopleList.Columns[6].Width = 120;

                dgvPeopleList.Columns[7].HeaderText = "Date Of Birth";
                dgvPeopleList.Columns[7].Width = 140;

                dgvPeopleList.Columns[8].HeaderText = "Nationality";
                dgvPeopleList.Columns[8].Width = 120;

                dgvPeopleList.Columns[9].HeaderText = "Phone";
                dgvPeopleList.Columns[9].Width = 120;

                dgvPeopleList.Columns[10].HeaderText = "Email";
                dgvPeopleList.Columns[10].Width = 170;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleList.CurrentRow.Cells[0].Value;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleList.CurrentRow.Cells[0].Value;

            frmAddUpdatePerson frm = new frmAddUpdatePerson(PersonID);
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeopleList.CurrentRow.Cells[0].Value + "] ? ", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson((int)dgvPeopleList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successul", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Nationality":
                    FilterColumn = "Nationality";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordNumbers.Text = dgvPeopleList.Rows.Count.ToString();

                return;
            }

            if (FilterColumn == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtFilter.Text.Trim());
            }

            lblRecordNumbers.Text = dgvPeopleList.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFilterBy.Text != "None");

            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewPeople_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not Implement yet", "Feature", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not Implement yet", "Feature", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
