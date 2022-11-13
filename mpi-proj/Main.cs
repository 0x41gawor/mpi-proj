using mpi_proj.Algorithm;
using mpi_proj.Sim;

namespace mpi_proj;

public class Main
{
    private Sim.Time _simTime;
    private System.System _system;
    private Sim.EventList _eventList;
    
    //Algorithms
    private readonly Algorithm.Init _algInit;
    private Algorithm.Time _algTime;
    private Algorithm.Event _algEvent;


    public Main()
    {
        _simTime = new Sim.Time();
        _eventList = new Sim.EventList();
        _system = new System.System();
        
        _algInit = new Algorithm.Init(ref _simTime, ref _system, ref _eventList);
        _algTime = new Algorithm.Time(ref _simTime, ref _eventList);
        _algEvent = new Algorithm.Event(ref _simTime, ref _eventList, ref _system);
    }

    public void Run()
    {
        _algInit.Run();

        var end = false;
        
        while(!end)
        {
            Console.WriteLine($"------------------");
            Console.WriteLine(_eventList);
            // Take next event from the event list
            var e = _algTime.Run();
            Console.WriteLine($"Event popped: {e}");
            Console.WriteLine($"simTime: {_simTime.Value}");
            // Handle the event
            end = _algEvent.Run(e);
        }
    }
}