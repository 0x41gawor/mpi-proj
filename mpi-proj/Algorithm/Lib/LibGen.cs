namespace mpi_proj.Algorithm.Lib;

public class LibGen : ILib
{
    private readonly double _meanA;
    private readonly double _meanB;
    private readonly double _meanC;

    public LibGen(double meanA, double meanB, double meanC)
    {
        _meanA = meanA;
        _meanB = meanB;
        _meanC = meanC;
    }


    public double Run(System.StreamEnum stream)
    {
        return stream switch
        {
            System.StreamEnum.A => _meanA,
            System.StreamEnum.B => _meanB,
            System.StreamEnum.C => _meanC,
            _ => 0.0
        };
    }
}