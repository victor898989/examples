//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Manifold con válvulas redundantes.
    /// </summary>
    public static class Formas_Valvulas_Manifold
    {
        public static Field3D ManifoldReforzado(
            double radio = 0.18,
            double longitud = 0.32,
            int valvulas = 4,
            double grosor = 0.012)
        {
            var externo = Field3D.Cylinder(radio, longitud);
            var interno = Field3D.Cylinder(radio - grosor, longitud);

            var carcasa = Field3D.Subtract(externo, interno);

            Field3D conjuntoValvulas = Field3D.Empty;

            for (int i = 0; i < valvulas; i++)
            {
                double ang = (Math.PI * 2 / valvulas) * i;
                double x = Math.Cos(ang) * (radio + 0.05);
                double y = Math.Sin(ang) * (radio + 0.05);

                var valvula = Field3D.Cylinder(0.03, 0.12)
                    .Translate(x, y, longitud * 0.4);

                conjuntoValvulas = Field3D.Combine(conjuntoValvulas, valvula);
            }

            return Field3D.Combine(carcasa, conjuntoValvulas);
        }
    }
}
