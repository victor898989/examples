//
// ShapeKernel_Turbopump.cs
//
// Exportación paramétrica para ShapeKernel.
//

using MotorFFSC.Models;
using System.Collections.Generic;

namespace MotorFFSC.Turbopump
{
    public static class ShapeKernel_Turbopump
    {
        public static Dictionary<string, double> Export(PumpSpec spec)
        {
            return new Dictionary<string, double>
            {
                { "r1", spec.R1 },
                { "r2", spec.R2 },
                { "bladeHeight", spec.BladeHeight },
                { "omega", spec.Omega },
                { "U2", spec.U2 },
                { "Cu2", spec.ShapeParams["Cu2"] }
            };
        }
    }
}
