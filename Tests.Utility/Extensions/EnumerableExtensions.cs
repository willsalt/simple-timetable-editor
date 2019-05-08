using System;
using System.Collections.Generic;

namespace Tests.Utility.Extensions
{
    public static class EnumerableExtensions
    {
        public static int MaxIndex<T>(this IEnumerable<T> sequence) where T : IComparable<T>
        {
            int maxIndex = -1;
            T maxValue = default(T);

            int index = 0;
            foreach (T item in sequence)
            {
                if (item.CompareTo(maxValue) > 0 || maxIndex == -1)
                {
                    maxIndex = index;
                    maxValue = item;
                }
                index++;
            }
            return maxIndex;
        }
    }
}
