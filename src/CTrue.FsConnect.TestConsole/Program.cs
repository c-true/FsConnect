using System;
using System.Collections.Generic;
using System.Threading;
using CommandLine;
using CommandLine.Text;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace CTrue.FsConnect.TestConsole
{
    /// <summary>
    /// The Flight Simulator Connect Test Console verifies basic use of the FsConnect library.
    /// </summary>
    class Program
    {
        private static readonly AutoResetEvent _connectedResetEvent = new AutoResetEvent(false);

        private static FsConnect _fsConnect;
        private static LoggingLevelSwitch _levelSwitch = new LoggingLevelSwitch(LogEventLevel.Warning);

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(_levelSwitch)
                .WriteTo.Console()
                .CreateLogger();

            Parser parser = new Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<Options>(args);

            parserResult
                .WithParsed(Run)
                .WithNotParsed(errs => DisplayHelp(parserResult, errs));

            Log.CloseAndFlush();
        }

        private static void Run(Options commandLineOptions)
        {
            _levelSwitch.MinimumLevel = commandLineOptions.LogLevel;

            try
            {
                _fsConnect = new FsConnect();

                _fsConnect.InputEventDefintion = "joystick:0:button:0";
                //_fsConnect.InputEventDefintion = "w";

                _fsConnect.InputEventRaised += (sender, args) => { Console.WriteLine("Input event raised"); };

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
                    Console.WriteLine("An error occurred while connection to Microsoft Flight Simulator: " + e.Message);
                    return;
                }
            
                //
                // Register event handlers
                //
                _fsConnect.ConnectionChanged += OnFsConnectOnConnectionChanged;

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

        private static void OnFsConnectOnConnectionChanged(object sender, bool args)
        {
            Console.WriteLine(_fsConnect.Connected ? "Connected to Flight Simulator" : "Disconnected from Flight Simulator");

            if (_fsConnect.Connected)
            {
                Console.WriteLine($"Application: {_fsConnect.ConnectionInfo.ApplicationName}");
                Console.WriteLine($"Application Version: {_fsConnect.ConnectionInfo.ApplicationVersion}");
                Console.WriteLine($"Application Build: {_fsConnect.ConnectionInfo.ApplicationBuild}");
                Console.WriteLine($"SimConnect Version: {_fsConnect.ConnectionInfo.SimConnectVersion}");
                Console.WriteLine($"SimConnect Build: {_fsConnect.ConnectionInfo.SimConnectBuild}");

                _connectedResetEvent.Set();
            }
        }

        private static void InitializeDataDefinitions(FsConnect fsConnect)
        {
            fsConnect.RegisterDataDefinition<PlaneInfoResponse>(Definitions.PlaneInfo);
            fsConnect.RegisterDataDefinition<PlanePosition>(Definitions.PlanePosition);
        }

        static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
        {
            HelpText helpText;
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
