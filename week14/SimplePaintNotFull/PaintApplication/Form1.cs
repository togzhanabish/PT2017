using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApplication
{
    public partial class Form1 : Form
    {
        Graphics g, g1;
        Pen p = new Pen(Color.Black);
        Point start = new Point(0, 0);
        Point end = new Point(0, 0);
        bool drawing = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void ColorChoose_Click(object sender, EventArgs e)
        {
            DialogResult r = colorDialog1.ShowDialog();
            if(r == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
            }

            ColorChoose.BackColor = p.Color;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(drawing)
            {
                p.Width = trackBar1.Value;
                end = e.Location;
                g = pictureBox1.CreateGraphics();
                g.DrawLine(p, start, end);
            }
            else 
            {
                p.Width = 1;
                g1 = pictureBox1.CreateGraphics();
                g1.DrawRectangle(p, e.X, e.Y, 16, 16);
                
            }
            
            start = end;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            if(e.Button == MouseButtons.Left)
            {
                drawing = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            p.Width = trackBar1.Value;
            label1.Text = " " + trackBar1.Value;
        }

        private void Eraser_Click(object sender, EventArgs e)
        {
            p.Color = Color.White;
            p.Width = 15;
        }
    }
}
