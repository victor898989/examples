//
// Geometry_Inyectores.cs
//
// Inyectores coaxiales FFSC.
//

using PicoGK;

namespace MotorFFSC.Geometry
{
    public static class Geometry_Inyectores
    {
        public static Field3D Crear(int n = 24)
        {
            Field3D inj = Field3D.Empty;

            for (int i = 0; i < n; i++)
            {
                double ang = i * (2 * System.Math.PI / n);
                double x = System.Math.Cos(ang) * 0.12;
                double y = System.Math.Sin(ang) * 0.12;

                var iny = Field3D.Cylinder(0.01, 0.08).Translate(x, y, 0);
                inj = Field3D.Combine(inj, iny);
            }

            return inj;
        }
    }
}
