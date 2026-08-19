//
// BartzCalculator.cs
//
// Implementación de la ecuación de Bartz para transferencia de calor.
// Basado en:
// hg = 0.026 * μ^0.2 * cp^0.6 * (Pc/C*)^0.8 * Dt^0.2 * Rc^-0.1 * (At/A)^0.9
//

using MotorFFSC.Models;

namespace MotorFFSC.Utils
{
    public static class BartzCalculator
    {
        public static double Evaluate(EngineParams p, double Tg, double Dt_local, double A_local)
        {
            double mu = 3.5e-5;
            double cp = 2000.0;
            double Pr = 0.7;
            double Cstar = 1500.0;

            double Pc = p.Pc;
            double Dt = p.Dt;
            double At = p.At;

            double Aratio = At / A_local;
            double Rc = Dt_local / 2.0;

            double hg =
                0.026 *
                System.Math.Pow(mu, 0.2) *
                System.Math.Pow(cp, 0.6) *
                System.Math.Pow(Pc / Cstar, 0.8) *
                System.Math.Pow(Dt, 0.2) *
                System.Math.Pow(Rc, -0.1) *
                System.Math.Pow(Aratio, 0.9) /
                System.Math.Pow(Pr, 0.6);

            return hg;
        }
    }
}
