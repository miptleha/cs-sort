using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sort
{
    public static class QuickSortClass
    {
        /// <summary>
        /// Split by pivot element into 3 parts, recursive sorting of parts
        /// </summary>
        public static void SortQuick<T>(this IList<T> list) where T : IComparable<T>
        {
            if (list.Count < 2)
                return;

            T pivot = Median(list[0], list[list.Count - 1], list[list.Count / 2]);
            var arrays = Partition(list, pivot);
            var left = arrays[0];
            var center = arrays[1];
            var right = arrays[2];

            SortQuick(left);
            SortQuick(right);
            int k = 0;
            for (int i = 0; i < left.Count; i++)
                list[k++] = left[i];
            for (int i = 0; i < center.Count; i++)
                list[k++] = center[i];
            for (int i = 0; i < right.Count; i++)
                list[k++] = right[i];
        }

        static T Median<T>(T a, T b, T c)  where T : IComparable<T>
        {
            return new[] { a, b, c }.OrderBy(x => x).ElementAt(1);
        }

        static List<T>[] Partition<T>(IList<T> list, T pivot) where T : IComparable<T>
        {
            var left = new List<T>();
            var center = new List<T>();
            var right = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                var v = list[i];
                if (v.CompareTo(pivot) < 0)
                    left.Add(v);
                else if (v.CompareTo(pivot) > 0)
                    right.Add(v);
                else
                    center.Add(v);
            }
            return new[] { left, center, right };
        }
    }
}
