﻿using ArrowLine.Abstract;
using System;
using System.Drawing;

namespace ArrowLine.Table
{
    class StackTable : AbstractTable
    {
        public StackTable(FigureType type)
        {
            Type = type;
        }

        public override void Draw()
        {
            format.Alignment = StringAlignment.Center;

            DrawBackRectangles();

            singltone.Graphics.FillRectangle(new SolidBrush(Color.White), objectRectangle);
            CreateBaseRactangle();

            IncreaseFrame();

            DrawStringRectangle(font, format, title, heightStringRectangle, stepDownPoint: 10);

            titleRectangle = stringRectangle;

            DrawHorizontalLine(lineIndex: 0, stepDownLine - 2);

            singltone.Graphics.DrawRectangle(pen, objectRectangle);

            DrawKnots();

            format.Alignment = StringAlignment.Near;
        }

        private void DrawBackRectangles()
        {
            Rectangle backRectangle;

            for (int i = 20; i >= 10; i -= 10)
            {
                backRectangle = new Rectangle(startPoint.X - i, startPoint.Y - i, width, height);

                singltone.Graphics.FillRectangle(new SolidBrush(Color.White), backRectangle);
                singltone.Graphics.DrawRectangle(pen, backRectangle);
            }
        }
    }
}
