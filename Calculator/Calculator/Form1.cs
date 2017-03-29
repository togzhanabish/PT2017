using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double memory = 0;

        CalcClass calc = new CalcClass();

        public Form1()
        {
            InitializeComponent();
        }

        private void numbers_click(object sender, EventArgs e)
        {
            /*Button btn = sender as Button;
            if (display.Text == "0" && btn.Text == ",") // очищаем textbox если там стоит 0 в начале
            {
                display.Text += btn.Text; // добавляем числа последовательно
            }  
            else
                if (display.Text == "0" && (btn.Text == "1" || btn.Text == "2" || btn.Text == "3" || btn.Text == "4" || btn.Text == "5" || btn.Text == "6" || btn.Text == "7" || btn.Text == "8" || btn.Text == "9"))
                display.Clear();
            display.Text += btn.Text;*/

            Button btn = sender as Button;
            if (display.Text == "0")
            {
                display.Clear();
                display.Text += btn.Text;
            }
               
            else
                display.Text += btn.Text;

        }

        private void operation_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.first_number = double.Parse(display.Text);//converting written string in textbox to double
            calc.operation = btn.Text;
            //label1.Text += display.Text;
            display.Text = ""; //ощищаем textbox
            //label1.Text = ""; 
        }

        private void result_click(object sender, EventArgs e)
        {
            calc.second_number = double.Parse(display.Text); //converting written string in textbox to double
            calc.calculate(); //вызываем метод/функцию calculate
            display.Text = calc.result.ToString(); //converting double result to string      
        }

        private void c_click(object sender, EventArgs e)
        {
            display.Text = ""; // очищаем textbox и обнуляем all variables
            calc.first_number = 0;
            calc.second_number = 0;
            calc.result = 0;
            calc.operation = "";
            //calc = new CalcClass();
        }
        private void ce_click(object sender, EventArgs e)
        {
            display.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutProgramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Calculator by Togzhan Abish. \nVersion 1.1   \nMicrosoft Corporation, 2017. \nAll rights reserved.", "About program");
        }

        private void button21_Click(object sender, EventArgs e) //Memory Save
        {
            memory = double.Parse(display.Text);
            display.Clear();
        }

        private void button19_Click(object sender, EventArgs e) //Memory Clear
        {
            memory = 0;
        }

        private void button22_Click(object sender, EventArgs e) //Memory Read
        {
            display.Text = memory.ToString();
        }
        private void button20_Click(object sender, EventArgs e) //M+
        {
            memory = memory + double.Parse(display.Text);
        }

        private void button23_Click(object sender, EventArgs e) //M-
        {
            memory = memory - double.Parse(display.Text);
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MC- Memory Clear. \nMR - Memory Read. \nMS - Memory save. \nM+ - Memory += display.Text. \nM- -Memory -= display.Text.", "Instructions");
        }

        private void button27_Click(object sender, EventArgs e) // 1/x
        {
            if(display.Text != "")
            {
                double h = Convert.ToDouble("1") / Convert.ToDouble(display.Text);
                display.Text = Convert.ToString(h);       
            }
            else
            {
                return;
            }
        }

        private void button26_Click(object sender, EventArgs e) // sqrt(x)
        {
            if (display.Text != "")
            {
                double k;
                k = Convert.ToDouble(display.Text);
                
                display.Text = Convert.ToString(Math.Sqrt(k));
            }
            else
            {
                return;
            }
        }

        private void button25_Click(object sender, EventArgs e) // x^2
        {
            if (display.Text != "")
            {
                double x;
                x = Convert.ToDouble(display.Text) * Convert.ToDouble(display.Text);
                display.Text = Convert.ToString(x);
            }
            else
            {
                return;
            }
        }

        private void button24_Click(object sender, EventArgs e) // %
        {
            if(display.Text != "")
            {
                double m;
                m = Convert.ToDouble(display.Text) / Convert.ToDouble("100");
                display.Text = Convert.ToString(m);
            }
            else
            {
                return;
            }
        }

        private void button28_Click(object sender, EventArgs e) // backspace
        {
            if (display.Text != string.Empty)
            {
                int length = display.Text.Length;
                if (length != 1)
                {
                    display.Text = display.Text.Remove(length - 1);
                }
                else
                {
                    display.Text = 0.ToString();
                }

            }
        }

        private void button29_Click(object sender, EventArgs e) // +/-
        {
            if(display.Text != "")
            {
                double c = Convert.ToDouble(this.display.Text);
                c = -c;
                display.Text = Convert.ToString(c);
            }
        }

        private void scientificCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e) //,
        {
            if (display.Text == ",")
                display.Text = "0,";

            if (display.Text.IndexOf(",") == -1)
                display.Text = display.Text + ",";          
        }
    }
}

