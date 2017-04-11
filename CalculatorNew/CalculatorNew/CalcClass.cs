using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorNew
{
    public class CalcClass
    {
        public double first_number;
        public double second_number;
        public double result;
        public string operation;

        public double moment;

        public bool error = false;
        public bool re = false;

        public double foronce = 1;

        public void calculate()
        {
            if (!re)
            {
                switch (operation)
                {
                    case "+":
                        result = first_number + second_number;
                        break;
                    case "-":
                        result = first_number - second_number;
                        break;
                    case "*":
                        result = first_number * second_number;
                        break;
                    case "/":
                        if (second_number == 0)
                        {
                            error = true;
                        }
                        result = first_number / second_number;
                        break;
                    case "x^y":
                        if (first_number < 0 && (1 / second_number) % 2 == 0)
                        {
                            error = true;
                        }
                        result = Math.Pow(first_number, second_number);
                        break;
                    case "√(y&x)":
                        if (first_number < 0 && second_number % 2 == 0)
                        {
                            error = true;
                        }
                        else
                        {
                            result = Math.Pow(first_number, 1 / second_number);
                            break;
                        }
                        break;
                }
                moment = second_number;

            }
            else if(re)
            {
                switch(operation)
                {
                    case "+":
                        result = result + moment;
                        break;
                    case "-":
                        result = result - moment;
                        break;
                    case "*":
                        result = result * moment;
                        break;
                    case "/":
                        if (second_number== 0)
                        {
                            error = false;
                        }
                        result = result / moment;
                        break;
                    case "x^y":
                        result = Math.Pow(result, moment);
                        break;
                    case "√(y&x)":
                        result = Math.Pow(result, 1 / moment);
                        break;
                }
            }
            re = true;
        }

        public void Calc1()
        {
            switch (operation)
            {
                case "n!":
                    if (first_number % 1 == 0)
                    {
                        for (int i = 2; i < first_number + 1; i++)
                        {
                            foronce *= i;
                        }
                        result = foronce;
                        foronce = 1;
                    }
                    else
                    {
                        error = true;
                    }
                    break;
                case "1/x":
                    if (first_number == 0)
                    {
                        error = true;
                    }
                    result = 1 / first_number;
                    break;
                case "X^2":
                    result = Math.Pow(first_number, 2);
                    break;
                case "x^3":
                    result = Math.Pow(first_number, 3);
                    break;
                case "sin":
                    result = Math.Sin((first_number * Math.PI) / 180);
                    break;
                case "cos":
                    result = Math.Cos((first_number * Math.PI) / 180);
                    break;
                case "tg":
                    result = Math.Tan((first_number * Math.PI) / 180);
                    break;
                case "√":
                    if (first_number < 0)
                    {
                        error = true;
                    }
                    result = Math.Sqrt(first_number);
                    break;
                case "%":
                    if (first_number < 0)
                    {
                        error = true;
                    }
                    result = first_number / 100;
                    break;
                case "∛x":
                    if (first_number < 0)
                    {
                        error = true;
                    }
                    result = Math.Pow(first_number, 1.0 / 3.0);
                    break;
                case "10^x":
                    if (first_number < 0)
                    {
                        result = Math.Pow((Math.Pow(10, first_number)), 1/first_number);
                    }
                    result = Math.Pow(10, first_number);
                    break;
                case "log":
                    if(first_number < 0)
                    {
                        error = true;
                    }
                    result = Math.Log10(first_number);
                    break;
                case "ln":
                    if(first_number < 0)
                    {
                        error = true;
                    }
                    result = Math.Log(first_number);
                    break;
            }
        }
    }
}
