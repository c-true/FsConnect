using CommandLine;

namespace CTrue.FsConnect.FsEnumGenerator
{
    public class Options
    {
        [Option('s', "source", HelpText = "Gets the source CSV file to read enum data from.", Required = true)]
        public string SourceFileName { get; set; }

        [Option('t', "target", HelpText = "Sets the name of the file to write generated code to.", Required = true)]
        public string TargetFileName { get; set; }
    }
}