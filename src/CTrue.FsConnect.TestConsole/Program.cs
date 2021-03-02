﻿using System;
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

        private static bool _paused = false;

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

                try
                {
                    if (string.IsNullOrEmpty(commandLineOptions.Hostname))
                    {
                        Console.WriteLine($"Connecting to Flight Simulator using index {commandLineOptions.ConfigIndex}");
                        _fsConnect.Connect("FsConnectTestConsole", commandLineOptions.ConfigIndex);
                    }
                    else
                    {
                        Console.WriteLine($"Connecting to Flight Simulator on {commandLineOptions.Hostname}:{commandLineOptions.Port}");
                        _fsConnect.Connect("FsConnectTestConsole", commandLineOptions.Hostname, commandLineOptions.Port, SimConnectProtocol.Ipv4);
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            
                // Register event handlers
                _fsConnect.FsDataReceived += HandleReceivedFsData;
                _fsConnect.ConnectionChanged += (sender, args) => { Console.WriteLine(_fsConnect.Connected ? "Connected to Flight Simulator" : "Disconnected from Flight Simulator" ); };
                _fsConnect.AircraftLoaded += (sender, args) => { Console.WriteLine("Aircraft loaded"); };
                _fsConnect.FlightLoaded += (sender, args) => { Console.WriteLine("Flight loaded"); };
                _fsConnect.SimStateChanged += (sender, args) => { Console.WriteLine("Flight simulator sim state changed. Running = " + args.Running); };
                _fsConnect.Crashed += (sender, args) => { Console.WriteLine("Aircraft crashed"); };
                _fsConnect.PauseStateChanged += (sender, args) => 
                { 
                    Console.WriteLine("Flight simulator pause state changed. Paused = " + args.Paused);
                    _paused = args.Paused;
                };

                _fsConnect.ObjectAddRemoveEventReceived += (sender, args) => { Console.WriteLine($"Object ID {args.ObjectID} added or removed"); };

                Console.WriteLine("Initializing data definitions");
                InitializeDataDefinitions(_fsConnect);
                InitializeKeyHandlers();

                _fsConnect.SetText("Test Console connected", 2);
                _fsConnect.RequestDataOnSimObject(Requests.ContineousPlaneInfo, Definitions.PlaneInfo, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, 0, 0, 0, 0);

                Console.WriteLine("Press any key to request data from Flight Simulator or ESC to quit.");
                Console.WriteLine("Press WASD keys to move, Q and E to rotate, R and F to change altitude.");

                ConsoleKeyInfo cki = Console.ReadKey(true);

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

        private static void InitializeDataDefinitions(FsConnect fsConnect)
        {
            List<SimProperty> definition = new List<SimProperty>();

            definition.Add(new SimProperty(FsSimVar.Title, FsUnit.None, SIMCONNECT_DATATYPE.STRING256));
            definition.Add(new SimProperty(FsSimVar.PlaneLatitude, FsUnit.Radians, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty(FsSimVar.PlaneLongitude, FsUnit.Radians, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty(FsSimVar.PlaneAltitudeAboveGround, FsUnit.Feet, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty("PLANE ALTITUDE", "Feet", SIMCONNECT_DATATYPE.FLOAT64)); // Example using known/new values
            definition.Add(new SimProperty(FsSimVar.PlaneHeadingDegreesTrue, FsUnit.Radians, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty(FsSimVar.AirspeedTrue, FsUnit.Knot, SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new SimProperty(FsSimVar.ZuluTime, FsUnit.Seconds, SIMCONNECT_DATATYPE.FLOAT64));

            fsConnect.RegisterDataDefinition<PlaneInfoResponse>(Definitions.PlaneInfo, definition);
        }

        private static void InitializeKeyHandlers()
        {
            _keyHandlers.Add(ConsoleKey.P, PollFlightSimulator);
            _keyHandlers.Add(ConsoleKey.W, MoveForward);
            _keyHandlers.Add(ConsoleKey.S, MoveBackward);
            _keyHandlers.Add(ConsoleKey.A, MoveLeft);
            _keyHandlers.Add(ConsoleKey.D, MoveRight);
            _keyHandlers.Add(ConsoleKey.Q, RotateLeft);
            _keyHandlers.Add(ConsoleKey.E, RotateRight);
            _keyHandlers.Add(ConsoleKey.R, IncreaseAltitude);
            _keyHandlers.Add(ConsoleKey.F, DecreaseAltitude);
            _keyHandlers.Add(ConsoleKey.L, PauseSimulator);
        }

        private static void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            try
            {
                if (e.RequestId == (uint)Requests.PlaneInfo)
                {
                    _planeInfoResponse = (PlaneInfoResponse)e.Data;

                    Console.WriteLine($"Time: {_planeInfoResponse.AbsoluteTime:F1}, Pos: ({FsUtils.Rad2Deg(_planeInfoResponse.Latitude):F4}, {FsUtils.Rad2Deg(_planeInfoResponse.Longitude):F4}), Alt: {_planeInfoResponse.Altitude:F0} ft, Hdg: {FsUtils.Rad2Deg(_planeInfoResponse.Heading):F1} deg, Speed: {_planeInfoResponse.Speed:F0} kt");
                }
                else if (e.RequestId == (uint)Requests.ContineousPlaneInfo)
                {
                    _planeInfoResponse = (PlaneInfoResponse)e.Data;

                    Console.WriteLine($"Time: {_planeInfoResponse.AbsoluteTime:F1}, Pos: ({FsUtils.Rad2Deg(_planeInfoResponse.Latitude):F4}, {FsUtils.Rad2Deg(_planeInfoResponse.Longitude):F4}), Alt: {_planeInfoResponse.Altitude:F0} ft, Hdg: {FsUtils.Rad2Deg(_planeInfoResponse.Heading):F1} deg, Speed: {_planeInfoResponse.Speed:F0} kt");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not handle received FS data: " + ex);
            }
        }

        private static void PollFlightSimulator()
        {
            _fsConnect.RequestData(Requests.PlaneInfo, Definitions.PlaneInfo);
        }

        private static void PauseSimulator()
        {
            _paused = !_paused;
            _fsConnect.Pause(_paused);
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
