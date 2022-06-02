namespace StackCalculator;

using System;

/// <summary>
/// Класс, производящий вычисление выражений в обратной польской записи
/// </summary>
public static class Calculator
{
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
        var arrayElements = inputString.Split(' ');
        if (arrayElements.Length == 0)
        {
            throw new ArgumentException();
        }
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
