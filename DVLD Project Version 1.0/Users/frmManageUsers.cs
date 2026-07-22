using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Global_Classes;
using DVLD_Project_Version_1._0.People;
using DVLD_Project_Version_1._0.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0
{
    public partial class frmManageUsers : Form
    {
        private DataTable _dtAllUsers;

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsersInfo();

            dgvUsersList.DataSource = _dtAllUsers;
            cbFilterBy.SelectedIndex = 0;
            lblNuberOfUsers.Text = dgvUsersList.Rows.Count.ToString();

            if (dgvUsersList.Rows.Count > 0)
            {
                dgvUsersList.Columns[0].HeaderText = "User ID";
                dgvUsersList.Columns[0].Width = 110;

                dgvUsersList.Columns[1].HeaderText = "Person ID";
                dgvUsersList.Columns[1].Width = 120;

                dgvUsersList.Columns[2].HeaderText = "Full Name";
                dgvUsersList.Columns[2].Width = 350;

                dgvUsersList.Columns[3].HeaderText = "UserName";
                dgvUsersList.Columns[3].Width = 120;

                dgvUsersList.Columns[4].HeaderText = "Is Active";
                dgvUsersList.Columns[4].Width = 120;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string ColumnFilter = "";

            switch (cbFilterBy.Text)
            {
                case "User ID":
                    ColumnFilter = "UserID";
                    break;
                case "Person ID":
                    ColumnFilter = "PersonID";
                    break;
                case "Full Name":
                    ColumnFilter = "FullName";
                    break;
                case "UserName":
                    ColumnFilter = "UserName";
                    break;
                case "Is Active":
                    ColumnFilter = "IsActive";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (txtFilterValue.Text == "" || ColumnFilter == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNuberOfUsers.Text = dgvUsersList.Rows.Count.ToString();
                return;
            }

            if (ColumnFilter != "FullName" && ColumnFilter != "UserName")
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format($"[{ColumnFilter}] = {txtFilterValue.Text.Trim()}");
            }
            else
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format($"[{ColumnFilter}] Like '{txtFilterValue.Text.Trim()}%'");
            }

            lblNuberOfUsers.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
            }
            else
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format($"[{FilterColumn}] = {FilterValue}");
            }

            lblNuberOfUsers.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

            frmManageUsers_Load(null,null);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

            frmManageUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmManageUsers_Load(null, null);
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsersList.CurrentRow.Cells[0].Value;

            if (UserID == clsGlobal.CurrentUser.UserID)
            {
                MessageBox.Show("You Cannot Delete Current User", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show($"Are Your sure you wanna Delete User ID {UserID}","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)
                == DialogResult.OK)
            {
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User is Not Deleted!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            frmManageUsers_Load(null, null);
        }
    }
}
