using mpi_proj.Sim;

namespace mpi_proj;

public class Main
{
    // Simulation
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

        var arrivalLib = new Algorithm.Lib.LibExp(Config.Mean); 
        var departureLib = new Algorithm.Lib.LibGen(Config.MeanA, Config.MeanB, Config.MeanC); 
        
        _algInit = new Algorithm.Init(ref _simTime, ref _system, ref _eventList, Config.SimulationTime);
        _algTime = new Algorithm.Time(ref _simTime, ref _eventList);
        _algEvent = new Algorithm.Event(ref _simTime, ref _eventList, ref _system, ref _stats, arrivalLib, departureLib);
    }

    public void Run()
    {
        _algInit.Run();

        var end = false;
        while(!end)
        {
            // Take next event from the event list
            var e = _algTime.Run();
            // Handle the event
            end = _algEvent.Run(e);
        }
        Console.WriteLine(_stats.Report(_system, _simTime.Value));
    }
}