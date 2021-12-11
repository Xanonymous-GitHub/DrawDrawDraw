using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class CanvasForm : Form
    {
        private DrawingModel.DrawerService _drawerService;
        private PresentationModel.CanvasFormViewModel _viewModel;
        private readonly Panel _canvas = new DoubleBufferedPanel();

        public CanvasForm()
        {
            InitializeComponent();
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);

            Button ClearButton = new();
            ClearButton.Text = "Clear";
            ClearButton.Dock = DockStyle.Top;
            ClearButton.AutoSize = true;
            ClearButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClearButton.Click += HandleClearButtonClick;
            Controls.Add(ClearButton);

            InitDefaultDrawingMode();
        }

        private void InitDefaultDrawingMode()
        {
            InitLineMode();
        }

        public void InitLineMode()
        {
            _drawerService = new(new DrawingModel.Line());
            BindViewModelAndDrawingStateChangeEvent();
        }

        public void InitRectangleMode()
        {
            _drawerService = new(new DrawingModel.Rectangle());
            BindViewModelAndDrawingStateChangeEvent();
        }

        public void InitEllipseMode()
        {
            _drawerService = new(new DrawingModel.Ellipse());
            BindViewModelAndDrawingStateChangeEvent();
        }

        private void BindViewModelAndDrawingStateChangeEvent()
        {
            _viewModel = new(_drawerService);
            _drawerService.DrawingStateChanged += HandleDrawingStateChanged;
        }

        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _drawerService.Clear();
        }

        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _drawerService.PointerPressed(e.X, e.Y);
        }

        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _drawerService.PointerReleased();
        }

        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _drawerService.PointerMoved(e.X, e.Y);
        }

        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _viewModel.Draw(e.Graphics);
        }

        public void HandleDrawingStateChanged()
        {
            Invalidate(true);
        }
    }
}
