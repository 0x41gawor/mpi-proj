using mpi_proj.Sim;

namespace mpi_proj.Algorithm;

public class Init
{
    public void Run(ref double simTime, ref System.System system, ref Sim.EventList eventList)
    {
        simTime = 0;
        //System state initialization
        system.Init();
        //EventList initializtion
        eventList.Push(new Sim.Event(10.0 , EventTypeEnum.End)); //TODO Extract const values 
        eventList.Push(new Sim.Event(1.0, EventTypeEnum.Arrival));
        
    }
}