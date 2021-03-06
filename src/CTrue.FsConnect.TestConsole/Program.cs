using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
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
        private static readonly AutoResetEvent _connectedResetEvent = new AutoResetEvent(false);

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
                    Console.WriteLine("An error occured while connection to Microsoft Flight Simulator: " + e.Message);
                    return;
                }
            
                //
                // Register event handlers
                //
                _fsConnect.FsDataReceived += HandleReceivedFsData;
                _fsConnect.ConnectionChanged += OnFsConnectOnConnectionChanged;

                // For diagnostic purposes
                _fsConnect.AircraftLoaded += (sender, args) => { Console.WriteLine("Aircraft loaded"); };
                _fsConnect.FlightLoaded += (sender, args) => { Console.WriteLine("Flight loaded"); };
                _fsConnect.SimStateChanged += (sender, args) => { Console.WriteLine("Flight simulator sim state changed. Running = " + args.Running); };
                _fsConnect.Crashed += (sender, args) => { Console.WriteLine("Aircraft crashed"); };
                _fsConnect.PauseStateChanged += (sender, args) => 
                { 
                    Console.WriteLine("Flight simulator pause state changed. Paused = " + args.Paused);
                };

                _fsConnect.ObjectAddRemoveEventReceived += (sender, args) => { Console.WriteLine($"Object ID {args.ObjectID} added or removed"); };

                //
                // Wait for connection to Flight Simulator before using API
                //

                bool receivedEvent = _connectedResetEvent.WaitOne(2000);

                if (receivedEvent == false)
                {
                    Console.WriteLine("Could not connect to Flight Simulator. Timed out waiting for connection");
                    return;
                }

                //
                // Post connection initialization
                //

                Console.WriteLine("Initializing data definitions");
                InitializeDataDefinitions(_fsConnect);

                _fsConnect.SetText("Test Console connected", 2);

                //_fsConnect.RequestDataOnSimObject(Requests.ContineousPlaneInfo, Definitions.PlaneInfo, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, 0, 0, 0, 0);

                //
                // Show menu
                //

                MainMenu mainMenu = new MainMenu(_fsConnect);
                mainMenu.Run();

                //
                // Tear down
                //

                if(_fsConnect.Connected)
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

        private static void OnFsConnectOnConnectionChanged(object sender, EventArgs args)
        {
            Console.WriteLine(_fsConnect.Connected ? "Connected to Flight Simulator" : "Disconnected from Flight Simulator");

            if (_fsConnect.Connected)
            {
                Console.WriteLine($"Application: {_fsConnect.ConnectionInfo.ApplicationName}");
                Console.WriteLine($"Application Version: {_fsConnect.ConnectionInfo.ApplicationVersionMajor}.{_fsConnect.ConnectionInfo.ApplicationVersionMajor}");
                Console.WriteLine($"Application Build: {_fsConnect.ConnectionInfo.ApplicationBuildMajor}.{_fsConnect.ConnectionInfo.ApplicationBuildMinor}");
                Console.WriteLine($"SimConnect Version: {_fsConnect.ConnectionInfo.SimConnectVersionMajor}.{_fsConnect.ConnectionInfo.SimConnectVersionMinor}");
                Console.WriteLine($"SimConnect Build: {_fsConnect.ConnectionInfo.SimConnectBuildMajor}.{_fsConnect.ConnectionInfo.SimConnectBuildMinor}");

                _connectedResetEvent.Set();
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

        private static void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            try
            {
                if (e.RequestId == (uint) Requests.ContineousPlaneInfo)
                {
                    _planeInfoResponse = (PlaneInfoResponse) e.Data;

                    Console.WriteLine(_planeInfoResponse.ToString());
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
