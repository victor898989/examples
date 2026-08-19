//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    public static class Formas_Turbobomba
    {
        public static Field3D Turbobomba(
            double radio = 0.16,
            double longitud = 0.28,
            int aspas = 10)
        {
            var cuerpo = Field3D.Cylinder(radio, longitud);

            Field3D conjuntoAspas = Field3D.Empty;

            for (int i = 0; i < aspas; i++)
            {
                double ang = (Math.PI * 2 / aspas) * i;
                double x = Math.Cos(ang) * (radio * 0.7);
                double y = Math.Sin(ang) * (radio * 0.7);

                var aspa = Field3D.Box(0.01, radio * 0.4, 0.06)
                    .Rotate(0, 0, ang)
                    .Translate(x, y, longitud * 0.3);

                conjuntoAspas = Field3D.Combine(conjuntoAspas, aspa);
            }

            return Field3D.Combine(cuerpo, conjuntoAspas);
        }
    }
}
