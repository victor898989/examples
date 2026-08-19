//
// TurbopumpDesignTask.cs
//
// Diseño paramétrico de turbobomba FFSC.
// Basado en:
//  - Ecuación de Euler: Δh = U2 * Cu2 - U1 * Cu1
//  - Continuidad: Q = 2π * rm * h * Cm
//
// Cita del PDF:
// “La ecuación de Euler para turbomáquinas relaciona el trabajo
//  específico con las velocidades periféricas y tangenciales.”
//

using System.Collections.Generic;
using MotorFFSC.Models;

namespace MotorFFSC.Physics
{
    public class TurbopumpDesignTask
    {
        public PumpSpec Run((EngineParams, double) input)
        {
            var (p, mdot) = input;

            double rho = 1141.0; // LOX
            double Q = mdot / rho;

            double deltaP = 30e6;
            double deltaH = deltaP / rho;

            double N = 40000.0;
            double omega = 2.0 * System.Math.PI * N / 60.0;

            double r2 = 0.06;
            double U2 = omega * r2;

            double Cu2 = deltaH / U2;

            double rm = 0.05;
            double Cm = 10.0;

            double h = Q / (2.0 * System.Math.PI * rm * Cm);

            return new PumpSpec
            {
                MassFlow = mdot,
                Head = deltaP,
                Omega = omega,
                U2 = U2,
                R2 = r2,
                R1 = 0.03,
                BladeHeight = h,
                ShapeParams = new Dictionary<string, double>
                {
                    { "r1", 0.03 },
                    { "r2", r2 },
                    { "h", h },
                    { "omega", omega },
                    { "Cu2", Cu2 }
                }
            };
        }
    }
}
