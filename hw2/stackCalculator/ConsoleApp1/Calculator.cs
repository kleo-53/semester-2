using System;
using StackCalculator.Tests;

namespace StackCalculator
{
    internal class Calculator
    {
        public static double Calculation(string inputString, string stackType)
        {
            IStack stack;
            if (stackType == "0")
            {
                stack = new StackOnArray();
            }
            else
            {
                stack = new StackOnList();
            }
            var arrayElements = inputString.Split(' ');
            for (var i = 0; i < arrayElements.Length; i++)
            {
                if (arrayElements[i][arrayElements[i].Length - 1] >= '0' 
                    && arrayElements[i][arrayElements[i].Length - 1] <= '9')
                {
                    stack.Push(double.Parse(arrayElements[i]));
                }
                else
                {
                    double firstElement = new int();
                    double secondElement = new int();
                    try
                    {
                        firstElement = stack.Pop();
                    }
                    catch
                    {
                        throw new Exception("Empty stack");
                    }
                    try
                    {
                        secondElement = stack.Pop();
                    }
                    catch
                    {
                        throw new Exception("Empty stack");
                    }
                    switch (arrayElements[i])
                    {
                        case "+":
                            stack.Push(firstElement + secondElement);
                            break;
                        case "-":
                            stack.Push(secondElement - firstElement);
                            break;
                        case "*":
                            stack.Push(firstElement * secondElement);
                            break;
                        case "/":
                            stack.Push(secondElement / firstElement);
                            break;
                    }
                }
            }
            if (stack.Count() == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new Exception("Empty stack");
            }
        }
    }
}
