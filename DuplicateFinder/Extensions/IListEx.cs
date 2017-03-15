using System.Collections.Generic;

namespace DuplicateFinder.Extensions
{
    internal static class IListEx
    {
        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
