﻿using System;
using System.Drawing;

namespace ArrowLine.Table
{
    public class InterfaceTable : AbstractTable
    {
        public InterfaceTable(FigureType type)
        {
            Type = type;
        }

        public override void Draw()
        {
            format.Alignment = StringAlignment.Center;

            CreateBaseRactangle();
            IncreaseFrame();
            DrawStringRectangle(font, format, "<< Interface >>", heightStringRectangle, stepDownPoint: 0);
            DrawStringRectangle(font, format, title, heightStringRectangle, stepDownPoint: 20);

            titleRectangle = stringRectangle;

            DrawHorizontalLine(lineIndex: 0, stepDownLine - 2);

            foreach (var item in RectanglesPoint(this))
            {
                singltone.Graphics.FillRectangle(Brushes.Red, item);
            }
            singltone.Graphics.DrawRectangle(singltone.pen, objectRectangle);

            format.Alignment = StringAlignment.Near;
        }
    }
}
