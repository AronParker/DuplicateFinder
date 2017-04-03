using System;
using System.Runtime.InteropServices;

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
