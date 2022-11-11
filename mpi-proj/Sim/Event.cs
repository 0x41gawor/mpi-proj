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
    
    public double Time => _time;

    public override string ToString()
    {
        return $"Event(time: {_time}, type: {_type})";
    }
}