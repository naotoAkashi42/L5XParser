using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace L5XParser.Model.ProgramElement
{
    public class Rung
    {
        private readonly string _number;
        private readonly string _comment;
        private readonly string _text;

        public Rung(string number, string comment, string text)
        {
            _number = number;
            _comment = comment;
            _text = text;
        }

        public override string ToString()
        {
            return $"Number = {_number}, Comment = {_comment}, Text = {_text}";
        }

        public IReadOnlyList<string> GetUsingInstructions()
        {
            var pattern = @"\(.*?\)";
            var regex = new Regex(pattern);
            var removed = RemoveSymbol(_text);
            var elements = regex.Split(removed).Where(s => !s.Equals(" ") || string.IsNullOrEmpty(s)).Select(s => s.Trim(' ')).ToList();
            elements.RemoveAll(ele => string.IsNullOrEmpty(ele));
            return elements;
        }

        private static string RemoveSymbol(string text)
        {
            var sym = new List<string>
            {
                "<![CDATA[",
                "];]]>",
                "[",
                "]",
                ",",
                ";",
            };

            sym.ForEach(s => text = text.Replace(s, string.Empty));
            return text;
        }
    }
}
