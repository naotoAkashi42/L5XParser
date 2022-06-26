using System;
using System.Text;
using Utilities;


namespace L5XParser.Model.ProgramElement
{
    public class Program
    {
        private readonly string _name;
        private readonly IReadOnlyList<Tag> _tags;
        private readonly IReadOnlyList<Routine> _routines;

        public Program(string name, List<Tag> tags, List<Routine> routines)
        {
            _name = name;
            _tags = tags;
            _routines = routines;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Program Name = {_name}"+ Environment.NewLine);
            
            sb.Append($"--Program Tags--" + Environment.NewLine);
            _tags.ForEach(tag => sb.Append(tag.ToString() + Environment.NewLine));

            sb.Append($"--Routines--" + Environment.NewLine);
            _routines.ForEach(routine => sb.Append(routine.ToString() + Environment.NewLine));

            return sb.ToString();
        }

        public IReadOnlyDictionary<string, int> GetUsingInstructionsWithCnt()
        {
            var list = new List<string>();
            _routines.ForEach(r => list.AddRange(r.GetUsingInstructions()));

            var hashset = new HashSet<string>(list);

            var dic = new Dictionary<string, int>();
            foreach (var ele in hashset)
            {
                var cnt = list.Count(inst => inst.Equals(ele));
                dic.Add(ele, cnt);
            }
            return dic;
        }
    }
}
