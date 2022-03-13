using System;

namespace StackCalculator
{
    public class Calculator
    {
        public static double Calculation(string inputString, string stackType)
        {
            IStack stack;
            if (stackType == "0")
            {
                stack = new StackOnArray();
            }
            else if (stackType == "1")
            {
                stack = new StackOnList();
            }
            else
            {
                throw new ArgumentException("Expected 0 or 1");
            }
            if (inputString == "")
            {
                throw new ArgumentNullException("Empty expression");
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
                        secondElement = stack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new InvalidOperationException("Empty stack");
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
                            if (firstElement.Equals(0))
                            {
                                throw new InvalidOperationException("Dividing by zero");
                            }
                            stack.Push(secondElement / firstElement);
                            break;
                        default:
                            throw new ArgumentException("Expected digits or +, -, *, /");
                    }
                }
            }
            if (stack.Count() == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new InvalidOperationException("Incorrect stack work");
            }
        }
    }
}
