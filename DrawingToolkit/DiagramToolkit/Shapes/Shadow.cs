//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Drawing2D;

//namespace DiagramToolkit.Shapes
//{
//    public class Shadow : DrawingObject
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public int Width { get; set; }
//        public int Height { get; set; }

//        //private Pen pen;
//        private SolidBrush solidBrush;
//        private List<DrawingObject> drawingObjects;

//        public Shadow()
//        {
//            this.solidBrush = new SolidBrush(Color.Black);
//            //solidBrush.Width = 1.5f;
//            drawingObjects = new List<DrawingObject>();
//        }

//        public Shadow(int x, int y) : this()
//        {
//            this.X = x;
//            this.Y = y;
//        }

//        public Shadow(int x, int y, int width, int height) : this(x, y)
//        {
//            this.Width = width;
//            this.Height = height;
//        }

//        public override bool Intersect(Point MousePosition)
//        {
//            if ((MousePosition.X >= X && MousePosition.X <= X + (X + Width - X)) && (MousePosition.Y >= Y && MousePosition.Y <= Y + (Y + Height - Y)))
//            {
//                return true;
//            }
//            return false;
//        }

//        public override void Move(int x, int y, int xAmount, int yAmount)
//        {
//            this.X = x + xAmount;
//            this.Y = y + yAmount;
//        }

//        public override void RenderOnStaticView()
//        {
//            this.solidBrush.Color = Color.Black;
//            //this.solidBrush.DashStyle = DashStyle.Solid;
//            //this.pen.Width = 1.5f;
//            Graphics.FillRectangle(this.solidBrush, X, Y, Width, Height);

//            foreach (DrawingObject obj in drawingObjects)
//            {
//                obj.SetGraphics(Graphics);
//                obj.RenderOnStaticView();
//            }
//        }

//        public override void RenderOnEditView()
//        {
//            this.solidBrush.Color = Color.Black;
//            //this.pen.DashStyle = DashStyle.Solid;
//            //this.pen.Width = 3.0f;
//            Graphics.FillRectangle(this.solidBrush, X, Y, Width, Height);

//            foreach (DrawingObject obj in drawingObjects)
//            {
//                obj.SetGraphics(Graphics);
//                obj.RenderOnEditView();
//            }

//        }

//        public override void RenderOnPreview()
//        {
//            this.solidBrush.Color = Color.Black;
//            //this.pen.DashStyle = DashStyle.DashDot;
//            //this.pen.Width = 1.5f;
//            Graphics.FillRectangle(this.solidBrush, X, Y, Width, Height);

//            foreach (DrawingObject obj in drawingObjects)
//            {
//                obj.SetGraphics(Graphics);
//                obj.RenderOnPreview();
//            }
//        }
//    }
//}
