namespace mpi_proj.Sim;

public class Event
{
    public double Time { get; }

    public EventTypeEnum Type { get; }

    public Event(double time, EventTypeEnum type)
    {
        Time = time;
        Type = type;
    }

    public override string ToString()
    {
        return $"Event(time: {Time:0.00}, type: {Type})";
    }
}