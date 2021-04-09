using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CTrue.FsConnect.FsEnumGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] eventLines = File.ReadAllLines("C:\\repo\\c-true\\FsConnect\\data\\Legacy Event IDs.csv");

            var fsEventList = GetFsEvents(eventLines);

            GenerateFsEnumsFile(fsEventList, @"C:\\repo\\c-true\\FsConnect\\data\\FsEventId.cs");

        }

        private static void GenerateFsEnumsFile(List<FsEventInfo> fsEventList, string fileName)
        {
            System.IO.StringWriter baseTextWriter = new System.IO.StringWriter();
            System.CodeDom.Compiler.IndentedTextWriter indentWriter = new IndentedTextWriter(baseTextWriter, "    ");

            // Sets the indentation level.
            indentWriter.Indent = 0;
            indentWriter.WriteLine("namespace CTrue.FsConnect");
            indentWriter.WriteLine("{");
            indentWriter.Indent++;
            indentWriter.WriteLine("public enum FsEventId");
            indentWriter.WriteLine("{");
            indentWriter.Indent++;

            foreach (var fsEvent in fsEventList)
            {
                indentWriter.WriteLine($"/// <summary>");
                indentWriter.WriteLine($"/// {fsEvent.Description}");
                indentWriter.WriteLine($"/// </summary>");
                indentWriter.WriteLine($"{fsEvent.Id},");
            }

            indentWriter.Indent--;
            indentWriter.WriteLine("};");

            indentWriter.WriteLine();

            indentWriter.WriteLine("internal static class FsEventNameLookup");
            indentWriter.WriteLine("{");
            indentWriter.Indent++;

            indentWriter.WriteLine("private static string[] _fsEventName = new string[] {");
            indentWriter.Indent++;
            
            foreach (var fsEvent in fsEventList)
            {
                indentWriter.WriteLine($"\"{fsEvent.Name}\",");
            }
            
            indentWriter.Indent--;
            indentWriter.WriteLine("};");

            indentWriter.WriteLine();
            indentWriter.WriteLine("public static string GetFsEventName(FsEventId id)");
            indentWriter.WriteLine("{");
            indentWriter.Indent++;

            indentWriter.WriteLine("return _fsEventName[(int)id];");

            indentWriter.Indent--;
            indentWriter.WriteLine("}");

            indentWriter.Indent--;
            indentWriter.WriteLine("}");

            indentWriter.Indent--;
            indentWriter.WriteLine("}");

            File.WriteAllText(fileName, baseTextWriter.ToString());
        }

        static List<FsEventInfo> GetFsEvents(string[] lines)
        {
            var list = new List<FsEventInfo>();

            foreach (var eventLine in lines)
            {
                string[] splits = eventLine.Split('\t');

                if(splits.Length != 4) continue;
                if(splits[0] == "Event ID") continue;
                if(splits[1] == "Unsupported") continue;
                if(splits[1] == "Not supported") continue;

                string[] nameSplit = splits[0].Split(' ');

                string name = splits[1];
                string id = "";
                string description = splits[2];

                if (nameSplit.Length > 0)
                    name = nameSplit[0];
                else
                    name = splits[1];

                name = name.Trim(new[] {','});

                id = GetFsEventId(name);

                // Remove duplicates
                if(list.Exists(x => x.Id.Equals(id))) continue;

                list.Add(new FsEventInfo()
                {
                    Id = id,
                    Name = name,
                    Description = description
                });
            }

            return list;
        }

        private static string GetFsEventId(string name)
        {
            return name;
        }
    }

    internal class FsEventInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
