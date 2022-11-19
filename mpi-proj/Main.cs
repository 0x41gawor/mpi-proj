using mpi_proj.Algorithm;
using mpi_proj.Sim;

namespace mpi_proj;

public class Main
{
    private readonly Sim.Time _simTime;
    private readonly System.System _system;
    private readonly Sim.EventList _eventList;
    
    // Algorithms
    private readonly Algorithm.Init _algInit;
    private readonly Algorithm.Time _algTime;
    private readonly Algorithm.Event _algEvent;
    // Stats
    private readonly Sim.Stats _stats;

    public Main()
    {
        _simTime = new Sim.Time();
        _eventList = new Sim.EventList();
        _system = new System.System();
        
        _stats = new Stats();

        var arrivalLib = new Algorithm.Lib.LibExp(2.0);
        var departureLib = new Algorithm.Lib.LibGen(0.5, 1.0, 2.0);
        
        _algInit = new Algorithm.Init(ref _simTime, ref _system, ref _eventList);
        _algTime = new Algorithm.Time(ref _simTime, ref _eventList);
        _algEvent = new Algorithm.Event(ref _simTime, ref _eventList, ref _system, ref _stats, arrivalLib, departureLib);
    }

    public void Run()
    {
        _algInit.Run();

        var end = false;
        Console.WriteLine(_eventList);
        while(!end)
        {
            Console.WriteLine($"------------------");
            // Take next event from the event list
            var e = _algTime.Run();
            Console.WriteLine($"Event popped: {e}");
            // Handle the event
            end = _algEvent.Run(e);
            Console.WriteLine(_eventList);
        }
        Console.WriteLine(_stats.Report());
    }
}