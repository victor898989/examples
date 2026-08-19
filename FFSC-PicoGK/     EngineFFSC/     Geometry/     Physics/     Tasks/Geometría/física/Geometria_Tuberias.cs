//
// Geometry_Tuberias.cs
//
// Tuberías FFSC para LOX y CH4.
//

using PicoGK;

namespace MotorFFSC.Geometry
{
    public static class Geometry_Tuberias
    {
        public static Field3D Crear()
        {
            var lox = Field3D.Cylinder(0.03, 0.5).Translate(0.1, 0, 0);
            var ch4 = Field3D.Cylinder(0.03, 0.5).Translate(-0.1, 0, 0);

            return Field3D.Combine(lox, ch4);
        }
    }
}
