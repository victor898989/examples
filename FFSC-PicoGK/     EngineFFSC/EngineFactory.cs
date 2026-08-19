namespace MotorFFSC.EngineFFSC
{
    public static class EngineFactory
    {
        public static EngineModel Crear(string version)
        {
            return version switch
            {
                "v03" => new V03_MultiObjetivo(),
                "v04" => new V04_Redundante(),
                "v05" => new V05_Adaptive(),
                _ => new V05_Adaptive()
            };
        }
    }
}
