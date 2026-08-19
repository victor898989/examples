//
// SPDX-License-Identifier: CC0-1.0
//

using System.IO;
using PicoGK;
using MotorFFSC.Geometría;

namespace MotorFFSC.Tasks
{
    /// <summary>
    /// Genera una vista explotada del motor FFSC y exporta cada componente
    /// como un archivo OBJ para inspección externa.
    /// </summary>
    public static class Task_ExplodedView
    {
        public static void Run(Field3D camara, Field3D spike, Field3D manifold, Field3D turbina, Field3D inyectores)
        {
            Directory.CreateDirectory("output/exploded");

            // Separaciones para vista explotada
            var camaraExp = camara.Translate(-0.25, 0, 0);
            var spikeExp = spike.Translate(0.25, 0, 0);
            var manifoldExp = manifold.Translate(0, 0.25, 0);
            var turbinaExp = turbina.Translate(0, -0.25, 0);
            var inyectoresExp = inyectores.Translate(0, 0, 0.25);

            // Exportar cada componente
            ExportOBJ("output/exploded/camara.obj", camaraExp);
            ExportOBJ("output/exploded/spike.obj", spikeExp);
            ExportOBJ("output/exploded/manifold.obj", manifoldExp);
            ExportOBJ("output/exploded/turbina.obj", turbinaExp);
            ExportOBJ("output/exploded/inyectores.obj", inyectoresExp);

            // Exportar ensamblado explotado completo
            var ensamblado = Field3D.Combine(
                camaraExp,
                spikeExp,
                manifoldExp,
                turbinaExp,
                inyectoresExp
            );

            ExportOBJ("output/exploded/ensamblado_explotado.obj", ensamblado);
        }

        private static void ExportOBJ(string ruta, Field3D geom)
        {
            using var writer = new StreamWriter(ruta);
            geom.ExportOBJ(writer);
        }
    }
}
