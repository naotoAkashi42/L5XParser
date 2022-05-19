using System.Xml.Linq;

namespace L5XParser.Logic
{
    public static class XmlParser
    {
        public static bool TryGetDataTypes(XElement xml, out IReadOnlyList<XElement> xElements)
        {
            return TryGetTargetElemnts(xml, "DataTypes", out xElements);
        }

        public static bool TryGetModules(XElement xml, out IReadOnlyList<XElement> xElements)
        {
            return TryGetTargetElemnts(xml, "Modules", out xElements);
        }

        public static bool TryGetTags(XElement xml, out IReadOnlyList<XElement> xElements)
        {
            return TryGetTargetElemnts(xml, "Tags", out xElements);
        }

        public static bool TryGetPrograms(XElement xml, out IReadOnlyList<XElement> xElements)
        {
            return TryGetTargetElemnts(xml, "Programs", out xElements);
        }

        private static bool TryGetTargetElemnts(XElement xml, string targetName, out IReadOnlyList<XElement> xElements)
        {
            xElements = null;
            if (xml == null) return false;

            try
            {
                xElements = xml.Descendants(targetName).ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}