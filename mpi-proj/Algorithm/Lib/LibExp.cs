namespace mpi_proj.Algorithm.Lib;

public class LibExp : ILib
{
   private double _mean;
   public LibExp(double mean)
   {
      _mean = mean;
   }
   
   public double Run()
   {
      var random = new Random();
      
      double rnd;
      do
      {
         rnd = random.NextDouble();
      } while (rnd == 0);

      return -_mean * Math.Log(rnd);
   }
}