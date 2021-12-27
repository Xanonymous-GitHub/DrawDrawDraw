﻿using System;
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
        private readonly List<Shape> _shapes = new();
        private Shape _drawingShape;

        private int _pressedShapeHash;

        public void PointerPressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                if (_drawingShape.ShouldStartDrawOnShape)
                {
                    int? startPointShapeHash = GetContainedShapeHash(x, y);
                    if (startPointShapeHash == null) return;
                    _pressedShapeHash = (int)startPointShapeHash;
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

                if (_drawingShape.ShouldEndDrawOnShape)
                {
                    int? endPointShapeHash = GetContainedShapeHash(x, y);
                    if (endPointShapeHash == null || endPointShapeHash == _pressedShapeHash)
                    {
                        _pressedShapeHash = new();

                        // TODO: re-init _drawingShape, not set properties to 0;
                        _drawingShape.x1 = 0;
                        _drawingShape.x2 = 0;
                        _drawingShape.y1 = 0;
                        _drawingShape.y2 = 0;
                        NotifyDrawingStateChanged();
                        return;
                    }
                }

                _shapes.Add((Shape)_drawingShape.Clone());
                NotifyDrawingStateChanged();
            }
        }

        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyDrawingStateChanged();
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

        private int? GetContainedShapeHash(double x, double y)
        {
            foreach (Shape shape in _shapes)
            {
                if (shape.ContainsPoint(x, y))
                {
                    return shape.GetHashCode();
                }
            }

            return null;
        }
    }
}
