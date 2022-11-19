using mpi_proj.Sim;

namespace mpi_proj.Algorithm;

public class Init
{
    private readonly Sim.Time _simTime;                    // _simTime reference
    private readonly Sim.EventList _eventList;  // _eventList reference
    private readonly System.System _system;     // _system reference

    private readonly double _simulationTime;

    public Init(ref Sim.Time simTime, ref System.System system, ref Sim.EventList eventList, double simulationTime)
    {
        _simTime = simTime;
        _system = system;
        _eventList = eventList;
        _simulationTime = simulationTime;
    }
    
    public void Run()
    {
        _simTime.Value = 0;
        //System state initialization
        _system.Init();
        //EventList initialization
        _eventList.Push(new Sim.Event(_simulationTime , EventTypeEnum.End)); 
        _eventList.Push(new Sim.Event(0.0, EventTypeEnum.ArrivalA));
        _eventList.Push(new Sim.Event(0.1, EventTypeEnum.ArrivalB));
        _eventList.Push(new Sim.Event(0.2, EventTypeEnum.ArrivalC));
    }
}