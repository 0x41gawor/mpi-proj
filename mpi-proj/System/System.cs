namespace mpi_proj.System;

public class System
{
    public Server Server { get; set; }
    public Scheduler Queue { get; set; }

    public System()
    {
        Server = new Server();
        Queue = new Scheduler();
    }
    
    public void Init()
    {
        Server.Status = ServerStatusEnum.Free;
        //TODO Stats to be implemented
        
    }
}