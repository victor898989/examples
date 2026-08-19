//
// ComputeThicknessTask.cs
//
// Cálculo de espesor estructural para el motor FFSC.
// Basado en:
//  - Tensión circunferencial (Barlow)
//  - Pared gruesa (Lamé)
//  - Margen térmico según Qnorm(z)
//
// Cita del PDF:
// “Por debajo de cierta temperatura desaparecen las llamas,
//  fenómeno denominado extinción.”
//

using System.Collections.Generic;
using MotorFFSC.Models;

namespace MotorFFSC.Physics
{
    public class ComputeThicknessTask
    {
        public ThicknessMap Run((EngineParams, ThermoMap) input)
        {
            var (p, thermo) = input;

            List<ThicknessPoint> pts = new();

            double FS = 1.5; // factor de seguridad
            double sigmaAllow = p.Material.YieldStrengthPa / FS;

            foreach (var t in thermo.Points)
            {
                double radius = LocalRadius(t.Z, p);

                //
                // Barlow: t = Pc * r / σ_allow
                //
                double tBarlow = (p.Pc * radius) / sigmaAllow;

                //
                // Margen térmico según Qnorm
                //
                double thermalFactor = 1.0 + 2.0 * t.Qnorm;

                double thickness = tBarlow * thermalFactor;

                pts.Add(new ThicknessPoint
                {
                    Z = t.Z,
                    Radius = radius,
                    Thickness = thickness
                });
            }

            return new ThicknessMap { Points = pts.ToArray() };
        }

        private double LocalRadius(double z, EngineParams p)
        {
            double A = p.At + (p.At * p.ExpansionRatio - p.At) * (z / p.Lstar);
            return Math.Sqrt(A / Math.PI);
        }
    }
}
