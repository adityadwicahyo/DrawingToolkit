using DiagramToolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.DrawingObjectList
{
    class GroupShape : DrawingObject
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
            foreach (DrawingObject obj in memberGroup)
            {
                obj.Move(x, y, xAmount, yAmount);
            }
        }
        public void addMember(DrawingObject obj)
        {
            this.memberGroup.Add(obj);
        }
        public void removeMember(DrawingObject obj)
        {
            //this.memberGroup.Remove(obj);
        }

        public override void RenderOnStaticView()
        {
            //foreach (DrawingObject obj in memberGroup)
            //{
              //  obj.RenderOnStaticView();
            //}
        }

        public override void RenderOnEditView()
        {
            //foreach (DrawingObject obj in memberGroup)
            //{
              //  obj.RenderOnEditView();
            //}
        }

        public override void RenderOnPreview()
        {
            //foreach (DrawingObject obj in memberGroup)
            //{
              //  obj.RenderOnPreview();
            //}
        }
    }
}
