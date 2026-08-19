//
// Geometry_Aerospike.cs
//
// Aerospike FFSC tipo Raptor.
// Perfil lineal + base toroidal.
//

using PicoGK;

namespace MotorFFSC.Geometry
{
    public static class Geometry_Aerospike
    {
        public static Field3D Crear(double longitud)
        {
            var spike = Field3D.Cone(0.02, 0.15, longitud);
            var baseToro = Field3D.Torus(0.15, 0.03)
                .Translate(0, 0, longitud);

            return Field3D.Combine(spike, baseToro);
        }
    }
}
