## Implementation and measurements of various types of sorting

Runs different `sorting algorithms` for random integer arrays and lists of different lengths in several passes.  
Solution `cs-sort.sln` is for the `Core` and `cs-sort-old.sln` is for the `Classic` `.NET Framework`.  
Before starting `cs-sort-old.sln` delete `obj` folder.  

Below are the results for `Arrays` in `Debug mode` for `.NET 8`.  
`Lists` work slower with a small number of elements.  
Enabling optimization can sometimes significantly speed up sorting.  
Using the `IList` interface has a negative impact on performance.  
More detailed information can be obtained by running the application.

### O(n^2) sorts

| n       | [Build-in][1] | [Bubble][2] | [Insertion][3] | [Selection][4] |
| ------- | -------- | ------ | --------- | --------- |
| 1       | 0 μs     | 0 μs   | 0 μs      | 0.1 μs    |
| 10      | 0.3 μs   | 1.1 μs | 0.7 μs    | 1.2 μs    |
| 100     | 2.4 μs   | 95 μs  | 36 μs     | 52 μs     |
| 1 000   | 34 μs    | 9.8 ms | 3.4 ms    | 4.4 ms    |
| 10 000  | 430 μs   | 710 ms | 270 ms    | 370 ms    |
| 25 000  | 1.2 ms   | 4.4 s  | 1.7 s     | 2.3 s     |

These algorithms are *not recommended* for use (significantly slower than built-in sorting)

### O(nlogn) sorts

| n          | [Build-in][1] | [Merge][5] | [Quick][6] |
| ---------- | ------ | ------ | ------ |
| 1          | 0 μs   | 0.2 μs | 0.1 μs |
| 10         | 0.3 μs | 6.8 μs | 3.8 μs |
| 100        | 2.2 μs | 48 μs  | 41 μs  |
| 1 000      | 34 μs  | 650 μs | 480 μs |
| 10 000     | 440 μs | 6.3 ms | 4.9 ms |
| 100 000    | 5.4 ms | 39 ms  | 52 ms  |
| 1 000 000  | 67 ms  | 430 ms | 600 ms |
| 10 000 000 | 780 ms | 4.9 s  | 6.9 s  |

*New algorithms coming soon*

[1]: https://learn.microsoft.com/en-us/dotnet/api/system.array.sort?view=net-8.0#system-array-sort
[2]: n2/BubbleSort.cs
[3]: n2/InsertionSort.cs
[4]: n2/SelectionSort.cs
[5]: nlogn/MergeSort.cs
[6]: nlogn/QuickSort.cs

[![Hits](https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https%3A%2F%2Fgithub.com%2Fmiptleha%2Fcs-sort&count_bg=%230C7DBD&title_bg=%23555555&icon=&icon_color=%23E7E7E7&title=hits&edge_flat=false)](https://hits.seeyoufarm.com)




















































