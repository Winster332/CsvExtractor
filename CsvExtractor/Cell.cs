namespace CsvExtractor
{
    public class Cell
    {
        public Vec2 Position { get; set; }
        public object Value { get; set; }
        private Table _table;

        public Cell()
        {
            Position = new Vec2();
            Value = null;
            _table = null;
        }

        public Cell(Table table, int x, int y, object value)
        {
            Position = new Vec2(x, y);
            Value = value;
            _table = table;
        }
        
        public Cell(int x, int y, object value)
        {
            Position = new Vec2(x, y);
            Value = value;
            _table = null;
        }

        public CellStream Stream()
        {
            return new CellStream(_table, this);
        }

        public void SetTable(Table table)
        {
            _table = table;
        }
        
        public float ToFloat() => float.Parse(Value.ToString());
        public double ToDouble() => double.Parse(Value.ToString());
        public int ToInt() => int.Parse(Value.ToString());
        public string ToString() => Value.ToString();
        public bool ToBoolean() => bool.Parse(Value.ToString());
        public char ToChar() => char.Parse(Value.ToString());

        public string GetString()
        {
            return $"Value: {Value}\nPosition: {Position}";
        }
    }
}