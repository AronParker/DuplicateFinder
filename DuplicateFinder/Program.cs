using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DuplicateFinder.Forms;
using static DuplicateFinder.NativeMethods;

namespace DuplicateFinder
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DuplicateFinderForm());
        }
    }
}
