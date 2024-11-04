using cs_sort.n2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace cs_sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunN2Sorts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void RunN2Sorts()
        {
            const int MAX_POWER_N2 = 6;
            const int TRY = 30;
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < MAX_POWER_N2; i++)
            {
                var total = (int)Math.Pow(10, i);
                var tsBuildIn = new List<TimeSpan>();
                var tsBubble = new List<TimeSpan>();
                var tsInsertion = new List<TimeSpan>();
                for (int k = 0; k < (i < MAX_POWER_N2 - 1 ? TRY : 1); k++)
                {
                    var src = new List<int>();
                    for (int j = 0; j < total; j++)
                        src.Add(rnd.Next(total));

                    tsBuildIn.Add(SortBuildIn(src).Elapsed);
                    tsBubble.Add(SortBubble(src).Elapsed);
                    tsInsertion.Add(SortInsertion(src).Elapsed);
                }
                Console.WriteLine($"{total}, BuildIn: {Time(Mean(tsBuildIn))}, Bubble: {Time(Mean(tsBubble))}, Insertion: {Time(Mean(tsInsertion))}");
            }
        }

        static TimeSpan Mean(List<TimeSpan> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.Sort();
            return source[source.Count / 2];
        }

        static string Time(TimeSpan ts)
        {
            if ((int)ts.TotalSeconds > 0)
                return $"{(int)ts.TotalSeconds} s";
            else if ((int)ts.TotalMilliseconds > 0)
                return $"{(int)ts.TotalMilliseconds} ms";
            else if ((int)(ts.TotalNanoseconds / 1000) > 0)
                return $"{(int)(ts.TotalNanoseconds / 1000)} mks";
            else
                return $"{(int)ts.TotalNanoseconds} ns";
        }

        static List<int> _etalon;

        private static Stopwatch SortInsertion(List<int> src)
        {
            var list = Copy(src);
            Stopwatch sw = Stopwatch.StartNew();
            list.InsertionSort();
            sw.Stop();
            if (!Comparer.Compare(_etalon, list))
                throw new Exception("Invalid implementaion of insertion sort");
            return sw;
        }

        private static Stopwatch SortBubble(List<int> src)
        {
            var list = Copy(src);
            Stopwatch sw = Stopwatch.StartNew();
            list.BubbleSort();
            sw.Stop();
            if (!Comparer.Compare(_etalon, list))
                throw new Exception("Invalid implementaion of bubble sort");
            return sw;
        }

        private static Stopwatch SortBuildIn(List<int> src)
        {
            var list = Copy(src);
            Stopwatch sw = Stopwatch.StartNew();
            list.Sort();
            sw.Stop();
            _etalon = list;
            return sw;
        }

        private static List<int> Copy(List<int> src) 
        {
            var list = new List<int>();
            list.AddRange(src);
            return list;
        }
    }
}
