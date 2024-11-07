using System;
using System.Collections.Generic;

namespace cs_sort
{
    public static class InsertionSort
    {
        /// <summary>
        /// Adding a card to the sorted deck
        /// </summary>
        public static void SortInsertion<T>(this IList<T> list) where T : IComparable<T>
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
