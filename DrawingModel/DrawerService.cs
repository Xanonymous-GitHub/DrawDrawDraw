using System;
using System.Collections.Generic;

namespace DrawingModel
{
    internal class DrawerService
    {
        private static readonly Lazy<DrawerService> lazy = new(() => new());

        public static DrawerService Instance => lazy.Value;

        private DrawerService() { }

        public void Use(Shape drawingShape) => _drawingShape = drawingShape;

        public event ModelChangedEventHandler DrawingStateChanged;
        public delegate void ModelChangedEventHandler();

        private bool _isPressed = false;
        private List<Shape> _shapes = new();
        private Shape _drawingShape;
        private Shape _pressedShape;
        private bool _onlyPress = true;
        private bool _freezed = false;

        private Stack<List<Shape>> _previousShapesSnapShots = new();
        private Stack<List<Shape>> _nextShapesSnapShots = new();

        public bool CanUndo => _previousShapesSnapShots.Count > 0;

        public bool CanRedo => _nextShapesSnapShots.Count > 0;

        public void Undo()
        {
            FreezeCurrentSnapShotToNext();
            UseLastSnapShot();
        }

        public void Redo()
        {
            FreezeCurrentSnapShotToPrevious();
            UseNextSnapShot();
        }

        public void PointerPressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _onlyPress = true;

                if (_drawingShape.ShouldStartDrawOnShape)
                {
                    Shape startPointShape = GetContainedShape(x, y);
                    if (startPointShape == null) return;
                    _pressedShape = startPointShape;
                }

                _drawingShape.x1 = x;
                _drawingShape.y1 = y;
                _drawingShape.x2 = x;
                _drawingShape.y2 = y;
                _isPressed = true;
            }
        }

        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                _onlyPress = false;
                if (!_freezed)
                {
                    FreezeCurrentSnapShotToPrevious();
                    _nextShapesSnapShots.Clear();
                    _freezed = true;
                }
                _drawingShape.x2 = x;
                _drawingShape.y2 = y;
                NotifyDrawingStateChanged();
            }
        }

        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                Shape endPointShape = GetContainedShape(x, y);

                if (_onlyPress)
                {
                    if (endPointShape != null)
                    {
                        _shapes.ForEach(shape => shape.IsSelected = false);
                        endPointShape.IsSelected = true;
                        NotifyDrawingStateChanged();
                    }

                    return;
                }

                if (_drawingShape.ShouldEndDrawOnShape)
                {
                    if (endPointShape == null || endPointShape == _pressedShape)
                    {
                        _pressedShape = null;

                        // TODO: re-init _drawingShape, not set properties to 0;
                        _drawingShape.x1 = 0;
                        _drawingShape.x2 = 0;
                        _drawingShape.y1 = 0;
                        _drawingShape.y2 = 0;
                        NotifyDrawingStateChanged();
                        return;
                    }
                }

                Shape newShapeToAdd = (Shape)_drawingShape.Clone();

                if (_drawingShape.ShouldMoveEndPointsToContainerCenterAfterDrawing)
                {
                    newShapeToAdd.x1 = (_pressedShape.x1 + _pressedShape.x2) / 2;
                    newShapeToAdd.y1 = (_pressedShape.y1 + _pressedShape.y2) / 2;
                    newShapeToAdd.x2 = (endPointShape.x1 + endPointShape.x2) / 2;
                    newShapeToAdd.y2 = (endPointShape.y1 + endPointShape.y2) / 2;
                }

                if (_drawingShape.ShouldMoveToBottomLayerAfterDrawing)
                {
                    int insertIndex = Math.Min(_shapes.IndexOf(_pressedShape), _shapes.IndexOf(endPointShape));
                    _shapes.Insert(insertIndex, newShapeToAdd);
                }
                else
                {
                    _shapes.Add(newShapeToAdd);
                }
                _freezed = false;
                NotifyDrawingStateChanged();
            }
        }

        public void Clear()
        {
            _isPressed = false;
            FreezeCurrentSnapShotToPrevious();
            _nextShapesSnapShots.Clear();
            _shapes.Clear();
            NotifyDrawingStateChanged();
        }

        private void FreezeCurrentSnapShotToPrevious() => _previousShapesSnapShots.Push(new(_shapes));

        private void FreezeCurrentSnapShotToNext() => _nextShapesSnapShots.Push(new(_shapes));

        private void UseLastSnapShot()
        {
            if (CanUndo)
            {
                _shapes = _previousShapesSnapShots.Pop();
                NotifyDrawingStateChanged();
            }
        }

        private void UseNextSnapShot()
        {
            if (CanRedo)
            {
                _shapes = _nextShapesSnapShots.Pop();
                NotifyDrawingStateChanged();
            }
        }

        public void UpdateCanvasBy(IPainter painter)
        {
            painter.ClearAll();
            foreach (Shape shape in _shapes)
            {
                shape.DrawBy(painter);
            }

            if (_isPressed)
            {
                _drawingShape.DrawBy(painter);
            }
        }

        private void NotifyDrawingStateChanged() => DrawingStateChanged?.Invoke();

        private Shape GetContainedShape(double x, double y)
        {
            int shapeAmount = _shapes.Count;
            for (int i = shapeAmount - 1; i >= 0; i--)
            {
                if (_shapes[i].ContainsPoint(x, y))
                {
                    return _shapes[i];
                }
            }

            return null;
        }
    }
}
