//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Tuberías del ciclo cerrado FFSC (LOX / CH4).
    /// Incluye tubería principal y dos derivaciones laterales.
    /// </summary>
    public static class Formas_TubosFFSC
    {
        public static Field3D RedTubos(
            double radioTubo = 0.03,
            double longitudPrincipal = 0.80,
            double longitudDerivacion = 0.60)
        {
            // Tubería principal horizontal
            var tuboPrincipal = Field3D.Cylinder(radioTubo, longitudPrincipal)
                .Rotate(Math.PI / 2, 0, 0)
                .Translate(0.30, 0, 0);

            // Derivación superior
            var derivacionSuperior = Field3D.Cylinder(radioTubo, longitudDerivacion)
                .Translate(0.30, 0.20, 0);

            // Derivación inferior
            var derivacionInferior = Field3D.Cylinder(radioTubo, longitudDerivacion)
                .Translate(0.30, -0.20, 0);

            return Field3D.Combine(
                tuboPrincipal,
                derivacionSuperior,
                derivacionInferior
            );
        }
    }
}
