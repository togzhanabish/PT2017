using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintProgram
{
    public partial class Form1 : Form
    {
        private PaintBase paint;

        public Form1()
        {
            InitializeComponent();
            paint = new PaintBase(pictureBox1); 
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint.prev = e.Location;
            if (paint.shape == Shape.Fill)
            {
                paint.q.Enqueue(e.Location);
                paint.curn = e.Location;
                paint.origin = paint.btm.GetPixel(e.Location.X, e.Location.Y);
                paint.Fill();
            }          
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                paint.Draw(e.Location);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint.SaveLastPath();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bit = new Bitmap(open.FileName);
                    pictureBox1.Image = bit;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }

        private void sveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "JPG file|*.jpg|PNG files|*.png";
            if (save.ShowDialog() == DialogResult.OK)
            {
                paint.SaveImage(save.FileName);
                paint.btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                paint.g.Clear(Color.White);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paint.ClearBtm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.Pencil;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.Line;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = colorDialog1.Color;
                paint.pen.Color = colorDialog1.Color;
                paint.fill = paint.pen.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.Rectangle;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.Ellipse;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.Erase;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.Fill;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.RightTriangle;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.Triangle;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.Rhombus;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to EXIT?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
               Close();
            }
            else if(MessageBox.Show("Do you really want to EXIT?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                Close();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            paint.path.Reset();
            paint.pen.Width = trackBar1.Value;
            label1.Text = "" + trackBar1.Value;
        }
    }
}
