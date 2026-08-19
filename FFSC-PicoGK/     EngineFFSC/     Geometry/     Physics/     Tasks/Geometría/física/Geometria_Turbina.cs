//
// Geometry_Turbina.cs
//
// Turbina FFSC simplificada.
//

using PicoGK;

namespace MotorFFSC.Geometry
{
    public static class Geometry_Turbina
    {
        public static Field3D Crear()
        {
            var disco = Field3D.Cylinder(0.12, 0.05);
            var eje = Field3D.Cylinder(0.03, 0.3).Translate(0, 0, -0.15);

            return Field3D.Combine(disco, eje);
        }
    }
}
