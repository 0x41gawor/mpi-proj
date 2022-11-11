namespace mpi_proj.Algorithm;

public class Event
{
    public bool Run(Sim.Event e)
    {
        return true;
    }

    private bool Arrival()
    {
        return true;
    }

    private bool Departure()
    {
        return true;
    }

    private bool End()
    {
        return true;
    }
}