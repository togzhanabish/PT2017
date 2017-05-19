using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Light13._04
{
    public partial class Form1 : Form
    {
        Graphics g;
        SolidBrush brush1;
        SolidBrush brush2;
        SolidBrush brush3;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            timer1.Enabled = true;
            brush1 = new SolidBrush(Color.Green);
            brush2 = new SolidBrush(Color.Yellow);
            brush3 = new SolidBrush(Color.Red);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.FillEllipse(brush1, 150, 70, 100, 100);
            g.FillEllipse(brush2, 150, 170, 100, 100);
            g.FillEllipse(brush3, 150, 270, 100, 100);
        }
    }
}
