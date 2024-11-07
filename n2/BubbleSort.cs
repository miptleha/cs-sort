using System;
using System.Collections.Generic;

namespace cs_sort
{
    public static class BubbleSort
    {
        /// <summary>
        /// Sequential swapping of adjacent elements
        /// </summary>
        public static void SortBubble<T>(this IList<T> list) where T : IComparable<T>
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                bool sorted = true;
                for (int j = 0; j < i; j++)
                {
                    var v = list[j];
                    if (list[j + 1].CompareTo(v) < 0)
                    {
                        sorted = false;
                        list[j] = list[j + 1];
                        list[j + 1] = v;
                    }
                }
                if (sorted)
                    break;
            }
        }
    }
}
