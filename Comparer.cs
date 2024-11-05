using System;
using System.Collections.Generic;

namespace cs_sort
{
    public static class Comparer
    {
        public static bool Compare<T>(IList<T> list1, IList<T> list2) where T : IComparable<T>
        {
            if (list1 == null || list2 == null) 
                return false;
            if (list1.Count != list2.Count) 
                return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].CompareTo(list2[i]) != 0)
                    return false;
            }

            return true;
        }
    }
}
