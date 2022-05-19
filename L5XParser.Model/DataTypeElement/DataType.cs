using System.Text;

namespace L5XParser.Model.DataTypeElement
{
    public class DataType
    {
        private string _name { get; set; }
        private IReadOnlyList<DataTypeMember> _members { get; }

        public DataType(string name, List<DataTypeMember> members)
        {
            _name = name;
            _members = members;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"DataTypeName = {_name}" + Environment.NewLine);
            sb.Append($"--Members--" + Environment.NewLine);
            foreach (var member in _members)
            {
                sb.Append(member.ToString());
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public int GetHiddenMemberCnt()
        {
            return _members.Count(mem => mem.IsHidden);
        }
    }
}
