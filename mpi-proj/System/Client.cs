namespace mpi_proj.System;

public class Client
{
    public double ArrivalTime { get; set; }

    public Client(double arrivalTime)
    {
        ArrivalTime = arrivalTime;
    }

    public override string ToString()
    {
        return $"Client(arrivalTime: {ArrivalTime})";
    }
}