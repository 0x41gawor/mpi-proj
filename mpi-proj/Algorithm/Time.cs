namespace mpi_proj.Algorithm;

public class Time
{
    private Sim.Time _simTime;                    // _simTime reference
    private readonly Sim.EventList _eventList;  // _eventList reference
    
    public Time(ref Sim.Time simTime, ref Sim.EventList eventList)
    {
        _eventList = eventList;
        _simTime = simTime;
    }
    
    public  Sim.Event Run()
    {
        var e = _eventList.Pop();
        _simTime.Value = e.Time;
        return e;
    }
}