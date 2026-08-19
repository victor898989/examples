public static void Task_Physics()
{
    var engine = EngineFactory.Crear("v05");
    var (camara, spike, manifold) = engine.Componentes();

    Task_PhysicsReport.Run(camara, spike, manifold);
}
