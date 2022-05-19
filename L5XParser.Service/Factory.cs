using L5XParser.Logic;
using L5XParser.Model;
using L5XParser.Model.DataTypeElement;
using L5XParser.Model.ProgramElement;
using System.Xml.Linq;
using Utilities;

namespace L5XParser.Service
{
    public class Factory
    {
        public static IReadOnlyList<DataType> CreateDataTypeInfoFormL5X(L5XFile source)
        {
            XmlParser.TryGetDataTypes(source.Xml, out var dataTypes);

            var list = new List<DataType>();
            foreach (var data in dataTypes.Elements("DataType"))
            {
                var name = data.GetAttributeValue("Name");
                var members = data.Element("Members")
                                  .Elements()
                                  .Select(ele => new DataTypeMember(ele.GetAttributeValue("Name"),
                                                                    ele.GetAttributeValue("DataType"),
                                                                    ele.GetAttributeValue("Hidden"))).ToList();
                list.Add(new DataType(name, members));
            }
            return list;
        }

        public static IReadOnlyList<Program> CreateProgramInfoFromL5X(L5XFile source)
        {
            XmlParser.TryGetPrograms(source.Xml, out var programs);

            var list = new List<Program>();
            foreach (var program in programs.Elements("Program"))
            {
                var programName = program.GetAttributeValue("Name");
                var tags = program.Element("Tags")
                                  .Elements()
                                  .Select(ele => new Tag(ele.GetAttributeValue("Name"),
                                                         ele.GetAttributeValue("DataType")));

                var routines = program.Element("Routines").Elements("Routine")
                                                          .Select(ele => new Routine(ele.GetAttributeValue("Name"),
                                                                  ele.GetElementValue("Description"),
                                                                  ele.Element("RLLContent").Elements("Rung")
                                                                                           .Select(r => new Rung(r.GetAttributeValue("Number"),
                                                                                                                 r.GetElementValue("Comment"),
                                                                                                                 r.GetElementValue("Text"))).ToList()));
                list.Add(new Program(programName, tags.ToList(), routines.ToList()));
            }
            return list;
        }

    }
}
