using mpi_proj.Sim;

namespace mpi_proj.Algorithm;

public class Event
{
    private Sim.Time _simTime;
    private readonly Sim.EventList _eventList;
    private System.System _system;

    public Event(ref Sim.Time simTime, ref Sim.EventList eventList, ref System.System system)
    {
        _simTime = simTime;
        _eventList = eventList;
        _system = system;
    }

    public bool Run(Sim.Event e)
    {
        return e.Type switch
        {
            EventTypeEnum.Arrival => Arrival(),
            EventTypeEnum.Departure => Departure(),
            EventTypeEnum.End => End(),
            _ => true
        };
    }

    private bool Arrival()
    {
        // Plan out the next arrival
        _eventList.Push(new Sim.Event(_simTime.Value + 1.5, EventTypeEnum.Arrival));
        return false;
    }

    private bool Departure()
    {
        return false;
    }

    private bool End()
    {
        return true;
    }
}