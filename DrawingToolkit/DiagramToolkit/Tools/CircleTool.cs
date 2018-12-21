using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using System;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class CircleTool : ToolStripButton, ITool
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

        public CircleTool()
        {
            this.Name = "Circle tool";
            this.ToolTipText = "Circle tool";
            this.Image = IconSet.circle;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
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
