//
// SPDX-License-Identifier: CC0-1.0
//
// EngineParams.cs
//
// Parámetros fundamentales del motor FFSC.
// Incluye:
//  - Presión de cámara
//  - Geometría de garganta
//  - L*
//  - Materiales
//  - Discretización axial
//
// Basado en los PDFs:
// “Termoquímica UC3M”
// “Diseño de motores de cohete”
//

namespace MotorFFSC.Models
{
    public class MaterialSpec
    {
        public string Name { get; set; }
        public double YieldStrengthPa { get; set; }
        public double Density { get; set; }
        public double ThermalConductivity { get; set; }
        public double YoungsModulus { get; set; }
    }

    public class EngineParams
    {
        public double Pc_bar { get; set; }
        public double Pc => Pc_bar * 1e5;

        public double Dt { get; set; }
        public double At { get; set; }

        public double Lstar { get; set; }
        public double ExpansionRatio { get; set; }

        public MaterialSpec Material { get; set; }

        public double TadInitialGuess { get; set; } = 3000.0;

        public int Nz { get; set; } = 300;
    }
}
