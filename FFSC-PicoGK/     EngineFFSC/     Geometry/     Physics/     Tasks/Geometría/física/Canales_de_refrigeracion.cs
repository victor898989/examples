//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Canales de refrigeración regenerativa para cámara y aerospike.
    /// Incluye canales helicoidales primarios y secundarios.
    /// </summary>
    public static class Canales_de_refrigeracion
    {
        /// <summary>
        /// Canales helicoidales primarios alrededor de la cámara.
        /// </summary>
        public static Field3D Primario(
            Field3D camara,
            Field3D spike,
            double radioCanal = 0.006,
            double paso = 0.02)
        {
            Field3D canales = Field3D.Empty;

            // Altura total de la cámara
            double altura = 0.45;

            for (double z = 0; z < altura; z += paso)
            {
                double ang = z * 10.0;
                double x = Math.Cos(ang) * 0.22;
                double y = Math.Sin(ang) * 0.22;

                var corte = Field3D.Cylinder(radioCanal, 0.05)
                    .Translate(x, y, z);

                canales = Field3D.Combine(canales, corte);
            }

            return Field3D.Subtract(camara, canales);
        }

        /// <summary>
        /// Canales helicoidales secundarios para refuerzo térmico.
        /// </summary>
        public static Field3D Secundario(
            Field3D camara,
            Field3D spike,
            double radioCanal = 0.004,
            double paso = 0.015)
        {
            Field3D canales = Field3D.Empty;

            double altura = 0.45;

            for (double z = 0; z < altura; z += paso)
            {
                double ang = z * 14.0;
                double x = Math.Cos(ang) * 0.18;
                double y = Math.Sin(ang) * 0.18;

                var corte = Field3D.Cylinder(radioCanal, 0.04)
                    .Translate(x, y, z);

                canales = Field3D.Combine(canales, corte);
            }

            return Field3D.Subtract(camara, canales);
        }
    }
}
