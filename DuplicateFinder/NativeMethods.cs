using System;
using System.Runtime.InteropServices;
using System.Security;
using DuplicateFinder.SafeHandles;

namespace DuplicateFinder
{
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {
        public const uint LVM_SETIMAGELIST = 0x1003;

        [Flags]
        public enum FOS : uint
        {
            OVERWRITEPROMPT = 0x2,
            STRICTFILETYPES = 0x4,
            NOCHANGEDIR = 0x8,
            PICKFOLDERS = 0x20,
            FORCEFILESYSTEM = 0x40,
            ALLNONSTORAGEITEMS = 0x80,
            NOVALIDATE = 0x100,
            ALLOWMULTISELECT = 0x200,
            PATHMUSTEXIST = 0x800,
            FILEMUSTEXIST = 0x1000,
            CREATEPROMPT = 0x2000,
            SHAREAWARE = 0x4000,
            NOREADONLYRETURN = 0x8000,
            NOTESTFILECREATE = 0x10000,
            HIDEMRUPLACES = 0x20000,
            HIDEPINNEDPLACES = 0x40000,
            NODEREFERENCELINKS = 0x100000,
            OKBUTTONNEEDSINTERACTION = 0x200000,
            DONTADDTORECENT = 0x2000000,
            FORCESHOWHIDDEN = 0x10000000,
            DEFAULTNOMINIMODE = 0x20000000,
            FORCEPREVIEWPANEON = 0x40000000,
            SUPPORTSTREAMABLEITEMS = 0x80000000
        }

        public enum LVSIL
        {
            NORMAL = 0,
            SMALL = 1,
            STATE = 2,
            GROUPHEADER = 3
        }

        [Flags]
        public enum SEE_MASK : uint
        {
            DEFAULT = 0x00000000,
            CLASSNAME = 0x00000001,
            CLASSKEY = 0x00000003,
            IDLIST = 0x00000004,
            INVOKEIDLIST = 0x0000000c,
            HOTKEY = 0x00000020,
            NOCLOSEPROCESS = 0x00000040,
            CONNECTNETDRV = 0x00000080,
            NOASYNC = 0x00000100,
            DOENVSUBST = 0x00000200,
            FLAG_NO_UI = 0x00000400,
            UNICODE = 0x00004000,
            NO_CONSOLE = 0x00008000,
            ASYNCOK = 0x00100000,
            HMONITOR = 0x00200000,
            NOZONECHECKS = 0x00800000,
            NOQUERYCLASSSTORE = 0x01000000,
            WAITFORINPUTIDLE = 0x02000000,
            FLAG_LOG_USAGE = 0x04000000
        }

        [Flags]
        public enum SHGFI : uint
        {
            ICON = 0x000000100,
            DISPLAYNAME = 0x000000200,
            TYPENAME = 0x000000400,
            ATTRIBUTES = 0x000000800,
            ICONLOCATION = 0x000001000,
            EXETYPE = 0x000002000,
            SYSICONINDEX = 0x000004000,
            LINKOVERLAY = 0x000008000,
            SELECTED = 0x000010000,
            ATTR_SPECIFIED = 0x000020000,
            LARGEICON = 0x000000000,
            SMALLICON = 0x000000001,
            OPENICON = 0x000000002,
            SHELLICONSIZE = 0x000000004,
            PIDL = 0x000000008,
            USEFILEATTRIBUTES = 0x000000010,
            ADDOVERLAYS = 0x000000020,
            OVERLAYINDEX = 0x000000040
        }

        public enum SIGDN
        {
            NORMALDISPLAY = 0,
            PARENTRELATIVEPARSING = unchecked((int) unchecked((int)0x80018001)),
            DESKTOPABSOLUTEPARSING = unchecked((int) 0x80028000),
            PARENTRELATIVEEDITING = unchecked((int) 0x80031001),
            DESKTOPABSOLUTEEDITING = unchecked((int) 0x8004c000),
            FILESYSPATH = unchecked((int) 0x80058000),
            URL = unchecked((int) 0x80068000),
            PARENTRELATIVEFORADDRESSBAR = unchecked((int) 0x8007c001),
            PARENTRELATIVE = unchecked((int) 0x80080001),
            PARENTRELATIVEFORUI = unchecked((int) 0x80094001)
        }

        public enum SW
        {
            HIDE = 0,
            SHOWNORMAL = 1,
            NORMAL = 1,
            SHOWMINIMIZED = 2,
            SHOWMAXIMIZED = 3,
            MAXIMIZE = 3,
            SHOWNOACTIVATE = 4,
            SHOW = 5,
            MINIMIZE = 6,
            SHOWMINNOACTIVE = 7,
            SHOWNA = 8,
            RESTORE = 9,
            SHOWDEFAULT = 10,
            FORCEMINIMIZE = 11,
            MAX = 11
        }

        [ComImport, Guid("d57c7288-d4ad-4768-be02-9d969532d960"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(FileOpenDialog))]
        public interface IFileOpenDialog
        {
            [PreserveSig]
            int Show(IntPtr hwndOwner);
            void SetFileTypes(uint cFileTypes, IntPtr rgFilterSpec);
            void SetFileTypeIndex(uint iFileType);
            void GetFileTypeIndex(out uint piFileType);
            void Advise(IntPtr pfde, out uint pdwCookie);
            void Unadvise(uint dwCookie);
            void SetOptions(FOS fos);
            void GetOptions(out FOS pfos);
            void SetDefaultFolder(IShellItem psi);
            void SetFolder(IShellItem psi);
            void GetFolder(out IShellItem ppsi);
            void GetCurrentSelection(out IShellItem ppsi);
            void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);
            void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);
            void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);
            void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);
            void GetResult(out IShellItem ppsi);
            void AddPlace(IShellItem psi, int fdcp);
            void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);
            void Close(int hr);
            void SetClientGuid(IntPtr guid);
            void ClearClientData();
            void SetFilter(IntPtr pFilter);
            void GetResults(out IShellItemArray ppenum);
            void GetSelectedItems(out IShellItemArray ppsai);
        }

        [ComImport, Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IShellItem
        {
            void BindToHandler(IntPtr pbc, IntPtr bhid, IntPtr riid, out IntPtr ppv);
            void GetParent(out IShellItem ppsi);
            void GetDisplayName(SIGDN sigdnName, [MarshalAs(UnmanagedType.LPWStr)] out string ppszName);
            void GetAttributes(uint sfgaoMask, out uint psfgaoAttribs);
            void Compare(IShellItem psi, uint hint, out int piOrder);
        }

        [ComImport, Guid("B63EA76D-1F85-456F-A19C-48159EFA858B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IShellItemArray
        {
            void BindToHandler(IntPtr pbc, IntPtr bhid, IntPtr riid, IntPtr ppvOut);            
            void GetPropertyStore(int Flags, IntPtr riid, IntPtr ppv);            
            void GetPropertyDescriptionList(IntPtr keyType, IntPtr riid, IntPtr ppv);            
            void GetAttributes(int AttribFlags, uint sfgaoMask, out uint psfgaoAttribs);            
            void GetCount(out uint pdwNumItems);            
            void GetItemAt(uint dwIndex, out IShellItem ppsi);            
            void EnumItems(IntPtr ppenumShellItems);
        }

        [DllImport("Shell32.dll", ExactSpelling = true)]
        public static extern void ILFree(IntPtr pidl);
        
        [DllImport("User32.dll", EntryPoint = "SendMessageW", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd,
                                                uint msg,
                                                IntPtr wParam,
                                                IntPtr lParam);

        [DllImport("UxTheme.dll", ExactSpelling = true)]
        public static extern int SetWindowTheme(IntPtr hWnd,
                                                [MarshalAs(UnmanagedType.LPWStr)] string appName,
                                                [MarshalAs(UnmanagedType.LPWStr)] string partList);

        [DllImport("Shell32.dll", EntryPoint = "SHGetFileInfoW")]
        public static extern IntPtr SHGetFileInfo([MarshalAs(UnmanagedType.LPTStr)] string pszPath,
                                                  uint dwFileAttributes,
                                                  ref SHFILEINFO psfi,
                                                  uint cbFileInfo,
                                                  SHGFI uFlags);

        [DllImport("Shell32.dll", ExactSpelling = true)]
        public static extern int SHOpenFolderAndSelectItems(SafeItemIDListHandle pidlFolder,
                                                            uint cidl,
                                                            IntPtr apidl,
                                                            uint dwFlags);

        [DllImport("Shell32.dll", ExactSpelling = true)]
        public static extern int SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string pszName,
                                                    IntPtr pbc,
                                                    out SafeItemIDListHandle ppidl,
                                                    uint sfgaoIn,
                                                    IntPtr psfgaoOut);

        [DllImport("Shell32.dll", EntryPoint = "ShellExecuteExW", SetLastError = true)]
        public static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO pExecInfo);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int memcmp(byte[] buf1, byte[] buf2, UIntPtr count);

        [StructLayout(LayoutKind.Sequential)]
        public struct SHELLEXECUTEINFO
        {
            public uint cbSize;
            public SEE_MASK fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public SW nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

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

        [ComImport, Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7")]
        public class FileOpenDialog
        {
        }
    }
}
