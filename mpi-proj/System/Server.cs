namespace mpi_proj.System;

public class Server
{
    private ServerStatusEnum _status;

    public ServerStatusEnum Status
    {
        get { return _status; }
        set { _status = value; }
    }
}