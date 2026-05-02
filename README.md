# SCADA-System-IIA2017-1
Final SCADA System Assignment for the course Industrial Information Technology (IIA2017-1) at USN Campus Porsgrunn.

The project follows a Norse mythology naming theme — **Bifrost** (control system), **Muninn** (data logger), and **Huginn** (monitoring app) — reflecting the interconnected components of a full SCADA pipeline.

---

## Task 1: Database Design
Design of the database schema used to store sensor readings and alarm events across the system.

> *Not yet implemented.*

---

## Task 2: Control System — Bifrost (LabVIEW)
Located in `02 Files/Task 2/`

A LabVIEW-based control system (`ControllSystem.lvproj`) named **Bifrost**. Connects to an OPC server to read live sensor data and applies a PID controller with a low-pass filter (LPF) for process control. Supports both live OPC data and simulated data for testing. Includes VIs for:
- OPC server connection and login (`opcServerConnect.vi`, `LoginOPC.vi`)
- PID control loop (`PId.vi`)
- Low-pass filter (`LPF.vi`)
- Database server connection (`DBserverConnect.vi`)
- Sensor configuration (`AddSensor.vi`, `OPCServerSettings.vi`)
- Simulated process data (`SimulatedData.vi`)

---

## Task 3: Data Logger — Muninn (LabVIEW)
Located in `02 Files/Task 3/`

A LabVIEW data logging application (`DataLogging.lvproj`) named **Muninn**. Connects to an OPC server to continuously read sensor values and logs them to a database. Includes VIs for:
- OPC server connection (`OPCServerConnect.vi`, `LoginOPCDL.vi`)
- Database server connection and settings (`dbServerConnect.vi`, `DBServerSettings.vi`)
- Sensor configuration (`SensorSettings.vi`)
- Core logging loop (`Muninn.vi`)

---

## Task 4: Alarm & Monitoring Application — Huginn (C# / .NET)
Located in `02 Files/Task 4/Huginn/`

A Windows Forms desktop application (`Huginn.csproj`) built in C# targeting .NET Framework 4.8, named **Huginn**. Serves as the operator-facing GUI for monitoring sensor readings and viewing alarms retrieved from the database.

---

## Task 5: Cyber Security
Analysis and implementation of security measures for the SCADA system (e.g., network segmentation, authentication, OPC security).

> *Not yet implemented.*

---

## Task 6: Final System
Integration of all tasks into a complete, functioning SCADA system.

> *Not yet implemented.*
