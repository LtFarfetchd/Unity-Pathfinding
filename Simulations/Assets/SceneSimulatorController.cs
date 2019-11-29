using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenario = MapParserController.Scenario;
using TileTypes = MapParserController.TileTypes;


public class SceneSimulatorController : MonoBehaviour
{
    public GameObject mapParser;

    // Start is called before the first frame update
    void Start()
    {
        // fetch the first scene
        Scenario[] scens = mapParser.GetComponent<MapParserController>().getNextScenarioSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
