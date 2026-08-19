//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;
using MotorFFSC.Geometría;
using MotorFFSC.Física;

namespace MotorFFSC.Tasks
{
    /// <summary>
    /// Ensambla el motor FFSC completo en un solo Field3D.
    /// Este Task es el que se usa para visualizar el motor en PicoGK.
    /// </summary>
    public static class Task_AssemblyFFSC
    {
        public static Field3D Run(Field3D camara, Field3D spike, Field3D manifold, Field3D turbina, Field3D inyectores)
        {
            // Geometría base
            var baseGeom = Field3D.Combine(camara, spike, manifold, turbina, inyectores);

            // Campos físicos
            var (stress, thermal, cfd) = PhysicsEngine.GenerarCampos(camara, spike, manifold);

            // Lattice adaptativo
            var lattice = PhysicsEngine.LatticeAdaptativo(stress, thermal);

            // Cooling adaptativo
            var cooling = PhysicsEngine.CoolingAdaptativo(camara, spike, thermal);

            // Ensamblado final
            var ensamblado = Field3D.Combine(baseGeom, lattice, cooling);

            return ensamblado;
        }
    }
}
