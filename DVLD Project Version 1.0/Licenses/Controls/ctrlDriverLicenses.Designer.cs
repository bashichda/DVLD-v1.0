namespace DVLD_Project_Version_1._0.Licenses.Controls
{
    partial class ctrlDriverLicenses
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbDriverLicenses = new System.Windows.Forms.GroupBox();
            this.tbDriversLicenses = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.lblLocalRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.lblInternationalRecordsCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvInternationalLicensesHitory = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicensesHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsInternationalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDriverLicenses.SuspendLayout();
            this.tbDriversLicenses.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHitory)).BeginInit();
            this.cmsLocalLicensesHistory.SuspendLayout();
            this.cmsInternationalLicenseHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDriverLicenses
            // 
            this.gbDriverLicenses.Controls.Add(this.tbDriversLicenses);
            this.gbDriverLicenses.Location = new System.Drawing.Point(3, 3);
            this.gbDriverLicenses.Name = "gbDriverLicenses";
            this.gbDriverLicenses.Size = new System.Drawing.Size(1062, 357);
            this.gbDriverLicenses.TabIndex = 0;
            this.gbDriverLicenses.TabStop = false;
            this.gbDriverLicenses.Text = "Driver Licenses";
            // 
            // tbDriversLicenses
            // 
            this.tbDriversLicenses.Controls.Add(this.tpLocal);
            this.tbDriversLicenses.Controls.Add(this.tpInternational);
            this.tbDriversLicenses.Location = new System.Drawing.Point(19, 34);
            this.tbDriversLicenses.Name = "tbDriversLicenses";
            this.tbDriversLicenses.SelectedIndex = 0;
            this.tbDriversLicenses.Size = new System.Drawing.Size(1039, 317);
            this.tbDriversLicenses.TabIndex = 0;
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.lblLocalRecordsCount);
            this.tpLocal.Controls.Add(this.label2);
            this.tpLocal.Controls.Add(this.label1);
            this.tpLocal.Controls.Add(this.dgvLocalLicensesHistory);
            this.tpLocal.Location = new System.Drawing.Point(4, 29);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(1031, 284);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // lblLocalRecordsCount
            // 
            this.lblLocalRecordsCount.AutoSize = true;
            this.lblLocalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalRecordsCount.Location = new System.Drawing.Point(114, 252);
            this.lblLocalRecordsCount.Name = "lblLocalRecordsCount";
            this.lblLocalRecordsCount.Size = new System.Drawing.Size(35, 20);
            this.lblLocalRecordsCount.TabIndex = 3;
            this.lblLocalRecordsCount.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Licenses History:";
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.AllowUserToAddRows = false;
            this.dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesHistory.AllowUserToOrderColumns = true;
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesHistory.ContextMenuStrip = this.cmsLocalLicensesHistory;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(16, 52);
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(1008, 192);
            this.dgvLocalLicensesHistory.TabIndex = 0;
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.lblInternationalRecordsCount);
            this.tpInternational.Controls.Add(this.label6);
            this.tpInternational.Controls.Add(this.label4);
            this.tpInternational.Controls.Add(this.dgvInternationalLicensesHitory);
            this.tpInternational.Location = new System.Drawing.Point(4, 29);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(1031, 284);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // lblInternationalRecordsCount
            // 
            this.lblInternationalRecordsCount.AutoSize = true;
            this.lblInternationalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalRecordsCount.Location = new System.Drawing.Point(111, 255);
            this.lblInternationalRecordsCount.Name = "lblInternationalRecordsCount";
            this.lblInternationalRecordsCount.Size = new System.Drawing.Size(35, 20);
            this.lblInternationalRecordsCount.TabIndex = 5;
            this.lblInternationalRecordsCount.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "# Records:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "International Licenses History:";
            // 
            // dgvInternationalLicensesHitory
            // 
            this.dgvInternationalLicensesHitory.AllowUserToAddRows = false;
            this.dgvInternationalLicensesHitory.AllowUserToDeleteRows = false;
            this.dgvInternationalLicensesHitory.AllowUserToOrderColumns = true;
            this.dgvInternationalLicensesHitory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicensesHitory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicensesHitory.ContextMenuStrip = this.cmsInternationalLicenseHistory;
            this.dgvInternationalLicensesHitory.Location = new System.Drawing.Point(13, 63);
            this.dgvInternationalLicensesHitory.Name = "dgvInternationalLicensesHitory";
            this.dgvInternationalLicensesHitory.ReadOnly = true;
            this.dgvInternationalLicensesHitory.Size = new System.Drawing.Size(1008, 182);
            this.dgvInternationalLicensesHitory.TabIndex = 2;
            // 
            // cmsLocalLicensesHistory
            // 
            this.cmsLocalLicensesHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsLocalLicensesHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLocalLicensesHistory.Name = "cmsLocalLicensesHistory";
            this.cmsLocalLicensesHistory.Size = new System.Drawing.Size(222, 64);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD_Project_Version_1._0.Properties.Resources.newDriverLices_32;
            this.showLicenseInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(221, 38);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // cmsInternationalLicenseHistory
            // 
            this.cmsInternationalLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsInternationalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmsInternationalLicenseHistory.Name = "cmsLocalLicensesHistory";
            this.cmsInternationalLicenseHistory.Size = new System.Drawing.Size(222, 42);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::DVLD_Project_Version_1._0.Properties.Resources.newDriverLices_32;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 38);
            this.toolStripMenuItem1.Text = "Show License Info";
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDriverLicenses);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1071, 375);
            this.gbDriverLicenses.ResumeLayout(false);
            this.tbDriversLicenses.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHitory)).EndInit();
            this.cmsLocalLicensesHistory.ResumeLayout(false);
            this.cmsInternationalLicenseHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDriverLicenses;
        private System.Windows.Forms.TabControl tbDriversLicenses;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLocalRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesHitory;
        private System.Windows.Forms.Label lblInternationalRecordsCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicensesHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
