//
// ThermoTables.cs
//
// Tablas Cp(T) simplificadas para cálculo termoquímico.
// Basado en polinomios NASA (simplificados para ingeniería).
//

namespace MotorFFSC.Utils
{
    public static class ThermoTables
    {
        public static double Cp_CO2(double T)
        {
            if (T < 1000) return 844.0 + 0.1 * (T - 300);
            return 1000.0 + 0.02 * (T - 1000);
        }

        public static double Cp_H2O(double T)
        {
            if (T < 1000) return 1850.0 + 0.15 * (T - 300);
            return 2100.0 + 0.03 * (T - 1000);
        }

        public static double Cp_O2(double T)
        {
            return 900.0 + 0.1 * (T - 300);
        }

        public static double Cp_N2(double T)
        {
            return 1040.0 + 0.1 * (T - 300);
        }
    }
}
