namespace mpi_proj.Algorithm;

public class Time
{
    public Sim.Event Run()
    {
        return new Sim.Event(0.0, Sim.EventTypeEnum.Departure);
    }
}