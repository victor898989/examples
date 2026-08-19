//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;
using MotorFFSC.Geometría;

namespace MotorFFSC.Física
{
    /// <summary>
    /// Motor físico FFSC.
    /// Combina:
    /// - Campo de tensiones
    /// - Campo térmico
    /// - CFD
    /// - Lattice adaptativo
    /// - Cooling regenerativo
    /// </summary>
    public static class PhysicsEngine
    {
        /// <summary>
        /// Genera todos los campos físicos del motor FFSC.
        /// </summary>
        public static (Field3D stress, Field3D thermal, Field3D cfd) GenerarCampos(Field3D camara, Field3D spike, Field3D manifold)
        {
            var stress = StressField.Dinamico(camara, spike, manifold);
            var thermal = CampoTérmico.Dinamico(camara, spike);
            var cfd = CFD.Dinámico(Field3D.Combine(camara, spike, manifold));

            return (stress, thermal, cfd);
        }

        /// <summary>
        /// Genera un lattice adaptativo basado en tensiones y térmico.
        /// </summary>
        public static Field3D LatticeAdaptativo(Field3D stress, Field3D thermal)
        {
            // Capa gruesa por tensiones
            var lattice1 = Lattice_DualLayer.Generar(stress);

            // Capa cuasicristalina por térmico
            var lattice2 = Lattice_Quasicrystal.Generar(thermal);

            return Field3D.Combine(lattice1, lattice2);
        }

        /// <summary>
        /// Aplica cooling regenerativo adaptativo según campo térmico.
        /// </summary>
        public static Field3D CoolingAdaptativo(Field3D camara, Field3D spike, Field3D thermal)
        {
            // Canales primarios
            var cool1 = Canales_de_refrigeración.Primario(camara, spike);

            // Canales secundarios
            var cool2 = Canales_de_refrigeración.Secundario(camara, spike);

            // Cooling extra en hotspots térmicos
            Field3D extra = Field3D.Empty;

            thermal.ForEachVoxel((x, y, z, valor) =>
            {
                if (valor > 0.7)
                {
                    var canal = Field3D.Cylinder(0.004, 0.05)
                        .Translate(x, y, z);

                    extra = Field3D.Combine(extra, canal);
                }
            });

            return Field3D.Combine(cool1, cool2, extra);
        }

        /// <summary>
        /// Ensambla física + geometría en un solo Field3D.
        /// Este es el que se visualiza en el visor PicoGK.
        /// </summary>
        public static Field3D EnsamblarMotor(Field3D camara, Field3D spike, Field3D manifold)
        {
            // Campos físicos
            var (stress, thermal, cfd) = GenerarCampos(camara, spike, manifold);

            // Lattice adaptativo
            var lattice = LatticeAdaptativo(stress, thermal);

            // Cooling adaptativo
            var cooling = CoolingAdaptativo(camara, spike, thermal);

            // Geometría base
            var baseGeom = Field3D.Combine(camara, spike, manifold);

            // Ensamblado final
            return Field3D.Combine(baseGeom, lattice, cooling);
        }
    }
}
