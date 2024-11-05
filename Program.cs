using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace cs_sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunN2Sorts();
                Cooldown();
                Console.WriteLine();
                RunNLogNSorts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void RunN2Sorts()
        {
            Console.WriteLine("Run O(n*n) sorts:");
            for (int a = 0; a < 2; a++)
            {
                if (a == 1)
                    Cooldown();
                Console.WriteLine(a == 0 ? "Array" : "List");
                const int MAX_POWER = 6;
                const int MAX_TRY = 5;
                var rnd = new Random(Guid.NewGuid().GetHashCode());
                for (int i = 0; i < MAX_POWER; i++)
                {
                    var total = (int)Math.Pow(10, i);
                    if (i == MAX_POWER - 1)
                        total = total / 4;
                    var tsBuildIn = new List<TimeSpan>();
                    var tsBubble = new List<TimeSpan>();
                    var tsInsertion = new List<TimeSpan>();
                    var tsSelection = new List<TimeSpan>();
                    for (int k = 0; k < (i < MAX_POWER - 1 ? MAX_TRY : 1); k++)
                    {
                        var src = new int[total];
                        for (int j = 0; j < total; j++)
                            src[j] = rnd.Next(total);

                        tsBuildIn.Add(SortBuildIn(src, a == 0).Elapsed);
                        tsBubble.Add(SortBubble(src, a == 0).Elapsed);
                        tsInsertion.Add(SortInsertion(src, a == 0).Elapsed);
                        tsSelection.Add(SortSelection(src, a == 0).Elapsed);
                    }
                    Console.WriteLine($"{total.ToString("N0")}, BuildIn: {Time(Mean(tsBuildIn))}, Bubble: {Time(Mean(tsBubble))}, Insertion: {Time(Mean(tsInsertion))}, Selection: {Time(Mean(tsSelection))}");
                }
            }
        }

        static void RunNLogNSorts()
        {
            Console.WriteLine("Run O(n*log(n)) sorts:");
            for (int a = 0; a < 2; a++)
            {
                if (a == 1)
                    Cooldown();
                Console.WriteLine(a == 0 ? "Array" : "List");
                const int MAX_POWER = 8;
                const int MAX_TRY = 5;
                var rnd = new Random(Guid.NewGuid().GetHashCode());
                for (int i = 0; i < MAX_POWER; i++)
                {
                    var total = (int)Math.Pow(10, i);
                    var tsBuildIn = new List<TimeSpan>();
                    var tsMerge = new List<TimeSpan>();
                    for (int k = 0; k < (i < MAX_POWER - 1 ? MAX_TRY : 1); k++)
                    {
                        var src = new List<int>();
                        for (int j = 0; j < total; j++)
                            src.Add(rnd.Next(total));

                        tsBuildIn.Add(SortBuildIn(src, a == 0).Elapsed);
                        tsMerge.Add(SortMerge(src, a == 0).Elapsed);
                    }
                    Console.WriteLine($"{total.ToString("N0")}, BuildIn: {Time(Mean(tsBuildIn))}, Merge: {Time(Mean(tsMerge))}");
                }
            }
        }

        static TimeSpan Mean(List<TimeSpan> source)
        {
            if (source == null || source.Count == 0)
                return default;

            source.Sort();
            return source[source.Count / 2];
        }

        static string Time(TimeSpan ts)
        {
            if ((int)ts.TotalSeconds > 0)
                return $"{Round(ts.TotalSeconds)} s";
            else if ((int)ts.TotalMilliseconds > 0)
                return $"{Round(ts.TotalMilliseconds)} ms";
            return $"{Round(ts.TotalMilliseconds * 1000)} mks";
        }

        static string Round(double n)
        {
            int len = ((int)n).ToString().Length;
            double r = Math.Pow(10, len - 2);
            double d = n / r;
            double d1 = Math.Round(d, 0) * r;
            decimal res = (decimal)d1;
            return res.ToString(CultureInfo.InvariantCulture);
        }

        static IList<int> _etalon;

        private static Stopwatch SortMerge(IList<int> src, bool isArray)
        {
            var list = Copy(src, isArray);
            Stopwatch sw = Stopwatch.StartNew();
            var list1 = list.MergeSort();
            sw.Stop();
            if (!Comparer.Compare(_etalon, list1))
                throw new Exception("Invalid implementaion of merge sort");
            return sw;
        }

        private static Stopwatch SortSelection(IList<int> src, bool isArray)
        {
            var list = Copy(src, isArray);
            Stopwatch sw = Stopwatch.StartNew();
            list.SelectionSort();
            sw.Stop();
            if (!Comparer.Compare(_etalon, list))
                throw new Exception("Invalid implementaion of selection sort");
            return sw;
        }

        private static Stopwatch SortInsertion(IList<int> src, bool isArray)
        {
            var list = Copy(src, isArray);
            Stopwatch sw = Stopwatch.StartNew();
            list.InsertionSort();
            sw.Stop();
            if (!Comparer.Compare(_etalon, list))
                throw new Exception("Invalid implementaion of insertion sort");
            return sw;
        }

        private static Stopwatch SortBubble(IList<int> src, bool isArray)
        {
            var list = Copy(src, isArray);
            Stopwatch sw = Stopwatch.StartNew();
            list.BubbleSort();
            sw.Stop();
            if (!Comparer.Compare(_etalon, list))
                throw new Exception("Invalid implementaion of bubble sort");
            return sw;
        }

        private static Stopwatch SortBuildIn(IList<int> src, bool isArray)
        {
            var list = Copy(src, isArray);
            Stopwatch sw = Stopwatch.StartNew();
            if (list is List<int>)
                ((List<int>)list).Sort();
            else
                Array.Sort((int[])list);
            sw.Stop();
            _etalon = list;
            return sw;
        }

        private static IList<int> Copy(IList<int> src, bool isArray) 
        {
            if (isArray)
            {
                var list = new int[src.Count];
                for (int i = 0; i < src.Count; i++)
                    list[i] = src[i];
                return list;
            }
            else
            {
                var list = new List<int>();
                list.AddRange(src);
                return list;
            }
        }

        static void Cooldown()
        {
            Console.WriteLine("Cooldown 10s");
            Thread.Sleep(10000);
        }
    }
}
