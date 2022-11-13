namespace mpi_proj.System;

public class Queue
{
    private readonly PriorityQueue<Client, double> _body;
    public int ClientsCount { get; set; }
    public bool IsEmpty { get; set; }

    public Queue()
    {
        _body = new PriorityQueue<Client, double>();
        ClientsCount = 0;
        IsEmpty = true;
    }

    public void Push(Client client)
    {
        _body.Enqueue(client, client.ArrivalTime);
        IsEmpty = _body.Count == 0 ? true : false;
        ClientsCount = _body.Count;
    }

    public Client Pop()
    {
        var client = _body.Dequeue();
        IsEmpty = _body.Count == 0 ? true : false;
        ClientsCount = _body.Count;
        return client;
    }

    public override string ToString()
    {
        var result = "Queue: [ ";

        var recreationList = new List<Client>();

        if (_body.Count == 0)
        {
            result += "]";
            return result;
        }
        
        while (_body.Count > 1)
        {
            var c = _body.Dequeue();
            result += c + ", ";
            recreationList.Add(c);
        }
        var last = _body.Dequeue();
        result += last;
        recreationList.Add(last);
        
        // recreation of the Queue
        recreationList.ForEach( c => {_body.Enqueue(c, c.ArrivalTime);});
        
        result += " ]";
        
        return result;
    }
}