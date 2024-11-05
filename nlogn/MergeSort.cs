using System;
using System.Collections.Generic;
using System.Linq;

namespace cs_sort
{
    public static class MergeSortClass
    {
        /// <summary>
        /// Split, recursively sort, then merge. Doesn't change the original list.
        /// </summary>
        public static T[] MergeSort<T>(this IList<T> list) where T : IComparable<T>
        {
            if (list.Count <= 1)
                return list.ToArray();

            var left = MergeSort(list.Take(list.Count / 2).ToArray());
            var right = MergeSort(list.Skip(list.Count / 2).ToArray());
            
            var res = new T[list.Count];
            int l = 0, r = 0, k = 0;
            while (l < left.Length && r < right.Length)
            {
                if (left[l].CompareTo(right[r]) <= 0)
                    res[k++] = left[l++];
                else
                    res[k++] = right[r++];
            }
            while (l < left.Length)
                res[k++] = left[l++];
            while (r < right.Length)
                res[k++] = right[r++];

            return res;
        }
    }
}
