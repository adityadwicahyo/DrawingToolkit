using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public abstract class DrawingState
    {
        private DrawingState state;

        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        public abstract void Draw(DrawingObject obj);
    }
}
