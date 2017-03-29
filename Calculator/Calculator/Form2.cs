using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form2 : Form
    {
        double memory = 0;

        CalcClass calc = new CalcClass();

        public Form2()
        {
            InitializeComponent();
        }

        private void numbers_click(object sender, EventArgs e)
        {
            if (display.Text == "0") // очищаем textbox если там стоит 0 в начале
                display.Clear();
            Button btn = sender as Button;
            display.Text += btn.Text; // добавляем числа последовательно
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.first_number = double.Parse(display.Text);//converting written string in textbox to double
            calc.operation = btn.Text;
            label1.Text = display.Text + calc.operation + calc.result;
            display.Text = ""; //ощищаем textbox
            label1.Text = "";
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

        private void button36_Click(object sender, EventArgs e) //MC
        {
            memory = 0;
        }

        private void button37_Click(object sender, EventArgs e) //MR
        {
            display.Text = memory.ToString();
        }

        private void button38_Click(object sender, EventArgs e) //MS
        {
            memory = double.Parse(display.Text);
            display.Clear();
        }

        private void button39_Click(object sender, EventArgs e) //M+
        {
            memory = memory + double.Parse(display.Text);
        }

        private void button40_Click(object sender, EventArgs e) //M-
        {
            memory = memory - double.Parse(display.Text);
        }

        private void button28_Click(object sender, EventArgs e) // +/-
        {
            if (display.Text != "")
            {
                double c = Convert.ToDouble(this.display.Text);
                c = -c;
                display.Text = Convert.ToString(c);
            }
        }

        private void button13_Click(object sender, EventArgs e) // |x|
        {
            if(display.Text != "")
            {
                double b = Convert.ToDouble(display.Text);
                
            }
        }

        private void button15_Click(object sender, EventArgs e) // x^2
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

        private void button14_Click(object sender, EventArgs e) // x!
        {
            if (display.Text != "")
            {
                double f = 1;

                for (int i = 0; i <= Convert.ToDouble(display.Text); i++)
                    f *= Convert.ToDouble(i);

                
            }
            else
            {
                return;
            }
        }

        private void button16_Click(object sender, EventArgs e) // x^y
        {
            if (display.Text != "")
            {
                double y;
                y = Math.Pow(Convert.ToDouble(calc.first_number), Convert.ToDouble(calc.second_number));
                display.Text = Convert.ToString(y);
            }
            else
            {
                return;
            }
        }

        private void button12_Click(object sender, EventArgs e) // 1/x
        {
            if (display.Text != "")
            {
                double h = Convert.ToDouble("1") / Convert.ToDouble(display.Text);
                display.Text = Convert.ToString(h);
            }
            else
            {
                return;
            }
        }

        private void button11_Click(object sender, EventArgs e) // x^3
        {
            if(display.Text != "")
            {
                double l = Convert.ToDouble(display.Text);
                
            }
        }

        private void button10_Click(object sender, EventArgs e) // 2^x
        {

        }

        private void button9_Click(object sender, EventArgs e) // ∛x
        {

        }

        private void button8_Click(object sender, EventArgs e) // √x
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

        private void button7_Click(object sender, EventArgs e) // sin
        {

        }

        private void button6_Click(object sender, EventArgs e) // cos
        {

        }

        private void button5_Click(object sender, EventArgs e) // tg
        {

        }

        private void button4_Click(object sender, EventArgs e) // %
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

        private void button3_Click(object sender, EventArgs e) // ln
        {
            if (display.Text != "")
            {
                double ln = Convert.ToDouble(display.Text);
                ln = Math.Log(ln);
                display.Text = Convert.ToString(ln);
            }
            else
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e) // log
        {
            if (display.Text != "")
            {
                double log = Convert.ToDouble(display.Text);
                log = Math.Log10(log);
                display.Text = Convert.ToString(log);
            }
        }

        private void button1_Click(object sender, EventArgs e) // e^x
        {
            if (display.Text != "")
            {
                double exp;
                exp = Math.Pow(Convert.ToDouble("2,7182818285"), Convert.ToDouble(display.Text));
                display.Text = Convert.ToString(exp);
            }
        }
    }
}
