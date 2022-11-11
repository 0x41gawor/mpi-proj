namespace mpi_proj.Sim;

public class Event
{
    private double _time;
    private EventTypeEnum _type;

    public Event(double time, EventTypeEnum type)
    {
        _time = time;
        _type = type;
    }
}