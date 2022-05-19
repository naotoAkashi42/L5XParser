using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L5XParser.Model
{
    public class L5XFile
    {
        public XElement Xml { get; }
        public L5XFile(XElement xml)
        {
            Xml = xml;
        }
    }
}
