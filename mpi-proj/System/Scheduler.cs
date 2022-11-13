namespace mpi_proj.System;

public class Scheduler
{
    private readonly Queue _queueA;
    private readonly Queue _queueB;
    private readonly Queue _queueC;
    
    public int ClientsCount { get; set; }
    public bool IsEmpty { get; set; }

    public Scheduler()
    {
        ClientsCount = 0;
        IsEmpty = true;
        _queueA = new Queue();
        _queueB = new Queue();
        _queueC = new Queue();
    }

    public void Push(Client client)
    {
        switch (client.Stream)
        {
            case StreamEnum.A:
                _queueA.Push(client);
                break;
            case StreamEnum.B:
                _queueB.Push(client);
                break;
            case StreamEnum.C:
                _queueC.Push(client);
                break;
        }
        IsEmpty = _queueA.IsEmpty && _queueB.IsEmpty && _queueC.IsEmpty;
        ClientsCount = _queueA.ClientsCount + _queueB.ClientsCount + _queueC.ClientsCount;
    }

    public Client Pop()
    {
        if (!_queueA.IsEmpty)
        {
            var c = _queueA.Pop();
            IsEmpty = _queueA.IsEmpty && _queueB.IsEmpty && _queueC.IsEmpty;
            ClientsCount = _queueA.ClientsCount + _queueB.ClientsCount + _queueC.ClientsCount;
            return c;
        }
        else if (!_queueB.IsEmpty)
        {
            var c = _queueB.Pop();
            IsEmpty = _queueA.IsEmpty && _queueB.IsEmpty && _queueC.IsEmpty;
            ClientsCount = _queueA.ClientsCount + _queueB.ClientsCount + _queueC.ClientsCount;
            return c;
        }
        else
        {
            var c = _queueC.Pop();
            IsEmpty = _queueA.IsEmpty && _queueB.IsEmpty && _queueC.IsEmpty;
            ClientsCount = _queueA.ClientsCount + _queueB.ClientsCount + _queueC.ClientsCount;
            return c;
        }
    }

    public override string ToString()
    {
        return $"Scheduler( A: {_queueA}, B: {_queueB}, C: {_queueC})";
    }
}