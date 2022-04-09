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
    public ListElement head;
    public ListElement tail;
    public int size;
    public UList()
    {
        head = new ListElement(0, null);
        tail = head;
        size = 0;
    }
    public void Add(int value)
    {
        var listElement = new ListElement(value, null);
        tail.next = listElement;
        tail = listElement;
        size++;
    }
    public void Add(int value, int position)
    {
        if (position < 0 || position > size)
        {
            throw new Exception();
        }
        ListElement? current = head;
        for (int i = 0; i < position; i++)
        {
            current = current.next;
        }
        if (current == head)
        {
            var element = new ListElement(value, head);
            head = element;
        }
        else if (current == tail)
        {
            Add(value);
        }
        else
        {
            var element = new ListElement(value, current.next);
            current = element;
        }
        size++;
    }

    public void Change(int value, int position)
    {
        if (position < 0 || position > size)
        {
            throw new Exception();
        }
        ListElement? current = head;
        for (int i = 0; i < position; i++)
        {
            current = current.next;
        }
        current.value = value;
    }

    public int Remove(int position)
    {
        if (position < 0 || position >= size)
        {
            throw new Exception();
        }
        ListElement? previous = null;
        ListElement current = head;
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


}
