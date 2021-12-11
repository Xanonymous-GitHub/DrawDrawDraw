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
    internal class WinAppPainter : IPainter
    {
        Canvas _canvas;
        public WinAppPainter(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            if (x1 > x2)
            {
                (x1, x2) = (x2, x1);
            }

            if (y1 > y2)
            {
                (y1, y2) = (y2, y1);
            }

            Windows.UI.Xaml.Shapes.Ellipse ellipse = new()
            {
                Width = Math.Abs(x2 - x1),
                Height = Math.Abs(y2 - y1),
                Fill = new SolidColorBrush(Colors.Orange),
                Stroke = new SolidColorBrush(Colors.Black)
            };

            Canvas.SetTop(ellipse, y1);
            Canvas.SetLeft(ellipse, x1);

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
            if (x1 > x2)
            {
                (x1, x2) = (x2, x1);
            }

            if (y1 > y2)
            {
                (y1, y2) = (y2, y1);
            }

            Windows.UI.Xaml.Shapes.Rectangle rectangle = new()
            {
                Width = Math.Abs(x2 - x1),
                Height = Math.Abs(y2 - y1),
                Fill = new SolidColorBrush(Colors.Yellow),
                Stroke = new SolidColorBrush(Colors.Black)
            };

            Canvas.SetTop(rectangle, y1);
            Canvas.SetLeft(rectangle, x1);

            _canvas.Children.Add(rectangle);
        }
    }
}
