using mpi_proj.Sim;
using mpi_proj.System;

namespace mpi_proj.Algorithm;

public class Event
{
    private readonly Sim.Time _simTime;
    private readonly Sim.EventList _eventList;
    private readonly System.System _system;

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
        switch (_system.Server.Status)
        {
            case ServerStatusEnum.Busy:
                _system.Queue.Push(new Client(_simTime.Value));
                break;
            case ServerStatusEnum.Free:
                _system.Server.Status = ServerStatusEnum.Busy;
                _eventList.Push(new Sim.Event(_simTime.Value + 2, EventTypeEnum.Departure));
                break;
        }
        return false;
    }

    private bool Departure()
    {
        switch (_system.Queue.IsEmpty)
        {
            case true:
                _system.Server.Status = ServerStatusEnum.Free;
                break;
            case false:
                var client = _system.Queue.Pop();
                _eventList.Push(new Sim.Event(_simTime.Value + 2, EventTypeEnum.Departure));
                break;
        }
        
        return false;
    }

    private bool End()
    {
        return true;
    }
}