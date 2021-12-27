using System;

namespace DrawingModel
{
    internal class Ellipse : Shape
    {
        public override object Clone()
        {
            Ellipse cloned = new();
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

            double h = (x1 + x2) / 2;
            double k = (y1 + y2) / 2;

            double rx = xD / 2;
            double ry = yD / 2;

            return (Math.Pow(x - h, 2) / Math.Pow(rx, 2)) + (Math.Pow(y - k, 2) / Math.Pow(ry, 2)) <= 1;
        }
        public override void DrawBy(IPainter painter) => painter.DrawEllipse(x1, y1, x2, y2);
    }
}
