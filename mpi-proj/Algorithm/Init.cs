using mpi_proj.Sim;

namespace mpi_proj.Algorithm;

public class Init
{
    private double _simTime;                    // _simTime reference
    private readonly Sim.EventList _eventList;  // _eventList reference
    private readonly System.System _system;     // _system reference

    public Init(ref double simTime, ref System.System system, ref Sim.EventList eventList)
    {
        _simTime = simTime;
        _system = system;
        _eventList = eventList;
    }
    
    public void Run()
    {
        _simTime = 0;
        //System state initialization
        _system.Init();
        //EventList initialization
        _eventList.Push(new Sim.Event(10.0 , EventTypeEnum.End)); //TODO Extract const values 
        _eventList.Push(new Sim.Event(1.0, EventTypeEnum.Arrival));
    }
}