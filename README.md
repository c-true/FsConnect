# FsConnect
A simple easy-to-use wrapper for the Flight Simulator 2020 SimConnect library. A simple solution to simple problems, if you already are fluent in SimConnect, this won't impress you much.
If, on the other hand, you just want to connect to Flight Simulator and read some information this may give you a quicker start.

## Current features
* Supports TCP connection, without use of SimConnect.cfg file
* Supports registering and requesting simple simulation variables.
* Does not require a Windows message pump.

# Usage

1) Create a .NET Framework Console project
2) Add a reference to the CTrue.FsConnect package.
3) See example below:

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
            fsConnect.Connect("localhost", 500);
            fsConnect.FsDataReceived += HandleReceivedFsData;

            List<Tuple<string, string, SIMCONNECT_DATATYPE>> definition = new List<Tuple<string, string, SIMCONNECT_DATATYPE>>();

            definition.Add(new Tuple<string, string, SIMCONNECT_DATATYPE>("Title", null, SIMCONNECT_DATATYPE.STRING256));
            definition.Add(new Tuple<string, string, SIMCONNECT_DATATYPE>("Plane Latitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new Tuple<string, string, SIMCONNECT_DATATYPE>("Plane Longitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new Tuple<string, string, SIMCONNECT_DATATYPE>("Plane Alt Above Ground", "feet", SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new Tuple<string, string, SIMCONNECT_DATATYPE>("Plane Heading Degrees Gyro", "degrees", SIMCONNECT_DATATYPE.FLOAT64));

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