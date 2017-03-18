using System;
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

        public static string GetHumanReadableSize(ulong sizeInBytes)
        {
            const ulong BytesPerKilobyte = 1000;
            const ulong BytesPerMegabyte = BytesPerKilobyte * 1000;
            const ulong BytesPerGigabyte = BytesPerMegabyte * 1000;
            const ulong BytesPerTerabyte = BytesPerGigabyte * 1000;
            const ulong BytesPerPetabyte = BytesPerTerabyte * 1000;
            const ulong BytesPerExabyte = BytesPerPetabyte * 1000;

            if (sizeInBytes == 1)
                return "1 Byte";

            if (sizeInBytes < BytesPerKilobyte)
                return $"{sizeInBytes:D} Bytes";

            if (sizeInBytes < BytesPerMegabyte)
            {
                var sizeInKB = (double)sizeInBytes / BytesPerKilobyte;
                return $"{sizeInKB:F2} KB";
            }

            if (sizeInBytes < BytesPerGigabyte)
            {
                var sizeInMB = (double)sizeInBytes / BytesPerMegabyte;
                return $"{sizeInMB:F2} MB";
            }

            if (sizeInBytes < BytesPerTerabyte)
            {
                var sizeInGB = (double)sizeInBytes / BytesPerGigabyte;
                return $"{sizeInGB:F2} GB";
            }

            if (sizeInBytes < BytesPerPetabyte)
            {
                var sizeInTB = (double)sizeInBytes / BytesPerTerabyte;
                return $"{sizeInTB:F2} TB";
            }

            if (sizeInBytes < BytesPerExabyte)
            {
                var sizeInPB = (double)sizeInBytes / BytesPerPetabyte;
                return $"{sizeInPB:F2} PB";
            }

            var sizeInEB = (double)sizeInBytes / BytesPerExabyte;
            return $"{sizeInEB:F2} EB";
        }
    }
}
