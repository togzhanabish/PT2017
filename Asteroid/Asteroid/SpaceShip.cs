using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsAgain
{
    public class SpaceShip
    {
        /*enum Position
        {
            Left,
            Right,
            Up,
            Down
        }

        private int _x, _y;
        private Position _objPosition;*/

        public Point location;
        public SolidBrush brush;
        public Graphics g;
        public int dx, dy;

        public SpaceShip(Graphics _g, Point p)
        {
            location = new Point();
            g = _g;
            brush = new SolidBrush(Color.Yellow);
            location = p;
        }

        public void Draw()
        {
            Point[] p =
            {
                new Point(location.X, location.Y - 65),
                new Point(location.X + 65, location.Y - 35),
                new Point(location.X + 65, location.Y + 35),
                new Point(location.X, location.Y + 65),
                new Point(location.X - 65, location.Y + 35),
                new Point(location.X - 65, location.Y - 35)
            };

            g.FillPolygon(brush, p);
        }

        public void Move(int width, int height,int d,  Gun gun)
        {
            if ((location.X > width) || (location.X < 0))
                dx *= -1;

            if ((location.Y > height) || (location.Y < 0))
                dy *= -1;

            switch (d)
            {
                case 1:
                    location.Y -= 10;
                    gun.location.Y -= 10;
                    break;
                case 2:
                    location.Y +=10;
                    gun.location.Y += 10;
                    break;
                case 3:
                    location.X += 10;
                    gun.location.X += 10;
                    break;
                case 4:
                    location.X -= 10;
                    gun.location.X -= 10;
                    break;
            }
            /*if (_objPosition == Position.Right)
            {
                _x += 10;
            }
            else if (_objPosition == Position.Left)
            {
                _x -= 10;
            }
            else if (_objPosition == Position.Up)
            {
                location.Y -= 10;
            }
            else if (_objPosition == Position.Down)
            {
                location.Y += 10;
            }*/
        }
    }
}
