using System;

namespace DrawingModel
{
    internal interface IShape
    {
        public void DrawBy(IPainter painter);
    }

    internal abstract class Shape : IShape, ICloneable
    {
        public double x1;
        public double y1;
        public double x2;
        public double y2;

        public abstract object Clone();
        public abstract void DrawBy(IPainter painter);
    }
}
