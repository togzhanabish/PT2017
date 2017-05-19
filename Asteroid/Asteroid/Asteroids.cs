using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsAgain
{
    public class Asteroids
    {
        public Point location;
        public SolidBrush brush;
        public Graphics g;

        public int dx = 15, dy = 15;

        public Asteroids() { }
        public Asteroids(Graphics _g, Point p)
        {
            location = new Point();
            g = _g;

            brush = new SolidBrush(Color.Red);
            location = p;
        }


        public void Draw()
        {
            Point[] part1 =
           {
                new Point(location.X, location.Y - 25),
                new Point(location.X + 25, location.Y + 10),
                new Point(location.X - 25, location.Y + 10)
            };
            Point[] part2 =
            {
                new Point(location.X - 25, location.Y - 10),
                new Point(location.X + 25, location.Y - 10),
                new Point(location.X, location.Y + 25)
            };

            g.FillPolygon(brush, part1);
            g.FillPolygon(brush, part2);
        }

        public void Move(int width, int height)
        {
            if ((location.X > width) || (location.X < 0))
                dx *= -1;

            if ((location.Y > height) || (location.Y < 0))
                dy *= -1;


            location.X += dx;
            location.Y += dy;
        }
    }
}