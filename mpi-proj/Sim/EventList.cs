namespace mpi_proj.Sim;

public class EventList
{
    private Queue<Event> _body;
    public Event e; 


    private Event Pop()
    {
        return new Event(0.0, EventTypeEnum.Arrival);
    }


    private void Push(Event e)
    {
    }
}