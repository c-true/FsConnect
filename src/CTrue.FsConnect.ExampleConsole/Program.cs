using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CTrue.FsConnect;
using Microsoft.FlightSimulator.SimConnect;

namespace FsConnectTest
{
    public enum Requests
    {
        PlaneInfoRequest = 0
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlaneInfoResponse
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Title;
        [SimVar(UnitId = FsUnit.Degree)]
        public double PlaneLatitude;
        [SimVar(UnitId = FsUnit.Degree)]
        public double PlaneLongitude;
        [SimVar(UnitId = FsUnit.Feet)]
        public double PlaneAltitude;
        [SimVar(UnitId = FsUnit.Degree)]
        public double PlaneHeadingDegreesTrue;
        [SimVar(NameId = FsSimVar.AirspeedTrue, UnitId = FsUnit.MeterPerSecond)]
        public double AirspeedTrueInMeterPerSecond;
        [SimVar(NameId = FsSimVar.AirspeedTrue, UnitId = FsUnit.Knot)]
        public double AirspeedTrueInKnot;
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

            int planeInfoDefinitionId = fsConnect.RegisterDataDefinition<PlaneInfoResponse>();

            ConsoleKeyInfo cki;

            do
            {
                fsConnect.RequestData((int)Requests.PlaneInfoRequest, planeInfoDefinitionId);
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

            fsConnect.Disconnect();
        }

        private static void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            if (e.Data == null || e.Data.Count == 0) return;

            if (e.RequestId == (uint)Requests.PlaneInfoRequest)
            {
                PlaneInfoResponse r = (PlaneInfoResponse)e.Data.FirstOrDefault();
                Console.WriteLine($"{r.PlaneLatitude:F4} {r.PlaneLongitude:F4} {r.PlaneAltitude:F1}ft {r.PlaneHeadingDegreesTrue:F1}deg {r.AirspeedTrueInMeterPerSecond:F0}m/s {r.AirspeedTrueInKnot:F0}kt");
            }
        }
    }
}