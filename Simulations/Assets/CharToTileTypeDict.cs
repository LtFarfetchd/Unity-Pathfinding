// a dictionary that can chain necessary operations for convenience
using System.Collections.Generic;
using TileTypes = MapParserController.TileTypes;

public class CharToTileTypeDict : Dictionary<char, TileTypes> {
    // chain add
    public CharToTileTypeDict cAdd(char key, TileTypes value) {
        Add(key, value);
        return this;
    }
}