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
        IGraphics _igraphics;

        public PresentationModel(Model model, Canvas canvas) 
        {
            _model = model;
            _igraphics = new WindowsStoreGraphicsAdaptor(canvas);
        }

        public void Draw()
        {
            _model.Draw(_igraphics);
        }
    }
}
