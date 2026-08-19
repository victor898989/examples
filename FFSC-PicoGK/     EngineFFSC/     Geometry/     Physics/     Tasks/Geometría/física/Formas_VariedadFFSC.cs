//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Manifold FFSC completo con múltiples ramas.
    /// </summary>
    public static class Formas_VariedadFFSC
    {
        public static Field3D ManifoldCompleto(
            double radio = 0.20,
            double longitud = 0.40,
            int ramas = 6)
        {
            var cuerpo = Field3D.Cylinder(radio, longitud);

            Field3D conjuntoRamas = Field3D.Empty;

            for (int i = 0; i < ramas; i++)
            {
                double ang = (Math.PI * 2 / ramas) * i;
                double x = Math.Cos(ang) * radio;
                double y = Math.Sin(ang) * radio;

                var rama = Field3D.Cylinder(0.05, 0.22)
                    .Rotate(Math.PI / 2, 0, 0)
                    .Translate(x, y, longitud * 0.5);

                conjuntoRamas = Field3D.Combine(conjuntoRamas, rama);
            }

            return Field3D.Combine(cuerpo, conjuntoRamas);
        }
    }
}
