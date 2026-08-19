//
// Geometry_Manifold.cs
//
// Manifold FFSC para alimentación dual LOX/CH4.
//

using PicoGK;

namespace MotorFFSC.Geometry
{
    public static class Geometry_Manifold
    {
        public static Field3D Crear()
        {
            var anillo = Field3D.Torus(0.25, 0.05);
            var union = Field3D.Cylinder(0.05, 0.15)
                .Translate(0, 0, -0.1);

            return Field3D.Combine(anillo, union);
        }
    }
}
