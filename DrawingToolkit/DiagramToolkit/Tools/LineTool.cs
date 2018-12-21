using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using System;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class LineTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private LineSegment lineSegment;


        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public LineTool()
        {
            this.Name = "Line tool";
            this.ToolTipText = "Line tool";
            this.Image = IconSet.diagonal_line;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            lineSegment = new LineSegment(new System.Drawing.Point(e.X, e.Y));
            this.lineSegment.ChangeState(PreviewState.GetInstance());
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.lineSegment != null)
                {
                    lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    canvas.AddDrawingObject(lineSegment);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
            canvas.AddDrawingObject(lineSegment);
            this.lineSegment.ChangeState(StaticState.GetInstance());
        }

        public void ToolHotKeysDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolHotKeysUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
