using System;
using System.Collections.Generic;
using System.Net;
using CommandLine;
using CommandLine.Text;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect.TestConsole
{
    /// <summary>
    /// The Flight Simulator Connect Test Console verifies basic use of the FsConnect library.
    /// </summary>
    class Program
    {
        private static FsConnect _fsConnect;
        private static Dictionary<ConsoleKey, Action> _keyHandlers = new Dictionary<ConsoleKey, Action>();
        private static PlaneInfoResponse _planeInfoResponse;

        private static double _deltaLatitude = 0.001;
        private static double _deltaLongitude = 0.001;
        private static double _deltaAltitude = 1000;
        private static double _deltaHeading = 10;

        static void Main(string[] args)
        {
            CommandLine.Parser parser = new CommandLine.Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<Options>(args);

            parserResult
                .WithParsed<Options>(options => Run(options))
                .WithNotParsed(errs => DisplayHelp(parserResult, errs));
        }

        private static void Run(Options commandLineOptions)
        {
            try
            {
                _fsConnect = new FsConnect();

                Console.WriteLine($"Connecting to Flight Simulator on {commandLineOptions.Hostname}:{commandLineOptions.Port}");
                try
                {
                    _fsConnect.Connect("FsConnectTestConsole", commandLineOptions.Hostname, commandLineOptions.Port);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            
                _fsConnect.FsDataReceived += HandleReceivedFsData;
                
                Console.WriteLine("Initializing data definitions");
                InitializeDataDefinitions(_fsConnect);

                _keyHandlers.Add(ConsoleKey.P, PollFlightSimulator);
                _keyHandlers.Add(ConsoleKey.W, MoveForward);
                _keyHandlers.Add(ConsoleKey.S, MoveBackward);
                _keyHandlers.Add(ConsoleKey.A, MoveLeft);
                _keyHandlers.Add(ConsoleKey.D, MoveRight);
                _keyHandlers.Add(ConsoleKey.Q, RotateLeft);
                _keyHandlers.Add(ConsoleKey.E, RotateRight);
                _keyHandlers.Add(ConsoleKey.R, IncreaseAltitude);
                _keyHandlers.Add(ConsoleKey.F, DecreaseAltitude);

                Console.WriteLine("Press any key to request data from Flight Simulator or ESC to quit.");
                ConsoleKeyInfo cki = Console.ReadKey(true);

                _fsConnect.SetText("Test Console connected", 2);

                _fsConnect.RequestData(Requests.PlaneInfo);

                while (cki.Key != ConsoleKey.Escape)
                {
                    if(_keyHandlers.ContainsKey(cki.Key))
                    {
                        _keyHandlers[cki.Key].Invoke();
                    }
                    else
                    {
                        PollFlightSimulator();
                    }

                    cki = Console.ReadKey(true);
                }

                Console.ReadKey(true);

                Console.WriteLine("Disconnecting from Flight Simulator");
                _fsConnect.SetText("Test Console disconnecting", 1);
                _fsConnect.Disconnect();
                _fsConnect.Dispose();
                _fsConnect = null;

                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e);
            }
        }

        private static void IncreaseAltitude()
        {
            _planeInfoResponse.Altitude += _deltaAltitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
        }

        private static void DecreaseAltitude()
        {
            _planeInfoResponse.Altitude -= _deltaAltitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
        }

        private static void RotateRight()
        {
            _planeInfoResponse.Heading += FsUtils.Deg2Rad(_deltaHeading);
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
        }

        private static void RotateLeft()
        {
            _planeInfoResponse.Heading -= FsUtils.Deg2Rad(_deltaHeading);
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
        }

        private static void MoveRight()
        {
            _planeInfoResponse.Longitude += _deltaLongitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
        }

        private static void MoveLeft()
        {
            _planeInfoResponse.Longitude -= _deltaLongitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
        }

        private static void MoveBackward()
        {
            _planeInfoResponse.Latitude -= _deltaLatitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
        }

        private static void MoveForward()
        {
            _planeInfoResponse.Latitude += _deltaLatitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
        }

        private static void PollFlightSimulator()
        {
            _fsConnect.RequestData(Requests.PlaneInfo);
        }

        private static void UpdateFlightSimulator()
        {
            _planeInfoResponse.Latitude += _deltaLatitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
        }

        private static void InitializeDataDefinitions(FsConnect fsConnect)
        {
            List<SimProperty> definition = new List<SimProperty>();

            definition.Add(new SimProperty(FsSimVar.Title, FsUnit.None, SIMCONNECT_DATATYPE.STRING256));
            definition.Add(new SimProperty(FsSimVar.PlaneLatitude, FsUnit.Radians, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty(FsSimVar.PlaneLongitude, FsUnit.Radians, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty(FsSimVar.PlaneAltitudeAboveGround, FsUnit.Feet, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty(FsSimVar.PlaneAltitude, FsUnit.Feet, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty(FsSimVar.PlaneHeadingDegreesTrue, FsUnit.Radians, SIMCONNECT_DATATYPE.FLOAT64));

            fsConnect.RegisterDataDefinition<PlaneInfoResponse>(Definitions.PlaneInfo, definition);
        }

        private static void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            try
            {
                if(e.RequestId == (uint)Requests.PlaneInfo)
                {
                    _planeInfoResponse = (PlaneInfoResponse)e.Data;

                    Console.WriteLine($"Pos: ({FsUtils.Rad2Deg(_planeInfoResponse.Latitude):F4}, {FsUtils.Rad2Deg(_planeInfoResponse.Longitude):F4}), Alt: {_planeInfoResponse.Altitude:F0} ft, Hdg: {FsUtils.Rad2Deg(_planeInfoResponse.Heading):F1} deg");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not handle received FS data: " + ex);
            }
        }

        static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
        {
            HelpText helpText = null;
            if (errs.IsVersion())  //check if error is version request
                helpText = HelpText.AutoBuild(result);
            else
            {
                helpText = HelpText.AutoBuild(result, h =>
                {
                    //configure help
                    h.AdditionalNewLineAfterOption = false;
                    h.Heading = "Flight Simulator Connect Test Console";
                    h.Copyright = "";
                    return HelpText.DefaultParsingErrorsHandler(result, h);
                }, e => e);
            }
            Console.WriteLine(helpText);
        }
    }
}
