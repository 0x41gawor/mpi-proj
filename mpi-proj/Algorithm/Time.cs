namespace mpi_proj.Algorithm;

public class Time
{
    private double _simTime;                    // _simTime reference
    private readonly Sim.EventList _eventList;  // _eventList reference
    
    public Time(ref Sim.EventList eventList, ref double simTime)
    {
        _eventList = eventList;
        _simTime = simTime;
    }
    
    public  Sim.Event Run()
    {
        var e = _eventList.Pop();
        _simTime = e.Time;
        return e;
    }
}