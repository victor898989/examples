//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;
using System;

namespace MotorFFSC.Física
{
    /// <summary>
    /// Cálculo de propiedades físicas del motor FFSC:
    /// - Volumen total
    /// - Masa (según densidad)
    /// - Centro de masa
    /// - Inercia aproximada
    /// </summary>
    public static class MassProperties
    {
        /// <summary>
        /// Calcula el volumen total del Field3D.
        /// </summary>
        public static double Volumen(Field3D geom, double voxelSize = 0.001)
        {
            double volumen = 0.0;

            geom.ForEachVoxel((x, y, z, valor) =>
            {
                if (valor > 0.5)
                    volumen += voxelSize * voxelSize * voxelSize;
            });

            return volumen;
        }

        /// <summary>
        /// Calcula la masa total según densidad.
        /// </summary>
        public static double Masa(Field3D geom, double densidad = 8200.0)
        {
            double volumen = Volumen(geom);
            return volumen * densidad;
        }

        /// <summary>
        /// Calcula el centro de masa del volumen.
        /// </summary>
        public static (double x, double y, double z) CentroDeMasa(Field3D geom)
        {
            double sx = 0, sy = 0, sz = 0;
            double total = 0;

            geom.ForEachVoxel((x, y, z, valor) =>
            {
                if (valor > 0.5)
                {
                    sx += x;
                    sy += y;
                    sz += z;
                    total++;
                }
            });

            if (total == 0)
                return (0, 0, 0);

            return (sx / total, sy / total, sz / total);
        }

        /// <summary>
        /// Calcula la inercia aproximada del motor.
        /// </summary>
        public static (double ix, double iy, double iz) Inercia(Field3D geom)
        {
            double ix = 0, iy = 0, iz = 0;

            geom.ForEachVoxel((x, y, z, valor) =>
            {
                if (valor > 0.5)
                {
                    ix += y * y + z * z;
                    iy += x * x + z * z;
                    iz += x * x + y * y;
                }
            });

            return (ix, iy, iz);
        }

        /// <summary>
        /// Genera un reporte completo de propiedades físicas.
        /// </summary>
        public static string Reporte(Field3D geom)
        {
            var volumen = Volumen(geom);
            var masa = Masa(geom);
            var cm = CentroDeMasa(geom);
            var iner = Inercia(geom);

            return
                $"--- PROPIEDADES FÍSICAS FFSC ---\n" +
                $"Volumen total: {volumen:F4} m³\n" +
                $"Masa estimada: {masa:F2} kg\n" +
                $"Centro de masa: ({cm.x:F3}, {cm.y:F3}, {cm.z:F3})\n" +
                $"Inercia: Ix={iner.ix:F3}, Iy={iner.iy:F3}, Iz={iner.iz:F3}\n";
        }
    }
}
