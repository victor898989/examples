//
// PumpSpec.cs
//
// Especificación paramétrica de turbobomba FFSC.
//

namespace MotorFFSC.Models
{
    public class PumpSpec
    {
        public double MassFlow { get; set; }
        public double Head { get; set; }
        public double Omega { get; set; }
        public double U2 { get; set; }
        public double R1 { get; set; }
        public double R2 { get; set; }
        public double BladeHeight { get; set; }

        public Dictionary<string, double> ShapeParams { get; set; }
    }
}
