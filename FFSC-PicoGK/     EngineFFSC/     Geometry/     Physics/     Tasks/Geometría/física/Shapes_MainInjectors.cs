//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Placa de inyectores del motor principal FFSC.
    /// Genera una placa circular con múltiples inyectores distribuidos radialmente.
    /// </summary>
    public static class Shapes_MainInjectors
    {
        public static Field3D PlacaInyectora(
            double radioPlaca = 0.24,
            int cantidadInyectores = 32,
            double radioInyector = 0.008,
            double longitudInyector = 0.06)
        {
            // Placa base
            var placa = Field3D.Cylinder(radioPlaca, 0.02);

            Field3D conjuntoInyectores = Field3D.Empty;

            for (int i = 0; i < cantidadInyectores; i++)
            {
                double ang = (Math.PI * 2 / cantidadInyectores) * i;
                double r = radioPlaca * 0.7;

                double x = Math.Cos(ang) * r;
                double y = Math.Sin(ang) * r;

                var inyector = Field3D.Cylinder(radioInyector, longitudInyector)
                    .Translate(x, y, 0.01);

                conjuntoInyectores = Field3D.Combine(conjuntoInyectores, inyector);
            }

            return Field3D.Combine(placa, conjuntoInyectores);
        }
    }
}
