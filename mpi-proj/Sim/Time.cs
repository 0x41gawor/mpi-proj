namespace mpi_proj.Sim;

// special wrapper class for double time, so it can be passed as ref 
// https://stackoverflow.com/questions/13221936/using-a-double-by-reference-in-c-sharp
public class Time
{
    private double _value;

    public double Value
    {
        get => _value;
        set => _value = value;
    }
}