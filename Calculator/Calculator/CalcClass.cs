﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalcClass
    {
        public double first_number;
        public double second_number;
        public double result;
        public string operation;
       
        public void calculate()
        {
            switch (operation)
            {
                case "+":
                    result = second_number + first_number;
                    break;
                case "-":
                    result = first_number - second_number;
                    break;
                case "*":
                    result = first_number * second_number;
                    break;
                case "/":
                    result = first_number / second_number;
                    break;
                default:
                    break;
            }
        }
    }
}
