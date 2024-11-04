using System;
using System.Collections.Generic;

namespace cs_sort.n2
{
    public static class BubbleSortClass
    {
        public static void BubbleSort<T>(this IList<T> list) where T : IComparable<T>
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                bool sorted = true;
                for (int j = 0; j < i; j++)
                {
                    if (list[j + 1].CompareTo(list[j]) < 0)
                    {
                        sorted = false;
                        var v = list[j];
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
