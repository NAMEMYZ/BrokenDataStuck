using ConsoleApp1;
using static System.Collections.Stack;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static bool IsCorrectParentheses(string t)
        {
            string first = "{([", end = "})]";
            ArrayStack stack = new ArrayStack(t.Length);

            for (int i = 0; i < t.Length; i++)
            {
                if (first.IndexOf(t[i].ToString()) >= 0)
                    stack.push(t[i]);
                else
                {
                    int j = end.IndexOf(t[i].ToString());
                    if (j >= 0)
                    {
                        if (stack.isEmpty() || !stack.pop().Equals(first[j]))
                            return false;
                    }
                }
            }
            return stack.isEmpty();
        }

        static string InfixtoPostfix(string infix)
        {
            string postfix = "";
            ArrayStack stack = new ArrayStack(infix.Length);
            for (int i = 0; i < infix.Length; i++)
            {
                char token = infix[i];
                if (!IsOperator(token))
                    postfix += token;
                else
                {
                    int p = OperatorPriority(token);
                    while (!stack.isEmpty() && OperatorPriority((char)stack.peek(), true) >= p)
                        postfix += stack.pop();
                    if (token.Equals(')') || token.Equals('}') || token.Equals(']'))
                        stack.pop();
                    else
                        stack.push(token);
                }
            }
            while (!stack.isEmpty())
                postfix += stack.pop();
            return postfix;
        }
        static bool IsOperator(char c)
        {
            string operators = "+-*/^(){}[]";
            return operators.IndexOf(c) >= 0;
        }

        static int OperatorPriority(char c, bool sw = false)
        {
            string operators = "+-*/^(){}[]";
            int[] priority = { 2, 2, 3, 3, 5, 6, 1, 6, 1, 6, 1 };
            int[] prioritysw = { 2, 2, 3, 3, 4, 0 };
            if (sw)
                return prioritysw[operators.IndexOf(c)];
            return priority[operators.IndexOf(c)];
        }

        static double CalculatePostfix(string postfix)
        {
            ArrayStack stack = new ArrayStack(postfix.Length);
            for (int i = 0; i < postfix.Length; i++)
            {
                if (!IsOperator(postfix[i]))
                    stack.push(postfix[i]);
                else if (stack.size() >= 2)
                {
                    double b = double.Parse(stack.pop().ToString());
                    double a = double.Parse(stack.pop().ToString());
                    double c = 0;
                    switch (postfix[i])
                    {
                        case '+': c = a + b; break;
                        case '-': c = a - b; break;
                        case '*': c = a * b; break;
                        case '/': c = a / b; break;
                        case '^': c = Math.Pow(a, b); break;
                    }
                    stack.push(c);
                }
            }
            return double.Parse(stack.pop().ToString());
        }


        /*static void Main(string[] args)
        {
            String s = "{[()]}";
            Console.WriteLine(IsCorrectParentheses(s));
            String l = "a+b*{c+(d*e+f)}*g";
            Console.WriteLine(InfixtoPostfix(l));
            String p = "1+2+3+4+5*6-7+8";
            Console.WriteLine(InfixtoPostfix(p));
            Console.WriteLine(CalculatePostfix(InfixtoPostfix(p)));
        }*/
    }
}