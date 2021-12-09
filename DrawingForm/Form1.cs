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
    public partial class Form1 : Form
    {
        private readonly DrawingModel.Model _model;
        private readonly PresentationModel.PresentationModel _presentationModel;
        private readonly Panel _canvas = new DoubleBufferedPanel();

        public Form1()
        {
            InitializeComponent();
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);

            Button clear = new();
            clear.Text = "Clear";
            clear.Dock = DockStyle.Top;
            clear.AutoSize = true;
            clear.AutoSizeMode =
            AutoSizeMode.GrowAndShrink;
            clear.Click += HandleClearButtonClick;
            Controls.Add(clear);

            _model = new();
            _presentationModel = new(_model, _canvas);

            _model._modelChanged += HandleModelChanged;
        }

        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
        }

        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _model.PointerPressed(e.X, e.Y);
        }

        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _model.PointerReleased(e.X, e.Y);
        }

        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.PointerMoved(e.X, e.Y);
        }

        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        public void HandleModelChanged()
        {
            Invalidate(true);
        }
    }
}
