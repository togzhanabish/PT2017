using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintProgram
{
    public enum Shape
    {
        Pencil,
        Line,
        Rectangle,
        Ellipse,
        Erase,
        Fill,
        Rhombus,
        Triangle,
        RightTriangle
    };
    public class PaintBase
    {
        public Graphics g;
        public GraphicsPath path;
        public PictureBox picture;
        public Pen pen;
        public Pen pen1;
        public Bitmap btm;
        public Point prev;
        public Shape shape;
        public Color origin;
        public Color fill;
        public Queue<Point> q;
        public Point curn;
        public SolidBrush brush;

        public PaintBase(PictureBox pictureBox1)
        {
            picture = pictureBox1;
            btm = new Bitmap(picture.Width, picture.Height);
            picture.Image = btm;
            pen = new Pen(Color.Black);
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
            path = new GraphicsPath();
            shape = Shape.Pencil;
            pen1 = new Pen(Color.Blue, 50);
            fill = Color.Black;
            origin = new Color();
            q = new Queue<Point>();
            brush = new SolidBrush(Color.White);

            picture.Paint += Picture_Paint;
        }

        private void Picture_Paint(object sender, PaintEventArgs e)
        {
            if (path != null)
                e.Graphics.DrawPath(pen, path);
        }

        public void SaveLastPath()
        {
            if (path != null)
                g.DrawPath(pen, path);
        }

        public void Draw(Point cur)
        {
            switch (shape)
            {
                case Shape.Pencil:
                    g.DrawLine(pen, prev, cur);
                    prev = cur;
                    break;
                case Shape.Line:
                    path.Reset();
                    path.AddLine(prev, cur);
                    break;
                case Shape.Rectangle:
                    path.Reset();

                    Point[] p =
                    {
                        new Point(cur.X, cur.Y),
                        new Point(prev.X, cur.Y),
                        new Point(prev.X, prev.Y),
                        new Point(cur.X, prev.Y),
                    };
                    path.AddPolygon(p);
                    break;
                case Shape.Ellipse:
                    path.Reset();
                    path.AddEllipse(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.X);
                    break;
                case Shape.Erase:
                    path.Reset();
                    g.FillEllipse(brush, prev.X , prev.Y, 10, 10);
                    prev = cur;
                    break;
                case Shape.Fill:
                    Fill();
                    break;
                case Shape.Triangle:
                    path.Reset();
                    Point[] ptr =
                    {
                        new Point(cur.X, cur.Y),
                        new Point((cur.X - prev.X)/2 + prev.X, prev.Y),
                        new Point(prev.X, cur.Y),
                    };
                    path.AddPolygon(ptr);
                    break;
                case Shape.Rhombus:
                    path.Reset();
                    Point[] prh =
                    {
                        new Point(cur.X, cur.Y),
                        new Point((cur.X - prev.X)/2 + prev.X, (cur.Y - prev.Y)*2 + prev.Y),
                        new Point(prev.X, cur.Y),
                        new Point((cur.X - prev.X)/ 2 + prev.X, prev.Y)
                    };
                    path.AddPolygon(prh);
                    break;
                case Shape.RightTriangle:
                    path.Reset();
                    Point[] prt =
                    {
                        new Point(cur.X, cur.Y),
                        new Point(cur.X/2, cur.Y),
                        new Point(prev.X, prev.Y),
                    };
                                 
                    path.AddPolygon(prt);
                    break;
               
            }
            picture.Refresh();
        }

        public void SaveImage(string filename)
        {
            btm.Save(filename);
        }

        public void Fill()
        {
            while (q.Count > 0)
            {
                curn = q.Dequeue();
                Check(curn.X, curn.Y - 1);
                Check(curn.X + 1, curn.Y);
                Check(curn.X, curn.Y + 1);
                Check(curn.X - 1, curn.Y);
            }
            picture.Refresh();
        }


        public void Check(int x, int y)
        {
            if (x > 0 && y > 0 && x < picture.Width && y < picture.Height)
            {
                if (btm.GetPixel(x, y) == origin)
                {
                    btm.SetPixel(x, y, fill);
                    q.Enqueue(new Point(x, y));
                }
            }
        }
        public void ClearBtm()
        {
            g.Clear(Color.White);
            picture.Refresh();
        }
    }
}
