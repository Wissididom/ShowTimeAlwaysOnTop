namespace ShowTimeAlwaysOnTop
{
    public class Config
    {
        public ConfigTime? Time { get; set; }
        public bool TimeShown { get; set; }
        public int Transparency { get; set; }
        public int Size { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public class ConfigTime
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string? Font { get; set; }
            public ConfigColor? Color { get; set; }
        }

        public class ConfigColor
        {
            public int A { get; set; }
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }
        }
    }
}
