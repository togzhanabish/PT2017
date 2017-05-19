using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace End1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e) // login
        {
            if (TextBox1.Text == "" && textBox2.Text == "")
            {
                TextBox1.Text = "Fields can not be empty";
                textBox2.Text = "Fields can not be empty";
            }
            if( TextBox1.Text != "admin")
            {
                MessageBox.Show("wrong login");
                TextBox1.Text = "";
                textBox2.Text = "";
            }
            
                
            if(TextBox1.Text == "admin" && textBox2.Text == "password123!")
            {
                MessageBox.Show("Success Authorization!");
            }
            
            if(textBox2.Text != "password123!")
            {
                textBox2.Text = "wrong password";
            }

           if(textBox2.TextLength < 8)
            {
                MessageBox.Show("password length should be greater than 8");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
                    
        }
    }
}