using System.Drawing;
using System;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    public class LineSegment : DrawingObject
    {
        private const double EPSILON = 3.0;

        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public LineSegment()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public LineSegment(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public LineSegment(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override bool Intersect(Point MousePosition)
        {
            double m = (double)(Endpoint.Y - Startpoint.Y) / (double)(Endpoint.X - Startpoint.X);
            double b = Endpoint.Y - m * Endpoint.X;
            double y_point = m * MousePosition.X + b;

            if (Math.Abs(MousePosition.Y - y_point) < EPSILON)
            {
                return true;
            }
            return false;
        }

        public override void Move(int x, int y, int xAmount, int yAmount)
        {
            this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
            this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
        }

        public override void RenderOnStaticView()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (Graphics != null)
            {
                Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override void RenderOnEditView()
        {
            pen.Color = Color.Blue;
            pen.Width = 3.0f;
            pen.DashStyle = DashStyle.Solid;

            if (Graphics != null)
            {
                Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            if (Graphics != null)
            {
                Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);

            }
        }
    }
}
