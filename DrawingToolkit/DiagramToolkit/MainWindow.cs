using DiagramToolkit.Commands;
using DiagramToolkit.MenuItems;
using DiagramToolkit.ToolbarItems;
using DiagramToolkit.Tools;
using System.Diagnostics;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public partial class MainWindow : Form
    {
        private IToolbox toolbox;
        private ICanvas canvas;

        public MainWindow()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            Debug.WriteLine("Initializing UI objects.");

            #region Canvas

            Debug.WriteLine("Loading canvas...");
            this.canvas = new DefaultCanvas();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.canvas);

            #endregion

            #region Commands

            BlackCanvasBgCommand blackCanvasBgCmd = new BlackCanvasBgCommand(this.canvas);
            WhiteCanvasBgCommand whiteCanvasBgCmd = new WhiteCanvasBgCommand(this.canvas);

            #endregion

            #region Toolbox

            // Initializing toolbox
            Debug.WriteLine("Loading toolbox...");
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);

            #endregion

            #region Tools

            // Initializing tools
            Debug.WriteLine("Loading tools...");
            this.toolbox.AddTool(new SelectionTool());
            this.toolbox.AddSeparator();
            this.toolbox.AddTool(new LineTool());
            this.toolbox.AddTool(new RectangleTool());
            //this.toolbox.AddTool(new CircleTool());
            this.toolbox.AddTool(new ShadowTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;

            #endregion
        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.canvas != null)
            {
                Debug.WriteLine("Tool " + tool.Name + " is selected");
                this.canvas.SetActiveTool(tool);
                tool.TargetCanvas = this.canvas;
            }
        }
    }
}
