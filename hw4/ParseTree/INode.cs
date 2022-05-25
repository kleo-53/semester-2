﻿namespace ParseTree;

/// <summary>
/// Интерфейс элемента дерева
/// </summary>
public interface INode
{
    /// <summary>
    /// Правый потомок
    /// </summary>
    INode ? rightSon { get; set; }

    /// <summary>
    /// Левый потомок
    /// </summary>
    INode ? leftSon { get; set; }

    /// <summary>
    /// Считает результат выражения, находящегося в потомках вершины
    /// </summary>
    /// <returns>Посчитанный результат</returns>
    public int Calculate();

    /// <summary>
    /// Печатает на консоль содержимое вершины
    /// </summary>
    public void PrintResult();
}
