namespace mpi_proj.Algorithm;

public class Time
{
    public Sim.Event Run(ref Sim.EventList eventList, ref double simTime)
    {
        Sim.Event e = eventList.Pop();
        simTime = e.Time;
        return e;
    }
}