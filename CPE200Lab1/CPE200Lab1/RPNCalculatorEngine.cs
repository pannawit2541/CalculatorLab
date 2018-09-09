﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
       public string ProcessSqrt(string str,string operate)
        {
            return unaryCalculate(operate, str);
        }

        public string Process(string str)
        {
            Stack<string> numberStack = new Stack<string>();
            string[] parts_stack = str.Split(' ');

            for(int i=0; i < parts_stack.Length ; i++)
            {
                if (isNumber(parts_stack[i]))
                {
                    numberStack.Push(parts_stack[i]);
                }
                else if (isOperator(parts_stack[i]))
                {
                    if(numberStack.Count < 2)
                    {
                        return "E";
                    }
                    string Second_Number = numberStack.Pop();
                    string First_Number = numberStack.Pop();
                    numberStack.Push(calculate(parts_stack[i], First_Number, Second_Number)) ;
                }

            }
            if(numberStack.Count != 1)
            {
                return "E";
            }
            return numberStack.Pop();
        }
    }
}
