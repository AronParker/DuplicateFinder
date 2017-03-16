using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        private IntPtr _sysImageList = IntPtr.Zero;

        public DuplicateFinderForm()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            AddFile(@"D:\Pictures");
            /*
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    AddFile(ofd.FileName);
                }
            }*/
        }

        private void AddFile(string path)
        {
            Debug.Assert(_directoriesListView.IsHandleCreated);

            var sfi = default(SHFILEINFO);
            var sysImageList = SHGetFileInfo(path, 0, ref sfi, (uint)Marshal.SizeOf<SHFILEINFO>(), SHGFI_DISPLAYNAME | SHGFI_SYSICONINDEX);

            if (sysImageList == IntPtr.Zero)
            {
                // uh oh
            }
            else if (_sysImageList != sysImageList)
            {
                var oldImageList = SendMessage(_directoriesListView.Handle, LVM_SETIMAGELIST, new IntPtr(LVSIL_SMALL), sysImageList);
                Debug.Assert(oldImageList == IntPtr.Zero);
                _sysImageList = sysImageList;
            }

            _directoriesListView.Items.Add(sfi.szDisplayName, sfi.iIcon);
        }

        private void DuplicateFinderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
