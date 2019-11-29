// provides a definition of each communally used component

public static class Types {
    // definition of types of tiles on each map
    // NT and OOB are effectively the same in this implementation
    public enum TileTypes {
        TRAVERSABLE,
        NON_TRAVERSABLE,
        OUT_OF_BOUNDS
    }

    public struct Scenario {
        // definition for a scenario according to MovingAI benchmarks
        public TileTypes[,] map;
        public int startX, startY, targetX, targetY;
        public float optimalLength;
        public Scenario(TileTypes[,] map, int startX, int startY, int targetX, int targetY, float optimalLength) {
            this.map = map;
            this.startX = startX; this.startY = startY;
            this.targetX = targetX; this.targetY = targetY;
            this.optimalLength = optimalLength;
        }
    }

    public struct Node {
        // definition of a node within a map (does not form part of the map definition,
        // is only used when executing an algorithm)
        public int x;
        public int y;
        public float priority;
        public Node (int x, int y, float priority) {
            this.x = x; this.y = y; this.priority = priority;
        }
    }

    public struct Action {
        // definition of an action taken by a pathfinding algorithm on a node
        // is given as a <node, action_type> double
        
    }

    public class Path {
        // definition of path (from source to target)
        // a 'path' represents a linked list node
        private Node node {get; set;}
        private Path next {get; set;}
        public Path (Node node) {
            this.node = node;
        }
    }
}