# CSC 236 (Introduction Algorithms) Practical

> ## Analysis of Searching Algorithms

A C# program analysing Binary and Tenary Searching Algorithms

> ### Method

- Generating Unsorted Random Arrays of sizes 50000, 100000, 250000, 500000, 750000 with elements ranging between 1 and 100

- Running the Searching algorithms (Binary and Tenary) on the arrays, searching for an element within the array eg (70)

- Running the Searching algorithms (Binary and Tenary) on the arrays again, searching for an element outside the array eg (120)

- Sort each of the random arrays

- Running the algorithms again on the sorted arrays, searching for an element within array (also, 60)

- Finally running the algorithms on the sorted arrays, searching for (also, 120) an element outside the array

- Exporting the test data of the analysis (The runtime of the algorithm on each arrays) in a csv file

> ### Observations After Test

- Both Searching Algorithm (Binary and Tenary) does not work properly on unsorted data. (Inference: Use the algorithms on sorted data only)

- Analytically, *Binary* and *Tenary* search has a time complexity of **log₂** and **log₃** respectively. Although Tenary search reduces the number of iterations (or recursive calls) compared to Binary search, the number of comparison done in each iteration (which is more) makes Tenary a tiny bit slower than than Binary Search.

--------------------
