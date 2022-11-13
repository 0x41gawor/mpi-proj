using mpi_proj.Sim;
using mpi_proj.System;

namespace mpi_proj.Algorithm;

public class Event
{
    private readonly Sim.Time _simTime;
    private readonly Sim.EventList _eventList;
    private readonly System.System _system;

    private readonly Algorithm.Lib.ILib _arrivalLib;
    private readonly Algorithm.Lib.ILib _departureLib;

    public Event(ref Sim.Time simTime, ref Sim.EventList eventList, ref System.System system,
        Lib.ILib arrivalLib, Lib.ILib departureLib)
    {
        _simTime = simTime;
        _eventList = eventList;
        _system = system;
        _arrivalLib = arrivalLib;
        _departureLib = departureLib;
    }

    public bool Run(Sim.Event e)
    {
        return e.Type switch
        {
            EventTypeEnum.ArrivalA => Arrival(e),
            EventTypeEnum.ArrivalB => Arrival(e),
            EventTypeEnum.ArrivalC => Arrival(e),
            EventTypeEnum.Departure => Departure(),
            EventTypeEnum.End => End(),
            _ => true
        };
    }

    private bool Arrival(Sim.Event e)
    {
        // Plan out the next arrival
        _eventList.Push(new Sim.Event(_simTime.Value + _arrivalLib.Run(), e.Type));
        switch (_system.Server.Status)
        {
            case ServerStatusEnum.Busy:
                var stream = e.Type switch
                {
                    EventTypeEnum.ArrivalA => StreamEnum.A,
                    EventTypeEnum.ArrivalB => StreamEnum.B,
                    EventTypeEnum.ArrivalC => StreamEnum.C,
                    _ => StreamEnum.A
                };
                _system.Queue.Push(new Client(_simTime.Value, stream));
                break;
            case ServerStatusEnum.Free:
                _system.Server.Status = ServerStatusEnum.Busy;
                _eventList.Push(new Sim.Event(_simTime.Value + _departureLib.Run(), EventTypeEnum.Departure));
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
                _eventList.Push(new Sim.Event(_simTime.Value + _departureLib.Run(), EventTypeEnum.Departure));
                break;
        }
        
        return false;
    }

    private bool End()
    {
        return true;
    }
}