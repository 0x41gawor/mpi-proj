using mpi_proj.System;

namespace mpi_proj.Sim;

public class Stats
{
    private readonly double[] _delay;
    private readonly int[] _delayCounts;
    private readonly int[] _arrivedCounts;

    public Stats()
    {
        _delay = new double[3];
        _delayCounts = new int[3];
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

    public void Delay(StreamEnum stream, double value)
    {
        switch (stream)
        {
            case StreamEnum.A:
                Console.WriteLine($"Strumien A: {value}");
                _delay[0] += value;
                _delayCounts[0]++;
                break;
            case StreamEnum.B:
                Console.WriteLine($"Strumien B: {value}");
                _delay[1] += value;
                _delayCounts[1]++;
                break;
            case StreamEnum.C:
                Console.WriteLine($"Strumien C: {value}");
                _delay[2] += value;
                _delayCounts[2]++;
                break;
        }
    }

    public string Report()
    {
        var mean = new double[3];
        for (var i = 0; i < 3; i++)
        {
            mean[i] = _delay[i] / _delayCounts[i];
        }

        string header = "================R-A-P-O-R-T==========================\n";
        string arrived = $"Arrived[ A: {_arrivedCounts[0]}, B: {_arrivedCounts[1]}, C: {_arrivedCounts[2]}]\n";
        string delays = $"Delays[ A: {mean[0]}, B: {mean[1]}, C: {mean[2]}]\n";
        string served = $"Served[ A: {_delayCounts[0]}, B: {_delayCounts[1]}, C: {_delayCounts[2]}]\n";

        return header + arrived +  served + delays;
    }
}