public static void Task_Exploded()
{
    var engine = EngineFactory.Crear("v05");
    var (camara, spike, manifold, turbina, inyectores) = engine.Componentes();

    Task_ExplodedView.Run(camara, spike, manifold, turbina, inyectores);
}
