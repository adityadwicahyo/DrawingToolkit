using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class ShadowTool : ToolStripButton, ITool
    {
        private ICanvas canvas;

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
                List<DrawingObject> listObjects = canvas.getListObjects();
                foreach (DrawingObject obj in listObjects)
                {
                    if (obj.Intersect(e.Location))
                    {
                        if(obj.GetType() == typeof(Rectangle))
                        {
                            Rectangle temp = (Rectangle)obj;
                            temp.setShadow();
                            canvas.Repaint();
                        }
                        break;
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
