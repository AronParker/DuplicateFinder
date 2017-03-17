using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuplicateFinder.Controls;
using static DuplicateFinder.NativeMethods;

namespace DuplicateFinder.Forms
{
    public partial class DuplicateFinderForm : Form
    {
        public DuplicateFinderForm()
        {
            InitializeComponent();
            DirectoriesListView_SelectedIndexChanged(this, EventArgs.Empty);

#if DEBUG
            AddPath(@"C:\Users\Aron\Desktop\1");
#endif
        }

        private void AddPath(string path)
        {
            var dir = new DirectoryInfo(path);
            var lvi = new ListViewItem(new[] { dir.Name, dir.FullName }, 0)
            {
                Tag = dir
            };

            _directoriesListView.Items.Add(lvi);
            _findButton.Enabled = true;
        }

        private void RemoveSelectedDirectories()
        {
            var selectedItems = _directoriesListView.SelectedIndices;

            for (var i = selectedItems.Count - 1; i >= 0; i--)
                _directoriesListView.Items.RemoveAt(selectedItems[i]);

            _findButton.Enabled = _directoriesListView.Items.Count > 0;
        }

        private void DirectoriesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            _removeButton.Enabled = _directoriesListView.SelectedItems.Count > 0;
        }

        private void DirectoriesListView_ItemActivate(object sender, EventArgs e)
        {
            var selectedItems = _directoriesListView.SelectedItems;

            if (selectedItems.Count != 1)
                return;

            var dir = (DirectoryInfo)selectedItems[0].Tag;

            using (Process.Start(dir.FullName))
            {
            }
        }

        private void DirectoriesListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                RemoveSelectedDirectories();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                AddPath(fbd.SelectedPath);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedDirectories();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            var dirs = _directoriesListView.Items.Cast<ListViewItem>().Select(x => (DirectoryInfo)x.Tag).ToArray();

            using (var duplicatesForm = new DuplicatesForm(dirs, _quickScanCheckBox.Checked))
                duplicatesForm.ShowDialog();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Aron Parker", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
