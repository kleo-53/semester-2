using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList;

public class UList
{
    public class ListElement
    {
        public int value;
        public ListElement? next;
        public ListElement(int value, ListElement? next)
        {
            this.value = value;
            this.next = next;
        }

    }
    public ListElement? head;
    public ListElement? tail;
    public int size;

    /// <summary>
    /// Класс списка
    /// </summary>
    public UList()
    {
        head = null;
        tail = head;
        size = 0;
    }

    /// <summary>
    /// Добавляет элемент в конец списка
    /// </summary>
    /// <param name="value">Добавляемый элемент</param>
    public void Add(int value)
    {
        var listElement = new ListElement(value, null);
        if (head == null)
        {
            head = listElement;
            tail = head;
        }
        else
        {
            tail.next = listElement;
            tail = listElement;
        }
        size++;
    }

    /// <summary>
    /// Добавляет элемент в заданную позицию
    /// </summary>
    /// <param name="value">Добавляемый элемент</param>
    /// <param name="position">Позиция, в которую нужно добавить элемент</param>
    /// <exception cref="OutOfListRangeException">Ошибка при неверно заданный позиции</exception>
    public void Add(int value, int position)
    {
        if (position < 0 || position > size)
        {
            throw new OutOfListRangeException();
        }
        ListElement? current = head;
        ListElement? previous = null;
        for (int i = 0; i < position; i++)
        {
            previous = current;
            current = current.next;
        }
        if (current == head)
        {
            var element = new ListElement(value, head);
            head = element;
            size++;
        }
        else if (current == null)
        {
            Add(value);
        }
        else
        {
            previous.next = new ListElement(value, current);
            size++;
        }
    }

    /// <summary>
    /// Меняет значение элемента по позиции
    /// </summary>
    /// <param name="value">Новое значение</param>
    /// <param name="position">Позиция</param>
    /// <exception cref="OutOfListRangeException">Ошибка при неверно заданный позиции</exception>
    public void Change(int value, int position)
    {
        if (position < 0 || position >= size)
        {
            throw new OutOfListRangeException();
        }
        ListElement? current = head;
        for (int i = 0; i < position; i++)
        {
            current = current.next;
        }
        current.value = value;
    }

    /// <summary>
    /// Проверяет, содержит список данное значение или нет
    /// </summary>
    /// <param name="value">Значение</param>
    /// <returns>Содержит список данное значение или нет</returns>
    public bool IsContain(int value)
    {
        ListElement? current = head;
        for (int i = 0; i < size; ++i)
        {
            if (current.value == value)
            {
                return true;
            }
            current = current.next;
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
        if (position < 0 || position >= size)
        {
            throw new OutOfListRangeException();
        }
        ListElement? previous = null;
        ListElement? current = head;
        for (int i = 0; i < position; i++)
        {
            previous = current;
            current = current.next;
        }
        int removedValue = current.value;
        if (current == head)
        {
            head = current.next;
        }
        else if (current == tail)
        {
            previous.next = null;
        }
        else
        {
            previous.next = current.next;
        }
        size--;
        return removedValue;
    }
}
