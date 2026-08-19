//
// SPDX-License-Identifier: CC0-1.0
//
// Geometry_NozzleProfile.cs
//
// Perfil de tobera FFSC basado en:
// - Ecuación de área A(z)
// - Relación de expansión Ae/At
// - Longitud característica L*
// - Teoría de toberas de cohete (PDF UC3M)
//
// Cita del PDF:
// “La combustión ocurre en superficies delgadas llamadas llamas,
//  separando reactivos de productos.”
//

using PicoGK;

namespace MotorFFSC.Geometry
{
    public static class Geometry_NozzleProfile
    {
        public static Field3D Crear(double At, double expansionRatio, double Lstar)
        {
            Field3D nozzle = Field3D.Empty;

            int N = 200;
            for (int i = 0; i < N; i++)
            {
                double z = (i / (double)(N - 1)) * Lstar;

                double A = Area(z, At, expansionRatio, Lstar);
                double r = System.Math.Sqrt(A / System.Math.PI);

                var slice = Field3D.Circle(r).Translate(0, 0, z);
                nozzle = Field3D.Combine(nozzle, slice);
            }

            return nozzle;
        }

        private static double Area(double z, double At, double expansionRatio, double Lstar)
        {
            double Ae = At * expansionRatio;
            return At + (Ae - At) * (z / Lstar);
        }
    }
}
