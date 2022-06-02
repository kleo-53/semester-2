namespace Test;

using System;
using System.Collections.Generic;

/// <summary>
/// Генерик-сортировка пузырьком, сравнивающая объекты по заданному компаратору
/// </summary>
/// <typeparam name="T">Тип элементов</typeparam>
public class BubbleSort<T> where T : IComparable<T>
{
    /// <summary>
    /// Функция сортировки пузырьком
    /// </summary>
    /// <param name="listOfElements">Список объектов, которые нужно сравнить</param>
    /// <param name="comp">Компаратор для определенного типа объектов</param>
    /// <returns></returns>
    public static List<T> Sort(List<T> listOfElements, IComparer<T> comp)
    {
        T temporary;
        for (int i = 0; i < listOfElements.Count; i++)
        {
            for (int j = i + 1; j < listOfElements.Count; j++)
            {
                if (comp.Compare(listOfElements[i], listOfElements[j]) > 0)
                {
                    temporary = listOfElements[i];
                    listOfElements[i] = listOfElements[j];
                    listOfElements[j] = temporary;
                }
            }
        }
        return listOfElements;
    }
}
