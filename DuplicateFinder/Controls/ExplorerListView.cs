using System;
using System.Diagnostics;
using System.Windows.Forms;
using DuplicateFinder;

namespace DuplicateFinder.Controls
{
    public class ExplorerListView : ListView
    {
        public ExplorerListView()
        {
            DoubleBuffered = true;
            
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            var hResult = NativeMethods.SetWindowTheme(Handle, "explorer", null);

            Debug.Assert(hResult == 0);

            base.OnHandleCreated(e);
        }
    }
}
