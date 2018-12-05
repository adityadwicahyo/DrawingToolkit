using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using System;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class ShadowTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Shadow shadow;

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

        public ShadowTool()
        {
            this.Name = "Shadow tool";
            this.ToolTipText = "Shadow tool";
            this.Image = IconSet.shadow;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.shadow = new Shadow(e.X, e.Y);
                this.shadow.ChangeState(PreviewState.GetInstance());
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.shadow != null)
                {
                    int width = e.X - this.shadow.X;
                    int height = e.Y - this.shadow.Y;

                    if (width > 0 && height > 0)
                    {
                        this.shadow.Width = width;
                        this.shadow.Height = height;
                    }

                    canvas.AddDrawingObject(shadow);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.canvas.AddDrawingObject(this.shadow);
                this.shadow.ChangeState(StaticState.GetInstance());
            }
        }
    }
}
