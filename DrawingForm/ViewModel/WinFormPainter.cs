using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingForm.PresentationModel
{
    internal class WinFormPainter : IPainter
    {
        Graphics _graphics;

        public WinFormPainter(Graphics graphics)
        {
            _graphics = graphics;
        }

        public void ClearAll()
        {
            /// <summary>
            /// Since we have used the Controll.Invalidate(true) in the Form, 
            /// the form's whole layer will directly be re-render again, 
            /// which will also clean every draw states, 
            /// so we don't need to do anythings in in this Clean function.
            /// </summary>
        }

        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Orange, new((int)Math.Round(x1), (int)Math.Round(x2), (int)Math.Round(y1), (int)Math.Round(y2)));
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Yellow, new((int)Math.Round(x1), (int)Math.Round(x2), (int)Math.Round(y1), (int)Math.Round(y2)));
        }
    }
}
