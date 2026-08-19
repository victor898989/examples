//
// VdbExporter.cs
//
// Exportador NanoVDB/OpenVDB para geometrías FFSC.
// Compatible con PicoGK.
//

using System.IO;
using PicoGK;

namespace MotorFFSC.Utils
{
    public static class VdbExporter
    {
        public static void Export(Field3D geom, string ruta)
        {
            using var fs = new FileStream(ruta, FileMode.Create);
            geom.ExportVDB(fs);
        }
    }
}
