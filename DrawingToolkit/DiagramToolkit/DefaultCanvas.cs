﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public class DefaultCanvas : Control, ICanvas
    {
        private ITool activeTool;
        private List<DrawingObject> drawingObjects;

        public DefaultCanvas()
        {
            Init();
        }

        private void Init()
        {
            this.drawingObjects = new List<DrawingObject>();
            this.DoubleBuffered = true;

            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            this.Paint += DefaultCanvas_Paint;
            this.MouseDown += DefaultCanvas_MouseDown;
            this.MouseUp += DefaultCanvas_MouseUp;
            this.MouseMove += DefaultCanvas_MouseMove;

            this.KeyDown += DefaultCanvas_HotkeysDown;
            this.KeyUp += DefaultCanvas_HotkeysUp;
        }

        private void DefaultCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseMove(sender, e);
            }
        }

        private void DefaultCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseUp(sender, e);
            }
        }

        private void DefaultCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDown(sender, e);
            }
        }

        private void DefaultCanvas_HotkeysDown(object sender, KeyEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolHotKeysDown(sender, e);
            }
        }

        private void DefaultCanvas_HotkeysUp(object sender, KeyEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolHotKeysUp(sender, e);
            }
        }

        private void DefaultCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (DrawingObject obj in drawingObjects)
            {
                obj.Graphics = e.Graphics;
                obj.Draw();
            }
        }

        public void Repaint()
        {
            this.Invalidate();
            this.Update();
        }

        public void SetActiveTool(ITool tool)
        {
            this.activeTool = tool;
        }

        public void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        public void AddDrawingObject(DrawingObject drawingObject)
        {
            this.drawingObjects.Add(drawingObject);
            this.Repaint();
            Debug.WriteLine("New drawing object");
        }

        public void AddDrawingObjectFirst(DrawingObject drawingObject)
        {
            this.drawingObjects.Reverse();
            this.drawingObjects.Add(drawingObject);
            this.drawingObjects.Reverse();
            this.Repaint();
            Debug.WriteLine("New drawing object");
        }

        public List<DrawingObject> getListObjects()
        {
            return drawingObjects;
        }
    }
}
