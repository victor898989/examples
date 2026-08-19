public static Field3D Task_VisualizarMotor()
{
    var engine = EngineFactory.Crear("v05");
    var (camara, spike, manifold) = engine.Componentes();

    return PhysicsEngine.EnsamblarMotor(camara, spike, manifold);
}
