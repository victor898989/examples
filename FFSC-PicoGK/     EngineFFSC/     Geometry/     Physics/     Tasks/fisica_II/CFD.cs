//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;
using System;

namespace MotorFFSC.Física
{
    /// <summary>
    /// Simulación CFD simplificada para el motor FFSC.
    /// Genera un campo volumétrico con velocidades y presiones aproximadas.
    /// Este campo se usa para:
    /// - Optimizar inyectores
    /// - Ajustar manifold
    /// - Refinar aerospike
    /// - Comparar versiones del motor
    /// </summary>
    public static class CFD
    {
        /// <summary>
        /// Genera un campo CFD estático basado en la geometría.
        /// </summary>
        public static Field3D Estático(Field3D geom)
        {
            Field3D campo = Field3D.Empty;

            geom.ForEachVoxel((x, y, z, valor) =>
            {
                if (valor < 0.5)
                    return;

                // Velocidad aproximada según distancia al centro
                double dist = Math.Sqrt(x * x + y * y);
                double vel = 1.0 - dist;

                // Presión aproximada según altura
                double pres = Math.Sin(z * 8.0) * 0.5 + 0.5;

                double intensidad = Math.Clamp((vel + pres) * 0.5, 0.0, 1.0);

                var voxel = Field3D.Sphere(intensidad * 0.01)
                    .Translate(x, y, z);

                campo = Field3D.Combine(campo, voxel);
            });

            return campo;
        }

        /// <summary>
        /// CFD dinámico para motores adaptativos (v05).
        /// Incluye oscilaciones de presión y turbulencia.
        /// </summary>
        public static Field3D Dinámico(Field3D geom)
        {
            Field3D campo = Field3D.Empty;

            geom.ForEachVoxel((x, y, z, valor) =>
            {
                if (valor < 0.5)
                    return;

                double dist = Math.Sqrt(x * x + y * y);

                double vel = (1.0 - dist) + Math.Sin(z * 12.0) * 0.2;
                double pres = Math.Cos(z * 9.0) * 0.3 + 0.7;

                double intensidad = Math.Clamp((vel + pres) * 0.5, 0.0, 1.0);

                var voxel = Field3D.Sphere(intensidad * 0.012)
                    .Translate(x, y, z);

                campo = Field3D.Combine(campo, voxel);
            });

            return campo;
        }
    }
}
