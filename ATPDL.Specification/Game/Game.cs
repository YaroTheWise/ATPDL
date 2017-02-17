using System.Reflection;

namespace ATPDL.Specification.Game
{
    public class Game
    {
        public Game()
        {
            Top = Point.Nil;
            Bottom = Point.Nil;
        }

        public int TieBrakeTop { get; set; }
        public int TieBrakeBottom { get; set; }

        public Point Top { get; set; }
        public Point Bottom { get; set; }
    }
}