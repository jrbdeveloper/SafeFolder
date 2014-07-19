namespace SafeFolder
{
    partial class FileReport
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
            this.savedFilesGrid = new System.Windows.Forms.DataGridView();
            this.fileRecipientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.savedFilesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileRecipientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // savedFilesGrid
            // 
            this.savedFilesGrid.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.savedFilesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.savedFilesGrid.Location = new System.Drawing.Point(1, 169);
            this.savedFilesGrid.Name = "savedFilesGrid";
            this.savedFilesGrid.Size = new System.Drawing.Size(846, 166);
            this.savedFilesGrid.TabIndex = 0;
            // 
            // fileRecipientBindingSource
            // 
            this.fileRecipientBindingSource.DataSource = typeof(SafeFolder.Core.Entities.FileRecipient);
            // 
            // fileBindingSource
            // 
            this.fileBindingSource.DataSource = typeof(SafeFolder.Core.Entities.File);
            // 
            // FileReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 335);
            this.Controls.Add(this.savedFilesGrid);
            this.Name = "FileReport";
            this.Text = "File Report";
            this.Load += new System.EventHandler(this.FileReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.savedFilesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileRecipientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView savedFilesGrid;
        private System.Windows.Forms.BindingSource fileBindingSource;
        private System.Windows.Forms.BindingSource fileRecipientBindingSource;
    }
}