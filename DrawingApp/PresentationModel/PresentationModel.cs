using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    internal class PresentationModel
    {
        Model _model;
        IPainter _painter;

        public PresentationModel(Model model, Canvas canvas)
        {
            _model = model;
            _painter = new WindowsStorePainterAdaptor(canvas);
        }

        public void Draw()
        {
            _model.DrawBy(_painter);
        }
    }
}
