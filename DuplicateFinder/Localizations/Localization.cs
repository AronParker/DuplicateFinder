using System;
using static System.FormattableString;

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

            return Invariant($"{count} {word}s");
        }

        public static string GetPlural(long count, string word)
        {
            if (word == null)
                throw new ArgumentNullException(nameof(word));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (count == 1)
                return "1 " + word;

            return Invariant($"{count} {word}s");
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
                return Invariant($"{sizeInBytes:D} Bytes");

            if (sizeInBytes < BytesPerMegabyte)
            {
                var sizeInKB = (double)sizeInBytes / BytesPerKilobyte;
                return Invariant($"{sizeInKB:F2} KB");
            }

            if (sizeInBytes < BytesPerGigabyte)
            {
                var sizeInMB = (double)sizeInBytes / BytesPerMegabyte;
                return Invariant($"{sizeInMB:F2} MB");
            }

            if (sizeInBytes < BytesPerTerabyte)
            {
                var sizeInGB = (double)sizeInBytes / BytesPerGigabyte;
                return Invariant($"{sizeInGB:F2} GB");
            }

            if (sizeInBytes < BytesPerPetabyte)
            {
                var sizeInTB = (double)sizeInBytes / BytesPerTerabyte;
                return Invariant($"{sizeInTB:F2} TB");
            }

            if (sizeInBytes < BytesPerExabyte)
            {
                var sizeInPB = (double)sizeInBytes / BytesPerPetabyte;
                return Invariant($"{sizeInPB:F2} PB");
            }

            var sizeInEB = (double)sizeInBytes / BytesPerExabyte;
            return Invariant($"{sizeInEB:F2} EB");
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
