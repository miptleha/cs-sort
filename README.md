## Implementation and measurements of various types of sorting

Tests were run on .Net 8 in Release mode.  
Tenfold measurements were made with the calculation of the median.

### O(n^2) sorts

| n       | [Build in][1] | [Bubble][2] | [Insertion][3] | [Selection][4] |
| ------- | -------- | ------ | --------- | --------- |
| 1       | 0 ns     | 100 ns | 100 ns    | 100 ns    |
| 10      | 200 ns   | 2 μs   | 1 μs      | 2 μs      |
| 100     | 2 μs     | 93 μs  | 100 μs    | 50 μs     |
| 1 000   | 33 μs    | 2 ms   | 9 ms      | 694 μs    |
| 10 000  | 453 μs   | 258 ms | 62 ms     | 62 ms     |
| 100 000 | 6 ms     | 25 s   | 5 s       | 6 s       |

[1]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-8.0
[2]: n2/BubbleSort.cs
[3]: n2/InsertionSort.cs
[4]: n2/SelectionSort.cs

### O(nlogn) sorts

*Coming soon*


[![Hits](https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https%3A%2F%2Fgithub.com%2Fmiptleha%2Fcs-sort&count_bg=%230C7DBD&title_bg=%23555555&icon=&icon_color=%23E7E7E7&title=hits&edge_flat=false)](https://hits.seeyoufarm.com)