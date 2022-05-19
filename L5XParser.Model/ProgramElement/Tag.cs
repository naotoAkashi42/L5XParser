namespace L5XParser.Model
{
    public class Tag
    {
        private readonly string _name;
        private readonly string _dataType;

        public Tag(string name, string type)
        {
            _name = name;
            _dataType = type;
        }

        public override string ToString()
        {
            return $"Name = {_name}, Type = {_dataType}";
        }
    }
}