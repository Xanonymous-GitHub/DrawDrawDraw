using System;

namespace DrawingModel
{
    internal class Rectangle : Shape
    {
        public override object Clone()
        {
            Rectangle cloned = new();
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

            return Math.Abs(x - x1) <= xD && Math.Abs(x - x2) <= xD && Math.Abs(y - y1) <= yD && Math.Abs(y - y2) <= yD;
        }

        public override string GetDescription() => $"Selected: Rectangle({x1}, {y1}, {x2}, {y2})";

        public override void DrawBy(IPainter painter)
        {
            if (IsSelected) painter.DrawRectangleSelectionBorder(x1, y1, x2, y2);
            else painter.DrawRectangle(x1, y1, x2, y2);
        }
    }
}
