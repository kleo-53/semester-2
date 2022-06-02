namespace Calculator;

using System;

/// <summary>
/// Класс калькулятора
/// </summary>
internal class MyCalculator
{
    private double? firstNumber;
    private double? secondNumber;
    private char? operation;
    private const double inaccuracy = 1e-7;

    /// <summary>
    /// Назначение чисел
    /// </summary>
    /// <param name="givenNumber">Данное число</param>
    public void AssignNumber(double givenNumber)
    {
        if (firstNumber == null)
        {
            firstNumber = givenNumber;
        }
        else
        {
            secondNumber = givenNumber;
        }
    }
    
    /// <summary>
    /// Назначение операции
    /// </summary>
    /// <param name="givenOperation">Операция</param>
    public void AssignOperation(char givenOperation)
    {
        this.operation = givenOperation;
    }

    /// <summary>
    /// Выполнение вычисления
    /// </summary>
    /// <returns>Получившееся значение</returns>
    /// <exception cref="DivideByZeroException">При делении на 0</exception>
    /// <exception cref="MissingArgumentException">Непредвиденная ошибка</exception>
    public double Calculate()
    {
        if (firstNumber == null || secondNumber == null)
        {
            throw new MissingArgumentException();
        }
        double? result;
        switch (operation)
        {
            case '+':
                {
                    result = firstNumber + secondNumber;
                    break;
                }
            case '-':
                {
                    result = firstNumber - secondNumber;
                    break;
                }
            case '*':
                {
                    result = firstNumber * secondNumber;
                    break;
                }
            case '/':
                {
                    if (Math.Abs((double)secondNumber) <= inaccuracy)
                    {
                        throw new DivideByZeroException();
                    }
                    result = firstNumber / secondNumber;
                    break;
                }
            default:
                {
                    throw new MissingArgumentException();
                }
        }
        firstNumber = result;
        return (double)result;
    }

    /// <summary>
    /// Очистка данных
    /// </summary>
    public void Clear()
    {
        this.firstNumber = null;
        this.secondNumber = null;
        this.operation = null;
    }

}
