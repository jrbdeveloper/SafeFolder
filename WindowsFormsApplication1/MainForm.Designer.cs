namespace SafeFolder
{
    partial class SafeFolderForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SafeFolderForm));
            this.localPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.servicePath = new System.Windows.Forms.TextBox();
            this.saveConfigurationBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.emailAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.configName = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurationList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configurationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.isDefaultCheck = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.deleteConfigurationBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.configurationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // localPath
            // 
            this.localPath.Location = new System.Drawing.Point(518, 56);
            this.localPath.Name = "localPath";
            this.localPath.Size = new System.Drawing.Size(229, 20);
            this.localPath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local File Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Service Location(s):";
            // 
            // servicePath
            // 
            this.servicePath.Location = new System.Drawing.Point(518, 82);
            this.servicePath.Name = "servicePath";
            this.servicePath.Size = new System.Drawing.Size(229, 20);
            this.servicePath.TabIndex = 6;
            // 
            // saveConfigurationBtn
            // 
            this.saveConfigurationBtn.Location = new System.Drawing.Point(684, 115);
            this.saveConfigurationBtn.Name = "saveConfigurationBtn";
            this.saveConfigurationBtn.Size = new System.Drawing.Size(63, 23);
            this.saveConfigurationBtn.TabIndex = 9;
            this.saveConfigurationBtn.Text = "Save";
            this.saveConfigurationBtn.UseVisualStyleBackColor = true;
            this.saveConfigurationBtn.Click += new System.EventHandler(this.saveConfigurationBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "E-Mail Address:";
            // 
            // emailAddress
            // 
            this.emailAddress.Location = new System.Drawing.Point(97, 82);
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.Size = new System.Drawing.Size(229, 20);
            this.emailAddress.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Configuration Name:";
            // 
            // configName
            // 
            this.configName.Location = new System.Drawing.Point(518, 30);
            this.configName.Name = "configName";
            this.configName.Size = new System.Drawing.Size(229, 20);
            this.configName.TabIndex = 4;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Safe Folder";
            this.notifyIcon1.Visible = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(759, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configurationList
            // 
            this.configurationList.AllowUserToDeleteRows = false;
            this.configurationList.AllowUserToResizeColumns = false;
            this.configurationList.AllowUserToResizeRows = false;
            this.configurationList.AutoGenerateColumns = false;
            this.configurationList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.configurationList.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.configurationList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configurationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.configurationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn7});
            this.configurationList.DataSource = this.configurationBindingSource;
            this.configurationList.Location = new System.Drawing.Point(0, 149);
            this.configurationList.MultiSelect = false;
            this.configurationList.Name = "configurationList";
            this.configurationList.ReadOnly = true;
            this.configurationList.Size = new System.Drawing.Size(759, 150);
            this.configurationList.TabIndex = 10;
            this.configurationList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.configurationList_CellClick);
            this.configurationList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.configurationList_RowEnter);
            this.configurationList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.configurationList_RowPostPaint);
            this.configurationList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.configurationList_RowsAdded);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "LocalFilePath";
            this.dataGridViewTextBoxColumn5.HeaderText = "LocalFilePath";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ServicePath";
            this.dataGridViewTextBoxColumn6.HeaderText = "ServicePath";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "IsDefault";
            this.dataGridViewCheckBoxColumn2.HeaderText = "IsDefault";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "OwnerProfile";
            this.dataGridViewTextBoxColumn7.HeaderText = "OwnerProfile";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // configurationBindingSource
            // 
            this.configurationBindingSource.DataSource = typeof(SafeFolder.Core.Entities.Configuration);
            // 
            // isDefaultCheck
            // 
            this.isDefaultCheck.AutoSize = true;
            this.isDefaultCheck.Location = new System.Drawing.Point(518, 119);
            this.isDefaultCheck.Name = "isDefaultCheck";
            this.isDefaultCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isDefaultCheck.Size = new System.Drawing.Size(71, 17);
            this.isDefaultCheck.TabIndex = 7;
            this.isDefaultCheck.Text = "Is Default";
            this.isDefaultCheck.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "First Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Last Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Password:";
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(97, 30);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(229, 20);
            this.firstName.TabIndex = 0;
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(97, 56);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(229, 20);
            this.lastName.TabIndex = 1;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(97, 110);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(229, 20);
            this.password.TabIndex = 3;
            // 
            // deleteConfigurationBtn
            // 
            this.deleteConfigurationBtn.Location = new System.Drawing.Point(603, 115);
            this.deleteConfigurationBtn.Name = "deleteConfigurationBtn";
            this.deleteConfigurationBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteConfigurationBtn.TabIndex = 19;
            this.deleteConfigurationBtn.Text = "Delete";
            this.deleteConfigurationBtn.UseVisualStyleBackColor = true;
            this.deleteConfigurationBtn.Click += new System.EventHandler(this.deleteConfigurationBtn_Click);
            // 
            // SafeFolderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 304);
            this.Controls.Add(this.deleteConfigurationBtn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.isDefaultCheck);
            this.Controls.Add(this.configurationList);
            this.Controls.Add(this.configName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emailAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveConfigurationBtn);
            this.Controls.Add(this.servicePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.localPath);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SafeFolderForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Safe Folder";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SafeFolderForm_FormClosing);
            this.Load += new System.EventHandler(this.SafeFolder_Load);
            this.Resize += new System.EventHandler(this.SafeFolder_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.configurationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox localPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox servicePath;
        private System.Windows.Forms.Button saveConfigurationBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox configName;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView configurationList;
        private System.Windows.Forms.CheckBox isDefaultCheck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDefaultDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn localFilePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerProfileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.BindingSource configurationBindingSource;
        private System.Windows.Forms.Button deleteConfigurationBtn;
    }
}

