using DVLD_BusinessLayer;
using DVLD_Project_Version_1._0.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_Version_1._0
{
    public partial class frmManageUsers : Form
    {
        DataTable _dtUsers = clsUser.GetAllUsersInfo();

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void _RefreshDataUsers()
        {
            dgvUsersList.DataSource = _dtUsers;

            lblNuberOfUsers.Text = _dtUsers.Rows.Count.ToString();

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshDataUsers();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

            _RefreshDataUsers();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshDataUsers();
        }
    }
}
