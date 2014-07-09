namespace SafeFolder
{
    partial class EncryptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncryptForm));
            this.lstRecipients = new System.Windows.Forms.CheckedListBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FullFileName = new System.Windows.Forms.Label();
            this.ActionPermissionList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lstRecipients
            // 
            this.lstRecipients.FormattingEnabled = true;
            this.lstRecipients.Location = new System.Drawing.Point(84, 44);
            this.lstRecipients.Name = "lstRecipients";
            this.lstRecipients.Size = new System.Drawing.Size(197, 184);
            this.lstRecipients.TabIndex = 0;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(84, 15);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(163, 20);
            this.txtEmailAddress.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(253, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(403, 205);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Make Safe";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File:";
            // 
            // FullFileName
            // 
            this.FullFileName.AutoSize = true;
            this.FullFileName.Location = new System.Drawing.Point(355, 22);
            this.FullFileName.MaximumSize = new System.Drawing.Size(120, 0);
            this.FullFileName.Name = "FullFileName";
            this.FullFileName.Size = new System.Drawing.Size(35, 13);
            this.FullFileName.TabIndex = 6;
            this.FullFileName.Text = "label3";
            // 
            // ActionPermissionList
            // 
            this.ActionPermissionList.BackColor = System.Drawing.SystemColors.Menu;
            this.ActionPermissionList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ActionPermissionList.FormattingEnabled = true;
            this.ActionPermissionList.Items.AddRange(new object[] {
            "Can Copy",
            "Can Delete",
            "Can Modify",
            "Can Forward"});
            this.ActionPermissionList.Location = new System.Drawing.Point(358, 66);
            this.ActionPermissionList.Name = "ActionPermissionList";
            this.ActionPermissionList.Size = new System.Drawing.Size(120, 90);
            this.ActionPermissionList.TabIndex = 9;
            // 
            // EncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 243);
            this.Controls.Add(this.ActionPermissionList);
            this.Controls.Add(this.FullFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.lstRecipients);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncryptForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encrypt Files";
            this.Load += new System.EventHandler(this.EncryptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstRecipients;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FullFileName;
        private System.Windows.Forms.CheckedListBox ActionPermissionList;
    }
}