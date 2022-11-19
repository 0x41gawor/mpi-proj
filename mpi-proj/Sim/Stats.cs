using mpi_proj.System;

namespace mpi_proj.Sim;

public class Stats
{
    private readonly double[] _delayQueue;
    private readonly int[] _delayQueueCounts;
    private readonly double[] _delaySystem;
    private readonly int[] _delaySystemCounts;
    private readonly int[] _arrivedCounts;

    public Stats()
    {
        _delayQueue = new double[3];
        _delayQueueCounts = new int[3];
        _delaySystem = new double[3];
        _delaySystemCounts = new int[3];
        _arrivedCounts = new int[3];
    }

    public void Arrive(StreamEnum stream)
    {
        switch (stream)
        {
            case StreamEnum.A:
                _arrivedCounts[0]++;
                break;
            case StreamEnum.B:
                _arrivedCounts[1]++;
                break;
            case StreamEnum.C:
                _arrivedCounts[2]++;
                break;
        }
    }

    public void DelayQueue(StreamEnum stream, double value)
    {
        switch (stream)
        {
            case StreamEnum.A:
                _delayQueue[0] += value;
                _delayQueueCounts[0]++;
                break;
            case StreamEnum.B:
                _delayQueue[1] += value;
                _delayQueueCounts[1]++;
                break;
            case StreamEnum.C:
                _delayQueue[2] += value;
                _delayQueueCounts[2]++;
                break;
        }
    }

    public void DelaySystem(StreamEnum stream, double value)
    {
        switch (stream)
        {
            case StreamEnum.A:
                _delaySystem[0] += value;
                _delaySystemCounts[0]++;
                break;
            case StreamEnum.B:
                _delaySystem[1] += value;
                _delaySystemCounts[1]++;
                break;
            case StreamEnum.C:
                _delaySystem[2] += value;
                _delaySystemCounts[2]++;
                break;
        }
    }
    public string Report()
    {
        var meanQueue = new double[3];
        for (var i = 0; i < 3; i++)
        {
            meanQueue[i] = _delayQueue[i] / _delayQueueCounts[i];
        }
        var meanSystem = new double[3];
        for (var i = 0; i < 3; i++)
        {
            meanSystem[i] = _delaySystem[i] / _delaySystemCounts[i];
        }
        

        string header = "================R-A-P-O-R-T==========================\n";
        string arrived = $"Arrived[ A: {_arrivedCounts[0]}, B: {_arrivedCounts[1]}, C: {_arrivedCounts[2]}]\n";
        string served = $"Served[ A: {_delayQueueCounts[0]}, B: {_delayQueueCounts[1]}, C: {_delayQueueCounts[2]}]\n";
        string delaysQueue = $"Delays in queue[ A: {meanQueue[0]}, B: {meanQueue[1]}, C: {meanQueue[2]}]\n";
        string delaysSystem = $"Delays in system[ A: {meanSystem[0]}, B: {meanSystem[1]}, C: {meanSystem[2]}]\n";

        return header + arrived + served + delaysQueue + delaysSystem;
    }
}