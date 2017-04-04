using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorNew
{
    public partial class Form1 : Form
    {
        double memory = 0;
        public static int cnt = 0;
        public bool re = false;
        

        CalcClass calc = new CalcClass();
        public Form1()
        {
            InitializeComponent();
        }

        private void standartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 268;
            display.Width = 240;
        }

        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 388;
            display.Width = 359;
        }

        private void numbers_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (display.Text == "0")
            {
                display.Clear();
                display.Text += btn.Text;
            }
            else if (label1.Text == "ERROR")
                display.Text = btn.Text;
            else
                display.Text += btn.Text;
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.first_number = double.Parse(display.Text);//converting written string in textbox to double
            calc.operation = btn.Text;
            calc.re = false;

            display.Text = "0"; //ощищаем textbox
            label1.Text = Convert.ToString(calc.first_number) + " " + calc.operation;
        }

        private void result_click(object sender, EventArgs e)
        {
            label1.Text = "";
            
            if (display.Text == "0")
            {
                calc.second_number = calc.first_number;
            } else
            {
                calc.second_number = double.Parse(display.Text); //converting written string in textbox to double
            }
            calc.calculate(); //вызываем метод/функцию calculate

            if (calc.error)
            {
                label1.Text = "ERROR";
            }
            else
            {
                display.Text = calc.result.ToString(); //converting double result to string
            }
        }

        private void C_Click(object sender, EventArgs e)
        {
            display.Text = ""; // очищаем textbox и обнуляем all variables
            calc.first_number = 0;
            calc.second_number = 0;
            calc.result = 0;
            calc.operation = "";
            //calc = new CalcClass();
            label1.Text = "";
        }

        private void CE_Click(object sender, EventArgs e)
        {
            display.Clear();
            label1.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Calculator by Togzhan Abish. \nVersion 1.1   \nMicrosoft Corporation, 2017. \nAll rights reserved.", "About program");
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MC- Memory Clear. \nMR - Memory Read. \nMS - Memory save. \nM+ - Memory += display.Text. \nM- -Memory -= display.Text.", "Instructions");
        }

        private void button3_Click(object sender, EventArgs e) //MS
        {
            memory = double.Parse(display.Text);
            display.Clear();
        }

        private void button1_Click(object sender, EventArgs e) //MC
        {
            memory = 0;
        }

        private void button2_Click(object sender, EventArgs e) //MR
        {
            display.Text = memory.ToString();
        }

        private void button4_Click(object sender, EventArgs e) //M+
        {
            memory = memory + double.Parse(display.Text);
        }

        private void button5_Click(object sender, EventArgs e) //M-
        {
            memory = memory - double.Parse(display.Text);
        }

       /* private void button17_Click(object sender, EventArgs e) // 1/x
        {
            if (display.Text != "")
            {
                double h; 
                h = Convert.ToDouble("1.0") / Convert.ToDouble(display.Text);
                display.Text = Convert.ToString(h);
            }
            else
            {
                return;
            }
        }

        private void button12_Click(object sender, EventArgs e) // %
        {
            if (display.Text != "")
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

        private void button7_Click(object sender, EventArgs e) // sqrt
        {
            if (display.Text != "" && Convert.ToDouble(display.Text) > 0)
            {
                double k;
                k = Convert.ToDouble(display.Text);
                label1.Text = Convert.ToString("sqrt" + "(" + (display.Text) + ")");
                display.Text = Convert.ToString(Math.Sqrt(k));
            }
            else
            {
                label1.Text = "ERROR!";
            }
        }*/

        private void button8_Click(object sender, EventArgs e) // +/-
        {
            if (display.Text != "")
            {
                double c = Convert.ToDouble(this.display.Text);
                c = -c;
                display.Text = Convert.ToString(c);
            }
            else
            {
                return;
            }
        }

        private void button11_Click(object sender, EventArgs e) // backspace
        {
            if (display.Text != string.Empty)
            {
                
                if (display.Text.Length != 1)
                {
                    display.Text = display.Text.Remove(display.Text.Length - 1);
                }
                else
                {
                    display.Text = 0.ToString();
                }

            }

            if(display.Text == "")
            {
                display.Text = "0";
            }
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (display.Text == ",")
                display.Text = "0,";

            if (display.Text.IndexOf(",") == -1)
                display.Text = display.Text + ",";
        }



        private void button40_Click(object sender, EventArgs e) // log
        {
            if (display.Text != "")
            {
                double log = Convert.ToDouble(display.Text);
                label1.Text = Convert.ToString("log" + "(" + (display.Text) + ")");
                log = Math.Log10(log);
                display.Text = Convert.ToString(log);
               
            }
            else
            {
                return;
            }
        }

        private void button34_Click(object sender, EventArgs e) // ln
        {
            if (display.Text != "")
            {
                double ln = Convert.ToDouble(display.Text);
                label1.Text = Convert.ToString("ln" + "(" + (display.Text) + ")");
                ln = Math.Log(ln);
                display.Text = Convert.ToString(ln);
            }
            else
            {
                return;
            }
        }

        private void OnlyOnce_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.first_number = double.Parse(display.Text);
            calc.operation = btn.Text;
            calc.Calc1();
            if (calc.error)
            {
                label1.Text = "Error";
                calc = new CalcClass();
            }
            else
            {
                display.Text = calc.result.ToString();
            }
        }

        /*private void button35_Click(object sender, EventArgs e) // sin
        {
            double sinn = Convert.ToDouble(display.Text);
            label1.Text = Convert.ToString("sin" + "(" + (display.Text) + ")");
            sinn = Math.Sin(calc.first_number * Math.PI / 180);
            display.Text = Convert.ToString(sinn);
        }

        private void button59_Click(object sender, EventArgs e) // cos
        {
            double coss = Convert.ToDouble(display.Text);
            label1.Text = Convert.ToString("cos" + "(" + (display.Text) + ")");
            coss = Math.Cos(calc.first_number * Math.PI / 180);
            display.Text = Convert.ToString(coss);
        }

        private void button60_Click(object sender, EventArgs e) // tg
        {
            double tgg = Convert.ToDouble(display.Text);
            label1.Text = Convert.ToString("tg" + "(" + (display.Text) + ")");
            tgg = Math.Tan(calc.first_number * Math.PI / 180);
            display.Text = Convert.ToString(tgg);
        }*/

        /*private void button45_Click(object sender, EventArgs e) // 10^x
        {
            if (display.Text != "")
            {
                double ex;
                ex = Math.Pow(Convert.ToDouble("10.0"), Convert.ToDouble(display.Text));
                display.Text = Convert.ToString(ex);
            }
            else
            {
                return;
            }
        }

        private void button49_Click(object sender, EventArgs e) // x^3
        {
            if (display.Text != "")
            {
                double exx;
                exx = Convert.ToDouble(display.Text) * Convert.ToDouble(display.Text) * Convert.ToDouble(display.Text);
                display.Text = Convert.ToString(exx);
            }
            else
            {
                return;
            }
        }

        private void button54_Click(object sender, EventArgs e) // x^2
        {
            if (display.Text != "")
            {
                double exn;
                exn = Convert.ToDouble(display.Text) * Convert.ToDouble(display.Text);
                display.Text = Convert.ToString(exn);
            }
            else
            {
                return;
            }
        }

        private void button39_Click(object sender, EventArgs e) // x^1/3
        {
            if (display.Text != "")
            {
                double exv;
                exv = Math.Pow(Convert.ToDouble(display.Text), Convert.ToDouble("1.0/3.0"));
                display.Text = Convert.ToString(exv);
            }
            else
            {
                return;
            }
        }*/
    }
}
