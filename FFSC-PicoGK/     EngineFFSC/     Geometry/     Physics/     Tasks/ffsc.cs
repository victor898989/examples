//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;
using FFSC_PicoGK.EngineFFSC;
using FFSC_PicoGK.Geometry;

namespace FFSC_PicoGK.Tasks
{
    public static class FFSCShowcase
    {
        public static Field3D Task()
        {
            // Selecciona el motor que quieres visualizar
            EngineModel engine = new V05_Adaptive();

            // Construye la geometría volumétrica del motor
            var geom = engine.BuildGeometry();

            // Opcional: aplicar LOD para viewer
            var lod = GeometryEngine.RegionLOD(geom);

            return lod;
        }
    }
}
