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
        public static void Main(string[] args)
        {
            string hostName = "localhost";
            uint port = 500;

            // Also supports "somehostname 1234"
            if(args.Length == 2)
            {
                hostName = args[0];
                port = uint.Parse(args[1]);
            }

            FsConnect fsConnect = new FsConnect();

            // Specify where the SimConnect.cfg should be written to
            fsConnect.SimConnectFileLocation = SimConnectFileLocation.Local;

            // Creates a SimConnect.cfg and connect to Flight Simulator using this configuration.
            fsConnect.Connect("TestApp", hostName, port, SimConnectProtocol.Ipv4);

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
                Console.WriteLine($"{r.Latitude:F4} {r.Longitude:F4} {r.Altitude:F1}ft {r.Heading:F1}deg");
            }
        }
    }
}