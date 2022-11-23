namespace mpi_proj;

public static class Config
{
    // mean value in arrival distribution (all streams)
    public const double Mean = 6.0; // every `Mean` time units, 3 clients arrive
    // mean value in departure distribution for stream A
    public const double MeanA = 0.5;
    // mean value in departure distribution for stream B
    public const double MeanB = 1.0;
    // mean value in departure distribution for stream C
    public const double MeanC = 1.5;
    // simulation time
    public const double SimulationTime = 100000.0;
}