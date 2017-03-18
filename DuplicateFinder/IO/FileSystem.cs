﻿using System;
using System.Globalization;
using System.IO;
using System.Security;
using DuplicateFinder.Extensions;

namespace DuplicateFinder.IO
{
    internal static class FileSystem
    {
        public static FileStream OpenFile(FileInfo file)
        {
            try
            {
                return new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, 1, FileOptions.SequentialScan);
            }
            catch (Exception ex) when (ex is IOException ||
                                       ex is UnauthorizedAccessException ||
                                       ex is SecurityException)
            {
                throw new FileSystemInfoException(file, ex);
            }
        }

        public static void ReadFile(FileInfo file, FileStream fs, byte[] buffer, int offset, int count)
        {
            try
            {
                fs.SafeRead(buffer, offset, count);
            }
            catch (Exception ex) when (ex is IOException ||
                                       ex is UnauthorizedAccessException ||
                                       ex is SecurityException)
            {
                throw new FileSystemInfoException(file, ex);
            }
        }
    }
}
