//
// FFSCShowcase.cs
//
// Punto de entrada para visualizar el motor FFSC en PicoGK.
//

using PicoGK;
using MotorFFSC.Tasks;

namespace MotorFFSC
{
    public static class FFSCShowcase
    {
        public static Field3D Task_VisualizarMotorAdaptive()
        {
            var engine = EngineFactory.Crear("v05");
            var (camara, spike, manifold, turbina, inyectores) = engine.Componentes();

            return Task_AssemblyFFSC_Adaptive.Run(
                camara,
                spike,
                manifold,
                turbina,
                inyectores
            );
        }
    }
}
