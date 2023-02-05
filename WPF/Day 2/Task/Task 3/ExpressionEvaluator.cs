using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    static class ExpressionEvaluator
    {
        public static double EvaluateExpression(string expression)
        {
            string currentNumber = "";
            bool decimalPointEncountered = false;
            Stack<double> values = new();
            Stack<char> operators = new();

            foreach (char c in expression)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    currentNumber += c;
                    if (c == '.')
                    {
                        decimalPointEncountered = true;
                    }
                }
                else
                {
                    if (decimalPointEncountered)
                    {
                        values.Push(double.Parse(currentNumber));
                    }
                    else
                    {
                        values.Push(int.Parse(currentNumber));
                    }
                    currentNumber = "";
                    decimalPointEncountered = false;

                    while (operators.Count > 0 && HasHigherPrecedence(operators.Peek(), c))
                    {
                        ApplyOperator(operators, values);
                    }
                    operators.Push(c);
                }
            }

            if (decimalPointEncountered)
            {
                values.Push(double.Parse(currentNumber));
            }
            else
            {
                values.Push(int.Parse(currentNumber));
            }
            //currentNumber = "";
            //decimalPointEncountered = false;

            while (operators.Count > 0)
            {
                ApplyOperator(operators, values);
            }

            return values.Pop();
        }

        public static bool HasHigherPrecedence(char operator1, char operator2)
        {
            if ((operator1 == '×' || operator1 == '÷') && (operator2 == '+' || operator2 == '-'))
            {
                return true;
            }
            return false;
        }

        public static void ApplyOperator(Stack<char> operators, Stack<double> values)
        {
            double value2 = values.Pop();
            double value1 = values.Pop();
            char op = operators.Pop();

            switch (op)
            {
                case '+':
                    values.Push(value1 + value2);
                    break;

                case '-':
                    values.Push(value1 - value2);
                    break;

                case '×':
                    values.Push(value1 * value2);
                    break;

                case '÷':
                    values.Push(value1 / value2);
                    break;
            }
        }

    }
}
