namespace mpi_proj.System;

public class System
{
    private Server _server;
    private Queue _queue;


    public System()
    {
        _server = new Server();
        _queue = new Queue();
    }
    
    public void Init()
    {
        _server.Status = ServerStatusEnum.Free;
        //TODO Stats to be implemented
        
    }
}