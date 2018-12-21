using DiagramToolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.DrawingObjectList
{
    class ShadowShape : DrawingObject
    {
        private List<DrawingObject> memberGroup = new List<DrawingObject>();

        public override void ChangeState(DrawingState state)
        {
            foreach (DrawingObject obj in memberGroup)
            {
                obj.ChangeState(state);
            }
            this.state = state;
        }

        public override bool Intersect(Point MousePosition)
        {
            foreach (DrawingObject obj in memberGroup)
            {
                if (obj.Intersect(MousePosition))
                {
                    return true;
                }
            }
            return false;
        }
        public override void Move(int x, int y, int xAmount, int yAmount)
        {
            int count = 0;
            foreach (DrawingObject obj in memberGroup)
            {
                obj.SetGraphics(Graphics);
                if (count == 0)
                {
                    obj.Move(x + 15, y+ 15, xAmount, yAmount);
                }
                else
                {
                    obj.Move(x, y, xAmount, yAmount);
                }
                count++;
            }
        }
        public void addMember(DrawingObject obj)
        {
            this.memberGroup.Insert(0, obj);
        }
        public void removeMember(DrawingObject obj)
        {
            //this.memberGroup.Remove(obj);
        }

        public override void RenderOnStaticView()
        {
            foreach (DrawingObject obj in memberGroup)
            {
                obj.SetGraphics(Graphics);
                obj.RenderOnStaticView();
            }
        }

        public override void RenderOnEditView()
        {
            foreach (DrawingObject obj in memberGroup)
            {
                obj.SetGraphics(Graphics);
                obj.RenderOnEditView();
            }
        }

        public override void RenderOnPreview()
        {
            foreach (DrawingObject obj in memberGroup)
            {
                obj.SetGraphics(Graphics);
                obj.RenderOnPreview();
            }
        }
    }
}
