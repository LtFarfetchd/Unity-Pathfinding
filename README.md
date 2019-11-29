Simulator for benchmarking pathfinding in Unity

**Objectives**
--------------
1. Benchmark different pathfinding algorithms
   * Dikjstra's Algorithm
   * Breadth-First-Search*
   * Depth-First-Search*
   * A*
   * Jump Point Search
   * JPS+
2. Benchmark different heuristics
3. Benchmark different priority queue implementations
4. Build UI to grant easy interchangeability between algos, heuristics and queue structs

'*' = could just implement one of the two

'~' = implemented

**Set-up**
----------
Notes: 
* Project is currently targeting Unity 2019.2.0f1
* Project is written on Arch Linux. Compatibility is not guaranteed on non-unix systems (I have not tested it)

1. Install Unity/UnityHub with correct Unity release
2. Clone this repo
3. Hit run!

**Info**
--------
* This project is designed to be a comprehensive point of reference for our team (and others) to use to experiment with pathfinding algorithm implementations, and as a source of implementation knowledge.
* The benchmarks used here can be found at https://movingai.com/benchmarks/, so far only Dragon Age Origins maps are being used (they are simple in terms of terrain types, so ideal for minimal benchmarking).
* You may use anything you find here for free, without attribution - though you may want to take the time to understand any algorithm or data structure implementations first, since I cannot guarantee correctness.

Please let me know (or submit a PR) if you discover any bugs, have suggestions or decide to use something you see here in your own project(s). :) 