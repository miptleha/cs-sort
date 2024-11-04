## Implementation and measurements of various types of sorting

Tests were run on .Net 8 in Release mode.  
Tenfold measurements were made with the calculation of the median.

### O(n^2) sorts

* [Bubble](n2/BubbleSort.cs)
* [Insertion](n2/InsertionSort.cs)
* [Selection](n2/SelectionSort.cs)

| n       | Build in | Bubble | Insertion | Selection |
| ------- | -------- | ------ | --------- | --------- |
| 1       | 0 ns     | 100 ns | 100 ns    | 100 ns    |
| 10      | 200 ns   | 2 μs   | 1 μs      | 2 μs      |
| 100     | 2 μs     | 93 μs  | 100 μs    | 50 μs     |
| 1 000   | 33 μs    | 2 ms   | 9 ms      | 694 μs    |
| 10 000  | 453 μs   | 258 ms | 62 ms     | 62 ms     |
| 100 000 | 6 ms     | 25 s   | 5 s       | 6 s       |
