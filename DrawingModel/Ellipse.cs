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

        public override void DrawBy(IPainter painter)
        {
            painter.DrawEllipse(x1, x2, y1, y2);
        }
    }
}
