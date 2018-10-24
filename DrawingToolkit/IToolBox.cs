﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public delegate void ToolSelectedEventHandler(ITool tool);

    public interface IToolBox
    {
        event ToolSelectedEventHandler ToolSelected;
        void AddTool(ITool tool);
        void RemoveTool(ITool tool);
        void AddSeparator();
        ITool ActiveTool { get; set; }
    }
}
