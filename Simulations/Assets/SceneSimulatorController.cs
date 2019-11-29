
using UnityEngine;
using Scenario = MapParserController.Scenario;


public class SceneSimulatorController : MonoBehaviour
{
    public GameObject mapParser;
    private int time = 0;

    // Update is called once per frame
    void Update()
    {
        if (time == 0) {
            // fetch the first scene
            Scenario[] scens = mapParser.GetComponent<MapParserController>().getNextScenarioSet();
        }

        time++;
    }
}
