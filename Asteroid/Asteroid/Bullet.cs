using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsAgain
{
    public class Bullet
    {
        public Point location;
        public SolidBrush brush;
        public Graphics g;

        public Bullet(Graphics _g, Point p)
        {
            location = new Point();
            g = _g;
            brush = new SolidBrush(Color.Green);
            location = p;
        }

        public void Draw()
        {
            g.FillEllipse(brush, location.X - 6, location.Y - 14, 11, 27);
            g.FillEllipse(brush, location.X - 14, location.Y - 6, 27, 11);
        }
    }
}