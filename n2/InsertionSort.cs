using System;
using System.Collections.Generic;

namespace cs_sort.n2
{
    public static class InsertionSortClass
    {
        public static void InsertionSort<T>(this IList<T> list) where T : IComparable<T>
        {
            for (int i = 1; i < list.Count; i++)
            {
                var v = list[i];
                int j = i;
                while (j > 0 && v.CompareTo(list[j - 1]) < 0) 
                {
                    list[j] = list[j - 1];
                    j--;
                }
                list[j] = v;
            }
        }
    }
}
