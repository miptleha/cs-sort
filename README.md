# Implementation and measurements of various types of sorting

## O(n^2) sorts

[Bubble](n2/BubbleSort)
[Insertion](n2/InsertionSort)

| n       | Build in | Bubble  | Insertion |
| ------- | -------- | ------- | --------- |
| 1       | 0 μs     | 23 μs   | 5 μs      |
| 10      | 18 μs    | 2 μs,   | 1 μs      |
| 100     | 2 μs     | 188 μs  | 104 μs    |
| 1 000   | 38 μs    | 2 ms    | 9 ms      |
| 10 000  | 456 μs   | 260 ms  | 92 ms     |
| 100 000 | 5 ms     | 25 s    | 5 s       |

