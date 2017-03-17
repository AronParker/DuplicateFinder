using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFinder.SafeHandles
{
    public class SafeItemIDListHandle : SafeHandle
    {
        public SafeItemIDListHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            NativeMethods.ILFree(handle);
            return true;
        }
    }
}
