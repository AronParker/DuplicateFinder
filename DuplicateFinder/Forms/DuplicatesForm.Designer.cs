namespace DuplicateFinder.Forms
{
    partial class DuplicatesForm
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
            if (_sysImageList != System.IntPtr.Zero)
            {
                System.Diagnostics.Debug.Assert(_duplicatesListView.IsHandleCreated);
                var sysImageList = NativeMethods.SendMessage(_duplicatesListView.Handle,
                                                             NativeMethods.LVM_SETIMAGELIST,
                                                             new System.IntPtr(NativeMethods.LVSIL_SMALL),
                                                             System.IntPtr.Zero);

                System.Diagnostics.Debug.Assert(sysImageList == _sysImageList);
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
            this._duplicatesLabel = new System.Windows.Forms.Label();
            this._addingFilesLabel = new System.Windows.Forms.Label();
            this._scannedFilesLabel = new System.Windows.Forms.Label();
            this._scannedSizeLabel = new System.Windows.Forms.Label();
            this._wastedFilesLabel = new System.Windows.Forms.Label();
            this._wastedSizeLabel = new System.Windows.Forms.Label();
            this._addedFilesValueLabel = new System.Windows.Forms.Label();
            this._addedSizeValueLabel = new System.Windows.Forms.Label();
            this._scannedFilesValueLabel = new System.Windows.Forms.Label();
            this._scannedSizeValueLabel = new System.Windows.Forms.Label();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._scanningFilesLabel = new System.Windows.Forms.Label();
            this._doneLabel = new System.Windows.Forms.Label();
            this._addedFilesLabel = new System.Windows.Forms.Label();
            this._addedSizeLabel = new System.Windows.Forms.Label();
            this._wastedFilesValueLabel = new System.Windows.Forms.Label();
            this._wastedSizeValueLabel = new System.Windows.Forms.Label();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._duplicatesListView = new DuplicateFinder.Controls.ExplorerListView();
            this._nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._sizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._dateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _duplicatesLabel
            // 
            this._duplicatesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._duplicatesLabel.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._duplicatesLabel.Location = new System.Drawing.Point(12, 10);
            this._duplicatesLabel.Name = "_duplicatesLabel";
            this._duplicatesLabel.Size = new System.Drawing.Size(760, 50);
            this._duplicatesLabel.TabIndex = 6;
            this._duplicatesLabel.Text = "0 Duplicates found";
            // 
            // _addingFilesLabel
            // 
            this._tableLayoutPanel.SetColumnSpan(this._addingFilesLabel, 2);
            this._addingFilesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addingFilesLabel.Enabled = false;
            this._addingFilesLabel.Font = new System.Drawing.Font("Segoe UI", 21F);
            this._addingFilesLabel.Location = new System.Drawing.Point(3, 0);
            this._addingFilesLabel.Name = "_addingFilesLabel";
            this._addingFilesLabel.Size = new System.Drawing.Size(246, 50);
            this._addingFilesLabel.TabIndex = 0;
            this._addingFilesLabel.Text = "Getting files...";
            this._addingFilesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _scannedFilesLabel
            // 
            this._scannedFilesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scannedFilesLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this._scannedFilesLabel.Location = new System.Drawing.Point(255, 50);
            this._scannedFilesLabel.Name = "_scannedFilesLabel";
            this._scannedFilesLabel.Size = new System.Drawing.Size(120, 20);
            this._scannedFilesLabel.TabIndex = 5;
            this._scannedFilesLabel.Text = "Scanned Files";
            // 
            // _scannedSizeLabel
            // 
            this._scannedSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scannedSizeLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this._scannedSizeLabel.Location = new System.Drawing.Point(381, 50);
            this._scannedSizeLabel.Name = "_scannedSizeLabel";
            this._scannedSizeLabel.Size = new System.Drawing.Size(120, 20);
            this._scannedSizeLabel.TabIndex = 6;
            this._scannedSizeLabel.Text = "Scanned Size";
            // 
            // _wastedFilesLabel
            // 
            this._wastedFilesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._wastedFilesLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this._wastedFilesLabel.Location = new System.Drawing.Point(507, 50);
            this._wastedFilesLabel.Name = "_wastedFilesLabel";
            this._wastedFilesLabel.Size = new System.Drawing.Size(120, 20);
            this._wastedFilesLabel.TabIndex = 7;
            this._wastedFilesLabel.Text = "Wasted Files";
            // 
            // _wastedSizeLabel
            // 
            this._wastedSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._wastedSizeLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this._wastedSizeLabel.Location = new System.Drawing.Point(633, 50);
            this._wastedSizeLabel.Name = "_wastedSizeLabel";
            this._wastedSizeLabel.Size = new System.Drawing.Size(124, 20);
            this._wastedSizeLabel.TabIndex = 8;
            this._wastedSizeLabel.Text = "Wasted Size";
            // 
            // _addedFilesValueLabel
            // 
            this._addedFilesValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addedFilesValueLabel.Font = new System.Drawing.Font("Segoe UI", 15F);
            this._addedFilesValueLabel.Location = new System.Drawing.Point(3, 70);
            this._addedFilesValueLabel.Name = "_addedFilesValueLabel";
            this._addedFilesValueLabel.Size = new System.Drawing.Size(120, 30);
            this._addedFilesValueLabel.TabIndex = 9;
            this._addedFilesValueLabel.Text = "-";
            // 
            // _addedSizeValueLabel
            // 
            this._addedSizeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addedSizeValueLabel.Font = new System.Drawing.Font("Segoe UI", 15F);
            this._addedSizeValueLabel.Location = new System.Drawing.Point(129, 70);
            this._addedSizeValueLabel.Name = "_addedSizeValueLabel";
            this._addedSizeValueLabel.Size = new System.Drawing.Size(120, 30);
            this._addedSizeValueLabel.TabIndex = 10;
            this._addedSizeValueLabel.Text = "-";
            // 
            // _scannedFilesValueLabel
            // 
            this._scannedFilesValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scannedFilesValueLabel.Font = new System.Drawing.Font("Segoe UI", 15F);
            this._scannedFilesValueLabel.Location = new System.Drawing.Point(255, 70);
            this._scannedFilesValueLabel.Name = "_scannedFilesValueLabel";
            this._scannedFilesValueLabel.Size = new System.Drawing.Size(120, 30);
            this._scannedFilesValueLabel.TabIndex = 11;
            this._scannedFilesValueLabel.Text = "-";
            // 
            // _scannedSizeValueLabel
            // 
            this._scannedSizeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scannedSizeValueLabel.Font = new System.Drawing.Font("Segoe UI", 15F);
            this._scannedSizeValueLabel.Location = new System.Drawing.Point(381, 70);
            this._scannedSizeValueLabel.Name = "_scannedSizeValueLabel";
            this._scannedSizeValueLabel.Size = new System.Drawing.Size(120, 30);
            this._scannedSizeValueLabel.TabIndex = 12;
            this._scannedSizeValueLabel.Text = "-";
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.Location = new System.Drawing.Point(12, 520);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(760, 30);
            this._progressBar.TabIndex = 5;
            // 
            // _scanningFilesLabel
            // 
            this._tableLayoutPanel.SetColumnSpan(this._scanningFilesLabel, 2);
            this._scanningFilesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scanningFilesLabel.Enabled = false;
            this._scanningFilesLabel.Font = new System.Drawing.Font("Segoe UI", 21F);
            this._scanningFilesLabel.Location = new System.Drawing.Point(255, 0);
            this._scanningFilesLabel.Name = "_scanningFilesLabel";
            this._scanningFilesLabel.Size = new System.Drawing.Size(246, 50);
            this._scanningFilesLabel.TabIndex = 1;
            this._scanningFilesLabel.Text = "Scanning files...";
            this._scanningFilesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _doneLabel
            // 
            this._tableLayoutPanel.SetColumnSpan(this._doneLabel, 2);
            this._doneLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._doneLabel.Enabled = false;
            this._doneLabel.Font = new System.Drawing.Font("Segoe UI", 21F);
            this._doneLabel.Location = new System.Drawing.Point(507, 0);
            this._doneLabel.Name = "_doneLabel";
            this._doneLabel.Size = new System.Drawing.Size(250, 50);
            this._doneLabel.TabIndex = 2;
            this._doneLabel.Text = "Done";
            this._doneLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _addedFilesLabel
            // 
            this._addedFilesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addedFilesLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this._addedFilesLabel.Location = new System.Drawing.Point(3, 50);
            this._addedFilesLabel.Name = "_addedFilesLabel";
            this._addedFilesLabel.Size = new System.Drawing.Size(120, 20);
            this._addedFilesLabel.TabIndex = 3;
            this._addedFilesLabel.Text = "Files";
            // 
            // _addedSizeLabel
            // 
            this._addedSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addedSizeLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this._addedSizeLabel.Location = new System.Drawing.Point(129, 50);
            this._addedSizeLabel.Name = "_addedSizeLabel";
            this._addedSizeLabel.Size = new System.Drawing.Size(120, 20);
            this._addedSizeLabel.TabIndex = 4;
            this._addedSizeLabel.Text = "Size";
            // 
            // _wastedFilesValueLabel
            // 
            this._wastedFilesValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._wastedFilesValueLabel.Font = new System.Drawing.Font("Segoe UI", 15F);
            this._wastedFilesValueLabel.Location = new System.Drawing.Point(507, 70);
            this._wastedFilesValueLabel.Name = "_wastedFilesValueLabel";
            this._wastedFilesValueLabel.Size = new System.Drawing.Size(120, 30);
            this._wastedFilesValueLabel.TabIndex = 13;
            this._wastedFilesValueLabel.Text = "-";
            // 
            // _wastedSizeValueLabel
            // 
            this._wastedSizeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._wastedSizeValueLabel.Font = new System.Drawing.Font("Segoe UI", 15F);
            this._wastedSizeValueLabel.Location = new System.Drawing.Point(633, 70);
            this._wastedSizeValueLabel.Name = "_wastedSizeValueLabel";
            this._wastedSizeValueLabel.Size = new System.Drawing.Size(124, 30);
            this._wastedSizeValueLabel.TabIndex = 14;
            this._wastedSizeValueLabel.Text = "-";
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tableLayoutPanel.ColumnCount = 6;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.Controls.Add(this._addingFilesLabel, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._scanningFilesLabel, 2, 0);
            this._tableLayoutPanel.Controls.Add(this._doneLabel, 4, 0);
            this._tableLayoutPanel.Controls.Add(this._addedFilesLabel, 0, 1);
            this._tableLayoutPanel.Controls.Add(this._addedSizeLabel, 1, 1);
            this._tableLayoutPanel.Controls.Add(this._scannedFilesLabel, 2, 1);
            this._tableLayoutPanel.Controls.Add(this._scannedSizeLabel, 3, 1);
            this._tableLayoutPanel.Controls.Add(this._wastedFilesLabel, 4, 1);
            this._tableLayoutPanel.Controls.Add(this._wastedSizeLabel, 5, 1);
            this._tableLayoutPanel.Controls.Add(this._addedFilesValueLabel, 0, 2);
            this._tableLayoutPanel.Controls.Add(this._addedSizeValueLabel, 1, 2);
            this._tableLayoutPanel.Controls.Add(this._scannedFilesValueLabel, 2, 2);
            this._tableLayoutPanel.Controls.Add(this._scannedSizeValueLabel, 3, 2);
            this._tableLayoutPanel.Controls.Add(this._wastedFilesValueLabel, 4, 2);
            this._tableLayoutPanel.Controls.Add(this._wastedSizeValueLabel, 5, 2);
            this._tableLayoutPanel.Location = new System.Drawing.Point(12, 413);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 3;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(760, 100);
            this._tableLayoutPanel.TabIndex = 4;
            // 
            // _duplicatesListView
            // 
            this._duplicatesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._duplicatesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._nameColumnHeader,
            this._sizeColumnHeader,
            this._dateColumnHeader,
            this._typeColumnHeader});
            this._duplicatesListView.Location = new System.Drawing.Point(12, 63);
            this._duplicatesListView.Name = "_duplicatesListView";
            this._duplicatesListView.Size = new System.Drawing.Size(760, 344);
            this._duplicatesListView.TabIndex = 7;
            this._duplicatesListView.UseCompatibleStateImageBehavior = false;
            this._duplicatesListView.View = System.Windows.Forms.View.Details;
            // 
            // _nameColumnHeader
            // 
            this._nameColumnHeader.Text = "Name";
            this._nameColumnHeader.Width = 300;
            // 
            // _sizeColumnHeader
            // 
            this._sizeColumnHeader.Text = "Size";
            this._sizeColumnHeader.Width = 80;
            // 
            // _dateColumnHeader
            // 
            this._dateColumnHeader.Text = "Last modified";
            this._dateColumnHeader.Width = 120;
            // 
            // _typeColumnHeader
            // 
            this._typeColumnHeader.Text = "Type";
            this._typeColumnHeader.Width = 120;
            // 
            // DuplicatesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this._duplicatesListView);
            this.Controls.Add(this._duplicatesLabel);
            this.Controls.Add(this._progressBar);
            this.Controls.Add(this._tableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DuplicatesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DuplicatesForm";
            this._tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        
        public System.Windows.Forms.Label _duplicatesLabel;
        public System.Windows.Forms.Label _addingFilesLabel;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        public System.Windows.Forms.Label _scanningFilesLabel;
        public System.Windows.Forms.Label _doneLabel;
        private System.Windows.Forms.Label _addedFilesLabel;
        private System.Windows.Forms.Label _addedSizeLabel;
        private System.Windows.Forms.Label _scannedFilesLabel;
        private System.Windows.Forms.Label _scannedSizeLabel;
        private System.Windows.Forms.Label _wastedFilesLabel;
        private System.Windows.Forms.Label _wastedSizeLabel;
        public System.Windows.Forms.Label _addedFilesValueLabel;
        public System.Windows.Forms.Label _addedSizeValueLabel;
        public System.Windows.Forms.Label _scannedFilesValueLabel;
        public System.Windows.Forms.Label _scannedSizeValueLabel;
        public System.Windows.Forms.Label _wastedFilesValueLabel;
        public System.Windows.Forms.Label _wastedSizeValueLabel;
        public System.Windows.Forms.ProgressBar _progressBar;
        private Controls.ExplorerListView _duplicatesListView;
        private System.Windows.Forms.ColumnHeader _nameColumnHeader;
        private System.Windows.Forms.ColumnHeader _sizeColumnHeader;
        private System.Windows.Forms.ColumnHeader _dateColumnHeader;
        private System.Windows.Forms.ColumnHeader _typeColumnHeader;
    }
}