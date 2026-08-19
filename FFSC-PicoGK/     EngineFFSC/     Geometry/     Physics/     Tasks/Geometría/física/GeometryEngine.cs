//
// SPDX-License-Identifier: CC0-1.0
//

using PicoGK;

namespace MotorFFSC.Geometría
{
    /// <summary>
    /// Motor de operaciones geométricas para combinar, unir,
    /// restar y aplicar LOD a geometrías volumétricas FFSC.
    /// </summary>
    public static class GeometryEngine
    {
        /// <summary>
        /// Combina múltiples Field3D en uno solo.
        /// </summary>
        public static Field3D Combinar(params Field3D[] campos)
        {
            Field3D resultado = Field3D.Empty;

            foreach (var c in campos)
                resultado = Field3D.Combine(resultado, c);

            return resultado;
        }

        /// <summary>
        /// Resta un conjunto de Field3D de otro.
        /// </summary>
        public static Field3D Restar(Field3D baseGeom, params Field3D[] cortes)
        {
            Field3D resultado = baseGeom;

            foreach (var c in cortes)
                resultado = Field3D.Subtract(resultado, c);

            return resultado;
        }

        /// <summary>
        /// Aplica un LOD (Level of Detail) para mejorar rendimiento en el visor.
        /// </summary>
        public static Field3D RegionLOD(Field3D campo, double factor = 0.5)
        {
            return campo.Downsample(factor);
        }

        /// <summary>
        /// Unión booleana explícita.
        /// </summary>
        public static Field3D Union(Field3D a, Field3D b)
        {
            return Field3D.Combine(a, b);
        }

        /// <summary>
        /// Intersección booleana.
        /// </summary>
        public static Field3D Interseccion(Field3D a, Field3D b)
        {
            return Field3D.Intersect(a, b);
        }

        /// <summary>
        /// Diferencia booleana.
        /// </summary>
        public static Field3D Diferencia(Field3D a, Field3D b)
        {
            return Field3D.Subtract(a, b);
        }
    }
}
