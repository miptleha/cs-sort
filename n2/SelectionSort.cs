using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sort.n2
{
    public static class SelectionSortClass
    {
        /// <summary>
        /// Looking for the minimum element in the unsorted part
        /// </summary>
        public static void SelectionSort<T>(this IList<T> list) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                var min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[min].CompareTo(list[j]) > 0)
                        min = j;
                }
                var v = list[min];
                list[min] = list[i];
                list[i] = v;
            }
        }
    }
}
