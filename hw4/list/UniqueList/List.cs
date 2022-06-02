namespace UniqueList;

/// <summary>
/// Ulist
/// </summary>
public class List
{
    /// <summary>
    /// Элемент списка
    /// </summary>
    private class ListElement
    {
        /// <summary>
        /// Значение элемента
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Следующий элемент списка
        /// </summary>
        public ListElement? Next { get; set; }

        /// <summary>
        /// Конструктор элемента
        /// </summary>
        /// <param name="value"></param>
        /// <param name="next"></param>
        public ListElement(int value, ListElement? next)
        {
            this.Value = value;
            this.Next = next;
        }

    }
    /// <summary>
    /// Первый элемент списка
    /// </summary>
    private ListElement? head;

    /// <summary>
    /// Последний элемент списка
    /// </summary>
    private ListElement? tail;

    /// <summary>
    /// Количество элементов в списке
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Добавляет элемент в конец списка
    /// </summary>
    /// <param name="value">Добавляемый элемент</param>
    public virtual void Add(int value)
    {
        var listElement = new ListElement(value, null);
        if (head == null)
        {
            head = listElement;
            tail = head;
        }
        else
        {
            tail.Next = listElement;
            tail = listElement;
        }
        Size++;
    }

    /// <summary>
    /// Добавляет элемент в заданную позицию
    /// </summary>
    /// <param name="value">Добавляемый элемент</param>
    /// <param name="position">Позиция, в которую нужно добавить элемент</param>
    /// <exception cref="OutOfListRangeException">Ошибка при неверно заданный позиции</exception>
    public virtual void Add(int value, int position)
    {
        if (position < 0 || position > Size)
        {
            throw new IndexOutOfRangeException();
        }
        ListElement? current = head;
        ListElement? previous = null; 
        if (position == Size)
        {
            Add(value);
            return;
        }
        for (int i = 0; i < position; i++)
        {
            previous = current;
            current = current.Next;
        }
        if (current == head)
        {
            var element = new ListElement(value, head);
            head = element;
            Size++;
        }
        else if (current == null)
        {
            Add(value);
        }
        else
        {
            previous.Next = new ListElement(value, current);
            Size++;
        }
    }

    /// <summary>
    /// Меняет значение элемента по позиции
    /// </summary>
    /// <param name="value">Новое значение</param>
    /// <param name="position">Позиция</param>
    /// <exception cref="OutOfListRangeException">Ошибка при неверно заданный позиции</exception>
    public virtual void Change(int value, int position)
    {
        if (position < 0 || position >= Size)
        {
            throw new IndexOutOfRangeException();
        }
        ListElement? current = head;
        for (int i = 0; i < position; i++)
        {
            current = current.Next;
        }
        current.Value = value;
    }

    /// <summary>
    /// Проверяет, содержит список данное значение или нет
    /// </summary>
    /// <param name="value">Значение</param>
    /// <returns>Содержит список данное значение или нет</returns>
    public bool Contains(int value)
    {
        ListElement? current = head;
        for (int i = 0; i < Size; ++i)
        {
            if (current.Value == value)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    /// <summary>
    /// Удаляет элемент по позиции
    /// </summary>
    /// <param name="position">Позиция, из которой удаляем элемент</param>
    /// <returns>Удаленное значение</returns>
    /// <exception cref="OutOfListRangeException">Ошибка при неверно заданный позиции</exception>
    public int Remove(int position)
    {
        if (position < 0 || position >= Size)
        {
            throw new IndexOutOfRangeException();
        }
        ListElement? previous = null;
        ListElement? current = head;
        for (int i = 0; i < position; i++)
        {
            previous = current;
            current = current.Next;
        }
        int removedValue = current.Value;
        if (current == head)
        {
            head = current.Next;
        }
        else if (current == tail)
        {
            previous.Next = null;
        }
        else
        {
            previous.Next = current.Next;
        }
        Size--;
        return removedValue;
    }
}
