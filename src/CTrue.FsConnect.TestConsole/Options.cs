using CommandLine;

namespace CTrue.FsConnect.TestConsole
{
    public class Options
    {
        [Option('h', "hostname", Required = true, HelpText = "Sets the hostname of the host that is running Flight Simulator.")]
        public string Hostname { get; set; }

        [Option('p', "port", Required = true, HelpText = "Sets the TCP port that Flight Simulator is being hosting on.")]
        public uint Port { get; set; }
    }
}