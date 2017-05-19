using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsAgain
{
    public class Gun
    {
        public Point location;
        public SolidBrush brush;
        public Graphics g;

        public Gun(Graphics _g, Point p)
        {
            location = new Point();
            g = _g;
            brush = new SolidBrush(Color.Green);
            location = p;
        }

        public void Draw()
        {
            Point[] gun =
            {
                new Point(location.X-15,location.Y-5),
                new Point(location.X,location.Y-25),
                new Point(location.X+15,location.Y-5),
                new Point(location.X+6,location.Y-5),
                new Point(location.X+6, location.Y+25),
                new Point(location.X-6,location.Y+25),
                new Point(location.X-6,location.Y-5)
            };
            g.FillPolygon(brush, gun);
        }
    }
}