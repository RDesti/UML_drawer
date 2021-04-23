﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ArrowLine
{
    public abstract class AbstractTable : AbstractFigure
    {
        protected TextBox title;
        protected int heightStringRectangle = 20;
        protected int stepDownLine = 20;
        protected int stepDownFieldPoint = 20;
        protected int stepDownPropertyPoint = 22;
        protected int stepDownMethodPoint = 24;
        protected List<string> fields;
        protected List<string> properties;
        protected List<string> methods;
        protected List<Rectangle> fieldRectangles;
        protected List<Rectangle> propertieRectangles;
        protected List<Rectangle> methodRectangles;
        protected List<LineInTable> linesInTable;
        public Rectangle objectRectangle;
        protected Rectangle stringRectangle;
        public List<Rectangle> highlightRectangles = new List<Rectangle>();
        public Font font;
        public StringFormat format;
        public Pen whitePen;
        public Pen blackPen;///////////
        public SolidBrush solidBrush;

        public AbstractTable()
        {
            font = new Font("Arial", 12, FontStyle.Regular);
            format = new StringFormat();
            whitePen = new Pen(Color.White, 3);////////////////
            solidBrush = new SolidBrush(Color.Black);//////Pen.Color
            blackPen = new Pen(Color.Black, 1);////////////////
            linesInTable = new List<LineInTable>();
            fields = new List<string>();
            fieldRectangles = new List<Rectangle>();
            properties = new List<string>();
            propertieRectangles = new List<Rectangle>();
            methods = new List<string>();
            methodRectangles = new List<Rectangle>();
            format.Alignment = StringAlignment.Center;

            LineInTable lineInTable = new LineInTable();

            for (int i = 0; i < 3; i++)
            {
                linesInTable.Add(lineInTable);
            }
        }

        private List<Rectangle> RectanglesPoint(AbstractFigure objectRectangle)
        {
            return new List<Rectangle>()
            {


                new Rectangle(objectRectangle.startPoint.X + objectRectangle.width/2 - 8, objectRectangle.startPoint.Y - 15, 15, 15),
                new Rectangle(objectRectangle.startPoint.X - 15, objectRectangle.startPoint.Y + objectRectangle.height/2 - 8, 15, 15),
                new Rectangle(objectRectangle.startPoint.X + objectRectangle.width/2 - 8, objectRectangle.startPoint.Y + objectRectangle.height , 15, 15 ),
                new Rectangle(objectRectangle.startPoint.X + objectRectangle.width , objectRectangle.startPoint.Y + objectRectangle.height/2 - 8, 15, 15)

            };
        }

        public bool Contain(Point pt)
        {
            foreach(var item in RectanglesPoint(this))
            {
                if (item.Contains(pt))
                {
                    return true;
                }
            }
            return false;
        }

        public void CreateBaseRactangle()
        {
            objectRectangle = new Rectangle(startPoint.X, startPoint.Y, width, height);
        }
        public override void AddField()
        {

            stepDownPropertyPoint += 20;
            stepDownMethodPoint += 20;
            format.Alignment = StringAlignment.Near;

            singltone.Graphics.DrawRectangle(whitePen, objectRectangle);

            if (methodRectangles.Count != 0)
            {
                ReDrawArea(methodRectangles, methods);
            }

            if (propertieRectangles.Count != 0)
            {
                ReDrawArea(propertieRectangles, properties);
                DrawHorizontalLine(lineIndex: 2, stepDownPropertyPoint + 1);
            }

            fields.Add(stringDataTable);
            fieldRectangles.Add(stringRectangle);

            DrawStringRectangle(font, format, stringDataTable, heightStringRectangle,
                stepDownPoint: stepDownFieldPoint += 20);

            height += heightStringRectangle;
            objectRectangle.Height += heightStringRectangle;
            height += 20;
            singltone.Graphics.DrawRectangle(singltone.pen, objectRectangle);

            DrawHorizontalLine(lineIndex: 1, stepDownFieldPoint + 1);
        }

        public override void AddProperty()
        {
            stepDownMethodPoint += 20;

            format.Alignment = StringAlignment.Near;

            singltone.Graphics.DrawRectangle(whitePen, objectRectangle);

            if (methodRectangles.Count != 0)
            {
                ReDrawArea(methodRectangles, methods);
            }

            DrawStringRectangle(font, format, stringDataTable, heightStringRectangle,
                stepDownPoint: stepDownPropertyPoint += 20);

            properties.Add(stringDataTable);
            propertieRectangles.Add(stringRectangle);

            height += heightStringRectangle;
            objectRectangle.Height += heightStringRectangle;
            height += 20;
            singltone.Graphics.DrawRectangle(singltone.pen, objectRectangle);

            DrawHorizontalLine(lineIndex: 2, stepDownPropertyPoint + 1);
        }

        public override void AddMethod()
        {
            format.Alignment = StringAlignment.Near;

            singltone.Graphics.DrawRectangle(whitePen, objectRectangle);

            DrawStringRectangle(font, format, stringDataTable, heightStringRectangle,
                stepDownPoint: stepDownMethodPoint += 20);

            methods.Add(stringDataTable);
            methodRectangles.Add(stringRectangle);

            height += heightStringRectangle;
            objectRectangle.Height += heightStringRectangle;
            height += 20;
            singltone.Graphics.DrawRectangle(singltone.pen, objectRectangle);
        }

        protected abstract void Resize();
        protected abstract void Move();
        protected virtual void DrawStringRectangle(
            Font font, StringFormat format, string text, int heightStringRectangle, int stepDownPoint)
        {
            stringRectangle = new Rectangle(startPoint.X, startPoint.Y + stepDownPoint, width, heightStringRectangle);
            singltone.Graphics.FillRectangle(new SolidBrush(Color.White), stringRectangle);
            singltone.Graphics.DrawString(text, font, solidBrush, stringRectangle, format);
        }

        protected virtual void ReDrawArea(List<Rectangle> stringRectangles, List<string> stringData)
        {
            for (int i = 0; i < stringRectangles.Count; i++)
            {
                stringRectangle = new Rectangle(stringRectangles[i].X,
                 stringRectangles[i].Y + 20, width, heightStringRectangle);

                stringRectangles[i] = stringRectangle;
                singltone.Graphics.FillRectangle(new SolidBrush(Color.White), stringRectangles[i].X, stringRectangles[i].Y, width, heightStringRectangle);
                singltone.Graphics.DrawString(stringData[i], font, solidBrush, stringRectangles[i], format);
            }
        }
        public override void ReDrawRectangleBody()
        {
            int tmpStepDownPoint = 40;

            for (int i = 0; i < fieldRectangles.Count; i++)
            {
                stringRectangle = new Rectangle(startPoint.X,
                    startPoint.Y + tmpStepDownPoint, width, heightStringRectangle);
                fieldRectangles[i] = stringRectangle;
                tmpStepDownPoint += 20;

                singltone.Graphics.FillRectangle(new SolidBrush(Color.White), fieldRectangles[i].X, fieldRectangles[i].Y, width, heightStringRectangle);
                singltone.Graphics.DrawString(fields[i], font, solidBrush, fieldRectangles[i], format);

            }

             DrawHorizontalLine(lineIndex: 1, stepDownFieldPoint + 1);

            for (int i = 0; i < propertieRectangles.Count; i++)
            {
                stringRectangle = new Rectangle(startPoint.X,
                    startPoint.Y + tmpStepDownPoint + 2, width, heightStringRectangle);
                propertieRectangles[i] = stringRectangle;
                tmpStepDownPoint += 20;
                singltone.Graphics.FillRectangle(new SolidBrush(Color.White), propertieRectangles[i].X, propertieRectangles[i].Y, width, heightStringRectangle);
                singltone.Graphics.DrawString(properties[i], font, solidBrush, propertieRectangles[i], format);

            }

            DrawHorizontalLine(lineIndex: 2, stepDownPropertyPoint + 1);

            for (int i = 0; i < methodRectangles.Count; i++)
            {
                stringRectangle = new Rectangle(startPoint.X,
                    startPoint.Y + tmpStepDownPoint + 4, width, heightStringRectangle);
                methodRectangles[i] = stringRectangle;
                tmpStepDownPoint += 20;
                singltone.Graphics.FillRectangle(new SolidBrush(Color.White), methodRectangles[i].X, methodRectangles[i].Y, width, heightStringRectangle);
                singltone.Graphics.DrawString(methods[i], font, solidBrush, methodRectangles[i], format);

            }
        }

        protected virtual void DrawHorizontalLine(int lineIndex, int stepDownPoint)
        {
            linesInTable[lineIndex]._startLinePoint.X = startPoint.X;
            linesInTable[lineIndex]._startLinePoint.Y = startPoint.Y + stepDownPoint + heightStringRectangle;
            linesInTable[lineIndex]._endLinePoint.X = startPoint.X + width;
            linesInTable[lineIndex]._endLinePoint.Y = startPoint.Y + stepDownPoint + heightStringRectangle;
            singltone.Graphics.DrawLine(singltone.pen, linesInTable[lineIndex]._startLinePoint, linesInTable[lineIndex]._endLinePoint);
        }


    }
}
