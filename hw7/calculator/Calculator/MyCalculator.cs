namespace Calculator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class MyCalculator
{
    private double? firstNumber;
    private double? secondNumber;
    private char? operation;
    private const double inaccuracy = 1e-7;

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
    
    public void AssignOperation(char givenOperation)
    {
        this.operation = givenOperation;
    }

    public double Calculate()
    {
        if (firstNumber == null || secondNumber == null)
        {
            throw new ArgumentNullException();
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

    public void Clear()
    {
        this.firstNumber = null;
        this.secondNumber = null;
        this.operation = null;
    }

}
