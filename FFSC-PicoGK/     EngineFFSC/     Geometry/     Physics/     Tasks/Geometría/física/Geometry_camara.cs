//
// Geometry_Camara.cs
//
// Cámara de combustión FFSC.
// Basado en:
// - L* (longitud característica)
// - At (área de garganta)
// - Perfil cilíndrico + transición convergente
//

using PicoGK;

namespace MotorFFSC.Geometry
{
    public static class Geometry_Camara
    {
        public static Field3D Crear(double At, double Lstar)
        {
            double r = System.Math.Sqrt(At / System.Math.PI);

            var cilindro = Field3D.Cylinder(r, Lstar * 0.6);
            var convergente = Field3D.Cone(r * 1.4, r, Lstar * 0.4)
                .Translate(0, 0, Lstar * 0.6);

            return Field3D.Combine(cilindro, convergente);
        }
    }
}
