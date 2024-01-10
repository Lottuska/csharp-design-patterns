using System;

namespace Coding.Exercise
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;
        public string Name { get; set; }

        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer)
            : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer)
            : base(renderer)
        {
            Name = "Square";
        }
    }

    public class VectorSquare : Square
    {
        public VectorSquare(IRenderer renderer)
            : base(renderer) { }
    }

    public class RasterSquare : Square
    {
        public RasterSquare(IRenderer renderer)
            : base(renderer) { }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs { get; } = "lines";
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs { get; } = "pixels";
    }
}
