# FsConnect
A simple easy-to-use wrapper for the Flight Simulator 2020 SimConnect library. A simple solution to simple problems, if you already are fluent in SimConnect, this won't impress you much.
If, on the other hand, you just want to connect to Flight Simulator and read some information this may give you a quicker start.

FsConnect uses the _Microsoft.FlightSimulator.SimConnect_ .NET Framework library and the underlying native x64 _simconnect.dll_ library. 
These files are distributed via the Flight Simulator 2020 SDK, currently version 0.6.1, but are included for easy use.

At the moment this project is intended as an easier to use wrapper than the current SimConnect for simple projects, creating a simpler C# programming model and reducing the need for repeated boiler plate code. Expect breaking changes.

## Current features
* Supports connections from API, without direct use of SimConnect.cfg file
* Supports registering and requesting simple simulation variables.
* Supports updating simulation variables.
* Does not require a Windows message pump.
* NuGet package handles deployment of native binaries, just add reference to package.

# Getting started
* Download the Flight Simulator SDK.
* See the list of available simulation variables in the SDK documentation: Documentation/04-Developer_Tools/SimConnect/SimConnect_Status_of_Simulation_Variables.html
* Determine unit to use when registering the data structure.
* Build a C# struct to hold data data definition. (See example below)
* Define a data definition and register it. (See example below)
* Take a look at the Simvars sample project and example below.

# Usage

1) Create a .NET Framework Console project that target x64.
2) Add a reference to the CTrue.FsConnect package.
3) Set up Flight Simulator to receive remote TCP connections, see the SimConnect.xml file, and configure the example accordingly.
4) See example below:

```csharp
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CTrue.FsConnect;
using Microsoft.FlightSimulator.SimConnect;

namespace FsConnectTest
{
    public enum Requests
    {
        PlaneInfo = 0
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlaneInfoResponse
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Title;
        public double Latitude;
        public double Longitude;
        public double Altitude;
        public double Heading;
    }

    public class FsConnectTestConsole
    {
        public static void Main()
        {
            FsConnect fsConnect = new FsConnect();
            
            // Specify where the SimConnect.cfg should be written to
            fsConnect.SimConnectFileLocation = SimConnectFileLocation.MyDocuments;
            
            // Creates a SimConnect.cfg and connect to Flight Simulator using this configuration.
            fsConnect.Connect("TestApp", "localhost", 500, SimConnectProtocol.Ipv4);

            // Other alternatives, use existing SimConfig.cfg and specify config index:
            // fsConnect.Connect(1);
            // or
            // fsConnect.Connect();

            fsConnect.FsDataReceived += HandleReceivedFsData;

            List<SimProperty> definition = new List<SimProperty>();

            // Consult the SDK for valid sim variable names, units and whether they can be written to.
            definition.Add(new SimProperty("Title", null, SIMCONNECT_DATATYPE.STRING256));
            definition.Add(new SimProperty("Plane Latitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty("Plane Longitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64));
            
            // Can also use predefined enums for sim variables and units (incomplete)
            definition.Add(new SimProperty(FsSimVar.PlaneAltitude, FsUnit.Feet, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty(FsSimVar.PlaneHeadingDegreesTrue, FsUnit.Degrees, SIMCONNECT_DATATYPE.FLOAT64));

            fsConnect.RegisterDataDefinition<PlaneInfoResponse>(Requests.PlaneInfo, definition);

            fsConnect.RequestData(Requests.PlaneInfo);
            Console.ReadKey();
            fsConnect.Disconnect();
        }

        private static void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            if (e.RequestId == (uint)Requests.PlaneInfo)
            {
                PlaneInfoResponse r = (PlaneInfoResponse)e.Data;
                Console.WriteLine($"{r.Latitude:F4} {r.Longitude:F4} {r.Altitude:F1} {r.Heading}");
            }
        }
    }
}
```
