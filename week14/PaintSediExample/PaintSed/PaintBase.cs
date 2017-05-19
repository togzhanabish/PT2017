using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class PaintBase
    {

        public enum Shape
        {
            Pencil, Line, Rectangle, Lastic, Fill, Ellipse, Circle,
            Rhombus, Triangle, RTriangle
        };


        public Graphics g;
        public GraphicsPath path;
        public PictureBox picture;
        public Pen pen;
        public Pen pen2;
        public Bitmap btm;
        public Point prev;
        public Shape shape;
        public Color origin;
        public Color fill;
        public Queue<Point> q;
        public Point curn;
        public int val;
        public SolidBrush wh;

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
            pen2 = new Pen(Color.Blue, 50);
            picture.Paint += Picture_Paint;
            fill = new Color();
            origin = new Color();
            q = new Queue<Point>();
            wh = new SolidBrush(Color.White);
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
                        new Point(cur.X, prev.Y)
                    };
                    path.AddPolygon(p);


                    // path.AddRectangle(new Rectangle(p[2].X, p[2].Y, cur.X - prev.X, cur.Y - prev.Y));
                    // path.AddEllipse(new Rectangle(p[2].X, p[2].Y, cur.X - prev.X, cur.Y - prev.Y));
                    break;
                case Shape.Lastic:
                    path.Reset();
                    g.FillRectangle(wh, prev.X - val / 2, prev.Y - val / 2, val + 20, val + 20);
                    prev = cur;
                    break;
                case Shape.Fill:
                    //Fill();
                    break;
                case Shape.Triangle:
                    path.Reset();
                    TADraw(cur);
                    break;
                case Shape.RTriangle:
                    path.Reset();
                    RTrDraw(cur);
                    break;
                case Shape.Ellipse:
                    path.Reset();
                    ElDraw(cur);
                    break;
                case Shape.Rhombus:
                    path.Reset();
                    RhDraw(cur);
                    break;
                case Shape.Circle:
                    path.Reset();
                    ClDraw(cur);
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

        public void TADraw(Point cur)
        {

            Point[] p2 =
                   {
                            new Point(cur.X, cur.Y),
                            new Point(prev.X, cur.Y),
                            new Point(prev.X, prev.Y)

                        };

            Point[] p =
                      {
                            new Point(cur.X, cur.Y),
                            new Point(cur.X, prev.Y),
                            new Point(prev.X, cur.Y)

                        };

            Point[] p3 =
                    {
                            new Point(cur.X, cur.Y),
                            new Point(cur.X, prev.Y),
                            new Point(prev.X, prev.Y)

                        };

            Point[] p4 =
                    {
                            new Point(prev.X, cur.Y),
                            new Point(cur.X, prev.Y),
                            new Point(prev.X, prev.Y)

                        };

            if (cur.X >= prev.X && cur.Y >= prev.Y)
            {
                path.AddPolygon(p2);
            }
            else if (cur.X <= prev.X && cur.Y >= prev.Y)
            {
                path.AddPolygon(p);
            }
            else if (cur.Y <= prev.Y && cur.X <= prev.X)
            {
                path.AddPolygon(p3);
            }
            else
            {
                path.AddPolygon(p4);
            }
        }

        public void ElDraw(Point cur)
        {
            Point[] p =
                        {
                            new Point(cur.X, cur.Y),
                            new Point(prev.X, cur.Y),
                            new Point(prev.X, prev.Y),
                            new Point(cur.X, prev.Y)
                        };


            path.AddEllipse(new Rectangle(p[2].X, p[2].Y, cur.X - prev.X, cur.Y - prev.Y));
        }

        public void ClDraw(Point cur)
        {

            Point[] p =
                        {
                            new Point(cur.X, cur.Y),
                            new Point(prev.X, cur.Y),
                            new Point(prev.X, prev.Y),
                            new Point(cur.X, prev.Y)
                        };

            if (cur.X >= prev.X && cur.Y >= prev.Y)
            {
                path.AddEllipse(new Rectangle(p[2].X, p[2].Y, cur.X - prev.X, cur.X - prev.X));
            }
            else if (cur.X <= prev.X && cur.Y >= prev.Y)
            {
                path.AddEllipse(new Rectangle(p[2].X, p[2].Y, cur.X - prev.X, Math.Abs(cur.X - prev.X)));
            }
            else if (cur.X <= prev.X && cur.Y <= prev.Y)
            {
                path.AddEllipse(new Rectangle(p[2].X, p[2].Y, cur.X - prev.X, cur.X - prev.X));
            }
            else if (cur.X >= prev.X && cur.Y <= prev.Y)
            {
                path.AddEllipse(new Rectangle(p[2].X, p[2].Y, Math.Abs(cur.X - prev.X), (cur.X - prev.X) * -1));
            }


        }
        public void RhDraw(Point cur)
        {
            Point[] p =
                           {
                            new Point(cur.X, cur.Y),
                            new Point((cur.X -prev.X)/2+prev.X, (cur.Y -prev.Y)*2+prev.Y),
                            new Point(prev.X, cur.Y),
                            new Point((cur.X -prev.X)/2+prev.X, prev.Y)
                        };


            path.AddPolygon(p);




        }

        public void RTrDraw(Point cur)
        {

            Point[] p3 =
                           {
                            new Point(cur.X, cur.Y),
                            new Point((cur.X -prev.X)/2+prev.X, (cur.Y -prev.Y)+prev.Y),
                            new Point(prev.X, cur.Y),
                            new Point((cur.X -prev.X)/2+prev.X, prev.Y)
                        };


            /* Point[] p3 =
                        {
                             new Point(cur.X, cur.Y),
                             new Point(cur.X/2, cur.Y),
                             new Point(prev.X, prev.Y),
                             //new Point(cur.X, prev.Y)
                         };
                         */
            path.AddPolygon(p3);
        }
    }
}