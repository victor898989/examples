//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Lattice estructural de doble capa basado en el campo de tensiones.
    /// Capa 1: estructura gruesa para cargas principales.
    /// Capa 2: estructura fina para disipación y vibración.
    /// </summary>
    public static class Lattice_DualLayer
    {
        public static Field3D Generar(
            Field3D stressField,
            double umbralGrueso = 0.6,
            double umbralFino = 0.3,
            double radioGrueso = 0.015,
            double radioFino = 0.008)
        {
            Field3D latticeGrueso = Field3D.Empty;
            Field3D latticeFino = Field3D.Empty;

            // Recorremos el campo de tensiones volumétrico
            stressField.ForEachVoxel((x, y, z, valor) =>
            {
                // Capa gruesa
                if (valor > umbralGrueso)
                {
                    var nodo = Field3D.Sphere(radioGrueso)
                        .Translate(x, y, z);

                    latticeGrueso = Field3D.Combine(latticeGrueso, nodo);
                }

                // Capa fina
                if (valor > umbralFino && valor <= umbralGrueso)
                {
                    var nodo = Field3D.Sphere(radioFino)
                        .Translate(x, y, z);

                    latticeFino = Field3D.Combine(latticeFino, nodo);
                }
            });

            return Field3D.Combine(latticeGrueso, latticeFino);
        }
    }
}
