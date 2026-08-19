//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Canales de refrigeración regenerativa para el manifold FFSC.
    /// Se generan canales helicoidales internos que recorren la carcasa del manifold.
    /// </summary>
    public static class Canales_de_refrigeracion_Manifold
    {
        /// <summary>
        /// Genera canales helicoidales dentro del manifold para refrigeración regenerativa.
        /// </summary>
        public static Field3D Regenerativo(
            Field3D manifold,
            double radioCanal = 0.008,
            double paso = 0.02,
            double radioTrayectoria = 0.12,
            double longitud = 0.32)
        {
            Field3D canales = Field3D.Empty;

            for (double z = 0; z < longitud; z += paso)
            {
                double ang = z * 10.0;

                double x = Math.Cos(ang) * radioTrayectoria;
                double y = Math.Sin(ang) * radioTrayectoria;

                var corte = Field3D.Cylinder(radioCanal, 0.06)
                    .Translate(x, y, z);

                canales = Field3D.Combine(canales, corte);
            }

            return Field3D.Subtract(manifold, canales);
        }
    }
}
