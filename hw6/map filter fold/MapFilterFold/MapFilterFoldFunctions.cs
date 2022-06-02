namespace MapFilterFold;

using System;
using System.Collections.Generic;

/// <summary>
/// Класс с функциями map, filter, fold
/// </summary>
public class MapFilterFoldFunctions
{
    /// <summary>
    /// Функция применяет функцию к списку
    /// </summary>
    /// <param name="list">Данный список</param>
    /// <param name="function">Данная функция</param>
    /// <returns>Список из элементов, к каждому из которых применили функцию</returns>
    public static List<int> Map(List<int> list, Func<int, int> function)
    {
        var result = new List<int>();
        for (int i = 0; i < list.Count; i++)
        {
            result.Add(function(list[i]));
        }
        return result;
    }

    /// <summary>
    /// Функция создает новый список из элементов, для которых переданная функция вернула истину
    /// </summary>
    /// <param name="list">Данный список</param>
    /// <param name="function">Данная функция</param>
    /// <returns>Список из элементов, для которых ппереданная функция истинна</returns>
    public static List<int> Filter(List<int> list, Func<int, bool> function)
    {
        var result = new List<int>();
        for (int i = 0; i < list.Count; i++)
        {
            if (function(list[i]))
            {
                result.Add(list[i]);
            }
        }
        return result;
    }

    /// <summary>
    /// Накапливает значениее путем применения функции к начальному элементу и списку
    /// </summary>
    /// <param name="list">Данный список</param>
    /// <param name="beginSymbol">Начаальный элемент</param>
    /// <param name="function">Данная функция</param>
    /// <returns>Накопленное значение</returns>
    public static long Fold(List<int> list, int beginSymbol, Func<long, int, long> function)
    {
        long result = beginSymbol;
        for (int i = 0; i < list.Count; i++)
        {
            result = function(result, list[i]);
        }
        return result;
    }
}
