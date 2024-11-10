using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sort
{
    public static class HeapSort
    {
        /// <summary>
        /// Sorting using a binary heap implemented on an array
        /// </summary>
        public static void SortHeap<T>(this IList<T> list) where T : IComparable<T>
        {
            List<T> heap = new List<T>();
            foreach (T item in list)
                HeapAdd(heap, item);

            int i = 0;
            while (heap.Count > 0)
                list[i++] = PopMin(heap);
        }

        static void HeapAdd<T>(IList<T> heap, T key) where T : IComparable<T>
        {
            heap.Add(key);
            SiftUp(heap, heap.Count);
        }

        static void SiftUp<T>(IList<T> heap, int index) where T : IComparable<T>
        {
            if (index == 1)
                return;

            int p = index / 2;
            if (heap[p - 1].CompareTo(heap[index - 1]) > 0)
            {
                var tmp = heap[p - 1];
                heap[p - 1] = heap[index - 1];
                heap[index - 1] = tmp;
                SiftUp(heap, p);
            }
        }

        static T PopMin<T>(IList<T> heap) where T : IComparable<T>
        {
            var v = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            SiftDown(heap, 1);
            return v;
        }

        static void SiftDown<T>(IList<T> heap, int index) where T : IComparable<T>
        {
            var l = index * 2;
            var r = index * 2 + 1;
            if (l >= heap.Count + 1)
                return;

            int m = l;
            if (r < heap.Count + 1 && heap[r - 1].CompareTo(heap[l - 1]) < 0)
                m = r;

            if (heap[index - 1].CompareTo(heap[m - 1]) > 0)
            {
                var tmp = heap[m - 1];
                heap[m - 1] = heap[index - 1];
                heap[index - 1] = tmp;
                SiftDown(heap, m);
            }
        }
    }
}
