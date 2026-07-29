namespace DVLD_Project_Version_1._0.Applications.LocalDrivingLicenseApplications
{
    partial class frmAddUpdateLocalDrivingLicenseApplication
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPersonaInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbApplicationInfo = new System.Windows.Forms.TabPage();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblLoclaDrivingApplicationID = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new DVLD_Project_Version_1._0.People.Controls.ctrlPersonCardWithFilter();
            this.tabControl1.SuspendLayout();
            this.tbPersonaInfo.SuspendLayout();
            this.tbApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPersonaInfo);
            this.tabControl1.Controls.Add(this.tbApplicationInfo);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(13, 122);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 504);
            this.tabControl1.TabIndex = 0;
            // 
            // tbPersonaInfo
            // 
            this.tbPersonaInfo.Controls.Add(this.btnNext);
            this.tbPersonaInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tbPersonaInfo.Location = new System.Drawing.Point(4, 29);
            this.tbPersonaInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPersonaInfo.Name = "tbPersonaInfo";
            this.tbPersonaInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPersonaInfo.Size = new System.Drawing.Size(912, 471);
            this.tbPersonaInfo.TabIndex = 0;
            this.tbPersonaInfo.Text = "Personal Info";
            this.tbPersonaInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Image = global::DVLD_Project_Version_1._0.Properties.Resources.Next;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(765, 419);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(130, 44);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbApplicationInfo
            // 
            this.tbApplicationInfo.Controls.Add(this.cbLicenseClass);
            this.tbApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tbApplicationInfo.Controls.Add(this.lblFees);
            this.tbApplicationInfo.Controls.Add(this.lblCreatedByUser);
            this.tbApplicationInfo.Controls.Add(this.lblLoclaDrivingApplicationID);
            this.tbApplicationInfo.Controls.Add(this.pictureBox5);
            this.tbApplicationInfo.Controls.Add(this.pictureBox4);
            this.tbApplicationInfo.Controls.Add(this.pictureBox3);
            this.tbApplicationInfo.Controls.Add(this.pictureBox2);
            this.tbApplicationInfo.Controls.Add(this.pictureBox1);
            this.tbApplicationInfo.Controls.Add(this.label6);
            this.tbApplicationInfo.Controls.Add(this.label5);
            this.tbApplicationInfo.Controls.Add(this.label4);
            this.tbApplicationInfo.Controls.Add(this.label3);
            this.tbApplicationInfo.Controls.Add(this.label2);
            this.tbApplicationInfo.Location = new System.Drawing.Point(4, 29);
            this.tbApplicationInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbApplicationInfo.Name = "tbApplicationInfo";
            this.tbApplicationInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbApplicationInfo.Size = new System.Drawing.Size(912, 471);
            this.tbApplicationInfo.TabIndex = 1;
            this.tbApplicationInfo.Text = "Application Info";
            this.tbApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(291, 170);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(271, 28);
            this.cbLicenseClass.TabIndex = 14;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(287, 136);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(49, 20);
            this.lblApplicationDate.TabIndex = 13;
            this.lblApplicationDate.Text = "[???]";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(287, 220);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(49, 20);
            this.lblFees.TabIndex = 12;
            this.lblFees.Text = "[???]";
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(287, 262);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(49, 20);
            this.lblCreatedByUser.TabIndex = 11;
            this.lblCreatedByUser.Text = "[???]";
            // 
            // lblLoclaDrivingApplicationID
            // 
            this.lblLoclaDrivingApplicationID.AutoSize = true;
            this.lblLoclaDrivingApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoclaDrivingApplicationID.Location = new System.Drawing.Point(287, 94);
            this.lblLoclaDrivingApplicationID.Name = "lblLoclaDrivingApplicationID";
            this.lblLoclaDrivingApplicationID.Size = new System.Drawing.Size(49, 20);
            this.lblLoclaDrivingApplicationID.TabIndex = 10;
            this.lblLoclaDrivingApplicationID.Text = "[???]";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Project_Version_1._0.Properties.Resources.CreatedBy_24;
            this.pictureBox5.Location = new System.Drawing.Point(257, 258);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Project_Version_1._0.Properties.Resources.fees;
            this.pictureBox4.Location = new System.Drawing.Point(257, 216);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Project_Version_1._0.Properties.Resources.newDriverLices_32;
            this.pictureBox3.Location = new System.Drawing.Point(257, 174);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Project_Version_1._0.Properties.Resources.calendar_24;
            this.pictureBox2.Location = new System.Drawing.Point(257, 132);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project_Version_1._0.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(257, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(81, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Created By : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Fees : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(81, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "License Class : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Application Date : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "D.L.Application ID : ";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(186, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(597, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "New Local Driving License Application";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_Project_Version_1._0.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(662, 636);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 44);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLD_Project_Version_1._0.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(798, 636);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 44);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(10, 13);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(905, 408);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // frmAddUpdateLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 692);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUpdateLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License Application";
            this.Activated += new System.EventHandler(this.frmAddUpdateLocalDrivingLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmAddUpdateLocalDrivingLicenseApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbPersonaInfo.ResumeLayout(false);
            this.tbApplicationInfo.ResumeLayout(false);
            this.tbApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbPersonaInfo;
        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.TabPage tbApplicationInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblLoclaDrivingApplicationID;
    }
}