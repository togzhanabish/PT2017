using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinAnimation
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        int x, y;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            pen = new Pen(Color.Cyan, 3);
            trackBar1.Maximum = 500;
            trackBar2.Maximum = 500;
            trackBar3.Maximum = 500;
            x = 200;
            y = 200;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Width = trackBar1.Value;
            Height = trackBar1.Value;
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawEllipse(pen, x, y, trackBar1.Value, trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            
            x += trackBar2.Value;
            Refresh();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            y += trackBar2.Value;
            Refresh();
        }

        
    }
}
