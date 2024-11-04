## Implementation and measurements of various types of sorting

### O(n^2) sorts

* [Bubble](n2/BubbleSort.cs)
* [Insertion](n2/InsertionSort.cs)

| n       | Build in | Bubble | Insertion |
| ------- | -------- | ------ | --------- |
| 1       | 0 ns     | 0 ns   | 0 ns      |
| 10      | 100 ns   | 2 μs   | 1 μs      |
| 100     | 2 μs     | 89 μs  | 102 μs    |
| 1 000   | 33 μs    | 2 ms   | 9 ms      |
| 10 000  | 424 μs   | 258 ms | 62 ms     |
| 100 000 | 5 ms     | 26 s   | 5 s       |

