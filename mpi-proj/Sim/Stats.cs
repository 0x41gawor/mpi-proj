using mpi_proj.System;

namespace mpi_proj.Sim;

public class Stats
{
    private readonly double[] _delayQueue;
    private readonly double[] _squareValueForDelayQueue;
    private readonly int[] _delayQueueCounts;
    private readonly double[] _delaySystem;
    private readonly int[] _delaySystemCounts;
    private readonly int[] _arrivedCounts;

    private  double _workloadRects;
    private  double _workloadLastSimTime;
    private  double _workloadValue;

    public Stats()
    {
        _delayQueue = new double[3];
        _squareValueForDelayQueue = new double[3];
        _delayQueueCounts = new int[3];
        _delaySystem = new double[3];
        _delaySystemCounts = new int[3];
        _arrivedCounts = new int[3];
        
        _workloadRects = 0.0;
        _workloadLastSimTime = 0.0;
        _workloadValue = 0.0;
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
                _squareValueForDelayQueue[0] += value * value;
                _delayQueueCounts[0]++;
                break;
            case StreamEnum.B:
                _delayQueue[1] += value;
                _squareValueForDelayQueue[1] += value * value;
                _delayQueueCounts[1]++;
                break;
            case StreamEnum.C:
                _delayQueue[2] += value;
                _squareValueForDelayQueue[2] += value * value;
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

    private double[] CountSigma()
    {
        var sigma1 = new double[3];
        for (var i = 0; i < 3; i++)
        {
            double ex2 = (_squareValueForDelayQueue[i] / _delayQueueCounts[i]);
            double ex = (_delayQueue[i] / _delayQueueCounts[i]);
            sigma1[i] = ex2 - ex*ex;
        }

        return sigma1;
    }

    public void Workload(double simTime, ServerStatusEnum status)
    {
        var timeInterval = simTime - _workloadLastSimTime;
        _workloadLastSimTime = simTime;
        var rect = timeInterval * (int)status;
        _workloadRects += rect;
        _workloadValue = _workloadRects / simTime;
    }
    public string Report(System.System system, double simTime)
    {
        Workload(simTime, system.Server.Status);
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

        var overallDelayQueue = (meanQueue[0] + meanQueue[1] + meanQueue[2]) / 3;
        var overallDelaySystem = (meanSystem[0] + meanSystem[1] + meanSystem[2]) / 3;
        var sigma = CountSigma();

        string header = "================R-A-P-O-R-T==========================\n";
        string arrived = $"Arrived[ A: {_arrivedCounts[0]}, B: {_arrivedCounts[1]}, C: {_arrivedCounts[2]}]\n";
        string served = $"Served[ A: {_delayQueueCounts[0]}, B: {_delayQueueCounts[1]}, C: {_delayQueueCounts[2]}]\n";
        string delaysQueue = $"Delays in queue[ A: {meanQueue[0]:0.00}, B: {meanQueue[1]:0.00}, C: {meanQueue[2]:0.00}]\n";
        string delaysSystem = $"Delays in system[ A: {meanSystem[0]:0.00}, B: {meanSystem[1]:0.00}, C: {meanSystem[2]:0.00}]\n";
        string sigma1Show = $"Variance[ A: {sigma[0]:0.00}, B: {sigma[1]:0.00}, C: {sigma[2]:0.00} ]\n";
        string overallDelays = $"Overall delays for all streams[ In Queue: {overallDelayQueue:0.00}, In System: {overallDelaySystem:0.00} ]\n";
        string workload = $"Server workload: {_workloadValue}\n";
        
        return header + arrived + served + delaysQueue + delaysSystem + sigma1Show + overallDelays + workload;
    }
}