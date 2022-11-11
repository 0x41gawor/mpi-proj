namespace mpi_proj;

public class Main
{
    private double _simTime;
    private System.System _system;
    private Sim.EventList _eventList;
    
    //Algorithms
    private Algorithm.Init _algInit;
    private Algorithm.Time _algTime;
    private Algorithm.Event _algEvent;


    public Main()
    {
        _algInit = new Algorithm.Init();
        _algTime = new Algorithm.Time();
        _algEvent = new Algorithm.Event();

        _eventList = new Sim.EventList();
        _system = new System.System();
    }

    public void Run()
    {
        _algInit.Run(ref _simTime, ref _system, ref _eventList);
        Console.WriteLine(_eventList.ToString());
        Console.WriteLine(_eventList.ToString());
        // _algTime.Run();
    }
}