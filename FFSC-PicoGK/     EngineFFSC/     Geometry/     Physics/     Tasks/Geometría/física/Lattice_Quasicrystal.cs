//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Lattice cuasicristalino basado en el campo de tensiones.
    /// Genera patrones no periódicos tipo Penrose para refuerzo estructural.
    /// </summary>
    public static class Lattice_Quasicrystal
    {
        public static Field3D Generar(
            Field3D stressField,
            double escala = 0.3,
            double intensidad = 0.5)
        {
            Field3D lattice = Field3D.Empty;

            stressField.ForEachVoxel((x, y, z, valor) =>
            {
                // Solo generamos cuasicristal donde hay tensión significativa
                if (valor < intensidad)
                    return;

                // Patrón cuasicristalino tipo Penrose
                double qx = Math.Cos(x * escala) + Math.Cos(y * escala * 1.618);
                double qy = Math.Sin(y * escala) + Math.Sin(z * escala * 1.618);

                double magnitud = Math.Abs(qx + qy);

                if (magnitud > 1.2)
                {
                    var nodo = Field3D.Sphere(0.006)
                        .Translate(x, y, z);

                    lattice = Field3D.Combine(lattice, nodo);
                }
            });

            return lattice;
        }
    }
}
