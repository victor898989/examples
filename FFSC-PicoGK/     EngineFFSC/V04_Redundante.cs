using PicoGK;
using MotorFFSC.Geometría;
using MotorFFSC.Física;

namespace MotorFFSC.EngineFFSC
{
    public class V04_Redundante : EngineModel
    {
        public override string Nombre => "FFSC v04 Redundante";

        public override Field3D ConstruirGeometria()
        {
            var camara = Formas_ChamberSpike.Camara();
            var spike = Formas_ChamberSpike.Aerospike();
            var manifold = Formas_Valvulas_Manifold.ManifoldReforzado();

            var coolingPrimario = Canales_de_refrigeracion.Primario(camara, spike);
            var coolingSecundario = Canales_de_refrigeracion.Secundario(camara, spike);
            var coolingManifold = Canales_de_refrigeracion_Manifold.Regenerativo(manifold);

            var stress = StressField.Desde(camara, spike, manifold);
            var lattice = Lattice_DualLayer.Generar(stress);

            return GeometryEngine.Combinar(
                camara, spike, manifold,
                coolingPrimario, coolingSecundario, coolingManifold,
                lattice
            );
        }
    }
}
