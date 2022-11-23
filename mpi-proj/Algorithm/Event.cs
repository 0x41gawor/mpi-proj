using mpi_proj.Sim;
using mpi_proj.System;

namespace mpi_proj.Algorithm;

public class Event
{
    private readonly Sim.Time _simTime;
    private readonly Sim.EventList _eventList;
    private readonly System.System _system;
    private readonly Sim.Stats _stats;

    private readonly Algorithm.Lib.ILib _arrivalLib;
    private readonly Algorithm.Lib.ILib _departureLib;

    public Event(ref Sim.Time simTime, ref Sim.EventList eventList, ref System.System system, ref Sim.Stats stats,
        Lib.ILib arrivalLib, Lib.ILib departureLib)
    {
        _simTime = simTime;
        _eventList = eventList;
        _system = system;
        _stats = stats;
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
        var stream = e.Type switch
        {
            EventTypeEnum.ArrivalA => StreamEnum.A,
            EventTypeEnum.ArrivalB => StreamEnum.B,
            EventTypeEnum.ArrivalC => StreamEnum.C,
            _ => StreamEnum.A
        };
        _stats.Arrive(stream);
        // Plan out the next arrival
        _eventList.Push(new Sim.Event(_simTime.Value + _arrivalLib.Run(stream), e.Type));
        switch (_system.Server.Status)
        {
            case ServerStatusEnum.Busy:
                _system.Queue.Push(new Client(_simTime.Value, stream));
                break;
            case ServerStatusEnum.Free:
                _stats.Workload(_simTime.Value, _system.Server.Status);
                _system.Server.Status = ServerStatusEnum.Busy;
                _stats.DelayQueue(stream, 0.0);
                // plan out the departure
                _system.Server.CurrentClient = new Client(_simTime.Value, stream);
                _eventList.Push(new Sim.Event(_simTime.Value + _departureLib.Run(stream), EventTypeEnum.Departure));
                break;
        }
        return false;
    }

    private bool Departure()
    {
        var departedClient = _system.Server.CurrentClient;
        _stats.DelaySystem(departedClient!.Stream, _simTime.Value - departedClient.ArrivalTime);
        switch (_system.Queue.IsEmpty)
        {
            case true:
                _stats.Workload(_simTime.Value, _system.Server.Status);
                _system.Server.Status = ServerStatusEnum.Free;
                _system.Server.CurrentClient = null;
                break;
            case false:
                var nextClient = _system.Queue.Pop();
                _stats.DelayQueue(nextClient.Stream, _simTime.Value - nextClient.ArrivalTime);
                // plan out the departure
                _system.Server.CurrentClient = nextClient;
                _eventList.Push(new Sim.Event(_simTime.Value + _departureLib.Run(nextClient.Stream), EventTypeEnum.Departure));
                break;
        }
        
        return false;
    }

    private bool End()
    {
        return true;
    }
}