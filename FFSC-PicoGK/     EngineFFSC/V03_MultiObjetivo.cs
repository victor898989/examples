using PicoGK;
using MotorFFSC.Geometría;
using MotorFFSC.Física;

namespace MotorFFSC.EngineFFSC
{
    public class V03_MultiObjetivo : EngineModel
    {
        public override string Nombre => "FFSC v03 MultiObjetivo";

        public override Field3D ConstruirGeometria()
        {
            var camara = Formas_ChamberSpike.Camara();
            var spike = Formas_ChamberSpike.Aerospike();
            var manifold = Formas_Válvulas_Manifold.ManifoldReforzado();

            var cooling = Canales_de_refrigeración.Primario(camara, spike);

            var stress = StressField.Desde(camara, spike, manifold);
            var lattice = Lattice_DualLayer.Generar(stress);

            return GeometryEngine.Combinar(
                camara, spike, manifold,
                cooling, lattice
            );
        }
    }
}
