//
// FFSC_Pipeline.cs
//
// Pipeline completo estilo LEAP71.
//

using MotorFFSC.Models;
using MotorFFSC.Physics;
using MotorFFSC.Geometry;
using MotorFFSC.Tasks;

namespace MotorFFSC.Pipeline
{
    public static class FFSC_Pipeline_II
    {
        public static Field3D Ejecutar(EngineParams p)
        {
            var thermo = new ComputeThermoTask().Run(p);
            var thick = new ComputeThicknessTask().Run((p, thermo));
            var pump = new TurbopumpDesignTask().Run((p, 250.0));

            var (camara, spike, manifold, turbina, inyectores, nozzle) =
                Geometry_FFSC_Assembly.Crear(p.At, p.Lstar, p.ExpansionRatio);

            return Task_AssemblyFFSC_Adaptive.Run(
                camara, spike, manifold, turbina, inyectores
            );
        }
    }
}
