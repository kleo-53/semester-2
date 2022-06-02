namespace SkipList;

using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Класс списка с пропусками
/// </summary>
/// <typeparam name="T">Тип значения в списке</typeparam>
public class MySkipList<T> : IList<T> where T : IComparable<T>
{
    private class Node
    {
        /// <summary>
        /// Значение в элементе
        /// </summary>
        public T? Value { get; private set; }

        /// <summary>
        /// Следующий элемент
        /// </summary>
        public Node? Next { get; set; }

        /// <summary>
        /// Элемент нижнего уровня
        /// </summary>
        public Node? Down { get; set; }

        /// <summary>
        /// Конструктор элемента по значению
        /// </summary>
        /// <param name="value">Данное значение</param>
        public Node(T? value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Конструктор элемента по нижнему и следующему
        /// </summary>
        /// <param name="value">Данное значение</param>
        /// <param name="next">Следующий элемент</param>
        /// <param name="down">Нижний элемент</param>
        public Node(T? value, Node? next, Node? down)
        {
            this.Value = value;
            this.Next = next;
            this.Down = down;
        }
    }

    private int maxLevel;
    private Node head; 
    private Node bottomHead;

    /// <summary>
    /// Число элементов в списке
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Если список доступен только для чтения
    /// </summary>
    public bool IsReadOnly { get; set; }

    /// <summary>
    /// Изменение значения элемента по индексу
    /// </summary>
    public T this[int index] {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int counter = 0;
            var node = bottomHead.Next;
            while (counter < index)
            {
                if (node == null)
                {
                    throw new ArgumentNullException();
                }
                node = node.Next;
                ++counter;
            }
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            return node.Value!;
        }
        set
        {
            throw new NotSupportedException("Can not change value by index!");
        }
    }

    /// <summary>
    /// Конструктор списка
    /// </summary>
    public MySkipList()
    {
        this.head = new Node(default);
        this.bottomHead = new Node(default);
        this.maxLevel = 1;
    }

    /// <summary>
    /// Поиск элемента
    /// </summary>
    private bool SearchRecursive(Node? node, T value)
    {
        if (node == null)
        {
            return false;
        }
        while (node.Next != null && value.CompareTo(node.Next.Value) > 0)
        {
            node = node.Next;
        }

        if (node.Next != null && node.Next.Value != null && node.Next.Value.Equals(value))
        {
            return true;
        }
        return SearchRecursive(node.Down, value);
    }

    /// <summary>
    /// Проверяет, содержится ли элемент в списке
    /// </summary>
    /// <param name="item">Данный элемент</param>
    /// <returns>Возвращает, содержится ли элемент в списке</returns>
    public bool Contains(T item)
    {
        return SearchRecursive(head, item);
    }

    private Node? InsertRecursive(Node node, T value)
    {
        while (node.Next != null && value.CompareTo(node.Next.Value) >= 0)
        {
            node = node.Next;
        }

        Node? downNode;
        if (node.Down == null)
        {
            downNode = null;
        }
        else
        {
            downNode = InsertRecursive(node.Down, value);
        }

        if (downNode != null || node.Down == null)
        {
            Node? curNext = node.Next;
            node.Next = new Node(value, curNext, downNode);

            Random random = new();
            if (random.Next(2) == 1)
            {
                return node.Next;
            }
            return null;
        }
        return null;
    }

    /// <summary>
    /// Добавление элемента
    /// </summary>
    /// <param name="item">Данное значение</param>
    public void Add(T item)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }

        ++Count;
        if (head.Next == null)
        {
            head.Next = new Node(item);
            return;
        }
        InsertRecursive(head, item);

        if (Count > Math.Pow(2, maxLevel))
        {
            var newHead = new Node(default);
            newHead.Down = head;
            head = newHead;
            ++maxLevel;
        }
    }

    private bool RemoveRecursive(Node node, T value)
    {
        while (node.Next != null && value.CompareTo(node.Next.Value) > 0)
        {
            node = node.Next;
        }
        var isRemoved = false;
        if (node.Down != null)
        {
            isRemoved = RemoveRecursive(node.Down, value);
        }
        if (node.Next != null && node.Next.Value != null && node.Next.Value.Equals(value))
        {
            node.Next = node.Next.Next;
            return true;
        }
        return isRemoved;
    }

    /// <summary>
    /// Удаление элемента
    /// </summary>
    /// <param name="item">Данный элемент</param>
    /// <returns>Получилось ли удалить элемент</returns>
    public bool Remove(T item)
    {
        if (RemoveRecursive(head, item))
        {
            --Count;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Возвращает энумератор
    /// </summary>
    public IEnumerator GetEnumerator()
    {
        var array = new T[Count];
        CopyTo(array, 0);
        return array.GetEnumerator();
    }

    /// <summary>
    /// Возвращает энумератор
    /// </summary>
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return (IEnumerator<T>)GetEnumerator();
    }

    /// <summary>
    /// Возвращает индекс по элементу
    /// </summary>
    /// <param name="item">Данный элемент</param>
    /// <returns>Индекс элемента</returns>
    public int IndexOf(T item)
    {
        int counter = 0;
        Node? node = head.Next;
        while (node != null)
        {
            if (node.Value != null && node.Value.Equals(item))
            {
                return counter;
            }
            node = node.Next;
            ++counter;
        }
        return -1;
    }

    /// <summary>
    /// Вставка элемента по индексу
    /// </summary>
    public void Insert(int index, T item)
    {
        throw new NotSupportedException("List is sorted!");
    }

    /// <summary>
    /// Удаление по индексу
    /// </summary>
    public void RemoveAt(int index)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException("Can not remove by index, only by value!");
        }
        if (index >= Count || Count < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        var value = this[index];
        Remove(value);
    }

    /// <summary>
    /// Полностью очищает список
    /// </summary>
    public void Clear()
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }
        head = new Node(default);
        bottomHead = new Node(default);
        maxLevel = 1;
        Count = 0;
    }

    /// <summary>
    /// Переносит список в массив
    /// </summary>
    /// <param name="array">Данный массив</param>
    /// <param name="arrayIndex">Номер, с которого нужно начать записывать элементы</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex >= Count || array.Length < Count - arrayIndex)
        {
            throw new ArgumentOutOfRangeException();
        }
        var node = bottomHead.Next;
        for (int i = 0; i < arrayIndex; ++i)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            node = node.Next;
        }
        var counter = 0;
        while (node != null)
        {
            if (node.Value == null)
            {
                throw new ArgumentNullException();
            }
            array[counter] = node.Value;
            node = node.Next;
            ++counter;
        }
    }
}
