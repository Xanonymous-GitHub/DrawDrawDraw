﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    internal class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        private double _firstPointX;
        private double _firstPointY;
        bool _isPressed = false;
        private readonly List<Line> _lines = new();
        private readonly Line _hint = new();

        public void PointerPressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _hint.x1 = _firstPointX;
                _hint.y1 = _firstPointY;
                _isPressed = true;
            }
        }

        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                _hint.x2 = x;
                _hint.y2 = y;
                NotifyModelChanged();
            }
        }

        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                Line hint = new();
                hint.x1 = _firstPointX;
                hint.y1 = _firstPointY;
                hint.x2 = x;
                hint.y2 = y;
                _lines.Add(hint);
                NotifyModelChanged();
            }
        }

        public void Clear()
        {
            _isPressed = false;
            _lines.Clear();
            NotifyModelChanged();
        }

        public void DrawBy(IPainter graphics)
        {
            graphics.ClearAll();
            foreach (Line aLine in _lines)
            {
                aLine.DrawBy(graphics);
            }

            if (_isPressed)
            {
                _hint.DrawBy(graphics);
            }
        }

        private void NotifyModelChanged()
        {
            _modelChanged?.Invoke();
        }
    }
}
