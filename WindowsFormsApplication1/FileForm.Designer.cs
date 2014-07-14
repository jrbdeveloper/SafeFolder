﻿namespace SafeFolder
{
    partial class FileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileForm));
            this.lstRecipients = new System.Windows.Forms.CheckedListBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FullFileName = new System.Windows.Forms.Label();
            this.canSaveCheck = new System.Windows.Forms.CheckBox();
            this.canForwardCheck = new System.Windows.Forms.CheckBox();
            this.canPrintCheck = new System.Windows.Forms.CheckBox();
            this.canCopyCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lstRecipients
            // 
            this.lstRecipients.FormattingEnabled = true;
            this.lstRecipients.Location = new System.Drawing.Point(84, 44);
            this.lstRecipients.Name = "lstRecipients";
            this.lstRecipients.Size = new System.Drawing.Size(197, 139);
            this.lstRecipients.TabIndex = 0;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(84, 15);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(163, 20);
            this.txtEmailAddress.TabIndex = 1;
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(253, 13);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(28, 23);
            this.btnAddAddress.TabIndex = 2;
            this.btnAddAddress.Text = "+";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(358, 161);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFile.TabIndex = 3;
            this.btnSaveFile.Text = "Make Safe";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File:";
            // 
            // FullFileName
            // 
            this.FullFileName.AutoSize = true;
            this.FullFileName.Location = new System.Drawing.Point(351, 19);
            this.FullFileName.MaximumSize = new System.Drawing.Size(120, 0);
            this.FullFileName.Name = "FullFileName";
            this.FullFileName.Size = new System.Drawing.Size(35, 13);
            this.FullFileName.TabIndex = 6;
            this.FullFileName.Text = "label3";
            // 
            // canSaveCheck
            // 
            this.canSaveCheck.AutoSize = true;
            this.canSaveCheck.Location = new System.Drawing.Point(358, 53);
            this.canSaveCheck.Name = "canSaveCheck";
            this.canSaveCheck.Size = new System.Drawing.Size(73, 17);
            this.canSaveCheck.TabIndex = 7;
            this.canSaveCheck.Text = "Can Save";
            this.canSaveCheck.UseVisualStyleBackColor = true;
            // 
            // canForwardCheck
            // 
            this.canForwardCheck.AutoSize = true;
            this.canForwardCheck.Location = new System.Drawing.Point(358, 77);
            this.canForwardCheck.Name = "canForwardCheck";
            this.canForwardCheck.Size = new System.Drawing.Size(86, 17);
            this.canForwardCheck.TabIndex = 8;
            this.canForwardCheck.Text = "Can Forward";
            this.canForwardCheck.UseVisualStyleBackColor = true;
            // 
            // canPrintCheck
            // 
            this.canPrintCheck.AutoSize = true;
            this.canPrintCheck.Location = new System.Drawing.Point(358, 101);
            this.canPrintCheck.Name = "canPrintCheck";
            this.canPrintCheck.Size = new System.Drawing.Size(69, 17);
            this.canPrintCheck.TabIndex = 9;
            this.canPrintCheck.Text = "Can Print";
            this.canPrintCheck.UseVisualStyleBackColor = true;
            // 
            // canCopyCheck
            // 
            this.canCopyCheck.AutoSize = true;
            this.canCopyCheck.Location = new System.Drawing.Point(358, 125);
            this.canCopyCheck.Name = "canCopyCheck";
            this.canCopyCheck.Size = new System.Drawing.Size(72, 17);
            this.canCopyCheck.TabIndex = 10;
            this.canCopyCheck.Text = "Can Copy";
            this.canCopyCheck.UseVisualStyleBackColor = true;
            // 
            // FileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 197);
            this.Controls.Add(this.canCopyCheck);
            this.Controls.Add(this.canPrintCheck);
            this.Controls.Add(this.canForwardCheck);
            this.Controls.Add(this.canSaveCheck);
            this.Controls.Add(this.FullFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnAddAddress);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.lstRecipients);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileForm_FormClosing);
            this.Load += new System.EventHandler(this.FileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstRecipients;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FullFileName;
        private System.Windows.Forms.CheckBox canSaveCheck;
        private System.Windows.Forms.CheckBox canForwardCheck;
        private System.Windows.Forms.CheckBox canPrintCheck;
        private System.Windows.Forms.CheckBox canCopyCheck;
    }
}