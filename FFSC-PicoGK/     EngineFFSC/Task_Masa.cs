public static void Task_Masa()
{
    var engine = EngineFactory.Crear("v05");
    var geom = engine.ConstruirGeometria();

    var reporte = MassProperties.Reporte(geom);

    File.WriteAllText("output/masa.txt", reporte);
}
