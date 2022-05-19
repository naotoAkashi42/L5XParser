using System.Xml.Linq;

namespace Utilities
{
    public static class Xml
    {
        public static string GetAttributeValue(this XElement ele, string attribute) 
                                    => ele == null ? string.Empty : ele.Attribute(attribute).Value;
        public static string GetElementValue(this XElement ele, string elementName)
        {
            if (ele == null) return string.Empty;

            try
            {
                return ele.Element(elementName).Value;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static bool TryGetChild(this XElement parent, string name, out XElement child)
        {
            child = null;
            if (parent == null) return false;

            try
            {
                child = parent.Element(name);
                if (child == null) return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}