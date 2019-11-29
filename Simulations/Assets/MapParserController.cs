using System.IO;
using System.Linq;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using CTTDict = CharToTileTypeDict;

public class MapParserController : MonoBehaviour
{
    public enum TileTypes {
        TRAVERSABLE,
        NON_TRAVERSABLE,
        OUT_OF_BOUNDS
    }

    public struct Scenario
    {
        TileTypes[,] map;
        int mapWidth, mapHeight, startX, startY, targetX, targetY;
        float optimalLength;

        public Scenario(TileTypes[,] map, int startX, int startY, int targetX, int targetY, float optimalLength) {
            this.map = map;
            this.mapWidth = map.GetLength(0); this.mapHeight = map.GetLength(1);
            this.startX = startX; this.startY = startY;
            this.targetX = targetX; this.targetY = targetY;
            this.optimalLength = optimalLength;
        }
    }

    private CTTDict charsToTileTypes = new CTTDict();
    private string mapDir;
    private string scenarioDir;
    private string[] mapFiles;
    private string[] scenarioFiles;
    private int currentMap = -1;

    private string getDirectory(string dirType) {
        string dir = Directory.GetCurrentDirectory();
        string subDir = "/Assets/" + dirType;
        dir += (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) ? subDir.Replace('/', '\\') : subDir;
        return dir;
    }

    // Start is called before the first frame update
    void Start()
    {
        // initialise the dictionary
        charsToTileTypes
            .cAdd('.', TileTypes.TRAVERSABLE)
            .cAdd('T', TileTypes.NON_TRAVERSABLE)
            .cAdd('@', TileTypes.OUT_OF_BOUNDS);

        // get the path to the components
        mapDir = getDirectory("Maps");
        scenarioDir = getDirectory("Scenarios");

        // create a list of the component file names
        mapFiles = Directory.GetFiles(mapDir).Where(file => !file.EndsWith(".meta")).ToArray();
        scenarioFiles = Directory.GetFiles(scenarioDir).Where(scen => !scen.EndsWith(".meta")).ToArray();
    }

    private string getNextMapFile() {
        return mapFiles[++currentMap];
    }

    private string getCurrentScenarioFile() {
        return scenarioFiles[currentMap];
    }

    private TileTypes[,] parseMapFile(string mapText) {
        // split the map by newlines and remove 4 lines of metadata
        string[] fullMapRows = mapText.Trim('\n').Split('\n'); // with metadata
        string[] mapRows = new string[fullMapRows.Length - 4]; // without metadata
        Array.Copy(fullMapRows, 4, mapRows, 0, mapRows.Length);

        int rows = mapRows.Length;
        int columns = mapRows[0].Length;

        TileTypes[,] parsedMap = new TileTypes[rows, columns];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                // convert chars to TileTypes using dict
                charsToTileTypes.TryGetValue(mapRows[i][j], out parsedMap[i, j]);
            }
        }
        return parsedMap;
    }

    private Scenario[] parseScenarioFile(string scenarioText, TileTypes[,] map) {
        // note that a scenario file contains multiple 'scenarios'
        string[] scenariosText = scenarioText.Split('\n');
        Scenario[] scenarios = new Scenario[scenariosText.Length - 1];
        for (int i = 1; i < scenariosText.Length; i++) { // skip first line of metadata
            string[] scenarioComponents = scenariosText[i].Split(null);
            Scenario scen = new Scenario(
                map, 
                int.Parse(scenarioComponents[4]), int.Parse(scenarioComponents[5]),
                int.Parse(scenarioComponents[6]), int.Parse(scenarioComponents[7]),
                float.Parse(scenarioComponents[8]));
            scenarios[i - 1] = scen;
        }
        return scenarios;
    }

    private TileTypes[,] getNextMap() {
        // fetch the next map in sequence
        string mapFilePath = getNextMapFile();
        // open it as a stream
        StreamReader sr = new StreamReader(mapFilePath);
        // parse the map and close stream
        string mapText = sr.ReadToEnd();
        TileTypes[,] parsedMap = parseMapFile(mapText);
        sr.Close();
        return parsedMap;
    }

    public Scenario[] getNextScenarioSet() {
        // switch to the next map
        TileTypes[,] map = getNextMap();
        // fetch the next scen set
        string scenFilePath = getCurrentScenarioFile();
        // open stream and read contents
        StreamReader sr = new StreamReader(scenFilePath);
        string scensText = sr.ReadToEnd();
        Scenario[] parsedScens = parseScenarioFile(scensText, map);
        sr.Close();
        return parsedScens;
    }
}
