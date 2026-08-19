# Getting started with PicoGK

PicoGK ("peacock") is a compact and robust geometry kernel for Computational Engineering.

You can find general information on [PicoGK.org](https://picogk.org) and the the [PicoGK repository on GitHub](https://leap71.com/PicoGK).

This repository contains example code, which showcases various aspects of PicoGK.

You can download this repository's source code to get an instant PicoGK-ready environment to play around with.

For more information, see the [PicoGK documentation on PicoGK.org](https://picogk.org/doc/)

# Topics
1. ComputeThermoTask → Tad, Tg(z), Bartz hg(z), Qnorm(z)  
2. ComputeThicknessTask → espesor estructural t(z)  
3. TurbopumpDesignTask → r1, r2, h, U2, Cu2, ω  
4. GenerateLatticeTask → Gyroid ↔ Quasicrystal  
5. Task_AssemblyFFSC_Adaptive → ensamblado final  
6. FFSCShowcase.Task_VisualizarMotorAdaptive → visor PicoGK  

---

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

# PicoGK

Download this example repository, open in VisualStudio Code, and run the code `Program.cs`.
1. **ComputeThermoTask**  
   Calcula Tad, Tg(z), Bartz hg(z), Qnorm(z).

2. **ComputeThicknessTask**  
   Calcula espesor estructural t(z) con Barlow + margen térmico.

3. **TurbopumpDesignTask**  
   Calcula r1, r2, h, U2, Cu2, ω.

4. **GenerateLatticeTask**  
   Genera lattice adaptativo:
   - Gyroid (zonas frías)
   - Cuasicristal (zonas calientes)
   - Interpolación exponencial

5. **Task_AssemblyFFSC_Adaptive**  
   Ensambla:
   - Geometría base
   - Lattice
   - Cooling
   - Campos físicos

6. **FFSCShowcase.Task_VisualizarMotorAdaptive**  
   Devuelve un `Field3D` para el visor PicoGK.

---

## csharp tasks

```csharp
Library.Go(0.5f, FFSCShowcase.Task_VisualizarMotorAdaptive);

The examples are organized into subfolders, according to the their category.

## examples
  FFSC-PicoGK/
    EngineFFSC/
    Geometry/
    Physics/
    Tasks/
    PicoGKBridge/
    Program.cs
    README.md
# Motor FFSC — PicoGK + LEAP71

## Turbopumps tests

Este repositorio contiene un motor de cohete **Full‑Flow Staged Combustion (FFSC)** modelado con:

- **PicoGK** (geometría volumétrica)
- **Tasks C#** (pipeline de diseño)
- **LEAP71‑style pipeline** (tubería completa)
- **Turbobomba paramétrica estilo Raptor**
- **Lattice adaptativo TPMS ↔ cuasicristal**
- **Cooling regenerativo adaptativo**
- **Termoquímica + Bartz + espesor estructural**

---

## 📁 Estructura del repositorio

EngineFFSC/ 
Geometría/ 
Física/ 
TareasModelos/ 
Utilidades/
FFSC-PicoGK/ 
MotorFFSC/ 
Geometría/ 
Física/ 
Tareas/ 
Turbobomba/ 
Modelos/ 
Utilidades/

