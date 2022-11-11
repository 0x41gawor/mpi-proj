namespace mpi_proj.Sim;

public class EventList
{
    private PriorityQueue<Event, double> _body;

    public EventList()
    {
        _body = new PriorityQueue<Event, double>();
    }

    public Event Pop()
    {
        return _body.Dequeue();
    }
    
    public void Push(Event e)
    {
        _body.Enqueue(e, e.Time);
    }

    public override string ToString()
    {
        PriorityQueue<Event, double> copy;
        var result = "EventList: [ ";
        
        copy = _body;//TODO For now, copy is not a real copy of body, printing removes events from evenList

        while (copy.Count > 1)
        {
            result += copy.Dequeue() + ", ";
        }

        result += copy.Dequeue();
        result += " ]";
        
        return result;
    }
}