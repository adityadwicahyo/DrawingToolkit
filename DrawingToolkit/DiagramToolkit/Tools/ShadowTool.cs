using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using DrawingToolkit.DrawingObjectList;
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
                            int xShadow = temp.X + 15;
                            int yShadow = temp.Y + 15;
                            int widthShadow = temp.Width;
                            int heightShadow = temp.Height;
                            ShadowRectangle aShadow = new ShadowRectangle(xShadow, yShadow);
                            aShadow.Width = widthShadow;
                            aShadow.Height = heightShadow;
                            //(obj as Rectangle).AddMember(aShadow);
                            //canvas.Repaint();
                            canvas.AddDrawingObjectFirst(aShadow);
                            GroupShape groupShape = new GroupShape();
                            canvas.AddDrawingObjectFirst(groupShape);
                            groupShape.addMember(temp);
                            groupShape.addMember(aShadow);
                            canvas.AddDrawingObject(groupShape);
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
