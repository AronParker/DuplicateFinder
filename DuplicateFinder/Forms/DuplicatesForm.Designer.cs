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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicatesForm));
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._duplicatesListView = new DuplicateFinder.Controls.ExplorerListView();
            this._nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._sizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._dateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._pathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deletePermanentlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._duplicatesLabel = new System.Windows.Forms.Label();
            this._errorsListView = new DuplicateFinder.Controls.ExplorerListView();
            this._errorType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._errorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._errorMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._errorPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this._errorsLabel = new System.Windows.Forms.Label();
            this._progressLabel = new System.Windows.Forms.Label();
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.Location = new System.Drawing.Point(12, 499);
            this._progressBar.Maximum = 10000;
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(760, 30);
            this._progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._progressBar.TabIndex = 4;
            // 
            // _duplicatesListView
            // 
            this._duplicatesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._duplicatesListView.CausesValidation = false;
            this._duplicatesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._nameColumnHeader,
            this._sizeColumnHeader,
            this._dateColumnHeader,
            this._typeColumnHeader,
            this._pathColumnHeader});
            this._duplicatesListView.ContextMenuStrip = this._contextMenuStrip;
            this._duplicatesListView.FullRowSelect = true;
            this._duplicatesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._duplicatesListView.Location = new System.Drawing.Point(12, 42);
            this._duplicatesListView.Name = "_duplicatesListView";
            this._duplicatesListView.Size = new System.Drawing.Size(760, 315);
            this._duplicatesListView.TabIndex = 1;
            this._duplicatesListView.UseCompatibleStateImageBehavior = false;
            this._duplicatesListView.View = System.Windows.Forms.View.Details;
            this._duplicatesListView.VirtualMode = true;
            this._duplicatesListView.ItemActivate += new System.EventHandler(this._openToolStripMenuItem_Click);
            this._duplicatesListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.DuplicatesListView_RetrieveVirtualItem);
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
            // _pathColumnHeader
            // 
            this._pathColumnHeader.Text = "Path";
            this._pathColumnHeader.Width = 136;
            // 
            // _contextMenuStrip
            // 
            this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripMenuItem,
            this._openFileLocationToolStripMenuItem,
            this._toolStripSeparator1,
            this._deleteToolStripMenuItem,
            this._deletePermanentlyToolStripMenuItem,
            this._toolStripSeparator2,
            this._propertiesToolStripMenuItem});
            this._contextMenuStrip.Name = "_contextMenuStrip";
            this._contextMenuStrip.Size = new System.Drawing.Size(234, 126);
            // 
            // _openToolStripMenuItem
            // 
            this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
            this._openToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this._openToolStripMenuItem.Text = "Open";
            this._openToolStripMenuItem.Click += new System.EventHandler(this._openToolStripMenuItem_Click);
            // 
            // _openFileLocationToolStripMenuItem
            // 
            this._openFileLocationToolStripMenuItem.Name = "_openFileLocationToolStripMenuItem";
            this._openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this._openFileLocationToolStripMenuItem.Text = "Open file location";
            this._openFileLocationToolStripMenuItem.Click += new System.EventHandler(this._openFileLocationToolStripMenuItem_Click);
            // 
            // _toolStripSeparator1
            // 
            this._toolStripSeparator1.Name = "_toolStripSeparator1";
            this._toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // _deleteToolStripMenuItem
            // 
            this._deleteToolStripMenuItem.Name = "_deleteToolStripMenuItem";
            this._deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this._deleteToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this._deleteToolStripMenuItem.Text = "Delete";
            this._deleteToolStripMenuItem.Click += new System.EventHandler(this._deleteToolStripMenuItem_Click);
            // 
            // _deletePermanentlyToolStripMenuItem
            // 
            this._deletePermanentlyToolStripMenuItem.Name = "_deletePermanentlyToolStripMenuItem";
            this._deletePermanentlyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this._deletePermanentlyToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this._deletePermanentlyToolStripMenuItem.Text = "Delete permanently";
            this._deletePermanentlyToolStripMenuItem.Click += new System.EventHandler(this._deletePermanentlyToolStripMenuItem_Click);
            // 
            // _toolStripSeparator2
            // 
            this._toolStripSeparator2.Name = "_toolStripSeparator2";
            this._toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
            // 
            // _propertiesToolStripMenuItem
            // 
            this._propertiesToolStripMenuItem.Name = "_propertiesToolStripMenuItem";
            this._propertiesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this._propertiesToolStripMenuItem.Text = "Properties";
            this._propertiesToolStripMenuItem.Click += new System.EventHandler(this._propertiesToolStripMenuItem_Click);
            // 
            // _duplicatesLabel
            // 
            this._duplicatesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._duplicatesLabel.CausesValidation = false;
            this._duplicatesLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._duplicatesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this._duplicatesLabel.Location = new System.Drawing.Point(12, 9);
            this._duplicatesLabel.Name = "_duplicatesLabel";
            this._duplicatesLabel.Size = new System.Drawing.Size(760, 30);
            this._duplicatesLabel.TabIndex = 0;
            this._duplicatesLabel.Text = "No duplicates found";
            this._duplicatesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _errorsListView
            // 
            this._errorsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._errorsListView.CausesValidation = false;
            this._errorsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._errorType,
            this._errorName,
            this._errorMessage,
            this._errorPath});
            this._errorsListView.FullRowSelect = true;
            this._errorsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._errorsListView.Location = new System.Drawing.Point(12, 393);
            this._errorsListView.Name = "_errorsListView";
            this._errorsListView.Size = new System.Drawing.Size(760, 100);
            this._errorsListView.SmallImageList = this._imageList;
            this._errorsListView.TabIndex = 3;
            this._errorsListView.UseCompatibleStateImageBehavior = false;
            this._errorsListView.View = System.Windows.Forms.View.Details;
            this._errorsListView.VirtualMode = true;
            this._errorsListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ErrorsListView_RetrieveVirtualItem);
            // 
            // _errorType
            // 
            this._errorType.Text = "Type";
            this._errorType.Width = 120;
            // 
            // _errorName
            // 
            this._errorName.Text = "Name";
            this._errorName.Width = 180;
            // 
            // _errorMessage
            // 
            this._errorMessage.Text = "Message";
            this._errorMessage.Width = 320;
            // 
            // _errorPath
            // 
            this._errorPath.Text = "Path";
            this._errorPath.Width = 136;
            // 
            // _imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList.Images.SetKeyName(0, "folder_error.png");
            this._imageList.Images.SetKeyName(1, "page_error.png");
            // 
            // _errorsLabel
            // 
            this._errorsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._errorsLabel.CausesValidation = false;
            this._errorsLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._errorsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this._errorsLabel.Location = new System.Drawing.Point(12, 360);
            this._errorsLabel.Name = "_errorsLabel";
            this._errorsLabel.Size = new System.Drawing.Size(760, 30);
            this._errorsLabel.TabIndex = 2;
            this._errorsLabel.Text = "No errors occured";
            this._errorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _progressLabel
            // 
            this._progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._progressLabel.Location = new System.Drawing.Point(12, 532);
            this._progressLabel.Name = "_progressLabel";
            this._progressLabel.Size = new System.Drawing.Size(760, 20);
            this._progressLabel.TabIndex = 5;
            this._progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DuplicatesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this._duplicatesLabel);
            this.Controls.Add(this._duplicatesListView);
            this.Controls.Add(this._errorsLabel);
            this.Controls.Add(this._errorsListView);
            this.Controls.Add(this._progressBar);
            this.Controls.Add(this._progressLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DuplicatesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Duplicate Finder";
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ProgressBar _progressBar;
        private Controls.ExplorerListView _duplicatesListView;
        private System.Windows.Forms.ColumnHeader _nameColumnHeader;
        private System.Windows.Forms.ColumnHeader _sizeColumnHeader;
        private System.Windows.Forms.ColumnHeader _dateColumnHeader;
        private System.Windows.Forms.ColumnHeader _typeColumnHeader;
        private System.Windows.Forms.ColumnHeader _pathColumnHeader;
        private System.Windows.Forms.Label _duplicatesLabel;
        private Controls.ExplorerListView _errorsListView;
        private System.Windows.Forms.ColumnHeader _errorType;
        private System.Windows.Forms.ColumnHeader _errorName;
        private System.Windows.Forms.ColumnHeader _errorPath;
        private System.Windows.Forms.ColumnHeader _errorMessage;
        private System.Windows.Forms.Label _errorsLabel;
        private System.Windows.Forms.Label _progressLabel;
        private System.Windows.Forms.ImageList _imageList;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _deletePermanentlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _propertiesToolStripMenuItem;
    }
}