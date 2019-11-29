// interface which defines priority queue data structures 
// must fill with standardised nodes corresponding to traversable tiles
using Node = Types.Node;

interface IQueueStructure {
    void insert(int x, int y); // creates and inserts a node into the heap
    void decreaseKey(Node node); // increase the priority of a known node (all implementations are min- structures)
    Node pop(); // remove and return the node of smallest key
}