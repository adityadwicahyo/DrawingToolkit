﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public interface ICanvas
    {
        String Name { get; set; }
        ITool GetActiveTool();
        void SetActiveTool(ITool tool);
        void Repaint();
        void SetBackgroundColor(Color color);

        void AddDrawingObject(DrawingObject drawingObject);
        void RemoveDrawingObject(DrawingObject drawingObject);

        DrawingObject GetObjectAt(int x, int y);
        DrawingObject SelectObjectAt(int x, int y);
        void DeselectAllObject();
    }
}