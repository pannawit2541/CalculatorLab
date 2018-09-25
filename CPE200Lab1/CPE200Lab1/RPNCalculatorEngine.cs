using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process_Sqrt_OverX(string str, string operate)
        {
            return unaryCalculate(operate, str);
        }

        public string Process(string str)
        {
            Stack<string> numberStack = new Stack<string>();
            string[] parts_stack = str.Split(' ');
            for (int i = 0; i < parts_stack.Length; i++)
            {
                string Second_Number;
                string First_Number;
                if (isNumber(parts_stack[i]))
                {
                    numberStack.Push(parts_stack[i]);
                }
                else if (isOperator(parts_stack[i]))
                {
                    try
                    {
                        Second_Number = numberStack.Pop();
                        First_Number = numberStack.Pop();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                        return "E";
                    }
                    
                    numberStack.Push(calculate(parts_stack[i], First_Number, Second_Number));
                }

            }
            //check Length of stack must equal 1
            if (numberStack.Count != 1)
                {
                    return "E";
                }
            //check length of stack
            return numberStack.Pop();
        }


    }
}
