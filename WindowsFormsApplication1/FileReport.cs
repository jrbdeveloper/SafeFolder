using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SafeFolder.Core.Contracts;
using SafeFolder.Core.Entities;

namespace SafeFolder
{
    public partial class FileReport : Form
    {
        #region Member Variables

        private readonly IConfigurationManager _configurationManager;
        private readonly IFileManager _fileManager;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public FileReport(IConfigurationManager configurationManager, IFileManager fileManager)
        {
            _configurationManager = configurationManager;
            _fileManager = fileManager;

            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void FileReport_Load(object sender, EventArgs e)
        {
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            var colFileName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Value",
                HeaderText = "File Name",
                DataPropertyName = "Value" // Tell the column which property of FileName it should use
            };

            savedFilesGrid.Columns.Add(colFileName);

            //savedFilesGrid.DataSource = _fileManager.GetAllSavedFiles();

            var column = new DataGridViewColumn
            {
                DataPropertyName = "File.Name",
                Name = "File Name"
            };

            savedFilesGrid.Columns.Add(column);
        }
        #endregion

        #region Private Methods
        #endregion

        

        
    }
}
