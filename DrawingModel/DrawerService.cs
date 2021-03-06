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
        private List<Shape> _selectedShapes = new();
        private Shape _drawingShape;
        private Shape _pressedShape;
        private bool _onlyPress = true;
        private bool _freezed = false;
        private bool _shouldUpdateMovedShapeReference = false;
        private double? _movingVectorX = null;
        private double? _movingVectorY = null;

        private Stack<List<Shape>> _previousShapesSnapShots = new();
        private Stack<List<Shape>> _nextShapesSnapShots = new();

        public bool CanUndo => _previousShapesSnapShots.Count > 0;

        public bool CanRedo => _nextShapesSnapShots.Count > 0;

        public string SelectedShapeDescription => _selectedShapes.Count > 0 ? _selectedShapes[0].GetDescription() : null;

        public void Undo()
        {
            _selectedShapes.Clear();
            FreezeCurrentSnapShotToNext();
            UseLastSnapShot();
        }

        public void Redo()
        {
            _selectedShapes.Clear();
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

                if (!_freezed && x != _drawingShape.x1 && y != _drawingShape.y1)
                {
                    _selectedShapes.Clear();
                    FreezeCurrentSnapShotToPrevious();
                    _nextShapesSnapShots.Clear();
                    _freezed = true;
                }

                Shape containedShape = GetContainedShape(x, y);

                if (containedShape != null && !_drawingShape.ShouldMoveEndPointsToContainerCenterAfterDrawing)
                {
                    containedShape.Move(x - _movingVectorX ?? 0, y - _movingVectorY ?? 0);
                    _shouldUpdateMovedShapeReference = true;
                    _movingVectorX = x;
                    _movingVectorY = y;
                }
                else if (_movingVectorX == null && _movingVectorY == null)
                {
                    _drawingShape.x2 = x;
                    _drawingShape.y2 = y;
                }

                NotifyDrawingStateChanged();
            }
        }

        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _movingVectorX = null;
                _movingVectorY = null;

                Shape endPointShape = GetContainedShape(x, y);

                if (_onlyPress)
                {
                    _selectedShapes.Clear();
                    if (endPointShape != null)
                    {
                        Shape newSelectedShape = (Shape)endPointShape.Clone();
                        newSelectedShape.x1 = endPointShape.x1;
                        newSelectedShape.y1 = endPointShape.y1;
                        newSelectedShape.x2 = endPointShape.x2;
                        newSelectedShape.y2 = endPointShape.y2;
                        newSelectedShape.IsSelected = true;
                        _selectedShapes.Add(newSelectedShape);
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
                        _ = _previousShapesSnapShots.Pop();
                        NotifyDrawingStateChanged();
                        return;
                    }
                }

                Shape newShapeToAdd = (Shape)_drawingShape.Clone();

                if (_drawingShape.ShouldMoveEndPointsToContainerCenterAfterDrawing)
                {
                    newShapeToAdd.ReferenceShapeA = _pressedShape;
                    newShapeToAdd.ReferenceShapeB = endPointShape;
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

                if (_shouldUpdateMovedShapeReference && _pressedShape != null)
                {
                    _shouldUpdateMovedShapeReference = false;
                    Shape target = _shapes[_shapes.FindIndex((shape) => _pressedShape.GetHashCode() == shape.GetHashCode())];
                    target.Move(x - _movingVectorX ?? 0, y - _movingVectorY ?? 0);
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
            _selectedShapes.Clear();
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

            foreach (Shape selectedShape in _selectedShapes)
            {
                selectedShape.DrawBy(painter);
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
