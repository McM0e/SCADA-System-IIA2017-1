# SCADA-System-IIA2017-1
Final SCADA System Assignment for the course Industrial Information Technology (IIA2017-1) at USN Campus Porsgrunn.

The project follows a Norse mythology naming theme — **Bifrost** (control system), **Muninn** (data logger), and **Huginn** (monitoring app) — reflecting the interconnected components of a full SCADA pipeline.

---

## Task 1: Database Design
Located in `02 Files/Task 1/`

Design of the database schema used to store sensor readings and alarm events across the system. A schema diagram (`DataBaseDesign.png`) and a SQL Server backup file (`SCADAAssignement.bak`) are included.

---

## Task 2: Control System — Bifrost (LabVIEW)
Located in `02 Files/Task 2/`

A LabVIEW-based control system (`ControllSystem.lvproj`) named **Bifrost**. Reads live data directly from a physical sensor and pushes the values into an OPC UA server. Applies a PID controller with a low-pass filter (LPF) for process control. Supports both live sensor data and simulated data for testing. Includes VIs for:
- OPC UA server connection and login (`opcServerConnect.vi`, `LoginOPC.vi`)
- Air heater process (`AirHeater.vi`)
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

A Windows Forms desktop application (`Huginn.csproj`) built in C# targeting .NET Framework 4.8, named **Huginn**. Serves as the operator-facing GUI for monitoring live sensor readings via OPC UA subscriptions, with user authentication backed by a SQL Server database.

Features implemented:
- Login form with email/password authentication (`loginForm.cs`)
- Session token generation, encrypted local storage with Windows DPAPI, and server-side validation (`AuthService.cs`, `TokenStorage.cs`)
- Auto-login on startup if a valid session token exists; logout invalidates the server-side session
- Role-based UI: admin menu is only visible to users with the Admin role
- Live sensor gauges that subscribe to OPC UA node changes and update in real time (`MainWindow.cs`)
- JSON-based configuration for OPC UA server connection, sensor node mappings, and database server settings, stored in `%AppData%\Huginn\config.json` (`ConfigManager.cs`, `AppConfig.cs`)
- Sensor editor form for managing OPC UA sensor names and node IDs (`EditSensors.cs`) — in progress
- Alarm system (`Alarm.cs`) — not yet implemented

---

## Task 5: Cyber Security
Analysis and implementation of security measures for the SCADA system (e.g., network segmentation, authentication, OPC security).

> *Not yet implemented.*

---

## Task 6: Final System
Integration of all tasks into a complete, functioning SCADA system.

> *Not yet implemented.*
