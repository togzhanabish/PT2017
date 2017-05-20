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

namespace Buttons
{
    public partial class Form1 : Form
    {
        PictureBox pb;
        Graphics g;
        TextBox tb;
        public Button[,] btns;

        public Form1()
        {
            InitializeComponent();
            btns = new Button[10, 10];
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            int x = 0, y = 0;
            for(x = 0; x <=9; x++)
            {
                for(y = 0; y <= 9; y++)
                {
                    btns[x, y] = new Button();
                    btns[x, y].Name = "button2" + y + x;
                    btns[x, y].Text = "knopka" + y + x;
                    btns[x, y].Location = new Point(x*51, y*51);
                    btns[x, y].Size = new Size(51, 51);
                    btns[x, y].Click += new EventHandler(btns_Click);
                    Controls.Add(btns[x, y]);
                }
            }
            /*for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    btns[i, j] = new Button();
                    btns[i, j].Text = "";
                    btns[i, j].Top = j * 45 + 100;
                    btns[i, j].Left = i * 45 + 100;
                    btns[i, j].BackColor = Color.White;
                    btns[i, j].Size = new Size(50, 50);
                    Controls.Add(btns[i, j]);

                    btns[i, j].MouseClick += new MouseEventHandler(Form1_MouseClick);
                }
            }*/
        }

        private void btns_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            for(int i = 0; i < 10; i++)
            {
                btns[i, btn.Location.X / 51].BackColor = Color.Red;
            }                             
            for(int i = 0; i < 10; i++)
            {
                btns[btn.Location.Y / 51, i].BackColor = Color.Red;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            /*for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    btns[0, j].BackColor = Color.Red;
                    btns[i, 0].BackColor = Color.Red;

                    
                }
            }*/
        }
    }
}
