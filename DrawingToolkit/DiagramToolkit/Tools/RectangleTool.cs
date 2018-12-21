using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using System;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class RectangleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Rectangle rectangle;

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

        public RectangleTool()
        {
            this.Name = "Rectangle tool";
            this.ToolTipText = "Rectangle tool";
            this.Image = IconSet.rectangle;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.rectangle = new Rectangle(e.X, e.Y);
                this.rectangle.ChangeState(PreviewState.GetInstance());
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.rectangle != null)
                {
                    int width = e.X - this.rectangle.X;
                    int height = e.Y - this.rectangle.Y;

                    if (width > 0 && height > 0)
                    {
                        this.rectangle.Width = width;
                        this.rectangle.Height = height;
                    }

                    canvas.AddDrawingObject(rectangle);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.canvas.AddDrawingObject(this.rectangle);
                this.rectangle.ChangeState(StaticState.GetInstance());
            }
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
