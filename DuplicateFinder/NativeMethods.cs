﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace DuplicateFinder
{
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int memcmp(byte[] buf1, byte[] buf2, UIntPtr count);

        [DllImport("uxtheme.dll")]
        public static extern int SetWindowTheme(IntPtr hWnd,
                                                [MarshalAs(UnmanagedType.LPWStr)] string appName,
                                                [MarshalAs(UnmanagedType.LPWStr)] string partList);
    }
}
