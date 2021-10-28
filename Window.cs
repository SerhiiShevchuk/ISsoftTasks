using System;

namespace Task_NET02_2
{
    public class Window
    {
        public override string ToString()
        {
            return $"{Title}({(Top?.ToString() ?? "?")}, " +
                            $"{(Left?.ToString() ?? "?")}, " +
                            $"{(Width?.ToString() ?? "?")}, " +
                            $"{(Height?.ToString() ?? "?")})";
        }
        public bool IsAllSettings()
        {
            return Title == "main" && Top.HasValue && Left.HasValue && Width.HasValue && Height.HasValue;
        }

        public string Title { get; set; }
        public double? Top { get; set; }
        public double? Left { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
    }
}
