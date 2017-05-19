using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidsAgain
{
    public partial class Form1 : Form
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

        Graphics g;

        Asteroids ast;
        SpaceShip ship;
        Bullet bullet;
        Gun gun;

        int d = 1;

        List<SpaceShip> sps = new List<SpaceShip>();
        List<Asteroids> astrs = new List<Asteroids>();
        List<Stars> stars = new List<Stars>();
        
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();

            /*_x = 50;
            _y = 50;
            _objPosition = Position.Down;*/

            
            astrs.Add(new Asteroids(g, new Point(180, 200)));
            astrs.Add(new Asteroids(g, new Point(220, 450)));
            astrs.Add(new Asteroids(g, new Point(800, 170)));
            astrs.Add(new Asteroids(g, new Point(610, 510)));

            stars.Add(new Stars(g, new Point(70, 125)));
            stars.Add(new Stars(g, new Point(360, 85)));
            stars.Add(new Stars(g, new Point(695, 142)));
            stars.Add(new Stars(g, new Point(880, 275)));
            stars.Add(new Stars(g, new Point(770, 400)));
            stars.Add(new Stars(g, new Point(865, 570)));
            stars.Add(new Stars(g, new Point(380, 500)));
            stars.Add(new Stars(g, new Point(70, 510)));

            ship = new SpaceShip(g, new Point(492, 325));
            bullet = new Bullet(g, new Point(547, 240));
            gun = new Gun(g, new Point(492, 325));

            timer1.Enabled = true;
            timer1.Interval = 50;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            foreach (Asteroids a in astrs)
            {
                a.Move(Width, Height);

            }

            foreach (Stars s in stars)
            {
                s.Move(Width, Height);
            }

            ship.Move(Width, Height, d, gun);
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    d = 1;
                    break;
                case Keys.Down:
                    d = 2;
                    break;
                case Keys.Right:
                    d = 3;
                    break;
                case Keys.Left:
                    d = 4;
                    break;
            }

                    /*if (e.KeyCode == Keys.Left)
                    {
                        _objPosition = Position.Left;
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        _objPosition = Position.Right;
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        _objPosition = Position.Up;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        _objPosition = Position.Down;
                    }*/

            }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.Blue);
            foreach (Asteroids a in astrs)
            {
                a.Draw();
            }

            foreach (Stars s in stars)
            {
                s.Draw();
            }
            ship.Draw();
            gun.Draw();
            bullet.Draw();
        }
    }
}