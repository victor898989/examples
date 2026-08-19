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
    public static class FFSC_Pipeline
    {
        public static Field3D Ejecutar(EngineParams p)
        {
            var thermo = new ComputeThermoTask().Run(p);
            var thick = new ComputeThicknessTask().Run((p, thermo));
            var pump = new TurbopumpDesignTask().Run((p, 250.0));

            var camara = Geometry_Camara.Crear(p.At, p.Lstar);
            var spike = Geometry_Aerospike.Crear(0.5);
            var manifold = Geometry_Manifold.Crear();
            var turbina = Geometry_Turbina.Crear();
            var inyectores = Geometry_Inyectores.Crear();

            return Task_AssemblyFFSC_Adaptive.Run(
                camara, spike, manifold, turbina, inyectores
            );
        }
    }
}
