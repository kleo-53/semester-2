namespace bor;

using System;

/// <summary>
/// Класс бора
/// </summary>
public class Tree
{
    /// <summary>
    /// Элемент бора
    /// </summary>
    private class Node
    {
        public Node?[] Children;
        public int HowManyWordsPassedNode;
        public int HowManyWordsEndsHere;
        public Node()
        {
            this.Children = new Node[26];
            this.HowManyWordsPassedNode = 0;
            this.HowManyWordsEndsHere = 0;
        }
    }
    private Node root;

    /// <summary>
    /// Размер бора
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Конструктор бора
    /// </summary>
    public Tree()
    {
        root = new Node();
        this.Size = 0;
    }

    /// <summary>
    /// Добавление элемента в бор
    /// </summary>
    /// <param name="element">Строка, которую нужно добавить</param>
    /// <returns>Находился ли такой же элемент в боре до этого добавления</returns>
    /// <exception cref="ArgumentNullException">Ошибка в случае добавления пустой строки</exception>
    public bool Add(string element)
    {
        if (element == null)
        {
            throw new ArgumentNullException("String can not be empty!");
        }
        ++Size;
        Node? current = root;
        var WasNotInBor = false;
        foreach (var symbol in element)
        {
            if (current == null)
            {
                return false;
            }
            ++current.HowManyWordsPassedNode;
            var code = symbol - 'a';
            if (current.Children[code] == null)
            {
                current.Children[code] = new Node();
                WasNotInBor = true;
            }
            current = current.Children[code];
        }
        ++current.HowManyWordsEndsHere;
        return WasNotInBor;
    }

    /// <summary>
    /// Проверка на нахождение в боре данного элемента
    /// </summary>
    /// <param name="element">Строка для проверки</param>
    /// <returns>Находится строка в боре или нет</returns>
    public bool Contains(string element)
    {
        Node? current = root;
        foreach (var symbol in element)
        {
            var code = symbol - 'a';
            if (current == null || current.Children == null || current.Children[code] == null)
            {
                return false;
            }
            current = current.Children[code];
        }
        return current.HowManyWordsEndsHere != 0;
    }

    /// <summary>
    /// Удаление строки из бора
    /// </summary>
    /// <param name="element">Строка для удаления</param>
    /// <returns>Успешно ли удален элемент</returns>
    public bool Remove(string element)
    {
        Node? current = root;
        var shouldRemove = false;
        foreach (var symbol in element)
        {
            var code = symbol - 'a';
            if (current == null || current.Children[code] == null)
            {
                return false;
            }
            if (current.Children[code].HowManyWordsPassedNode > 1)
            {
                --current.Children[code].HowManyWordsPassedNode;
                current = current.Children[code];
            }
            else
            {
                if (!shouldRemove)
                {
                    shouldRemove = true;
                }
                var temporary = current.Children[code];
                current.Children[code] = null;
                current = temporary;
            }
        }
        --Size;
        return true;
    }

    /// <summary>
    /// Поиск количества строк, начинающихся с заданного префикса
    /// </summary>
    /// <param name="prefix">Данный префикс</param>
    /// <returns>Количество слов с таким же префиксом</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        Node? current = root;
        foreach (var symbol in prefix)
        {
            var code = symbol - 'a';
            if (current == null || current.Children == null || current.Children[code] == null)
            {
                return 0;
            }
            current = current.Children[code];
        }
        return current.HowManyWordsPassedNode;
    }
}
