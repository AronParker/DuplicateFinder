namespace DuplicateFinder.Forms
{
    partial class DuplicateFinderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicateFinderForm));
            this._directoriesListView = new DuplicateFinder.Controls.ExplorerListView();
            this._directoryNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._directoryPathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this._footerPanel = new System.Windows.Forms.Panel();
            this._quickScanCheckBox = new System.Windows.Forms.CheckBox();
            this._aboutButton = new System.Windows.Forms.Button();
            this._findButton = new System.Windows.Forms.Button();
            this._removeButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this._footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _directoriesListView
            // 
            this._directoriesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._directoriesListView.CausesValidation = false;
            this._directoriesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._directoryNameColumnHeader,
            this._directoryPathColumnHeader});
            this._directoriesListView.FullRowSelect = true;
            this._directoriesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._directoriesListView.Location = new System.Drawing.Point(12, 12);
            this._directoriesListView.Name = "_directoriesListView";
            this._directoriesListView.Size = new System.Drawing.Size(434, 193);
            this._directoriesListView.SmallImageList = this._imageList;
            this._directoriesListView.TabIndex = 0;
            this._directoriesListView.UseCompatibleStateImageBehavior = false;
            this._directoriesListView.View = System.Windows.Forms.View.Details;
            this._directoriesListView.ItemActivate += new System.EventHandler(this.DirectoriesListView_ItemActivate);
            this._directoriesListView.SelectedIndexChanged += new System.EventHandler(this.DirectoriesListView_SelectedIndexChanged);
            this._directoriesListView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DirectoriesListView_PreviewKeyDown);
            // 
            // _directoryNameColumnHeader
            // 
            this._directoryNameColumnHeader.Text = "Directory name";
            this._directoryNameColumnHeader.Width = 150;
            // 
            // _directoryPathColumnHeader
            // 
            this._directoryPathColumnHeader.Text = "Directory path";
            this._directoryPathColumnHeader.Width = 280;
            // 
            // _imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList.Images.SetKeyName(0, "folder.png");
            // 
            // _footerPanel
            // 
            this._footerPanel.BackColor = System.Drawing.SystemColors.Control;
            this._footerPanel.CausesValidation = false;
            this._footerPanel.Controls.Add(this._quickScanCheckBox);
            this._footerPanel.Controls.Add(this._aboutButton);
            this._footerPanel.Controls.Add(this._findButton);
            this._footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._footerPanel.Location = new System.Drawing.Point(0, 211);
            this._footerPanel.Name = "_footerPanel";
            this._footerPanel.Size = new System.Drawing.Size(584, 50);
            this._footerPanel.TabIndex = 3;
            // 
            // _quickScanCheckBox
            // 
            this._quickScanCheckBox.Location = new System.Drawing.Point(12, 12);
            this._quickScanCheckBox.Name = "_quickScanCheckBox";
            this._quickScanCheckBox.Size = new System.Drawing.Size(308, 26);
            this._quickScanCheckBox.TabIndex = 2;
            this._quickScanCheckBox.Text = "Quick scan";
            this._quickScanCheckBox.UseVisualStyleBackColor = true;
            // 
            // _aboutButton
            // 
            this._aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._aboutButton.CausesValidation = false;
            this._aboutButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._aboutButton.Image = global::DuplicateFinder.Properties.Resources.information;
            this._aboutButton.Location = new System.Drawing.Point(452, 12);
            this._aboutButton.Name = "_aboutButton";
            this._aboutButton.Size = new System.Drawing.Size(120, 26);
            this._aboutButton.TabIndex = 1;
            this._aboutButton.Text = "About";
            this._aboutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._aboutButton.UseVisualStyleBackColor = true;
            this._aboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // _findButton
            // 
            this._findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._findButton.CausesValidation = false;
            this._findButton.Enabled = false;
            this._findButton.Image = global::DuplicateFinder.Properties.Resources.zoom;
            this._findButton.Location = new System.Drawing.Point(326, 12);
            this._findButton.Name = "_findButton";
            this._findButton.Size = new System.Drawing.Size(120, 26);
            this._findButton.TabIndex = 0;
            this._findButton.Text = "Find duplicates";
            this._findButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._findButton.UseVisualStyleBackColor = true;
            this._findButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // _removeButton
            // 
            this._removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._removeButton.CausesValidation = false;
            this._removeButton.Image = global::DuplicateFinder.Properties.Resources.folder_delete;
            this._removeButton.Location = new System.Drawing.Point(452, 58);
            this._removeButton.Name = "_removeButton";
            this._removeButton.Size = new System.Drawing.Size(120, 40);
            this._removeButton.TabIndex = 2;
            this._removeButton.Text = "Remove directory";
            this._removeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._removeButton.UseVisualStyleBackColor = true;
            this._removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // _addButton
            // 
            this._addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._addButton.CausesValidation = false;
            this._addButton.Image = global::DuplicateFinder.Properties.Resources.folder_add;
            this._addButton.Location = new System.Drawing.Point(452, 12);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(120, 40);
            this._addButton.TabIndex = 1;
            this._addButton.Text = "Add directory";
            this._addButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DuplicateFinderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this._footerPanel);
            this.Controls.Add(this._removeButton);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._directoriesListView);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DuplicateFinderForm";
            this.Text = "Duplicate Finder";
            this._footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ExplorerListView _directoriesListView;
        private System.Windows.Forms.ColumnHeader _directoryNameColumnHeader;
        private System.Windows.Forms.ColumnHeader _directoryPathColumnHeader;
        private System.Windows.Forms.ImageList _imageList;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _removeButton;
        private System.Windows.Forms.Panel _footerPanel;
        private System.Windows.Forms.Button _aboutButton;
        private System.Windows.Forms.Button _findButton;
        private System.Windows.Forms.CheckBox _quickScanCheckBox;
    }
}