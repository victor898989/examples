using PicoGK;

namespace MotorFFSC.EngineFFSC
{
    public abstract class EngineModel
    {
        public abstract string Nombre { get; }
        public abstract Field3D ConstruirGeometria();
    }
}
