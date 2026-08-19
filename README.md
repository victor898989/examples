# Getting started with PicoGK

PicoGK ("peacock") is a compact and robust geometry kernel for Computational Engineering.

You can find general information on [PicoGK.org](https://picogk.org) and the the [PicoGK repository on GitHub](https://leap71.com/PicoGK).

This repository contains example code, which showcases various aspects of PicoGK.

You can download this repository's source code to get an instant PicoGK-ready environment to play around with.

For more information, see the [PicoGK documentation on PicoGK.org](https://picogk.org/doc/)

# Tests/vscode
 FFSC-PicoGK/
    EngineFFSC/
      EngineModel.cs
      EngineFactory.cs
      V03_MultiObjective.cs
      V04_Redundant.cs
      V05_Adaptive.cs
    Geometry/
      Shapes_ChamberSpike.cs
      Shapes_ManifoldValves.cs
      Shapes_ManifoldFFSC.cs
      Shapes_PreBurner.cs
      Shapes_Turbopump.cs
      Shapes_Turbine.cs
      Shapes_MainInjectors.cs
      Shapes_FaldaModular.cs
      Shapes_PipesFFSC.cs
      CoolingChannels.cs
      CoolingChannels_Manifold.cs
      Lattice_DualLayer.cs
      Lattice_Quasicrystal.cs
      GeometryEngine.cs
    Physics/
      StressField.cs
      ThermalField.cs
      MassProperties.cs
      CFD.cs
    Tasks/
      Task_GenerateViews.cs
      Task_ThermalComparison.cs
      Task_RedundancyDiagram.cs
      Task_PhysicsReport.cs
      Task_ExplodedView.cs
      Task_AssemblyFFSC.cs
    PicoGKBridge/
      Mesher.cs
      VdbExporter.cs
      ObjExporter.cs
    Program.cs

# Running PicoGK

Download this example repository, open in VisualStudio Code, and run the code `Program.cs`.

The examples are organized into subfolders, according to the their category.

# examples
  FFSC-PicoGK/
    EngineFFSC/
    Geometry/
    Physics/
    Tasks/
    PicoGKBridge/
    Program.cs
    README.md

