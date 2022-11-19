namespace mpi_proj.System;

public class Server
{
    public ServerStatusEnum Status { get; set; }
    public Client? CurrentClient { get; set; }
}