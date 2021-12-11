using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    internal class MainPageViewModel
    {
        DrawerService _drawerService;
        IPainter _painter;

        public MainPageViewModel(DrawerService drawerService, Canvas canvas)
        {
            _drawerService = drawerService;
            _painter = new WinAppPainter(canvas);
        }

        public void Draw()
        {
            _drawerService.DrawBy(_painter);
        }
    }
}
