﻿using ArrowLine.CapArrow;
using ArrowLine.Line;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;

namespace ArrowLine.Arrow
{
    public class ImplementationArrow : AbstractFigure
    {
        public override void Draw()
        {
            if (Math.Abs(_startPoint.X - _endPoint.X) < 20)
            {
                _endPoint.X = _startPoint.X;
            }
            else if (Math.Abs(_startPoint.Y - _endPoint.Y) < 20)
            {
                _endPoint.Y = _startPoint.Y;
            }

            AbstractArrowCap arrowCap = new CloseCapArrow(_startPoint, _endPoint);
            arrowCap.Draw();

            AbstractLine line = new DashLineArrow(_startPoint, _endPoint);
            line.Draw();
            singltone.pen.DashStyle = DashStyle.Solid;
        }
    }
}
