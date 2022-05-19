using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5XParser.Model
{
    public class DataTypeMember
    {
        private string _name { get; }
        private string _type { get; }
        private bool _hidden { get; }

        public bool IsHidden => _hidden;

        public DataTypeMember(string name, string type, string hidden)
        {
            _name = name;
            _type = type;    
            _hidden = hidden.Equals("true");
        }

        public override string ToString()
        {
            return $"MemberName = {_name}, Type = {_type}, Hidden = {_hidden}";
        }
    }
}
