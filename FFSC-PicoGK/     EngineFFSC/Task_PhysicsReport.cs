//
// SPDX-License-Identifier: CC0-1.0
//

using System.IO;
using PicoGK;
using MotorFFSC.Física;
using MotorFFSC.Geometría;

namespace MotorFFSC.Tasks
{
    /// <summary>
    /// Genera un reporte físico completo del motor FFSC:
    /// - Volumen
    /// - Masa
    /// - Centro de masa
    /// - Inercia
    /// - Tensiones
    /// - Campo térmico
    /// - CFD
    /// </summary>
    public static class Task_PhysicsReport
    {
        public static void Run(Field3D camara, Field3D spike, Field3D manifold)
        {
            Directory.CreateDirectory("output");

            // Geometría base
            var geom = Field3D.Combine(camara, spike, manifold);

            // Propiedades físicas
            var volumen = MassProperties.Volumen(geom);
            var masa = MassProperties.Masa(geom);
            var cm = MassProperties.CentroDeMasa(geom);
            var iner = MassProperties.Inercia(geom);

            // Campos físicos
            var stress = StressField.Dinamico(camara, spike, manifold);
            var thermal = CampoTérmico.Dinamico(camara, spike);
            var cfd = CFD.Dinámico(geom);

            // Reporte
            string reporte =
                "=============================\n" +
                "   REPORTE FÍSICO FFSC\n" +
                "=============================\n\n" +
                "--- PROPIEDADES GEOMÉTRICAS ---\n" +
                $"Volumen total: {volumen:F4} m³\n" +
                $"Masa estimada: {masa:F2} kg\n" +
                $"Centro de masa: ({cm.x:F3}, {cm.y:F3}, {cm.z:F3})\n" +
                $"Inercia: Ix={iner.ix:F3}, Iy={iner.iy:F3}, Iz={iner.iz:F3}\n\n" +
                "--- CAMPOS FÍSICOS ---\n" +
                $"Stress voxels: {stress.CountVoxels()}\n" +
                $"Thermal voxels: {thermal.CountVoxels()}\n" +
                $"CFD voxels: {cfd.CountVoxels()}\n\n" +
                "--- NOTAS ---\n" +
                "Este reporte se genera automáticamente a partir de la geometría FFSC.\n" +
                "Los campos físicos se usan para lattice, cooling y optimización.\n";

            File.WriteAllText("output/Reporte_FFSC.txt", reporte);
        }
    }
}
