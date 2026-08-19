//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Geometría de la cámara de combustión y el aerospike.
    /// </summary>
    public static class Formas_ChamberSpike
    {
        public static Field3D Camara(
            double radioCamara = 0.25,
            double radioTobera = 0.12,
            double longitud = 0.45)
        {
            var cilindro = Field3D.Cylinder(radioCamara, longitud);
            var cuello = Field3D.Cylinder(radioTobera, longitud * 0.25)
                .Translate(0, 0, longitud * 0.75);

            return Field3D.Combine(cilindro, cuello);
        }

        public static Field3D Aerospike(
            double altura = 0.55,
            double radioBase = 0.12)
        {
            var spike = Field3D.Cone(radioBase, altura);
            return spike.Translate(0, 0, -altura * 0.5);
        }
    }
}
