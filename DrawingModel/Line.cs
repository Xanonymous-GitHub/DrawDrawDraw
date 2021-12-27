using System;

namespace DrawingModel
{
    internal class Line : Shape
    {
        public Line() : base()
        {
            ShouldStartDrawOnShape = true;
            ShouldEndDrawOnShape = true;
            ShouldFixPositionAfterDrawing = true;
        }

        public override object Clone()
        {
            Line cloned = new();
            cloned.x1 = x1;
            cloned.x2 = x2;
            cloned.y1 = y1;
            cloned.y2 = y2;
            return cloned;
        }

        public override bool ContainsPoint(double x, double y)
        {
            double xb, xs, yb, ys;

            if (x1 > x2)
            {
                (xb, xs) = (x1, x2);
            }
            else
            {
                (xb, xs) = (x2, x1);
            }

            if (y1 > y2)
            {
                (yb, ys) = (y1, y2);
            }
            else
            {
                (yb, ys) = (y2, y1);
            }

            double xD = xb - xs;
            double yD = yb - ys;

            bool isInsideTheRange = Math.Abs(x - x1) <= xD && Math.Abs(x - x2) <= xD && Math.Abs(y - y1) <= yD && Math.Abs(y - y2) <= yD;

            double solpeA = (y - y1) / (x - x1);
            double solpeB = (y - y2) / (x - x2);

            return isInsideTheRange && solpeA == solpeB;
        }
        public override void DrawBy(IPainter painter) => painter.DrawLine(x1, y1, x2, y2);
    }
}
