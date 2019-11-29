// interface which defines algorithm executors 
// receive the specifications necessary to pathfind, spit out a path
// implementing classes will need to time execution

using Scenario = Types.Scenario;
using Path = Types.Path;

public interface IAlgorithmExecutor {
    Path executeScenario(Scenario scen);
}