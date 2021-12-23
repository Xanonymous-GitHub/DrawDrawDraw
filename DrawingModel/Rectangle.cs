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

        public override void DrawBy(IPainter painter) => painter.DrawRectangle(x1, y1, x2, y2);
    }
}
