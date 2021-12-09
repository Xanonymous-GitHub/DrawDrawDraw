namespace DrawingModel
{
    internal interface IPainter
    {
        void ClearAll();
        void DrawLine(double x1, double y1, double x2, double y2);
        void DrawRectangle(double x1, double y1, double x2, double y2);
        void DrawEllipse(double x1, double y1, double x2, double y2);
    }
}
