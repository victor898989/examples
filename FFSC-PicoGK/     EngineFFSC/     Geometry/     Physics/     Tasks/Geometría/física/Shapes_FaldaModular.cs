//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Falda modular reforzada del aerospike.
    /// Incluye nervaduras radiales y estructura anti-vibración.
    /// </summary>
    public static class Shapes_FaldaModular
    {
        public static Field3D Falda(
            double radio = 0.22,
            double altura = 0.18,
            int nervaduras = 12,
            double grosor = 0.02)
        {
            // Falda cilíndrica base
            var faldaBase = Field3D.Cylinder(radio, altura);

            Field3D conjuntoNervaduras = Field3D.Empty;

            for (int i = 0; i < nervaduras; i++)
            {
                double ang = (Math.PI * 2 / nervaduras) * i;

                // Nervadura rectangular
                var nervadura = Field3D.Box(
                        grosor,          // grosor
                        radio * 0.8,     // largo
                        altura           // altura
                    )
                    .Rotate(0, 0, ang)
                    .Translate(
                        Math.Cos(ang) * (radio * 0.5),
                        Math.Sin(ang) * (radio * 0.5),
                        altura * 0.5
                    );

                conjuntoNervaduras = Field3D.Combine(conjuntoNervaduras, nervadura);
            }

            return Field3D.Combine(faldaBase, conjuntoNervaduras);
        }
    }
}
