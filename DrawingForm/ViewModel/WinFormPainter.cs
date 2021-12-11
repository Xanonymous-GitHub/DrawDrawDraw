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
            SolidBrush solidBrush = new(Color.Orange);
            _graphics.FillEllipse(solidBrush, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            SolidBrush solidBrush = new(Color.Yellow);

            if (x1 > x2)
            {
                (x1, x2) = (x2, x1);
            }

            if (y1 > y2)
            {
                (y1, y2) = (y2, y1);
            }

            _graphics.FillRectangle(solidBrush, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }
    }
}
