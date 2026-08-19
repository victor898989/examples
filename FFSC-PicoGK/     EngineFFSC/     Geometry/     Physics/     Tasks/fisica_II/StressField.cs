//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Física
{
    /// <summary>
    /// Generador de campo de tensiones volumétrico para el motor FFSC.
    /// Este campo se usa para:
    /// - Lattice adaptativo
    /// - Refuerzos estructurales
    /// - Optimización de masa
    /// - Cooling inteligente
    /// </summary>
    public static class StressField
    {
        /// <summary>
        /// Campo de tensiones estático basado en proximidad a la cámara y manifold.
        /// </summary>
        public static Field3D Desde(Field3D camara, Field3D spike, Field3D manifold)
        {
            var stress = Field3D.Empty;

            // Recorremos el volumen combinado
            var combinado = Field3D.Combine(camara, spike, manifold);

            combinado.ForEachVoxel((x, y, z, valor) =>
            {
                // Distancia al eje central (zona de mayor tensión)
                double distCentro = Math.Sqrt(x * x + y * y);

                // Tensión base
                double tension = 1.0 - distCentro;

                // Aumentar tensión cerca del manifold
                if (manifold.Sample(x, y, z) > 0.5)
                    tension += 0.4;

                // Aumentar tensión cerca del spike
                if (spike.Sample(x, y, z) > 0.5)
                    tension += 0.3;

                // Normalizar
                tension = Math.Clamp(tension, 0.0, 1.0);

                // Crear voxel de tensión
                if (tension > 0.1)
                {
                    var voxel = Field3D.Sphere(tension * 0.01)
                        .Translate(x, y, z);

                    stress = Field3D.Combine(stress, voxel);
                }
            });

            return stress;
        }

        /// <summary>
        /// Campo de tensiones dinámico para motores adaptativos (v05).
        /// </summary>
        public static Field3D Dinamico(Field3D camara, Field3D spike, Field3D manifold)
        {
            var stress = Field3D.Empty;

            var combinado = Field3D.Combine(camara, spike, manifold);

            combinado.ForEachVoxel((x, y, z, valor) =>
            {
                double distCentro = Math.Sqrt(x * x + y * y);

                // Oscilación dinámica tipo vibración
                double oscilacion = Math.Sin(z * 12.0) * 0.2;

                double tension = (1.0 - distCentro) + oscilacion;

                if (manifold.Sample(x, y, z) > 0.5)
                    tension += 0.5;

                if (spike.Sample(x, y, z) > 0.5)
                    tension += 0.4;

                tension = Math.Clamp(tension, 0.0, 1.0);

                if (tension > 0.1)
                {
                    var voxel = Field3D.Sphere(tension * 0.012)
                        .Translate(x, y, z);

                    stress = Field3D.Combine(stress, voxel);
                }
            });

            return stress;
        }
    }
}
