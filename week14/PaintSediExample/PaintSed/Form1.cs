using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Paint
{
    public partial class Form1 : Form
    {
        private PaintBase paint;
        public Point p;

        public Form1()
        {
            InitializeComponent();
            paint = new PaintBase(pictureBox1);
            p = new Point();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint.prev = e.Location;
            // p = e.Location;




            if (paint.shape == PaintBase.Shape.Fill)
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


        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                switch (btn.Text)
                {
                    case "Pencil":
                        paint.shape = PaintBase.Shape.Pencil;
                        break;

                    case "Line":
                        paint.shape = PaintBase.Shape.Line;
                        break;
                    case "Rectangle":
                        paint.shape = PaintBase.Shape.Rectangle;
                        break;
                    case "Lastic":
                        paint.shape = PaintBase.Shape.Lastic;
                        break;
                    case "Fill":
                        paint.shape = PaintBase.Shape.Fill;

                        break;
                    case "Ellipse":
                        paint.shape = PaintBase.Shape.Ellipse;
                        break;

                    case "Circle":
                        paint.shape = PaintBase.Shape.Circle;
                        break;
                    case "Rhombus":
                        paint.shape = PaintBase.Shape.Rhombus;
                        break;
                    case "Triangle":
                        paint.shape = PaintBase.Shape.Triangle;
                        break;
                    case "RTriangle":
                        paint.shape = PaintBase.Shape.RTriangle;
                        break;

                }

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint.SaveLastPath();
        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

            paint.path.Reset();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.BackColor = colorDialog1.Color;
                paint.pen.Color = colorDialog1.Color;
                paint.fill = label1.BackColor;
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            paint.path.Reset();

            paint.pen.Width = trackBar1.Value;
            paint.val = trackBar1.Value;
        }



        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //  openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                paint.btm = new Bitmap(Image.FromFile(openFileDialog1.FileName), pictureBox1.Size);
                paint.picture.Image = paint.btm;
                paint.g = Graphics.FromImage(paint.btm);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG file|*.jpg|PNG files|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                paint.SaveImage(saveFileDialog1.FileName);
                paint.btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                paint.g.Clear(Color.White);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}