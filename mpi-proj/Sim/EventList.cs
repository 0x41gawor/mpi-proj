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
        var result = "EventList: [ ";

        var recreationList = new List<Event>();
        
        while (_body.Count > 1)
        {
            var e = _body.Dequeue();
            result += e + ", ";
            recreationList.Add(e);
        }
        var last = _body.Dequeue();
        result += last;
        recreationList.Add(last);
        
        // recreation of the Queue
        recreationList.ForEach( e => {_body.Enqueue(e, e.Time);});
        
        result += " ]";
        
        return result;
    }
}