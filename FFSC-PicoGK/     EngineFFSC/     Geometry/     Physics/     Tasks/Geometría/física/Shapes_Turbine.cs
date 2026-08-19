//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Turbina de la turbobomba FFSC.
    /// Genera un rotor con aspas radiales.
    /// </summary>
    public static class Shapes_Turbine
    {
        public static Field3D Turbina(
            double radio = 0.14,
            double grosor = 0.06,
            int aspas = 12)
        {
            // Cubo central (hub)
            var cubo = Field3D.Cylinder(radio * 0.4, grosor);

            Field3D conjuntoAspas = Field3D.Empty;

            for (int i = 0; i < aspas; i++)
            {
                double ang = (Math.PI * 2 / aspas) * i;

                var aspa = Field3D.Box(
                        0.02,          // grosor del aspa
                        radio * 0.6,   // largo del aspa
                        grosor         // altura del aspa
                    )
                    .Rotate(0, 0, ang)
                    .Translate(0, 0, grosor * 0.5);

                conjuntoAspas = Field3D.Combine(conjuntoAspas, aspa);
            }

            return Field3D.Combine(cubo, conjuntoAspas);
        }
    }
}
