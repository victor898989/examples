//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Física
{
    /// <summary>
    /// Generador de campo térmico volumétrico para el motor FFSC.
    /// Este campo se usa para:
    /// - Optimización de canales de refrigeración
    /// - Lattice térmico adaptativo
    /// - Análisis de hotspots
    /// - Comparación entre versiones del motor
    /// </summary>
    public static class CampoTermico
    {
        /// <summary>
        /// Campo térmico estático basado en proximidad a la cámara y al aerospike.
        /// </summary>
        public static Field3D Desde(Field3D camara, Field3D spike)
        {
            Field3D campo = Field3D.Empty;

            var combinado = Field3D.Combine(camara, spike);

            combinado.ForEachVoxel((x, y, z, valor) =>
            {
                // Distancia al eje central (zona más caliente)
                double distCentro = Math.Sqrt(x * x + y * y);

                // Temperatura base
                double temp = 1.0 - distCentro;

                // Aumentar temperatura cerca del spike
                if (spike.Sample(x, y, z) > 0.5)
                    temp += 0.4;

                // Normalizar
                temp = Math.Clamp(temp, 0.0, 1.0);

                // Crear voxel térmico
                if (temp > 0.1)
                {
                    var voxel = Field3D.Sphere(temp * 0.01)
                        .Translate(x, y, z);

                    campo = Field3D.Combine(campo, voxel);
                }
            });

            return campo;
        }

        /// <summary>
        /// Campo térmico dinámico para motores adaptativos (v05).
        /// Incluye oscilaciones térmicas simulando ciclos de combustión.
        /// </summary>
        public static Field3D Dinamico(Field3D camara, Field3D spike)
        {
            Field3D campo = Field3D.Empty;

            var combinado = Field3D.Combine(camara, spike);

            combinado.ForEachVoxel((x, y, z, valor) =>
            {
                double distCentro = Math.Sqrt(x * x + y * y);

                // Oscilación térmica tipo pulso de combustión
                double pulso = Math.Sin(z * 10.0) * 0.25;

                double temp = (1.0 - distCentro) + pulso;

                if (spike.Sample(x, y, z) > 0.5)
                    temp += 0.5;

                temp = Math.Clamp(temp, 0.0, 1.0);

                if (temp > 0.1)
                {
                    var voxel = Field3D.Sphere(temp * 0.012)
                        .Translate(x, y, z);

                    campo = Field3D.Combine(campo, voxel);
                }
            });

            return campo;
        }
    }
}
