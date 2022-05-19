namespace Test;

using System.Collections.Generic;

/// <summary>
/// Абстрактный класс, который для каждого типа реализуется отдельно
/// </summary>
/// <typeparam name="T">Тип элемента</typeparam>
public abstract class Comparer<T> : IComparer<T>
{
    /// <summary>
    /// Абстрактный метод сравнения, который для каждого типа элементов свой
    /// </summary>
    /// <param name="x">Первый элемент</param>
    /// <param name="y">Второй элемент</param>
    /// <returns>Значение < 0, если первый меньше второго
    /// = 0, если элементы равны
    /// > 0, если правый элемент больше левого</returns>
    public abstract int Compare(T? x, T? y);
}
