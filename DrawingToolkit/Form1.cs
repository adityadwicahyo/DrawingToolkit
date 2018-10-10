using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            objGraphic = panel1.CreateGraphics();
        }

        // Global Variable
        int tebal = 4, initialX, initialY;
        Pen p;
        //Color wrn, wrn1;
        Color wrn = Color.Black; 
        Color wrn1 = Color.Black;
        private Graphics objGraphic;
        private bool shouldPaint = false, warna = false;
        Boolean line, rectang, circle;
        double px, py, vector, angle;
        // Circle
        int cirW, cirL;

        // Line
        private Point preCoor, newCoor;

        // Rectangle
        int width, height;

        // Reset Button
        void reset()
        {
            line = false;
            rectang = false;
            circle = false;
        }

        void colour()
        {
            warna = true;
            p = new Pen(wrn);
            tebal = 5;
        }

        // Formula
        void rumusline()
        {
            px = newCoor.X; py = newCoor.Y;
            vector = Math.Sqrt((Math.Pow(px, 2)) + (Math.Pow(py, 2)));
            angle = Math.Atan(py / px) * 180 / Math.PI;
            //display();
        }

        void rumusrectang()
        {
            px = width; py = height;
            vector = px * py;
            if (rectang == true)
            { angle = 0; }
            //display();
        }

        void rumuscircle()
        {
            px = cirW; py = cirL;
            vector = Math.PI * 0.5 * (cirW + cirL);
            if (circle == true)
            { angle = 360; }
            //display();
        }

        // Mouse Event
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && warna == true)
            {
                if (line == true)
                {
                    shouldPaint = true;
                    preCoor = e.Location; newCoor = preCoor;
                    panel1.Invalidate();
                }

                else if (rectang == true)
                {
                    shouldPaint = true;
                    initialX = e.X; initialY = e.Y;
                    panel1.Invalidate();
                }

                else if (circle == true)
                {
                    shouldPaint = true;
                    initialX = e.X; initialY = e.Y;
                    panel1.Invalidate();
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (shouldPaint == true && warna == true)
            {
                if (line == true)
                {
                    ControlPaint.DrawReversibleLine(panel1.PointToScreen(preCoor), panel1.PointToScreen(newCoor), wrn1);
                    newCoor = new Point(e.X, e.Y);
                    ControlPaint.DrawReversibleLine(panel1.PointToScreen(preCoor), panel1.PointToScreen(newCoor), wrn1);
                }

                else if (rectang == true)
                {
                    this.Refresh();
                    p.Width = tebal;
                    width = e.X - initialX;
                    height = e.Y - initialY;
                    Rectangle rect = new Rectangle(Math.Min(e.X, initialX),
                        Math.Min(e.Y, initialY),
                        Math.Abs(e.X - initialX),
                        Math.Abs(e.Y - initialY));
                    objGraphic.DrawRectangle(p, rect);
                }

                else if (circle == true)
                {
                    this.Refresh();
                    p.Width = tebal;
                    cirW = Math.Abs(e.X - initialX);
                    cirL = Math.Abs(e.Y - initialY);
                    Rectangle rec = new Rectangle(Math.Min(e.X, initialX),
                        Math.Min(e.Y, initialY),
                        Math.Abs(e.X - initialX),
                        Math.Abs(e.Y - initialY));
                    objGraphic.DrawEllipse(p, rec);
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (shouldPaint == true && warna == true)
            {
                if (line == true)
                {
                    p.Width = tebal;
                    ControlPaint.DrawReversibleLine(panel1.PointToScreen(preCoor), panel1.PointToScreen(newCoor), wrn1);
                    objGraphic.DrawLine(p, preCoor, newCoor);
                    rumusline(); shouldPaint = false;
                }

                else if (rectang == true)
                { rumusrectang(); shouldPaint = false; }

                else if (circle == true)
                { rumuscircle(); shouldPaint = false; }
            }
        }

        private void resetBackColour()
        {
            lineToolStripMenuItem.BackColor = Color.White;
            circleToolStripMenuItem.BackColor = Color.White;
            rectangleToolStripMenuItem.BackColor = Color.White;
        }

        // Menu Shape
        private void Line_Click(object sender, EventArgs e)
        {
            reset();
            line = true;
            colour();
            resetBackColour();
            lineToolStripMenuItem.BackColor = Color.Aqua;
        }

        private void Rectang_Click(object sender, EventArgs e)
        {
            reset();
            rectang = true;
            colour();
            resetBackColour();
            rectangleToolStripMenuItem.BackColor = Color.Aqua;
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            reset();
            circle = true;
            colour();
            resetBackColour();
            circleToolStripMenuItem.BackColor = Color.Aqua;
        }
    }
}
