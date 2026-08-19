//
// SPDX-License-Identifier: CC0-1.0
//

using System;

namespace MotorFFSC.EngineFFSC
{
    /// <summary>
    /// Fábrica de motores FFSC.
    /// Devuelve la versión solicitada del motor:
    /// - v03 → MultiObjetivo
    /// - v04 → Redundante
    /// - v05 → Adaptativo
    /// </summary>
    public static class EngineFactory
    {
        public static EngineModel Crear(string version)
        {
            switch (version.ToLower())
            {
                case "v03":
                case "03":
                    return new V03_MultiObjetivo();

                case "v04":
                case "04":
                    return new V04_Redundante();

                case "v05":
                case "05":
                default:
                    return new V05_Adaptive();
            }
        }
    }
}

