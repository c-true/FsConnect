# FsConnect
A simple easy-to-use wrapper for the Flight Simulator 2020 SimConnect library. A simple solution to simple problems, if you already are fluent in SimConnect, this won't impress you much.
If, on the other hand, you just want to connect to Flight Simulator and read some information this may give you a quicker start.

FsConnect uses the _Microsoft.FlightSimulator.SimConnect_ .NET Framework library and the underlying native x64 _simconnect.dll_ library. 
These files are distributed via the Flight Simulator 2020 SDK, currently version 0.5.1, but are included for easy use.

## Current features
* Supports TCP connection, without use of SimConnect.cfg file
* Supports registering and requesting simple simulation variables.
* Does not require a Windows message pump.
* NuGet package handles deployment of native binaries, just add reference to package.

# Getting started
* Download the Flight Simulator SDK and take a look at the Simvars sample project.

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
        public double AltitudeAboveGround;
        public double Heading;
    }

    public class FsConnectTestConsole
    {
        public static void Main()
        {
            FsConnect fsConnect = new FsConnect();
            fsConnect.Connect("TestApp", "localhost", 500);
            fsConnect.FsDataReceived += HandleReceivedFsData;

            List<SimProperty> definition = new List<SimProperty>();

            // Consult the SDK for valid sim variable names, units and whether they can be written to.
            definition.Add(new SimProperty("Title", null, SIMCONNECT_DATATYPE.STRING256));
            definition.Add(new SimProperty("Plane Latitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty("Plane Longitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64));
            
            // Can also use predefined enums for sim variables and units (incomplete)
            definition.Add(new SimProperty(FsSimVar.PlaneAltitude, FsUnit.Feet, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty("Plane Heading Degrees Gyro", "degrees", SIMCONNECT_DATATYPE.FLOAT64));

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
                Console.WriteLine($"{r.Latitude:F4} {r.Longitude:F4} {r.AltitudeAboveGround:F1} {r.Heading}");
            }
        }
    }
}
```