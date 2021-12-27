using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingModel;
using Rectangle = DrawingModel.Rectangle;

namespace DrawingForm
{
    public partial class CanvasForm : Form
    {
        private readonly DrawerService _drawerService = DrawerService.Instance;
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
            UpdateToolStripMenuItem();
            InitDefaultDrawingMode();
        }

        private void InitDefaultDrawingMode()
        {
            InitRectangleMode();
        }

        public void InitLineMode()
        {
            _drawerService.Use(Shape.Create<Line>());
            BindViewModelAndDrawingStateChangeEvent();
        }

        public void InitRectangleMode()
        {
            _drawerService.Use(Shape.Create<Rectangle>());
            BindViewModelAndDrawingStateChangeEvent();
        }

        public void InitEllipseMode()
        {
            _drawerService.Use(Shape.Create<Ellipse>());
            BindViewModelAndDrawingStateChangeEvent();
        }

        private void BindViewModelAndDrawingStateChangeEvent()
        {
            _viewModel = new(_drawerService);
            _drawerService.DrawingStateChanged += HandleDrawingStateChanged;
        }

        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _drawerService.PointerPressed(e.X, e.Y);
        }

        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _drawerService.PointerReleased(e.X, e.Y);
        }

        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _drawerService.PointerMoved(e.X, e.Y);
        }

        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _viewModel.UpdateCanvas(e.Graphics);
            UpdateToolStripMenuItem();
        }

        public void HandleDrawingStateChanged()
        {
            Invalidate(true);
        }

        private void UseRectangleButton_Click(object sender, EventArgs e)
        {
            InitRectangleMode();
        }

        private void UseEllipseButton_Click(object sender, EventArgs e)
        {
            InitEllipseMode();
        }

        private void ClearCanvasButton_Click(object sender, EventArgs e)
        {
            _drawerService.Clear();
        }

        private void UseLineButton_Click(object sender, EventArgs e)
        {
            InitLineMode();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawerService.Undo();
            UpdateToolStripMenuItem();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawerService.Redo();
            UpdateToolStripMenuItem();
        }

        private void UpdateToolStripMenuItem()
        {
            UndoToolStripMenuItem.Enabled = _drawerService.CanUndo;
            RedoToolStripMenuItem.Enabled = _drawerService.CanRedo;
        }
    }
}
