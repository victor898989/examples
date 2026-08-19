//
// SPDX-License-Identifier: CC0-1.0
//
// ComputeThermoTask.cs
//
// Tarea termoquímica para el motor FFSC.
// Calcula:
//  - Temperatura adiabática de llama (Tad)
//  - Mapa térmico axial Tg(z)
//  - Coeficiente de película Bartz hg(z)
//  - Campo normalizado Qnorm(z)
//
// Basado en los PDFs aportados:
// “Termoquímica UC3M”
// “Ecuaciones y referencias para el diseño de motores de cohete”
//
// Cita del PDF:
// “La combustión ocurre en superficies delgadas llamadas llamas,
//  separando reactivos de productos.”
//

using System;
using System.Linq;
using MotorFFSC.Models;
using MotorFFSC.Utils;

namespace MotorFFSC.Physics
{
    public class ComputeThermoTask
    {
        public ThermoMap Run(EngineParams p)
        {
            //
            // 1. Resolver Tad (temperatura adiabática de llama)
            //
            double Tad = SolveTad(p);

            //
            // 2. Construir discretización axial
            //
            ThermoPoint[] pts = new ThermoPoint[p.Nz];

            for (int i = 0; i < p.Nz; i++)
            {
                double z = p.Lstar * (i / (double)(p.Nz - 1));

                double A_local = LocalArea(z, p);
                double Dt_local = Math.Sqrt(4.0 * A_local / Math.PI);

                //
                // 3. Evaluar Bartz
                //
                double hg = BartzCalculator.Evaluate(p, Tad, Dt_local, A_local);

                pts[i] = new ThermoPoint
                {
                    Z = z,
                    Tg = Tad,
                    Hg = hg,
                    Qnorm = 0.0
                };
            }

            //
            // 4. Normalizar Qnorm
            //
            double hgMin = pts.Min(t => t.Hg);
            double hgMax = pts.Max(t => t.Hg);

            foreach (var t in pts)
                t.Qnorm = (t.Hg - hgMin) / Math.Max(1e-12, hgMax - hgMin);

            return new ThermoMap { Points = pts };
        }

        //
        // --- Rutina iterativa para Tad ---
        //
        private double SolveTad(EngineParams p)
        {
            double Tlow = 1500;
            double Thigh = 4000;

            for (int i = 0; i < 60; i++)
            {
                double Tmid = 0.5 * (Tlow + Thigh);
                double resid = EnergyResidual(Tmid, p);

                if (Math.Abs(resid) < 1e-6)
                    return Tmid;

                double rlow = EnergyResidual(Tlow, p);

                if (rlow * resid <= 0)
                    Thigh = Tmid;
                else
                    Tlow = Tmid;
            }

            return 0.5 * (Tlow + Thigh);
        }

        //
        // --- Residual energético simplificado ---
        //
        private double EnergyResidual(double T, EngineParams p)
        {
            // hReact = entalpía de reactivos
            double hReact = -100000.0; // placeholder

            // Cp medio representativo
            double cpMean = 1500.0;

            // hProd = entalpía de productos
            double hProd = hReact + cpMean * (T - 298.15);

            return hProd - hReact - cpMean * (p.TadInitialGuess - 298.15);
        }

        //
        // --- Perfil de área local ---
        //
        private double LocalArea(double z, EngineParams p)
        {
            double At = p.At;
            double Ae = p.At * p.ExpansionRatio;

            return At + (Ae - At) * (z / p.Lstar);
        }
    }
}
