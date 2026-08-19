using PicoGK;
using MotorFFSC.Geometria;
using MotorFFSC.Fisica;

namespace MotorFFSC.EngineFFSC
{
    public class V05_Adaptive : EngineModel
    {
        public override string Nombre => "FFSC v05 Adaptive";

        public override Field3D ConstruirGeometria()
        {
            var camara = Formas_ChamberSpike.Camara();
            var spike = Formas_ChamberSpike.Aerospike();
            var falda = Shapes_FaldaModular.Falda();

            var manifold = Formas_VariedadFFSC.ManifoldCompleto();
            var preburner = Formas_PreBurner.PreBurner();
            var turbobomba = Formas_Turbobomba.Turbobomba();
            var turbina = Shapes_Turbine.Turbina();
            var inyectores = Shapes_MainInjectors.PlacaInyectora();
            var tubos = Formas_TubosFFSC.RedTubos();

            var coolingPrimario = Canales_de_refrigeracion.Primario(camara, spike);
            var coolingSecundario = Canales_de_refrigeracion.Secundario(camara, spike);
            var coolingManifold = Canales_de_refrigeracion_Manifold.Regenerativo(manifold);

            var stress = StressField.Dinamico(camara, spike, manifold);

            var latticeDual = Lattice_DualLayer.Generar(stress);
            var latticeQuasi = Lattice_Quasicrystal.Generar(stress);

            return GeometryEngine.Combinar(
                camara, spike, falda,
                manifold, preburner, turbobomba, turbina,
                inyectores, tubos,
                coolingPrimario, coolingSecundario, coolingManifold,
                latticeDual, latticeQuasi
            );
        }
    }
}
