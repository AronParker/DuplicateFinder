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
using static DuplicateFinder.NativeMethods;

namespace DuplicateFinder.Forms
{
    public partial class DuplicatesForm : Form
    {
        private DirectoryInfo[] _dirs;
        private bool _quickScan;

        private IntPtr _sysImageList = IntPtr.Zero;

        
        public DuplicatesForm(DirectoryInfo[] dirs, bool quickScan)
        {
            if (dirs == null)
                throw new ArgumentNullException(nameof(dirs));

            _dirs = dirs;
            _quickScan = quickScan;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {

        }

        private void AddFile(string path)
        {
            Debug.Assert(_duplicatesListView.IsHandleCreated);

            var sfi = default(SHFILEINFO);
            var sysImageList = SHGetFileInfo(path, 0, ref sfi, (uint)Marshal.SizeOf<SHFILEINFO>(), SHGFI_DISPLAYNAME | SHGFI_TYPENAME | SHGFI_SYSICONINDEX);

            if (sysImageList == IntPtr.Zero)
            {
                // uh oh
            }
            else if (_sysImageList != sysImageList)
            {
                var oldImageList = SendMessage(_duplicatesListView.Handle, LVM_SETIMAGELIST, new IntPtr(LVSIL_SMALL), sysImageList);
                Debug.Assert(oldImageList == IntPtr.Zero);
                _sysImageList = sysImageList;
            }

            _duplicatesListView.Items.Add(sfi.szDisplayName, sfi.iIcon);
        }
    }
}
