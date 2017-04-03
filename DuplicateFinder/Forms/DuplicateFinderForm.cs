using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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
            AddDirectory(new DirectoryInfo(@"C:\Users\Aron\Desktop\1"));
#endif
        }
        
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
                drgevent.Effect = DragDropEffects.Link;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            _directoriesListView.BeginUpdate();

            foreach (var path in (string[])drgevent.Data.GetData(DataFormats.FileDrop))
                if (Directory.Exists(path))
                    AddDirectory(new DirectoryInfo(path));

            _directoriesListView.EndUpdate();
        }

        private void AddDirectory(DirectoryInfo newDir)
        {
            if (DirectoryAlreadyCovered(newDir))
            {
                MessageBox.Show("The folder you selected is already contained within another folder that is already added. Please remove the existing folder first or select a folder outside of the existing folders.",
                                "Invalid folder",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            RemoveDirectoriesThatThisCovers(newDir);

            var lvi = new ListViewItem(new[] { newDir.Name, newDir.FullName }, 0)
            {
                Tag = newDir
            };

            _directoriesListView.Items.Add(lvi);
            _findButton.Enabled = true;
        }

        private bool DirectoryAlreadyCovered(DirectoryInfo newDir)
        {
            foreach (var dir in _directoriesListView.Items.Cast<ListViewItem>().Select(x => (DirectoryInfo)x.Tag))
                if (newDir.FullName.StartsWith(dir.FullName, StringComparison.OrdinalIgnoreCase))
                    return true;

            return false;
        }

        private void RemoveDirectoriesThatThisCovers(DirectoryInfo newDir)
        {
            foreach (var item in _directoriesListView.Items.Cast<ListViewItem>())
            {
                var dir = (DirectoryInfo)item.Tag;

                if (dir.FullName.StartsWith(newDir.FullName, StringComparison.OrdinalIgnoreCase))
                    item.Remove();
            }
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

        private void DirectoriesListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                RemoveSelectedDirectories();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var fbd = new IFileOpenDialog();
            fbd.SetOptions(FOS.PICKFOLDERS | FOS.FORCEFILESYSTEM | FOS.ALLOWMULTISELECT | FOS.PATHMUSTEXIST | FOS.FILEMUSTEXIST);
            var hr = fbd.Show(Handle);

            if (hr >= 0)
            {
                fbd.GetResults(out var results);
                results.GetCount(out var count);

                for (var i = 0U; i < count; i++)
                {
                    results.GetItemAt(i, out var si);
                    si.GetDisplayName(SIGDN.FILESYSPATH, out var fullPath);
                    AddDirectory(new DirectoryInfo(fullPath));
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedDirectories();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            var dirs = _directoriesListView.Items.Cast<ListViewItem>().Select(x => (DirectoryInfo)x.Tag).ToArray();

            using (var duplicatesForm = new DuplicatesForm(dirs))
                duplicatesForm.ShowDialog();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Aron Parker", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
