namespace StackCalculator;

using System;
using StackCalculator.Tests;

namespace StackCalculator
/// <summary>
/// Класс, производящий вычисление выражений в обратной польской записи
/// </summary>
public static class Calculator
{
    internal class Calculator
    /// <summary>
    /// Функция выполняет вычисление
    /// </summary>
    /// <param name="inputString">Строка в обратной польской записи</param>
    /// <param name="stack">Один из возможных стеков, с корорым нужно работать</param>
    /// <returns>Ответ или наличие ошибки в строке</returns>
    /// <exception cref="IndexOutOfRangeException">Ошибка в случае пустой строки</exception>
    /// <exception cref="DivideByZeroException">Ошибка в случае деления на 0</exception>
    public static (double, bool) Calculation(string inputString, IStack stack)
    {
        public static double Calculation(string inputString, string stackType)
        var arrayElements = inputString.Split(' ');
        if (arrayElements.Length == 0)
        {
            IStack stack;
            if (stackType == "0")
            throw new ArgumentException();
        }
        for (var i = 0; i < arrayElements.Length; i++)
        {
            if (arrayElements[i][arrayElements[i].Length - 1] >= '0' 
                && arrayElements[i][arrayElements[i].Length - 1] <= '9')
            {
                stack = new StackOnArray();
                stack.Push(double.Parse(arrayElements[i]));
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
                double firstElement;
                double secondElement;
                var isOkay = true;
                (firstElement, isOkay) = stack.Pop();
                if (!isOkay)
                {
                    stack.Push(double.Parse(arrayElements[i]));
                    return (0, false);
                }
                else
                (secondElement, isOkay) = stack.Pop();
                if (!isOkay)
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
                        if (Math.Abs(firstElement) < 0.0000001)
                        {
                            throw new DivideByZeroException();
                        }
                        stack.Push(secondElement / firstElement);
                        break;
                    default:
                        return (0, false);
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
