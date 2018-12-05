using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.States
{
    class PreviewState : DrawingState
    {
        private static DrawingState instance;
        public static DrawingState GetInstance()
        {
            if (instance == null)
            {
                instance = new PreviewState();
            }
            return instance;
        }
        public override void Draw(DrawingObject obj)
        {
            obj.RenderOnPreview();
        }
    }
}
