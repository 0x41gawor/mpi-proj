namespace mpi_proj.System;

public class Client
{
    public double ArrivalTime { get; set; }
    
    public StreamEnum Stream { get; set; }

    public Client(double arrivalTime, StreamEnum stream)
    {
        ArrivalTime = arrivalTime;
        Stream = stream;
    }

    public override string ToString()
    {
        return $"Client(arrivalTime: {ArrivalTime}, stream: {Stream})";
    }
}