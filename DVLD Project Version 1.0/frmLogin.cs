using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using System.IO;

namespace DVLD_Project_Version_1._0
{
    public partial class frmLogin : Form
    {
        private string _filePath = Path.Combine(Application.StartupPath, "remember.txt");

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.Find(txtUsername.Text, txtPassword.Text);

            if (User != null && User.IsActive)
            {
                if (chkRememberme.Checked)
                {
                    string[] linesToSave = { txtUsername.Text, txtPassword.Text };

                    File.WriteAllLines(_filePath, linesToSave);
                }
                else
                {
                    if (File.Exists(_filePath))
                    {
                        File.Delete(_filePath);
                    }
                }

                frmMain frm = new frmMain();
                this.Hide();
                frm.ShowDialog();
            }
            else if (User != null && !User.IsActive)
            {
                MessageBox.Show("Your Account is Deactiveted Please Contact Your Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Invalid UserName/Password!", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);

                if (lines.Length >= 2)
                {
                    txtUsername.Text = lines[0];
                    txtPassword.Text = lines[1];

                    chkRememberme.Checked = true;
                }
            }
        }
    }
}
