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

        public bool IsSelected = false;

        public bool ShouldStartDrawOnShape = false;
        public bool ShouldEndDrawOnShape = false;
        public bool ShouldMoveEndPointsToContainerCenterAfterDrawing = false;
        public bool ShouldMoveToBottomLayerAfterDrawing = false;

        public Shape ReferenceShapeA = null;
        public Shape ReferenceShapeB = null;

        public abstract object Clone();
        public abstract void DrawBy(IPainter painter);
        public static Shape Create<T>() where T : Shape, new() => new T();
        public abstract bool ContainsPoint(double x, double y);
        public abstract string GetDescription();
        public void Move(double x, double y)
        {
            x1 += x;
            x2 += x;
            y1 += y;
            y2 += y;
        }

        public double CenterX => (x1 + x2) / 2;
        public double CenterY => (y1 + y2) / 2;
    }
}
