using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    internal class WindowsStorePainterAdaptor : IPainter
    {
        Canvas _canvas;
        public WindowsStorePainterAdaptor(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            Ellipse ellipse = new();
            ellipse.Fill = new SolidColorBrush(Colors.Orange);
            ellipse.Width = Math.Abs(x2 - x1);
            ellipse.Height = Math.Abs(y2 - y1);
            _canvas.Children.Add(ellipse);
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new()
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = new SolidColorBrush(Colors.Black)
            };

            _canvas.Children.Add(line);
        }

        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Rectangle rectangle = new();
            rectangle.Fill = new SolidColorBrush(Colors.Yellow);
            rectangle.Width = Math.Abs(x2 - x1);
            rectangle.Height = Math.Abs(y2 - y1);
            _canvas.Children.Add(rectangle);
        }
    }
}
