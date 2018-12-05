﻿using DiagramToolkit.States;
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
            foreach(DrawingObject obj in listObjects)
            {
                if(obj.Intersect(e.Location))
                {
                    currentObject = obj;
                    obj.ChangeState(EditState.GetInstance());
                    break;
                }
                else
                {
                    obj.ChangeState(StaticState.GetInstance());
                    currentObject = null;
                }
            }
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
    }
}
