using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace classwork
{
    public partial class Form1 : Form
    {

        Graphics g;
        int dx = 5;
        Boolean b = true;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            timer1.Interval = 100;
            timer1.Enabled = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Cyan, 3);

            Point[] points = {
                new Point(20 + dx, 200), 
                new Point(20 + dx, 150), 
                new Point(50 + dx, 150),
                new Point(60 + dx, 120),
                new Point(160+ dx, 120),
                new Point(170+ dx, 150),
                new Point(200+ dx, 150),
                new Point(200+ dx, 200),
                
            };

            SolidBrush brush = new SolidBrush(Color.Cyan);
            g.FillPolygon(brush, points);

            

            brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, 40 + dx, 180, 30, 30);

            brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, 140 + dx, 180, 30, 30);

        }

        

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Location);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if( b)
            {
                dx += 20;
            }
            else
            {
                dx -= 20;
            }
            if(Width - 100 < dx)
            {
                b = false;
            }

            if(dx < 0)
            {
                b = true;
            }

            Refresh();
        }
    }
}
