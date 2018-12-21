using DiagramToolkit.States;
using DrawingToolkit.DrawingObjectList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class SelectionTool : ToolStripButton, ITool
    {
        private int xInitial;
        private int yInitial;
        private ICanvas canvas;
        private DrawingObject currentObject;

        private Boolean multiselectProcess = false;
        private List<DrawingObject> memberGroup = new List<DrawingObject>();

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

        public SelectionTool()
        {
            this.Name = "Selection tool";
            this.ToolTipText = "Selection tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;

            List<DrawingObject> listObjects = canvas.getListObjects();
            foreach (DrawingObject obj in listObjects)
            {
                foreach(DrawingObject member in memberGroup)
                {
                    if(!multiselectProcess && obj != member)
                    {
                        obj.ChangeState(StaticState.GetInstance());
                    }
                }
            }

            foreach (DrawingObject obj in listObjects)
            {
                //obj.ChangeState(StaticState.GetInstance());
                if (obj.Intersect(e.Location))
                {
                    //if (!multiselectProcess)
                    //{
                    //    memberGroup.Clear();
                    //    if (currentObject != null)
                    //    {
                    //        currentObject.ChangeState(StaticState.GetInstance());
                    //        Console.WriteLine("ajksa");
                    //    }
                    //}
                    //else
                    //{
                    //    if (!memberGroup.Any() && this.currentObject != null) memberGroup.Add(this.currentObject);
                    //    memberGroup.Add(obj);
                    //}

                    currentObject = obj;
                    obj.ChangeState(EditState.GetInstance());
                    break;
                }
                else
                {
                    obj.ChangeState(StaticState.GetInstance());
                    
                }
            }
            canvas.Repaint();

        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.currentObject != null)
            {
                int xAmount = e.X - xInitial;
                int yAmount = e.Y - yInitial;
                xInitial = e.X;
                yInitial = e.Y;
                currentObject.Move(e.X, e.Y, xAmount, yAmount);

                currentObject.ChangeState(EditState.GetInstance());
                canvas.Repaint();
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            //currentObject.ChangeState(StaticState.GetInstance());
            currentObject = null;
        }

        public void ToolHotKeysDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            if (e.KeyCode == System.Windows.Forms.Keys.ControlKey)
            {
                multiselectProcess = true;
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.G)
            {
                if (memberGroup.Count() > 0)
                {
                    GroupShape groupObject = new GroupShape();
                    foreach (DrawingObject obj in memberGroup)
                    {
                        groupObject.addMember(obj);
                    }
                    groupObject.ChangeState(EditState.GetInstance());
                    this.canvas.AddDrawingObject(groupObject);
                    this.currentObject = groupObject;
                    memberGroup.Clear();
                }
            }
        }

        public void ToolHotKeysUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.ControlKey)
            {
                multiselectProcess = false;
            }
        }
    }
}
