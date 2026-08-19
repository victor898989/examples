//
// Program.cs
//
// Ejecuta el visor PicoGK con el motor FFSC adaptativo.
//

using PicoGK;
using MotorFFSC;

class Program
{
    static void Main(string[] args)
    {
        Library.Go(0.5f, FFSCShowcase.Task_VisualizarMotorAdaptive);
    }
}
