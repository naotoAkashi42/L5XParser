using System.Text;
using Utilities;

namespace L5XParser.Model.ProgramElement
{
    public class Routine
    {
        private readonly string _name;
        private readonly string _description;
        private readonly IReadOnlyList<Rung> _rungs;

        public Routine(string name, string description, List<Rung> rungs)
        {
            _name = name;
            _description = description;
            _rungs = rungs;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Name = {_name}" + Environment.NewLine);
            sb.Append($"description = {_description}" + Environment.NewLine);

            sb.Append("--Rungs--" + Environment.NewLine);
            _rungs.ForEach(rung => sb.Append(rung.ToString() + Environment.NewLine));

            return sb.ToString();
        }

        public IReadOnlyList<string> GetUsingInstructions()
        {
            var list = new List<string>();
            _rungs.ForEach(r => list.AddRange(r.GetUsingInstructions()));
            return list;
        }
    }
}
