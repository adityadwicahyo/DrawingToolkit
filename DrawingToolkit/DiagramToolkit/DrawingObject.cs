using DiagramToolkit.States;
using System;
using System.Drawing;

namespace DiagramToolkit
{
    public abstract class DrawingObject
    {
        public Guid ID { get; set; }
        public Graphics Graphics { get; set; }
        protected DrawingState state;

        public virtual void SetGraphics(Graphics graphics)
        {
            this.Graphics = graphics;
        }

        public DrawingObject()
        {
            ID = Guid.NewGuid();
            this.ChangeState(PreviewState.GetInstance());
        }

        public abstract void Move(int x, int y, int xAmount, int yAmount);
        
        public abstract bool Intersect(Point MousePosition);

        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        public virtual void ChangeState(DrawingState state)
        {
            this.state = state;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
        }

        public abstract void RenderOnStaticView();
        public abstract void RenderOnEditView();
        public abstract void RenderOnPreview();
    }
}
