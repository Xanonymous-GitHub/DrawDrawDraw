using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm.PresentationModel
{
    internal class CanvasFormViewModel
    {
        private readonly DrawerService _drawerService;
        public CanvasFormViewModel(DrawerService drawerService)
        {
            _drawerService = drawerService;
        }

        public void UpdateCanvas(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _drawerService.UpdateCanvasBy(new WinFormPainter(graphics));
        }
    }
}
