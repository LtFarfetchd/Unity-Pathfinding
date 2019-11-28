using System.IO;
using UnityEngine;
using CTTDict = CharToTileTypeDict;

public class MapParserController : MonoBehaviour
{
    public enum TileTypes {
        TRAVERSABLE,
        NON_TRAVERSABLE,
        OUT_OF_BOUNDS
    }

    private CTTDict charsToTileTypes;

    private string[] mapFiles;
    private int currentMap = 0;

    // Start is called before the first frame update
    void Start()
    {
        // initialise the dictionary
        charsToTileTypes
            .cAdd('.', TileTypes.TRAVERSABLE)
            .cAdd('T', TileTypes.NON_TRAVERSABLE)
            .cAdd('@', TileTypes.OUT_OF_BOUNDS);

        // create a list of the map paths (relative) and sort it
        

    }

    private string getNextMapFile() {
        return mapFiles[++currentMap];
    }

    public TileTypes[,] parseMapFile(string mapText) {
        // split the map by newlines
        string[] mapRows = mapText.Split('\n');
        int rows = mapRows.Length;
        int columns = mapRows[0].Length;

        TileTypes[,] parsedMap = new TileTypes[rows, columns];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                charsToTileTypes.TryGetValue(mapRows[i][j], out parsedMap[i, j]);
            }
        }
        return parsedMap;
    }

    public TileTypes[,] getNextMap() {
        // fetch the next map in sequence
        string mapFilePath = getNextMapFile();
        // open it as a stream
        StreamReader sr = new StreamReader(mapFilePath);
        // parse the map and close stream
        TileTypes[,] parsedMap = parseMapFile(sr.ReadToEnd());
        sr.Close();
        return parsedMap;
    }
}
