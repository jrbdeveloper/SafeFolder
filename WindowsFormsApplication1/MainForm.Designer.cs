namespace SafeFolder
{
    partial class SafeFolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SafeFolder));
            this.localPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.servicePath = new System.Windows.Forms.TextBox();
            this.addServiceLocation = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.emailAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.configName = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurationList = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            this.isDefaultCheck = new System.Windows.Forms.CheckBox();
            this.configNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceLocationPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDefaultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.configurationList)).BeginInit();
            this.SuspendLayout();
            // 
            // localPath
            // 
            this.localPath.Location = new System.Drawing.Point(476, 34);
            this.localPath.Name = "localPath";
            this.localPath.Size = new System.Drawing.Size(271, 20);
            this.localPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local File Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Service Location(s):";
            // 
            // servicePath
            // 
            this.servicePath.Location = new System.Drawing.Point(476, 71);
            this.servicePath.Name = "servicePath";
            this.servicePath.Size = new System.Drawing.Size(271, 20);
            this.servicePath.TabIndex = 3;
            // 
            // addServiceLocation
            // 
            this.addServiceLocation.Location = new System.Drawing.Point(641, 107);
            this.addServiceLocation.Name = "addServiceLocation";
            this.addServiceLocation.Size = new System.Drawing.Size(106, 23);
            this.addServiceLocation.TabIndex = 4;
            this.addServiceLocation.Text = "Save Configuration";
            this.addServiceLocation.UseVisualStyleBackColor = true;
            this.addServiceLocation.Click += new System.EventHandler(this.addServiceLocation_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "E-Mail Address:";
            // 
            // emailAddress
            // 
            this.emailAddress.Location = new System.Drawing.Point(123, 70);
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.Size = new System.Drawing.Size(229, 20);
            this.emailAddress.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Configuration Name:";
            // 
            // configName
            // 
            this.configName.Location = new System.Drawing.Point(123, 32);
            this.configName.Name = "configName";
            this.configName.Size = new System.Drawing.Size(229, 20);
            this.configName.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
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
            this.configurationList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.configurationList.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.configurationList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configurationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.configurationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.configNameColumn,
            this.localFilePath,
            this.emailAddressColumn,
            this.serviceLocationPath,
            this.isDefaultColumn});
            this.configurationList.Location = new System.Drawing.Point(0, 149);
            this.configurationList.MultiSelect = false;
            this.configurationList.Name = "configurationList";
            this.configurationList.ReadOnly = true;
            this.configurationList.Size = new System.Drawing.Size(759, 150);
            this.configurationList.TabIndex = 5;
            this.configurationList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.configurationList_RowEnter);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(560, 107);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 14;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // isDefaultCheck
            // 
            this.isDefaultCheck.AutoSize = true;
            this.isDefaultCheck.Location = new System.Drawing.Point(476, 111);
            this.isDefaultCheck.Name = "isDefaultCheck";
            this.isDefaultCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isDefaultCheck.Size = new System.Drawing.Size(71, 17);
            this.isDefaultCheck.TabIndex = 15;
            this.isDefaultCheck.Text = "Is Default";
            this.isDefaultCheck.UseVisualStyleBackColor = true;
            // 
            // configNameColumn
            // 
            this.configNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.configNameColumn.HeaderText = "Configuration Name";
            this.configNameColumn.Name = "configNameColumn";
            this.configNameColumn.ReadOnly = true;
            // 
            // localFilePath
            // 
            this.localFilePath.HeaderText = "Local File Path";
            this.localFilePath.Name = "localFilePath";
            this.localFilePath.ReadOnly = true;
            // 
            // emailAddressColumn
            // 
            this.emailAddressColumn.HeaderText = "E-Mail Address";
            this.emailAddressColumn.Name = "emailAddressColumn";
            this.emailAddressColumn.ReadOnly = true;
            // 
            // serviceLocationPath
            // 
            this.serviceLocationPath.HeaderText = "Service Location";
            this.serviceLocationPath.Name = "serviceLocationPath";
            this.serviceLocationPath.ReadOnly = true;
            // 
            // isDefaultColumn
            // 
            this.isDefaultColumn.HeaderText = "Is Default";
            this.isDefaultColumn.Name = "isDefaultColumn";
            this.isDefaultColumn.ReadOnly = true;
            // 
            // SafeFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 304);
            this.Controls.Add(this.isDefaultCheck);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.configurationList);
            this.Controls.Add(this.configName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emailAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addServiceLocation);
            this.Controls.Add(this.servicePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.localPath);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SafeFolder";
            this.Text = "Safe Folder";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.SafeFolder_Load);
            this.Resize += new System.EventHandler(this.SafeFolder_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.configurationList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox localPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox servicePath;
        private System.Windows.Forms.Button addServiceLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox configName;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView configurationList;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn configNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailAddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceLocationPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn isDefaultColumn;
        private System.Windows.Forms.CheckBox isDefaultCheck;
    }
}

