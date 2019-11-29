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

    public class Path {
        // definition of path (from source to target)
        // a 'path' represents a linked list node
        private int x {get; set;}
        private int y {get; set;}
        private Path next {get; set;}
        public Path (int x, int y) {
            this.x = x; this.y = y;
        }
    }
}