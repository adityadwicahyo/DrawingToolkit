using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    public class ShadowRectangle : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        private SolidBrush solidBrush;
        private List<DrawingObject> drawingObjects;

        public ShadowRectangle()
        {
            this.solidBrush = new SolidBrush(Color.Black);
            drawingObjects = new List<DrawingObject>();
        }

        public ShadowRectangle(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public ShadowRectangle(int x, int y, int width, int height) : this(x, y)
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
        }

        public override void RenderOnStaticView()
        {
            this.solidBrush.Color = Color.Black;
            Graphics.FillRectangle(this.solidBrush, X, Y, Width, Height);

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(Graphics);
                obj.RenderOnStaticView();
            }
        }

        public override void RenderOnEditView()
        {
            this.solidBrush.Color = Color.Black;
            Graphics.FillRectangle(this.solidBrush, X, Y, Width, Height);

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(Graphics);
                obj.RenderOnEditView();
            }

        }

        public override void RenderOnPreview()
        {
            this.solidBrush.Color = Color.Black;
            Graphics.FillRectangle(this.solidBrush, X, Y, Width, Height);

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(Graphics);
                obj.RenderOnPreview();
            }
        }
    }
}
