namespace StackCalculator;

using System;
using StackCalculator.Tests;

/// <summary>
/// Класс, производящий вычисление выражений в обратной польской записи
/// </summary>
internal static class Calculator
{
    public static (double, bool) Calculation(string inputString, IStack stack)
    {
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
                double firstElement;
                double secondElement;
                var isOkay = true;
                (firstElement, isOkay) = stack.Pop();
                if (!isOkay)
                {
                    return (0, false);
                }
                (secondElement, isOkay) = stack.Pop();
                if (!isOkay)
                {
                    return (0, false);
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
                    default:
                        return (0, false);
                }
            }
        }
        if (stack.Count() == 1)
        {
            return stack.Pop();
        }
        else
        {
            return (0, false);
        }
    }
}
