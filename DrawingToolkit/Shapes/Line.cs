using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit.Shapes
{
    public class Line
    {
        private Point preCoor;
        private Point newCoor;
        private double px, py, vector, angle;
        int tebal, initialX, initialY;

        private Pen p;

        private Graphics objGraphic;

        public void rumusline()
        {
            p = new Pen(Color.Black);
            tebal = 5;
            px = newCoor.X;
            py = newCoor.Y;
            vector = Math.Sqrt((Math.Pow(px, 2)) + (Math.Pow(py, 2)));
            angle = Math.Atan(py / px) * 180 / Math.PI;
        }

        public void rumusline(Point startpoint)
        {
            this.preCoor = startpoint;
        }

        public void rumusline(Point startpoint, Point endpoint)
        {
            this.newCoor = endpoint;
        }

        public void Draw()
        {
            this.objGraphic.DrawLine(this.p, preCoor, newCoor);
        }
    }
}
