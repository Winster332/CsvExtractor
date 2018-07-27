namespace CsvExtractor
{
    public class Vec2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vec2()
        {
            X = 0;
            Y = 0;
        }

        public Vec2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{{ x:{X}, y:{Y} }}";
        }
    }
}