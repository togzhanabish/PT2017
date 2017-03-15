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
            if (display.Text == "0" ) // очищаем textbox если там стоит 0 в начале
                display.Clear();
            Button btn = sender as Button;
            display.Text += btn.Text; // добавляем числа последовательно
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(calc.result != 0)
            {

            }
            calc.first_number = double.Parse(display.Text);//converting written string in textbox to double
            calc.operation = btn.Text;
            //labelCurrentOperation.Text = calc.result + "" + calc.operation;
            display.Text = ""; //ощищаем textbox
            
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
            /*string s = display.Text;
            s = s.Substring(s.Length - 1, s.Length - 1);
            display.Text = s;*/
            display.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutProgramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Calculator by Togzhan Abish.  Version 1.1   Microsoft Corporation, 2017. All rights reserved.", "About program");
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
    }
}
