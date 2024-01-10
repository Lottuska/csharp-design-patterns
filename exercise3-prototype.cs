using System;

namespace Coding.Exercise
{
    public class Point
    {
        public int X, Y;

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public Point() { }
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            Line line = new Line { Start = new Point(Start), End = new Point(End) };
            return line;
        }
    }
}
