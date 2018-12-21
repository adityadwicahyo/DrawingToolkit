using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    public class Rectangle : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        //private Pen pen;
        private SolidBrush solidBrush;
        private SolidBrush shadowBrush;
        private List<DrawingObject> drawingObjects;

        private bool isShadow = false;

        public Rectangle()
        {
            this.solidBrush = new SolidBrush(Color.Black);
            this.shadowBrush = new SolidBrush(Color.Black);
            //pen.Width = 1.5f;
            drawingObjects = new List<DrawingObject>();
        }

        public Rectangle(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public Rectangle(int x, int y, int width, int height) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public override bool Intersect(Point MousePosition)
        {
            if ((MousePosition.X >= X && MousePosition.X <= X + (X + Width - X)) && (MousePosition.Y >= Y && MousePosition.Y <= Y + (Y + Height - Y)))
            {
                return true;
            }
            return false;
        }

        public override void Move(int x, int y, int xAmount, int yAmount)
        {
            this.X = x + xAmount;
            this.Y = y + yAmount;

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.Move(x + 15, y + 15, xAmount, yAmount);
            }
        }

        public override void RenderOnStaticView()
        {
            this.solidBrush.Color = Color.Aqua;
            //this.pen.DashStyle = DashStyle.Solid;
            //this.pen.Width = 1.5f;
            //this.shadowBrush.Color = Color.Black;
            //if (isShadow) Graphics.FillRectangle(this.shadowBrush, X + 15, Y + 15, Width, Height);
            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(Graphics);
                obj.RenderOnStaticView();
            }

            Graphics.FillRectangle(this.solidBrush, X, Y, Width, Height);
        }

        public override void RenderOnEditView()
        {
            this.solidBrush.Color = Color.Blue;
            //this.pen.DashStyle = DashStyle.Solid;
            //this.pen.Width = 3.0f;
            //this.shadowBrush.Color = Color.Black;
            //if (isShadow) Graphics.FillRectangle(this.shadowBrush, X + 15, Y + 15, Width, Height);
            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(Graphics);
                obj.RenderOnEditView();
            }

            Graphics.FillRectangle(this.solidBrush, X, Y, Width, Height);
        }

        public override void RenderOnPreview()
        {
            this.solidBrush.Color = Color.Red;
            //this.pen.DashStyle = DashStyle.DashDot;
            //this.pen.Width = 1.5f;
            //this.shadowBrush.Color = Color.Black;
            //if (isShadow) Graphics.FillRectangle(this.shadowBrush, X + 15, Y + 15, Width, Height);
            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(Graphics);
                obj.RenderOnPreview();
            }

            Graphics.FillRectangle(this.solidBrush, X, Y, Width, Height);
        }

        //public void AddMember(DrawingObject obj)
        //{
        //    this.drawingObjects.Add(obj);
        //}

        public void setShadow()
        {
            isShadow = true;
        }
    }
}
