﻿using System;
using System.Runtime.InteropServices;
using System.Security;
using DuplicateFinder.SafeHandles;

namespace DuplicateFinder
{
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {
        public const uint SHGFI_DISPLAYNAME = 0x00000200;
        public const uint SHGFI_TYPENAME = 0x00000400;
        public const uint SHGFI_SYSICONINDEX = 0x00004000;

        public const uint LVM_SETIMAGELIST = 0x1003;
        public const int LVSIL_SMALL = 1;

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int memcmp(byte[] buf1, byte[] buf2, UIntPtr count);

        [DllImport("UxTheme.dll", ExactSpelling = true)]
        public static extern int SetWindowTheme(IntPtr hWnd,
                                                [MarshalAs(UnmanagedType.LPWStr)] string appName,
                                                [MarshalAs(UnmanagedType.LPWStr)] string partList);

        [DllImport("Shell32.dll", EntryPoint = "ILCreateFromPathW")]
        public static extern SafeItemIDListHandle ILCreateFromPath([MarshalAs(UnmanagedType.LPWStr)] string pszPath);

        [DllImport("Shell32.dll", ExactSpelling = true)]
        public static extern void ILFree(IntPtr pidl);

        [DllImport("Shell32.dll", ExactSpelling = true)]
        public static extern int SHOpenFolderAndSelectItems(SafeItemIDListHandle pidlFolder,
                                                            uint cidl,
                                                            IntPtr apidl,
                                                            uint dwFlags);

        [DllImport("Shell32.dll", EntryPoint = "SHGetFileInfoW")]
        public static extern IntPtr SHGetFileInfo([MarshalAs(UnmanagedType.LPTStr)] string pszPath,
                                                  uint dwFileAttributes,
                                                  ref SHFILEINFO psfi,
                                                  uint cbFileInfo,
                                                  uint uFlags);
        
        [DllImport("User32.dll", EntryPoint = "SendMessageW", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd,
                                                uint msg,
                                                IntPtr wParam,
                                                IntPtr lParam);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }
    }
}
