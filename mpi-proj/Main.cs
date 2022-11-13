using mpi_proj.Algorithm;

namespace mpi_proj;

public class Main
{
    private double _simTime;
    private System.System _system;
    private Sim.EventList _eventList;
    
    //Algorithms
    private readonly Algorithm.Init _algInit;
    private Algorithm.Time _algTime;
    private Algorithm.Event _algEvent;


    public Main()
    {
        _eventList = new Sim.EventList();
        _system = new System.System();
        
        _algInit = new Algorithm.Init(ref _simTime, ref _system, ref _eventList);
        _algTime = new Algorithm.Time(ref _eventList, ref _simTime);
        _algEvent = new Algorithm.Event();
    }

    public void Run()
    {
        _algInit.Run();
        Console.WriteLine(_eventList);
        var e = _eventList.Pop();
        var e1 = _algTime.Run();
        Console.WriteLine(e);
        Console.WriteLine(e1);
        Console.WriteLine(_eventList);
    }
}