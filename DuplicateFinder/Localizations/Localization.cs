using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DuplicateFinder.Localizations
{
    public static class Localization
    {
        public static string GetPlural(int count, string word)
        {
            if (word == null)
                throw new ArgumentNullException(nameof(word));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (count == 1)
                return "1 " + word;

            return count.ToString(NumberFormatInfo.InvariantInfo) + " " + word + "s";
        }

        public static string GetPlural(long count, string word)
        {
            if (word == null)
                throw new ArgumentNullException(nameof(word));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (count == 1)
                return "1 " + word;

            return count.ToString(NumberFormatInfo.InvariantInfo) + " " + word + "s";
        }

        public static string GetHumanReadableFileSize(long sizeInBytes)
        {
            if (sizeInBytes < 0)
                throw new ArgumentOutOfRangeException(nameof(sizeInBytes));

            const long BytesPerKilobyte = 1000;
            const long BytesPerMegabyte = BytesPerKilobyte * 1000;
            const long BytesPerGigabyte = BytesPerMegabyte * 1000;
            const long BytesPerTerabyte = BytesPerGigabyte * 1000;
            const long BytesPerPetabyte = BytesPerTerabyte * 1000;
            const long BytesPerExabyte = BytesPerPetabyte * 1000;

            if (sizeInBytes == 1)
                return "1 Byte";

            if (sizeInBytes < BytesPerKilobyte)
                return sizeInBytes.ToString("D", NumberFormatInfo.InvariantInfo) + " Bytes";

            if (sizeInBytes < BytesPerMegabyte)
            {
                var sizeInKB = (double)sizeInBytes / BytesPerKilobyte;
                return sizeInKB.ToString("F2", NumberFormatInfo.InvariantInfo) + " KB";
            }

            if (sizeInBytes < BytesPerGigabyte)
            {
                var sizeInMB = (double)sizeInBytes / BytesPerMegabyte;
                return sizeInMB.ToString("F2", NumberFormatInfo.InvariantInfo) + " MB";
            }

            if (sizeInBytes < BytesPerTerabyte)
            {
                var sizeInGB = (double)sizeInBytes / BytesPerGigabyte;
                return sizeInGB.ToString("F2", NumberFormatInfo.InvariantInfo) + " GB";
            }

            if (sizeInBytes < BytesPerPetabyte)
            {
                var sizeInTB = (double)sizeInBytes / BytesPerTerabyte;
                return sizeInTB.ToString("F2", NumberFormatInfo.InvariantInfo) + " TB";
            }

            if (sizeInBytes < BytesPerExabyte)
            {
                var sizeInPB = (double)sizeInBytes / BytesPerPetabyte;
                return sizeInPB.ToString("F2", NumberFormatInfo.InvariantInfo) + " PB";
            }

            var sizeInEB = (double)sizeInBytes / BytesPerExabyte;
            return sizeInEB.ToString("F2", NumberFormatInfo.InvariantInfo) + " EB";
        }

        public static string GetHumanReadableTimeSpan(TimeSpan ts)
        {
            var ticks = ts.Ticks;

            if (ticks < TimeSpan.TicksPerSecond)
                return "less than a second";

            if (ticks < TimeSpan.TicksPerMinute)
            {
                var seconds = (ticks / TimeSpan.TicksPerSecond);

                return GetPlural(seconds, "second");
            }

            if (ticks < TimeSpan.TicksPerHour)
            {
                var minutes = ticks / TimeSpan.TicksPerMinute;
                var seconds = ticks % TimeSpan.TicksPerMinute / TimeSpan.TicksPerSecond;

                return GetPlural(minutes, "minute") + " " + GetPlural(seconds, "second");
            }

            if (ticks < TimeSpan.TicksPerDay)
            {
                var hours = ticks / TimeSpan.TicksPerHour;
                var minutes = ticks % TimeSpan.TicksPerHour / TimeSpan.TicksPerMinute;

                return GetPlural(hours, "hour") + " " + GetPlural(minutes, "minute");
            }

            {
                var days = ticks / TimeSpan.TicksPerDay;
                var hours = ticks % TimeSpan.TicksPerDay / TimeSpan.TicksPerHour;

                return GetPlural(days, "day") + " " + GetPlural(hours, "hour");
            }
        }
    }
}
