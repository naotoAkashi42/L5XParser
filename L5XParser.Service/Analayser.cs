using L5XParser.Model;
using System.Xml.Linq;

namespace L5XParser.Service
{
    public class Analayser
    {
        public static void OutputDataTypeInfo(FileInfo src)
        {
            if (!src.Exists) throw new ArgumentException();

            var xml = XElement.Load(src.FullName);

            var dataTypes = Factory.CreateDataTypeInfoFormL5X(new L5XFile(xml));

            using (var sw = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "temp.txt")))
            {
                foreach (var dataType in dataTypes)
                {
                    sw.WriteLine(dataType.ToString());

                    sw.WriteLine("---ExInfo---");
                    sw.WriteLine($"HiddenMemberCount = {dataType.GetHiddenMemberCnt()}");
                    sw.WriteLine("------");
                    sw.WriteLine();
                }

                sw.WriteLine("--count Info---");
                sw.WriteLine($"use user definde type count = {dataTypes.Count}");
            }
        }

        public static void OutputProgramInfo(FileInfo src)
        {
            if (!src.Exists) throw new ArgumentException();

            var xml = XElement.Load(src.FullName);


            var programs = Factory.CreateProgramInfoFromL5X(new L5XFile(xml));

            using (var sw = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "temp.txt")))
            {
                foreach (var program in programs)
                {
                    sw.WriteLine(program.ToString());

                    sw.WriteLine("---Instructions---");
                    foreach(var ele in program.GetUsingInstructionsWithCnt())
                    {
                        sw.WriteLine($" {ele.Key} [{ele.Value}]");
                    }
                    sw.WriteLine("------");
                    sw.WriteLine();
                }
            }
        }
    }
}