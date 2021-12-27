using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DrawingModel;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly DrawerService _drawerService = DrawerService.Instance;
        private PresentationModel.MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            ClearCanvasButton.Click += HandleClearButtonClick;
            UseRectangleButton.Click += HandleRectangleButtonClick;
            UseEllipseButton.Click += HandleEllipseButtonClick;
            UseLineButon.Click += HandleLineButtonClick;
            RedoButton.Click += HandleRedoButtonClick;
            UndoButton.Click += HandleUndoButtonClick;
            InitDefaultDrawingMode();
        }

        private void InitDefaultDrawingMode()
        {
            InitEllipseMode();
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
            _viewModel = new(_drawerService, _canvas);
            _drawerService.DrawingStateChanged += HandleDrawingStateChanged;
        }

        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _drawerService.Clear();
        }

        private void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            InitRectangleMode();
        }

        private void HandleEllipseButtonClick(object sender, RoutedEventArgs e)
        {
            InitEllipseMode();
        }

        private void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            InitLineMode();
        }

        private void HandleUndoButtonClick(object sender, RoutedEventArgs e)
        {
            _drawerService.Undo();
        }

        private void HandleRedoButtonClick(object sender, RoutedEventArgs e)
        {
            _drawerService.Redo();
        }

        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _drawerService.PointerPressed(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _drawerService.PointerReleased(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _drawerService.PointerMoved(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        public void HandleDrawingStateChanged()
        {
            _viewModel.UpdateCanvas();
        }
    }
}
