using System;
using System.Collections.Generic;
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
                FsConnect fsConnect = new FsConnect();

                Console.WriteLine("Connecting to Flight Simulator");
                fsConnect.Connect(commandLineOptions.Hostname, commandLineOptions.Port);
            
                fsConnect.FsDataReceived += HandleReceivedFsData;

                Console.WriteLine("Initializing data definitions");
                InitializeDataDefinitions(fsConnect);

                Console.WriteLine("Press any key to request data from Flight Simulator or Q to quit.");
                ConsoleKeyInfo cki = Console.ReadKey(true);

                while (cki.Key != ConsoleKey.Q)
                {
                    fsConnect.RequestData(Requests.PlaneInfo);
                    
                    cki = Console.ReadKey(true);
                }

                Console.WriteLine("Disconnecting from Flight Simulator");
                fsConnect.Disconnect();
                
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e);
            }
        }

        private static void InitializeDataDefinitions(FsConnect fsConnect)
        {
            List<Tuple<string, string, SIMCONNECT_DATATYPE>>
                definition = new List<Tuple<string, string, SIMCONNECT_DATATYPE>>();

            definition.Add(new Tuple<string, string, SIMCONNECT_DATATYPE>("Title", null, SIMCONNECT_DATATYPE.STRING256));
            definition.Add(
                new Tuple<string, string, SIMCONNECT_DATATYPE>("Plane Latitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(
                new Tuple<string, string, SIMCONNECT_DATATYPE>("Plane Longitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(
                new Tuple<string, string, SIMCONNECT_DATATYPE>("Plane Alt Above Ground", "feet", SIMCONNECT_DATATYPE.FLOAT64));
            definition.Add(new Tuple<string, string, SIMCONNECT_DATATYPE>("Plane Heading Degrees Gyro", "degrees",
                SIMCONNECT_DATATYPE.FLOAT64));

            fsConnect.RegisterDataDefinition<PlaneInfoResponse>(Requests.PlaneInfo, definition);
        }

        private static void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            try
            {
                if(e.RequestId == (uint)Requests.PlaneInfo)
                {
                    PlaneInfoResponse r = (PlaneInfoResponse)e.Data;

                    Console.WriteLine($"{r.Latitude:F4} {r.Longitude:F4} {r.AltitudeAboveGround:F1} {r.Heading}");
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
