//
// Geometry_FFSC_Assembly.cs
//
// Ensamblado geométrico del motor FFSC.
// Combina:
// - Cámara
// - Aerospike
// - Manifold
// - Tuberías
// - Turbina
// - Inyectores
// - Tobera
//

using PicoGK;

namespace MotorFFSC.Geometry
{
    public static class Geometry_FFSC_Assembly
    {
        public static (Field3D camara, Field3D spike, Field3D manifold, Field3D turbina, Field3D inyectores, Field3D nozzle)
            Crear(double At, double Lstar, double expansionRatio)
        {
            var camara = Geometry_Camara.Crear(At, Lstar);
            var spike = Geometry_Aerospike.Crear(0.5);
            var manifold = Geometry_Manifold.Crear();
            var turbina = Geometry_Turbina.Crear();
            var inyectores = Geometry_Inyectores.Crear();
            var nozzle = Geometry_NozzleProfile.Crear(At, expansionRatio, Lstar);

            return (camara, spike, manifold, turbina, inyectores, nozzle);
        }
    }
}
