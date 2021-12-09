﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    internal class Line
    {
        public double x1;
        public double y1;
        public double x2;
        public double y2;

        public void DrawBy(IPainter painter)
        {
            painter.DrawLine(x1, y1, x2, y2);
        }
    }
}
