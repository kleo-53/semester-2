namespace SparseVector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Operation
{
    public virtual MySparseVector Calculate(MySparseVector firstVector, MySparseVector secondVector, char operation)
    {
        if (firstVector.Size != secondVector.Size)
        {
            throw new ArithmeticException();
        }
        firstVector.NotNullPositions.Sort();
        secondVector.NotNullPositions.Sort();
        var resultVector = new MySparseVector();
        resultVector.Size = Math.Max(firstVector.NotNullPositions.Last().Item1, firstVector.NotNullPositions.Last().Item1);
        var firstIndex = 0;
        var secondIndex = 0;

        while (firstIndex != firstVector.NotNullPositions.Count && secondIndex != secondVector.NotNullPositions.Count)
        {
            if (firstVector.NotNullPositions[firstIndex].Item1 > secondVector.NotNullPositions[secondIndex].Item1)
            {
                resultVector.NotNullPositions.Add(secondVector.NotNullPositions[secondIndex]);
                secondIndex++;
            }
            else if (firstVector.NotNullPositions[firstIndex].Item1 < secondVector.NotNullPositions[secondIndex].Item1)
            {
                resultVector.NotNullPositions.Add(firstVector.NotNullPositions[firstIndex]);
                firstIndex++;
            }
            else
            {
                switch (operation)
                {
                    case '+':
                        {
                            resultVector.NotNullPositions.Add((firstIndex, firstVector.NotNullPositions[firstIndex].Item2
                                + secondVector.NotNullPositions[secondIndex].Item2));
                            break;
                        }
                    case '-':
                        {
                            resultVector.NotNullPositions.Add((firstIndex, firstVector.NotNullPositions[firstIndex].Item2
                                - secondVector.NotNullPositions[secondIndex].Item2));
                            break;
                        }
                    case '*':
                        {
                            resultVector.NotNullPositions.Add((firstIndex, firstVector.NotNullPositions[firstIndex].Item2
                                * secondVector.NotNullPositions[secondIndex].Item2));
                            break;
                        }
                    case '/':
                        {
                            resultVector.NotNullPositions.Add((firstIndex, firstVector.NotNullPositions[firstIndex].Item2
                                / secondVector.NotNullPositions[secondIndex].Item2));
                            break;
                        }
                    default:
                        throw new InvalidDataException();
                }
                firstIndex++;
                secondIndex++;
            }
        }
        return resultVector;
    }
}
