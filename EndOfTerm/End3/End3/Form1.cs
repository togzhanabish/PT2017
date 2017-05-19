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

namespace End3
{
    public partial class Form1 : Form
    {
        Graphics g;
        GraphicsPath gp;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            gp = new GraphicsPath();
            pen = new Pen(Color.Red);

        }




    }
}
