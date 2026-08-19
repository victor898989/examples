//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    public static class Formas_PreBurner
    {
        public static Field3D PreBurner(
            double radio = 0.14,
            double longitud = 0.22,
            int inyectores = 16)
        {
            var camara = Field3D.Cylinder(radio, longitud);

            Field3D conjuntoInyectores = Field3D.Empty;

            for (int i = 0; i < inyectores; i++)
            {
                double ang = (Math.PI * 2 / inyectores) * i;
                double x = Math.Cos(ang) * (radio - 0.03);
                double y = Math.Sin(ang) * (radio - 0.03);

                var iny = Field3D.Cylinder(0.01, 0.06)
                    .Translate(x, y, longitud * 0.2);

                conjuntoInyectores = Field3D.Combine(conjuntoInyectores, iny);
            }

            return Field3D.Combine(camara, conjuntoInyectores);
        }
    }
}
